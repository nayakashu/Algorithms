using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace TimeLoggerService
{
    public partial class Service1 : ServiceBase
    {
        Timer travelTimer = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            travelTimer = new Timer();
            this.travelTimer.Interval = 60000;
            this.travelTimer.Elapsed += new ElapsedEventHandler(travelTimer_Tick);
            this.travelTimer.Enabled = true;
            TimeLogger.WriteErrorLog("Travel Time Logger Started");
        }

        protected override void OnStop()
        {
            this.travelTimer.Enabled = false;
            TimeLogger.WriteErrorLog("Travel Time Logger Stopped");
        }

        private void travelTimer_Tick(object sender, ElapsedEventArgs e)
        {
            // Fire Timer Every 5 Mins
            int timeInterval = Convert.ToInt32(DateTime.Now.ToString("HHmm"));
            if(timeInterval % 5 == 0)
                TimeLogger.LogTime();
        }

    }
}
