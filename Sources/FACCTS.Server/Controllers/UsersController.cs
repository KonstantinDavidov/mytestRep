using FACCTS.Server.DataContracts;
using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace FACCTS.Server.Controllers
{
    [Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UsersController : ApiControllerBase
    {

        public List<User> Get(string roleName)
        {
            return DataManager.UserRepository.GetAll()
                .Where(u => u.Roles.Any(r => r.RoleName == roleName))
                .ToList();
        }

        public HttpResponseMessage GetCurrent()
        {
            if (HttpContext.Current != null)
            {
                var currentPrincipal = HttpContext.Current.User;
                if (currentPrincipal == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot determine the current user"); 
                }
                var currentUser = DataManager.UserRepository
                    .GetAll()
                    .FirstOrDefault(x => x.Username == currentPrincipal.Identity.Name);
                currentUser.Password = null;
                return Request.CreateResponse<CurrentUserResponse>(HttpStatusCode.OK, new CurrentUserResponse()
                    {
                        CurrentUser = currentUser,
                    });
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot determine the current user"); 
        }
    }
}
