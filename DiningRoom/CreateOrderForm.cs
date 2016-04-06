
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
    public partial class CreateOrderForm : Form
    {
        IRemoteObj server;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public CreateOrderForm(IRemoteObj server)
        {
            InitializeComponent();

            this.server = server;
            menu = server.getMenu();

            cmbBoxDestTable.Items.AddRange(server.getTables().ToArray());
            
            for(int i = 0; i < menu.Count; i++)
            {
                cmbBoxOrder.Items.Add(menu.ElementAt(i).Value.Description + " | " + menu.ElementAt(i).Value.Price + "€");
            }

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

           if (cmbBoxDestTable.SelectedIndex == -1 || cmbBoxOrder.SelectedIndex == -1 || txtQnt.Text.Trim().Length == 0)
           {
               txtFormError.Text = "You cannot have blank fields.";
               return;
           }

           int qnt;
           try {
               qnt = Int32.Parse(txtQnt.Text);
           } catch(Exception)
           {
               txtFormError.Text = "Quantity must be a valid integer.";
               return;
           }

           txtFormError.Text = "";

           int destTable = Int32.Parse(cmbBoxDestTable.Text);

           int item = menu.ElementAt(cmbBoxOrder.SelectedIndex).Value.Id;

           server.addOrder(new Order(qnt, destTable, item));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.FindForm().Close();
        }

    }
}
