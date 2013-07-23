using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class Users : WebApiClientBase
    {
        protected Users() : base()
        {

        }

        public static List<Faccts.Model.Entities.User> GetByRole(string roleName)
        {
            return new Users().GetUsersByRole(roleName).Select(x => new Faccts.Model.Entities.User(x))
                .ToList();
        }

        public static Faccts.Model.Entities.User GetCurrent()
        {
            User r = new Users().GetCurrentUser();
            if (r == null)
                return null;
            return new Faccts.Model.Entities.User(r);
        }

        protected List<User> GetUsersByRole(string roleName)
        {
            var result =  this.CallServiceGet<List<User>>(string.Format("{0}/{1}/{2}", "Users", "Get", roleName));
            return result;
        }

        protected User GetCurrentUser()
        {
            var result = this.CallServiceGet<CurrentUserResponse>(string.Format("{0}/{1}", "Users", "GetCurrent"));
            if (result == null)
            {
                return null;
            }
            return result.CurrentUser;
        }
    }
}
