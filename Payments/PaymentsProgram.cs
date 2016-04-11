using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace Payments
{
    static class PaymentsProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("Payments.exe.config", false);

            IRemoteObj remote = Server.RemoteConnect("Payments");
            if (remote == null) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PaymentsForm(remote));
        }
    }
}
