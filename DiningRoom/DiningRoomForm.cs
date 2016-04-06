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
        IRemoteObj remote;

        public DiningRoomForm(IRemoteObj remoteObject)
        {
            this.remote = remoteObject;
            InitializeComponent();
            RefreshOrdersView(null);

            Intermediate inter = new Intermediate();
            inter.UpdateOrder += RefreshOrdersViewHandler;
            remote.UpdateOrder += inter.FireUpdateOrder;
        }

        // Button 1 (New Order Form)
        private void button1_Click(object sender, EventArgs e)
        {
            CreateOrderForm createorder = new CreateOrderForm(remote);
            createorder.Show();
        }


        // Button 2 (Get Bill)
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Bill for table " + comboBox1.SelectedItem);
            if (comboBox1.SelectedIndex >= 0) {                
                remote.getTableBill(((int) comboBox1.SelectedItem)-1);
            }
        }

        // Refresh the View
        private void RefreshOrdersViewHandler(Order order)
        {
            BeginInvoke(new OrderHandler(RefreshOrdersView), new object[] { order });
        }

        private void RefreshOrdersView(Order order)
        {
            HashSet<int> tables_served = new HashSet<int>();
            List<Order> orders = remote.getOrders();
            List<bool> tables = remote.getTables();

            // List 1
            listBox1.Items.Clear();
            foreach (Order o in orders) {
                listBox1.Items.Add(o.ToString());
                tables_served.Add(o.Table);
            }


            // Bill list
            // Add all tables with orders that are not closed
            comboBox1.Items.Clear();
            foreach (int i in tables_served.AsEnumerable()) {
                if (tables.ElementAt(i)) {
                    comboBox1.Items.Add(i+1);
                }
            }

        }

        
    }


}
