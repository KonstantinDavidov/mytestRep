using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;
using Microsoft.Win32;

namespace FACCTS.Server.Setup.Common
{
    public static class IisManager
    {
        public static int IisVersion
        {
            get
            {
                int iisVersion;

                using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp"))
                {
                    if (iisKey == null)
                        throw new Exception("IIS is not installed.");

                    iisVersion = (int)iisKey.GetValue("MajorVersion");
                }

                return iisVersion;
            }
        }

        #region WebSites

        public static IList<IisWebSite> GetIis6Sites()
        {
            List<IisWebSite> sites = new List<IisWebSite>();
            using (DirectoryEntry iisRoot = new DirectoryEntry("IIS://localhost/W3SVC"))
            {
                iisRoot.RefreshCache();

                sites.AddRange(iisRoot.Children.Cast<DirectoryEntry>().
                    Where(w => w.SchemaClassName.ToLower(CultureInfo.InvariantCulture) == "iiswebserver").
                    Select(w => new IisWebSite(w.Name, w.Properties["ServerComment"].Value.ToString())));
            }

            return sites;
        }

        public static IList<IisWebSite> GetIis7UpwardsSites()
        {
            List<IisWebSite> sites = new List<IisWebSite>();

            using (ServerManager iisManager = new ServerManager())
            {
                sites.AddRange(iisManager.Sites.Select
                    (s => new IisWebSite(s.Id.ToString(CultureInfo.InvariantCulture), s.Name)));
            }

            return sites;
        }

        public static IList<IisWebSite> GetIisWebSites()
        {
            return (IisVersion < 7) ? GetIis6Sites() : GetIis7UpwardsSites();
        }

        #endregion

        #region App Pools

        public static IList<string> GetIis6AppPools()
        {
            List<string> pools = new List<string>();
            using (DirectoryEntry poolRoot = new DirectoryEntry("IIS://localhost/W3SVC/AppPools"))
            {
                poolRoot.RefreshCache();

                pools.AddRange(poolRoot.Children.Cast<DirectoryEntry>().Select(p => p.Name));
            }

            return pools;
        }

        public static IList<string> GetIis7UpwardsAppPools()
        {
            List<string> pools = new List<string>();

            using (ServerManager iisManager = new ServerManager())
            {
                pools.AddRange(iisManager.ApplicationPools.Select(p => p.Name));
            }

            return pools;
        }

        public static IList<string> GetIisAppPools()
        {
            return (IisVersion < 7) ? GetIis6AppPools() : GetIis7UpwardsAppPools();
        }

        #endregion
    }
}
