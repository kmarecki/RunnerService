using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace RunnerService
{
    public partial class RunnerService : ServiceBase
    {
        public RunnerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string script = ConfigurationManager.AppSettings["OnStart"]; 
            ExecuteScript(script);
        }

        protected override void OnStop()
        {
            string script = ConfigurationManager.AppSettings["OnStop"];
            ExecuteScript(script);
        }

        private Process ExecuteScript(string script)
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd", " /c " + script);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;

            process = Process.Start(processInfo);
            return process;
        }
    }
}
