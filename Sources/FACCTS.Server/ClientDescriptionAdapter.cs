using DotNetOpenAuth.OAuth2;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.Messaging;

namespace FACCTS.Server
{
    public class ClientDescriptionAdapter : IClientDescription
    {
        private OAuth_Client _client;
        public ClientDescriptionAdapter(OAuth_Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            _client = client;
        }

        public ClientType ClientType
        {
            get { return (ClientType)_client.ClientType; }
        }

        public Uri DefaultCallback
        {
            get { return string.IsNullOrEmpty(_client.Callback) ? null : new Uri(_client.Callback); }
        }

        public bool HasNonEmptySecret
        {
            get { return !string.IsNullOrEmpty(_client.ClientSecret); }
        }

        public bool IsCallbackAllowed(Uri callback)
        {
            if (string.IsNullOrEmpty(_client.Callback))
            {
                // No callback rules have been set up for this client.
                return true;
            }

            // In this sample, it's enough of a callback URL match if the scheme and host match.
            // In a production app, it is advisable to require a match on the path as well.
            Uri acceptableCallbackPattern = new Uri(_client.Callback);
            if (string.Equals(acceptableCallbackPattern.GetLeftPart(UriPartial.Authority), callback.GetLeftPart(UriPartial.Authority), StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }

        public bool IsValidClientSecret(string secret)
        {
            return MessagingUtilities.EqualsConstantTime(secret, _client.ClientSecret);
        }
    }
}
