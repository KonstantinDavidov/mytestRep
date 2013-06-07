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
using System.Configuration;
using Thinktecture.IdentityModel.Constants;

namespace FACCTS.Services
{
    public class WebApiClientBase
    {
        protected ILogger Logger { get; set; }

        protected IAuthenticationService AuthenticationService { get; set; }

        private string _webApiBaseAddress = ConfigurationManager.AppSettings["WepApiEndpoint"];

        public WebApiClientBase()
        {
            Logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
            AuthenticationService = ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>();
        }

        public virtual T CallServiceGet<T>(string route)
        {
            if (!AuthenticationService.IsAuthenticated)
            {
                return default(T);
            }
            using (var client = new HttpClient
            {
                BaseAddress = new Uri(_webApiBaseAddress)
            })
            {
                T result = default(T);

                try
                {
                    client.SetBearerToken(AuthenticationService.GetToken());
                    var response = client.GetAsync(route).Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsAsync<T>().Result;

                }
                catch (Exception ex)
                {
                    Logger.Fatal("An exception was thrown during the call of the Web Service (GET).", ex);
                }
                return result;
            }
            
        }

        public virtual T CallServicePost<T>(string route, FormUrlEncodedContent content)
        {
            using (var client = new HttpClient
            {
                BaseAddress = new Uri(_webApiBaseAddress)
            })
            {
                T result = default(T);
                try
                {
                    client.SetBearerToken(AuthenticationService.GetToken());
                    var response = client.PostAsync(route, content).Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsAsync<T>().Result;

                }
                catch (Exception ex)
                {
                    Logger.Fatal("An exception was thrown during the call of the Web Service (POST).", ex);
                }
                return result;
            }
        }


    }
}
