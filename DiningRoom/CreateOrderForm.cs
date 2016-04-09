
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
        IRemoteObj remote;
        SortedDictionary<int, RemoteObject.MenuItem> menu;

        public CreateOrderForm(IRemoteObj remote)
        {
            InitializeComponent();

            this.remote = remote;
            menu = remote.getMenu();

            List<bool> tables = remote.getTables();

            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i]) cmbBoxDestTable.Items.Add(new DiningRoomForm.UIKeyValuePair(i,"Table "+(i+1)));
            }
            
            
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

            int table = (cmbBoxDestTable.SelectedItem as DiningRoomForm.UIKeyValuePair).Key;

            if (!remote.getTables()[table])
            {
                txtFormError.Text = "Table has already asked for bill.";
                return;
            }

            int item = menu.ElementAt(cmbBoxOrder.SelectedIndex).Value.Id;

            remote.addOrder(new Order(qnt, table, item));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.FindForm().Close();
        }

    }
}
