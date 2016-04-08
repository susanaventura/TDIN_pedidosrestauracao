using RemoteObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("BarKitchen.exe.config", false);

            Console.WriteLine("[BarKitchen] connecting to Server...");

            IRemoteObj remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.ping("BarKitchen");

            Console.WriteLine("[BarKitchen] connected.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
