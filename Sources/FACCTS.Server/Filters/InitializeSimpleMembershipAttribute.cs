using FACCTS.Server.Data.Providers.Membership;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FACCTS.Server.Model.DataModel;
using log4net;
using FACCTS.Server.Common;
using FACCTS.Server.Data;

namespace FACCTS.Server.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        private ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.MethodEntry("InitializeSimpleMembershipAttribute.OnActionExecuting");
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            _logger.MethodExit("InitializeSimpleMembershipAttribute.OnActionExecuting");
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<DatabaseContext>(null);

                try
                {
                    using (var context = new DatabaseContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}