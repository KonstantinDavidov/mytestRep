using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using FACCTS.Server.Setup.Common;

namespace FACCTS.Server.Setup.CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult GetWebSites(Session session)
        {
            try
            {
                if (session == null) { throw new ArgumentNullException("session"); }

                View comboBoxView = session.Database.OpenView("select * from ComboBox");

                int order = 1;

                foreach (IisWebSite site in IisManager.GetIisWebSites())
                {
                    Record newComboRecord = new Record("WEBSITEVALUE", order++, site.ID, site.Name);
                    comboBoxView.Modify(ViewModifyMode.InsertTemporary, newComboRecord);
                }

                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                if (session != null)
                    session.Log("Custom Action Exception: " + ex);

                return ActionResult.Failure;
            }
        }

        [CustomAction]
        public static ActionResult GetAppPools(Session session)
        {
            try
            {
                if (session == null) { throw new ArgumentNullException("session"); }

                View comboBoxView = session.Database.OpenView("select * from ComboBox");

                int order = 1;

                foreach (string appPool in IisManager.GetIisAppPools())
                {
                    Record newComboRecord = new Record("APPPOOLVALUE", order++, appPool);
                    comboBoxView.Modify(ViewModifyMode.InsertTemporary, newComboRecord);
                }

                return ActionResult.Success;
            }
            catch (Exception e)
            {
                if (session != null)
                    session.Log("Custom Action Exception " + e);
            }

            return ActionResult.Failure;
        }
    }
}
