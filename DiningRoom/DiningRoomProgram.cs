using RemoteObject;
using System;
using System.Collections;
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

            Console.WriteLine("[DiningRoom] connecting to Server...");

            IRemoteObj remote = (IRemoteObj)GetRemote.New(typeof(IRemoteObj));
            remote.ping("DiningRoom");

            Console.WriteLine("[DiningRoom] connected.");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DiningRoomForm(remote));            
        }
    }

    
}
