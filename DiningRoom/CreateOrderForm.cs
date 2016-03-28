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
        public CreateOrderForm()
        {
            InitializeComponent();

            ComboBox tables = this.Controls.Find("cmbBoxDestTable", true).FirstOrDefault() as ComboBox;
            tables.Items.AddRange(Program.server.getTables());

            
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            int qnt = Int32.Parse((this.Controls.Find("txtQnt", true).FirstOrDefault() as TextBox).Text);
            int destTable = Int32.Parse((this.Controls.Find("cmbBoxDestTable", true).FirstOrDefault() as TextBox).Text);
            int item = 1;
            Program.server.addOrder(new Order(qnt, destTable, item));
        }
    }
}
