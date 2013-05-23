using DotNetOpenAuth.Messaging.Bindings;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FACCTS.Server.Common;

namespace FACCTS.Server.Code
{
    [Export(typeof(ICryptoKeyStore))]
    [Export(typeof(INonceStore))]
    public class DatabaseKeyNonceStore : INonceStore, ICryptoKeyStore 
    {
        /// </summary>
        public DatabaseKeyNonceStore()
        {
        }

        [Import]
        public IDataManager DataManager { protected get; set; }

        [Import]
        public ILog Logger { protected get; set; }

        #region INonceStore Members

        /// <summary>
        /// Stores a given nonce and timestamp.
        /// </summary>
        /// <param name="context">The context, or namespace, within which the
        /// <paramref name="nonce"/> must be unique.
        /// The context SHOULD be treated as case-sensitive.
        /// The value will never be <c>null</c> but may be the empty string.</param>
        /// <param name="nonce">A series of random characters.</param>
        /// <param name="timestampUtc">The UTC timestamp that together with the nonce string make it unique
        /// within the given <paramref name="context"/>.
        /// The timestamp may also be used by the data store to clear out old nonces.</param>
        /// <returns>
        /// True if the context+nonce+timestamp (combination) was not previously in the database.
        /// False if the nonce was stored previously with the same timestamp and context.
        /// </returns>
        /// <remarks>
        /// The nonce must be stored for no less than the maximum time window a message may
        /// be processed within before being discarded as an expired message.
        /// This maximum message age can be looked up via the
        /// <see cref="DotNetOpenAuth.Configuration.MessagingElement.MaximumMessageLifetime"/>
        /// property, accessible via the <see cref="DotNetOpenAuth.Configuration.DotNetOpenAuthSection.Configuration"/>
        /// property.
        /// </remarks>
        public bool StoreNonce(string context, string nonce, DateTime timestampUtc)
        {
            Logger.MethodEntry(null, nonce, timestampUtc);
            try
            {
                DataManager.NonceRepository.Insert(new OAuth_Nonce { Context = context, Code = nonce, Timestamp = timestampUtc });
                Logger.MethodExit();
                return true;
            }
            //catch (System.Data.Linq.DuplicateKeyException)
            //{
                //return false;
            //}
            catch (SqlException)
            {
                return false;
            }
            
        }

        #endregion

        #region ICryptoKeyStore Members

        public CryptoKey GetKey(string bucket, string handle)
        {
            Logger.MethodEntry(null, bucket, handle);
            // It is critical that this lookup be case-sensitive, which can only be configured at the database.
            var matches = from key in DataManager.SymmetricCryptoKeyRepository.Get()
                          where key.Bucket == bucket && key.Handle == handle
                          select new CryptoKey(key.Secret, key.ExpiresUtc.AsUtc());
            Logger.MethodExit();

            return matches.FirstOrDefault();
        }

        public IEnumerable<KeyValuePair<string, CryptoKey>> GetKeys(string bucket)
        {
            Logger.MethodEntry(null, bucket);
            return from key in DataManager.SymmetricCryptoKeyRepository.Get()
                   where key.Bucket == bucket
                   orderby key.ExpiresUtc descending
                   select new KeyValuePair<string, CryptoKey>(key.Handle, new CryptoKey(key.Secret, key.ExpiresUtc.AsUtc()));
        }

        public void StoreKey(string bucket, string handle, CryptoKey key)
        {
            Logger.MethodEntry(null, bucket, handle, key);
            var keyRow = new OAuth_SymmetricCryptoKey()
            {
                Bucket = bucket,
                Handle = handle,
                Secret = key.Key,
                ExpiresUtc = key.ExpiresUtc,
            };

            DataManager.SymmetricCryptoKeyRepository.Insert(keyRow);
            Logger.MethodExit();
        }

        public void RemoveKey(string bucket, string handle)
        {
            Logger.MethodEntry(null, bucket, handle);
            var match = DataManager.SymmetricCryptoKeyRepository.Get(k => k.Bucket == bucket && k.Handle == handle).FirstOrDefault();
            if (match != null)
            {
                DataManager.SymmetricCryptoKeyRepository.Delete(match);
            }
            Logger.MethodExit();
        }

        #endregion
    }
}