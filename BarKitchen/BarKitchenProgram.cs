using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace BarKitchen
{
    static class BarKitchenProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("BarKitchen.exe.config", false);

            IRemoteObj remote = Server.RemoteConnect("BarKitchen");
            if (remote == null) return;            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BarKitchenForm(remote));
        }
    }
}
