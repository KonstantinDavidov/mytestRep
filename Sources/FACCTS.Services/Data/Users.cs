using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected List<User> GetUsersByRole(string roleName)
        {
            var result =  this.CallServiceGet<List<User>>(string.Format("{0}/{1}/{2}", "Users", "Get", roleName));
            return result;
        }
    }
}
