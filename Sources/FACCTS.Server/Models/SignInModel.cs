using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Models
{
    public class SignInModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources.SignInModel))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.SignInModel))]
        public string Password { get; set; }

        [Display(Name = "EnableSSO", ResourceType = typeof(Resources.SignInModel))]
        public bool EnableSSO { get; set; }

        bool? isSigninRequest;
        public bool IsSigninRequest
        {
            get
            {
                if (isSigninRequest == null)
                {
                    isSigninRequest = !String.IsNullOrWhiteSpace(ReturnUrl);
                }
                return isSigninRequest.Value;
            }
            set
            {
                isSigninRequest = value;
            }
        }
        public string ReturnUrl { get; set; }
        public bool ShowClientCertificateLink { get; set; }
    }
}