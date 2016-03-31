using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningRoom
{
    public partial class CreateOrderForm : Form
    {
        SortedDictionary<int, Server.MenuItem> menu;

        public CreateOrderForm()
        {
            InitializeComponent();
            
            cmbBoxDestTable.Items.AddRange(Program.server.getTables());
            
            menu = Program.server.getMenu();

            System.Object[] orders = new System.Object[Program.server.getMenu().Count];

            for(int i = 0; i < orders.Length; i++)
            {
                orders[i] = menu.ElementAt(i).Value.Description + " | " + menu.ElementAt(i).Value.Price + "€";
            }

            cmbBoxOrder.Items.AddRange(orders);
            
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

            Program.server.addOrder(new Order(qnt, destTable, item));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }


    }
}
