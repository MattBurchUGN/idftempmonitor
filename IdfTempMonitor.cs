using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SharePoint.Client;
using System.Security;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Timers;
using System.Net.Http;


namespace idftempmonitor
{
    public partial class IdfTempMonitor : ServiceBase
    {
        JsonDocument response1;
        JsonDocument response2;
        JsonDocument response3;
        JsonDocument response4;
        JsonDocument response5;
        public IdfTempMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            IList<IPAddress> ipList = new List<IPAddress>();
            ipList.Add(IPAddress.Parse("10.109.255.241"));
            ipList.Add(IPAddress.Parse("10.109.255.243"));
            ipList.Add(IPAddress.Parse("10.109.255.245"));
            ipList.Add(IPAddress.Parse("10.109.255.247"));
            ipList.Add(IPAddress.Parse("10.109.255.249"));
            dispatcherTimer_Tick1(null, null);
            dispatcherTimer_Tick2(null, null);
            dispatcherTimer_Tick3(null, null);
            dispatcherTimer_Tick4(null, null);
            dispatcherTimer_Tick5(null, null);
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick1);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick2);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick3);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick4);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick5);
            dispatcherTimer.Interval = new TimeSpan(0, 30, 0);
            dispatcherTimer.Start();
            // setup interval to query each IP
            // write to sharepoint list the response
        }

        protected override void OnStop()
        {
            // make sure all async tasks are complete.
            //close connections
        }
    }
}
