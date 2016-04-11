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

namespace StatisticsView
{
    public partial class StatisticsViewForm : Form
    {
        IRemoteObj remote;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public StatisticsViewForm(IRemoteObj remote)
        {
            InitializeComponent();

            this.remote = remote;
            this.menu = remote.getMenu();

            RefreshView(-1, null);

            Intermediate inter = new Intermediate();
            inter.PayBill += RefreshViewHandler;
            remote.PayBill += inter.FirePayBill;
        }

        private void RefreshViewHandler(int table, List<Order> orders)
        {
            BeginInvoke(new TableHandler(RefreshView), new object[] {table, orders});
        }

        
        private void RefreshView(int table, List<Order> orders)
        {
            SortedDictionary<int, int> sales = remote.getSales();
            List<StatListItem> sales_items = new List<StatListItem>();
            List<StatListItem> sorted;
            int total_sales = 0; float total_profit = 0;

            foreach (int key in sales.Keys)
            {
                StatListItem item = new StatListItem(key, sales[key], menu);
                total_sales += item.Quantity;
                total_profit += item.Profit;
                sales_items.Add(item);
            }

            // Labels
            labelTotalProfit.Text = "Total Profit: " + total_profit + " euro(s)";
            labelTotalSales.Text = "Total Sales: " + total_sales + " unit(s)";

            // Most sold
            sorted = sales_items.OrderBy(o => -o.Quantity).ToList();
            listBoxMostSold.Items.Clear();
            for (int i = 0; i < sorted.Count && i < 10 && sorted[i].Quantity > 0; i++)
            {
                listBoxMostSold.Items.Add((i + 1) + 
                    " - " + sorted[i].Description + 
                    " - " + sorted[i].Quantity + " unit(s)");
            };

            // Most Profit
            sorted = sales_items.OrderBy(o => -o.Profit).ToList();
            listBoxMostProfit.Items.Clear();
            for (int i = 0; i < sorted.Count && i < 10 && sorted[i].Quantity > 0; i++)
            {
                listBoxMostProfit.Items.Add((i + 1) +
                    " - " + sorted[i].Description +
                    " - " + sorted[i].Profit + " euro(s)");
            };

        }
        private class StatListItem
        {
            public int Item { get; set; }
            public int Quantity { get; set; }
            public float Profit { get; set; }
            public string Description { get; set; }

            public StatListItem(int item, int quantity, SortedDictionary<int, RemoteObject.MenuItem> menu)
            {
                this.Item = item;
                this.Quantity = quantity;
                this.Profit = quantity * menu[item].Price;
                this.Description = menu[item].Description;
            }
        }
    }
}
