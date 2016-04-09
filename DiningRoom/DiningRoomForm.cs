using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RemoteObject;

namespace DiningRoom
{
    public partial class DiningRoomForm : Form
    {
        IRemoteObj remote;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public DiningRoomForm(IRemoteObj remoteObject)
        {
            InitializeComponent();

            remote = remoteObject;
            menu = remote.getMenu();
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
            Console.WriteLine("Bill for table " + listBoxTables.SelectedItem);
            if (listBoxTables.SelectedIndex >= 0) {
                remote.getTableBill((listBoxTables.SelectedItem as UIKeyValuePair).Key);
                listBoxTables.SelectedIndex = -1;
            }
        }

        // List Views
        private void ListViewPendingOrders_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.WriteLine(e.Item);
        }

        private void ListViewDoneOrders_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.WriteLine(e.Item);
        }


        // Table Combo Box

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = listBoxTables.SelectedIndex;

            if (ind == -1)
            {
                listBoxTableBill.Items.Clear();
            }
            else
            {
                int table = (listBoxTables.SelectedItem as UIKeyValuePair).Key;
                List<Order> orders = remote.getOrders();
                listBoxTableBill.Items.Clear();
                float total = 0;

                foreach (Order o in orders) {
                    if (o.Table != table) continue;

                    total += o.GetPrice(menu);
                    listBoxTableBill.Items.Add(o.ToStringBill(menu));
                }
                listBoxTableBill.Items.Add("Total: " + total + " euro(s)");
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

            // Order Listing
            listBoxDoneOrders.Items.Clear();
            listBoxPendingOrders.Items.Clear();
            foreach (Order o in orders) {
                ListBox list = (o.Status == OrderStatus.Done) ? listBoxDoneOrders : listBoxPendingOrders;

                list.Items.Add(o.ToStringStatus(menu));
                tables_served.Add(o.Table);
            }

            // Tables Listing
            listBoxTables.SelectedIndex = -1;
            listBoxTables.Items.Clear();
            foreach (int i in tables_served) {
                if (tables[i]) listBoxTables.Items.Add(new UIKeyValuePair(i, "Table " + (i + 1)));
            }
        }


    }


}
