using MyFirstService.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyFirstService
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            GlobalFunctions.WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;

            try
            {
                string szCmdline = "D:\\wwwroot\\aslMonitor\\AslMonitor";
                ProcessAsUser.Launch(szCmdline);
            }
            catch(Exception ex)
            {
                GlobalFunctions.WriteToFile($"Error: {ex.Message}");
            }
        }

        protected override void OnStop()
        {
            GlobalFunctions.WriteToFile("Service is stopped at " + DateTime.Now);
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            GlobalFunctions.WriteToFile("Service is recall at " + DateTime.Now);
        }

    }
}
