using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading.Tasks;
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
            Console.WriteLine("[DiningRoom] connecting to Server");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DiningRoomForm form = new DiningRoomForm();
            form.SetRemoteObject(new RemoteObject.RemoteObj());
            Application.Run(form);

        }
    }
}
