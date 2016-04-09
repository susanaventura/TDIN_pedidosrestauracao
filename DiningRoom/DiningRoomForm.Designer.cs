using System;

namespace DiningRoom
{
    partial class DiningRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetBill = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxTableBill = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewDoneOrders = new System.Windows.Forms.ListView();
            this.listViewPendingOrders = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "New order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pending Orders";
            // 
            // btnGetBill
            // 
            this.btnGetBill.Location = new System.Drawing.Point(214, 300);
            this.btnGetBill.Name = "btnGetBill";
            this.btnGetBill.Size = new System.Drawing.Size(75, 23);
            this.btnGetBill.TabIndex = 8;
            this.btnGetBill.Text = "Get Bill";
            this.btnGetBill.UseVisualStyleBackColor = true;
            this.btnGetBill.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Done Orders";
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(27, 34);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(262, 21);
            this.comboBoxTables.TabIndex = 1;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTables_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tables";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxTableBill);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGetBill);
            this.panel1.Controls.Add(this.comboBoxTables);
            this.panel1.Location = new System.Drawing.Point(295, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 332);
            this.panel1.TabIndex = 2;
            // 
            // listBoxTableBill
            // 
            this.listBoxTableBill.FormattingEnabled = true;
            this.listBoxTableBill.Location = new System.Drawing.Point(27, 74);
            this.listBoxTableBill.Name = "listBoxTableBill";
            this.listBoxTableBill.Size = new System.Drawing.Size(262, 212);
            this.listBoxTableBill.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewDoneOrders);
            this.panel2.Controls.Add(this.listViewPendingOrders);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(4, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 331);
            this.panel2.TabIndex = 11;
            // 
            // listViewDoneOrders
            // 
            this.listViewDoneOrders.Location = new System.Drawing.Point(11, 203);
            this.listViewDoneOrders.Name = "listViewDoneOrders";
            this.listViewDoneOrders.Size = new System.Drawing.Size(260, 110);
            this.listViewDoneOrders.TabIndex = 12;
            this.listViewDoneOrders.UseCompatibleStateImageBehavior = false;
            this.listViewDoneOrders.View = System.Windows.Forms.View.List;
            // 
            // listViewPendingOrders
            // 
            this.listViewPendingOrders.Location = new System.Drawing.Point(11, 74);
            this.listViewPendingOrders.Name = "listViewPendingOrders";
            this.listViewPendingOrders.Size = new System.Drawing.Size(260, 110);
            this.listViewPendingOrders.TabIndex = 11;
            this.listViewPendingOrders.UseCompatibleStateImageBehavior = false;
            this.listViewPendingOrders.View = System.Windows.Forms.View.List;
            // 
            // DiningRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 351);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DiningRoomForm";
            this.Text = "Dining Room";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewDoneOrders;
        private System.Windows.Forms.ListView listViewPendingOrders;
        private System.Windows.Forms.ListBox listBoxTableBill;
    }
}

