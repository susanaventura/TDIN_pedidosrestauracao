using RemoteObject;
using System;
using System.Collections.Generic;

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
            List<Order> orders = remote.getOrders();
            List<bool> tables = remote.getTables();

            // Order Listing
            lstBoxBarPending.Items.Clear();
            lstBoxBarProcessing.Items.Clear();

            lstBoxKitchenPending.Items.Clear();
            lstBoxKitchenProcessing.Items.Clear();

            foreach (Order o in orders)
            {
                if (o.Status == OrderStatus.Done) continue;


                if (menu[o.Item].Type == RoomType.Bar)
                {
                    ListBox list = (o.Status == OrderStatus.Processing) ? lstBoxBarProcessing : lstBoxBarPending;

                    list.Items.Add(o);
                    list.DisplayMember = "OrderDescription";

                }
                else if (menu[o.Item].Type == RoomType.Kitchen)
                {
                    ListBox list = (o.Status == OrderStatus.Processing) ? lstBoxKitchenProcessing : lstBoxKitchenPending;

                    list.Items.Add(o);
                    list.DisplayMember = "OrderDescription";
                }
                else Console.WriteLine("Wrong type");
            }  
        }

        private void btnBarToPrep_Click(object sender, EventArgs e)
        {
            if (lstBoxBarPending.SelectedItem != null)
                remote.setOrderStatus((Order) lstBoxBarPending.SelectedItem, OrderStatus.Processing);
        }

        private void btnKitchenToPrep_Click(object sender, EventArgs e)
        {
            if(lstBoxKitchenPending.SelectedItem != null)
                remote.setOrderStatus((Order)lstBoxKitchenPending.SelectedItem, OrderStatus.Processing);
        }

        private void btnBarDone_Click(object sender, EventArgs e)
        {
            if (lstBoxBarProcessing.SelectedItem != null)
                remote.setOrderStatus((Order)lstBoxBarProcessing.SelectedItem, OrderStatus.Done);
        }

        private void btnKitchenDone_Click(object sender, EventArgs e)
        {
            if (lstBoxKitchenProcessing.SelectedItem != null)
                remote.setOrderStatus((Order)lstBoxKitchenProcessing.SelectedItem, OrderStatus.Done);
        }
    }
}
