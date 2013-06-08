using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
