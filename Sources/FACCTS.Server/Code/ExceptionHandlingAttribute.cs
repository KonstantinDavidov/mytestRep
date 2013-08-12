using FACCTS.Server.Common;
using log4net;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace FACCTS.Server.Code
{
    public class ExceptionHandlingAttribute : HandleErrorAttribute
    {
        public ExceptionHandlingAttribute() : base()
        {
            Logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        protected ILog Logger { get; set; }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            if (context.Exception is FACCTSException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Exception"
                });

            }

            //Log Critical errors
            Logger.Fatal("An exception occurred: ", context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}