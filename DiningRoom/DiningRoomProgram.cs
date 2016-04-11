using RemoteObject;
using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace DiningRoom
{

    static class DiningRoomProgram
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RemotingConfiguration.Configure("DiningRoom.exe.config", false);

            IRemoteObj remote = Server.RemoteConnect("DiningRoom");
            if (remote == null) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DiningRoomForm(remote));            
        }
    }

    
}
