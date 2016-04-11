using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace StatisticsView
{
    static class StatisticsViewProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("StatisticsView.exe.config", false);
            
            IRemoteObj remote = Server.RemoteConnect("StatisticsView");
            if (remote == null) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StatisticsViewForm(remote));
        }
    }
}
