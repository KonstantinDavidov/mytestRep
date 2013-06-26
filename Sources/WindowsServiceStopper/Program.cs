using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace WindowsServiceStopper
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "FACCTS.IntegrationScheduler";

            var services = ServiceController.GetServices();
            if (services.FirstOrDefault(s => s.ServiceName == serviceName) != null)
            {
                var controller = new ServiceController(serviceName);
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped);


                Process p = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                /*startInfo.Arguments = string.Format("stop {0}", serviceName);
                startInfo.FileName = "sc.exe";
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();*/

                p = new Process();
                startInfo = new ProcessStartInfo();
                startInfo.Arguments = string.Format("delete {0}", serviceName);
                startInfo.FileName = "sc.exe";
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();
            }
        }
    }
}
