using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace WindowsServiceStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceName = "FACCTS.IntegrationScheduler";

            var services = ServiceController.GetServices();
            ServiceController controller;

            Process p = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            if (services.FirstOrDefault(s => s.ServiceName == serviceName) != null)
            {
                controller = new ServiceController(serviceName);
                controller.Stop();
                controller.WaitForStatus(ServiceControllerStatus.Stopped);

                p = new Process();
                startInfo = new ProcessStartInfo();
                startInfo = new ProcessStartInfo();
                startInfo.Arguments = string.Format("delete {0}",
                    serviceName,
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                startInfo.FileName = "sc.exe";
                p.StartInfo = startInfo;
                p.Start();
                p.WaitForExit();
            }

            p = new Process();
            startInfo = new ProcessStartInfo();
            startInfo = new ProcessStartInfo();
            startInfo.Arguments = string.Format("create {0} binpath= {1}\\FACCTS.WindowsService.exe start= auto",
                serviceName,
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            startInfo.FileName = "sc.exe";
            p.StartInfo = startInfo;
            p.Start();
            p.WaitForExit();

            controller = new ServiceController(serviceName);
            controller.Start();
            controller.WaitForStatus(ServiceControllerStatus.Running);
        }
    }
}
