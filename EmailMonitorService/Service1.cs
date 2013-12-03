using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailMonitorService
{
    public partial class Service1 : ServiceBase
    {
        EmailMonitor emailMonitor;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            emailMonitor = new EmailMonitor();
            var timer = new Timer();
            timer.Interval = 3000;
            timer.Elapsed += (o, e) =>
            {
                emailMonitor.SendUnprocessedEmails();
            };
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            emailMonitor = null;
        }
    }
}
