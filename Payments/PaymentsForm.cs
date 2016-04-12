using RemoteObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payments
{
    public partial class PaymentsForm : Form
    {
        IRemoteObj remote;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public PaymentsForm(IRemoteObj remote)
        {
            InitializeComponent();
            this.remote = remote;
            menu = remote.getMenu();

            RefreshView();

            Intermediate inter = new Intermediate();
            inter.GetBill += RefreshViewHandler;
            inter.PayBill += RefreshViewHandler;
            remote.GetBill += inter.FireGetBill;            
            remote.PayBill += inter.FirePayBill;
        }

        // Table select
        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = listBoxTables.SelectedIndex;

            if (ind == -1)
            {
                listBoxBill.Items.Clear();
            }
            else
            {
                int table = (listBoxTables.SelectedItem as UIKeyValuePair).Key;
                List<Order> orders = remote.getOrders();
                listBoxBill.Items.Clear();
                float total = 0;

                foreach (Order o in orders)
                {
                    if (o.Table != table) continue;

                    total += o.GetPrice(menu);
                    listBoxBill.Items.Add(o.ToStringBill(menu));
                }
                listBoxBill.Items.Add("Total: " + total + " euro(s)");
            }
        }

        // Pay button click
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedIndex >= 0)
                remote.payTableBill((listBoxTables.SelectedItem as UIKeyValuePair).Key);
        }

        // Refresh the View
        delegate void RefreshViewDelegate(); 
        private void RefreshViewHandler(int table, List<Order> orders)
        {
            BeginInvoke(new RefreshViewDelegate(RefreshView), new object[] {});
        }

        private void RefreshView()
        {
            // Tables Listing
            List<bool> tables = remote.getTables();            
            listBoxTables.SelectedIndex = -1;
            listBoxTables.Items.Clear();

            for(int i = 0; i < tables.Count; i++)
            {
                if (!tables[i]) listBoxTables.Items.Add(new UIKeyValuePair(i, "Table " + (i + 1)));
            }
        }


    }
}
