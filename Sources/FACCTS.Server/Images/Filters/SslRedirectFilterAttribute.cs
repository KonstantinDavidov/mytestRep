using FACCTS.Server.Common;
using log4net;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FACCTS.Server.Filters
{
    public class SslRedirectFilterAttribute : ActionFilterAttribute
    {
        int _port = 443;

        public SslRedirectFilterAttribute(int sslPort)
        {
            _port = sslPort;
        }

        private ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.MethodEntry("SslRedirectFilterAttribute.OnActionExecuting");
            if (!filterContext.HttpContext.Request.IsSecureConnection)
            {
                string absoluteUri = GetAbsoluteUri(filterContext.HttpContext.Request.Url).AbsoluteUri;
                _logger.InfoFormat("Redirect to: {0}", absoluteUri);
                filterContext.Result = new RedirectResult(
                    absoluteUri,
                    true);
            }
            _logger.MethodExit("SslRedirectFilterAttribute.OnActionExecuting");
        }

        private Uri GetAbsoluteUri(Uri uriFromCaller)
        {
            UriBuilder builder = new UriBuilder(Uri.UriSchemeHttps, uriFromCaller.Host);
            builder.Path = uriFromCaller.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            builder.Port = _port;

            string query = uriFromCaller.GetComponents(UriComponents.Query, UriFormat.UriEscaped);
            if (query.Length > 0)
            {
                string uriWithoutQuery = builder.Uri.AbsoluteUri;
                string absoluteUri = string.Format("{0}?{1}", uriWithoutQuery, query);
                return new Uri(absoluteUri, UriKind.Absolute);
            }
            else
            {
                return builder.Uri;
            }
        }
    }
}