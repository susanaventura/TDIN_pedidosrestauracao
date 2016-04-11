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

namespace Bar
{
    public partial class BarKitchenForm : Form
    {

        IRemoteObj remote;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public BarKitchenForm(IRemoteObj remoteObject)
        {
            InitializeComponent();

            remote = remoteObject;
            menu = remote.getMenu();

            Intermediate inter = new Intermediate();
            inter.UpdateOrder += RefreshOrdersViewHandler;
            remote.UpdateOrder += inter.FireUpdateOrder;
        }


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
            lstBoxBarPending.Items.Clear();
            lstBoxBarPreparing.Items.Clear();

            lstBoxKitchenPending.Items.Clear();
            lstBoxKitchenPreparing.Items.Clear();

            foreach (Order o in orders)
            {

                if (menu[o.Item].Type == RoomType.Bar)
                {
                    ListBox list = (o.Status == OrderStatus.Processing) ? lstBoxBarPreparing : lstBoxBarPending;

                    list.Items.Add(o.ToStringStatus(menu));
                }
                else if (menu[o.Item].Type == RoomType.Kitchen)
                {
                    ListBox list = (o.Status == OrderStatus.Processing) ? lstBoxKitchenPreparing : lstBoxKitchenPending;

                    list.Items.Add(o.ToStringStatus(menu));
                }
                else Console.WriteLine("Wrong type");
            }  
        }



    }
}
