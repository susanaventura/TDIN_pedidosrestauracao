using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteObject;

namespace DiningRoom
{
    public partial class DiningRoomForm : Form
    {
        IRemoteObj server;

        public DiningRoomForm(IRemoteObj remoteObject)
        {
            this.server = remoteObject;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrderForm createorder = new CreateOrderForm(server);
            createorder.Show();
        }
    }


}
