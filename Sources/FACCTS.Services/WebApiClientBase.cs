using FACCTS.Services.Authentication;
using FACCTS.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Clients;
using Thinktecture.IdentityModel.Extensions;
using Newtonsoft.Json;

namespace FACCTS.Services
{
    public class WebApiClientBase
    {
        protected ILogger Logger { get; set; }

        protected IAuthenticationService AuthenticationService { get; set; }


        public WebApiClientBase()
        {
            Logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
            AuthenticationService = ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>();
        }

        public virtual T CallServiceGet<T>(string baseAddress)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            T result = default(T);

            try
            {
                client.SetBearerToken(AuthenticationService.GetToken());
                var response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsAsync<T>().Result;
                
            }
            catch (Exception ex)
            {
                Logger.Fatal("An exception was thrown during the call of the Web Service.", ex);
            }
            return result;
        }


    }
}
