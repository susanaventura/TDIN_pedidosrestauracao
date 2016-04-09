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
            Console.WriteLine("Bill for table " + comboBoxTables.SelectedItem);
            if (comboBoxTables.SelectedIndex >= 0) {                
                remote.getTableBill((comboBoxTables.SelectedItem as UIKeyValuePair).Key);
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

        private void ComboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = comboBoxTables.SelectedIndex;

            if (ind == -1)
            {
                listBoxTableBill.Items.Clear();
            }
            else
            {
                int table = (comboBoxTables.SelectedItem as UIKeyValuePair).Key;
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

            // List 1
            listViewDoneOrders.Items.Clear();
            listViewPendingOrders.Items.Clear();
            foreach (Order o in orders) {
                ListView list;
                Color color = Color.White;

                list = (o.Status == OrderStatus.Done) ? listViewDoneOrders : listViewPendingOrders;
                switch (o.Status) {
                    case OrderStatus.Waiting: color = Color.Red; break;
                    case OrderStatus.Processing: color = Color.Yellow; break;
                    case OrderStatus.Done: color = Color.Green; break;
                }

                ListViewItem item = new ListViewItem(o.ToString(menu));
                item.BackColor = color;
                item.Tag = o;
                list.Items.Add(item);
                tables_served.Add(o.Table);
            }

            // ComboBoxTables
            comboBoxTables.Items.Clear();
            foreach (int i in tables_served) {
                if (tables[i]) comboBoxTables.Items.Add(new UIKeyValuePair(i, "Table " + (i + 1)));
            }
        }


        // Aux
        private class UIKeyValuePair
        {
            public int Key { get; set; }
            public string Value { get; set; }

            public UIKeyValuePair(int key, string value)
            {
                this.Key = key;
                this.Value = value;
            }

            public override string ToString() {
                return Value;
            }
        }

       
    }


}
