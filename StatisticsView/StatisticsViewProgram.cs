using RemoteObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading.Tasks;
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

            Console.WriteLine("[StatisticsView] connecting to Server...");

            IRemoteObj remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.ping("StatisticsView");

            Console.WriteLine("[StatisticsView] connected.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StatisticsViewForm(remote));
        }
    }
}
