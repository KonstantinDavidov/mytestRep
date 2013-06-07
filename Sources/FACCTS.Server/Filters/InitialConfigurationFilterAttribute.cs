using FACCTS.Server.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.Filters
{
    public class InitialConfigurationFilterAttribute : ActionFilterAttribute
    {
        
        public IConfigurationRepository ConfigurationRepository 
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfigurationRepository>();
            } 
        }

        private IRelyingPartyRepository _relyingPartyRepository = ServiceLocator.Current.GetInstance<IRelyingPartyRepository>();

        public InitialConfigurationFilterAttribute() : base()
        {
            _logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        private ILog _logger;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.MethodEntry("InitialConfigurationFilterAttribute.OnActionExecuting");

            var config = ConfigurationRepository.Global;
            // update global config
            ConfigurationRepository.Global = config;

            var keys = ConfigurationRepository.Keys;
            var currentCertificate = keys.SigningCertificate;
            string certificateFriendlyName = ConfigurationManager.AppSettings["SSLCertificateFriendlyName"];
            if (currentCertificate != null)
            {
                _logger.Info("The signing certificate is already present in the database.");
                try
                {
                    _logger.Info("Trying to find the signing certificate");
                    var cert = X509.LocalMachine.My.SubjectDistinguishedName.Find(currentCertificate, false).First();

                    // make sure we can access the private key
                    var pk = cert.PrivateKey;

                    UpdateCertificate(keys, cert);
                    _logger.InfoFormat("Signing certificate was found: {0}", cert.Subject);
                }
                catch (CryptographicException)
                {
                    _logger.InfoFormat(Resources.InitialConfigurationController.NoReadAccessPrivateKey, WindowsIdentity.GetCurrent().Name);
                    var cert = GetAvailableCertificateFromStore();
                    UpdateCertificate(keys, cert);
                    _logger.InfoFormat("Signing certificate was set to: {0}", cert.Subject);
                }
            }
            else
            {
                _logger.Info("The signing certificate is absent in the database.");
                var cert = GetAvailableCertificateFromStore();
                UpdateCertificate(keys, cert);
                _logger.InfoFormat("Signing certificate was set to: {0}", cert.Subject);
            }
            // updates key material config
            ConfigurationRepository.Keys = keys;

            base.OnActionExecuting(filterContext);
            _logger.MethodExit("InitialConfigurationFilterAttribute.OnActionExecuting");
        }

        private void UpdateCertificate(Thinktecture.IdentityServer.Models.Configuration.KeyMaterialConfiguration keys, X509Certificate2 cert)
        {
            keys.SigningCertificate = cert;
            if (string.IsNullOrWhiteSpace(keys.SymmetricSigningKey))
            {
                //keys.SymmetricSigningKey = CryptoRandom.CreateRandomKeyString(32);
                RelyingParty rp;
                if (_relyingPartyRepository.TryGet(FACCTS.Server.Common.Constants.RelyingParties.FACCTS, out rp))
                {
                    keys.SymmetricSigningKey = Convert.ToBase64String(rp.SymmetricSigningKey);
                    rp.EncryptingCertificate = cert;
                    _relyingPartyRepository.Update(rp);
                    //rp.EncryptingCertificateThumbprint = keys.SymmetricSigningKey;
                }
                else
                {
                    throw new FACCTSException("Relying party record was not found!");
                }
            }
        }


        private X509Certificate2 GetAvailableCertificateFromStore()
        {
            var list = new List<X509Certificate2>();
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            string certificateFriendlyName = ConfigurationManager.AppSettings["SSLCertificateFriendlyName"];

            try
            {
                foreach (var cert in store.Certificates)
                {
                    if (cert.FriendlyName == certificateFriendlyName)
                    {
                        list.Add(cert);
                    }
                    // todo: add friendly name
                    
                }
            }
            finally
            {
                store.Close();
            }

            return list.FirstOrDefault();
        }
    }
}