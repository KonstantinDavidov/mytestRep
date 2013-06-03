using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FACCTS.Server
{
    public static class Endpoints
    {
        public const string OAuth2Authorize = "authorization/oauth2/authorize";
        public const string OAuth2Callback = "authorization/oauth2/callback";
        public const string OAuth2Token = "authorization/oauth2/token";
    }
}