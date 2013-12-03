using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EmailMonitorService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new Service1() 
            //};
            //ServiceBase.Run(ServicesToRun);

            var mailClient = new EmailClient();

            mailClient.SendMail("mjoyce@forthrightsolutions.com", "mikejoyce19@gmail.com","This is a test", "Testing testing testing");

            Console.ReadKey();
        }
    }
}
