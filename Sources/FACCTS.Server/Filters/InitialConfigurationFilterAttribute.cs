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

                    keys.SigningCertificate = cert;
                    _logger.InfoFormat("Signing certificate was found: {0}", cert.Subject);
                }
                catch (CryptographicException)
                {
                    _logger.InfoFormat(Resources.InitialConfigurationController.NoReadAccessPrivateKey, WindowsIdentity.GetCurrent().Name);
                    var cert = GetAvailableCertificateFromStore();
                    keys.SigningCertificate = cert;
                    _logger.InfoFormat("Signing certificate was set to: {0}", cert.Subject);
                }
            }
            else
            {
                _logger.Info("The signing certificate is absent in the database.");
                var cert = GetAvailableCertificateFromStore();
                keys.SigningCertificate = cert;
                //_logger.InfoFormat("Signing certificate was set to: {0}", cert.Subject);
            }

            if (string.IsNullOrWhiteSpace(keys.SymmetricSigningKey))
            {
                keys.SymmetricSigningKey = Convert.ToBase64String(CryptoRandom.CreateRandomKey(32));
            }

            // updates key material config
            ConfigurationRepository.Keys = keys;

            base.OnActionExecuting(filterContext);
            _logger.MethodExit("InitialConfigurationFilterAttribute.OnActionExecuting");
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