namespace DiningRoom
{
    partial class CreateOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxDestTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoxOrder = new System.Windows.Forms.ComboBox();
            this.txtQnt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.txtFormError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table";
            // 
            // cmbBoxDestTable
            // 
            this.cmbBoxDestTable.FormattingEnabled = true;
            this.cmbBoxDestTable.Location = new System.Drawing.Point(134, 41);
            this.cmbBoxDestTable.Name = "cmbBoxDestTable";
            this.cmbBoxDestTable.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxDestTable.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity";
            // 
            // cmbBoxOrder
            // 
            this.cmbBoxOrder.FormattingEnabled = true;
            this.cmbBoxOrder.Location = new System.Drawing.Point(134, 89);
            this.cmbBoxOrder.Name = "cmbBoxOrder";
            this.cmbBoxOrder.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxOrder.TabIndex = 4;
            // 
            // txtQnt
            // 
            this.txtQnt.Location = new System.Drawing.Point(134, 142);
            this.txtQnt.Name = "txtQnt";
            this.txtQnt.Size = new System.Drawing.Size(121, 20);
            this.txtQnt.TabIndex = 8;
            this.txtQnt.Text = "1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(29, 223);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 11;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // txtFormError
            // 
            this.txtFormError.AutoSize = true;
            this.txtFormError.Location = new System.Drawing.Point(116, 187);
            this.txtFormError.Name = "txtFormError";
            this.txtFormError.Size = new System.Drawing.Size(0, 13);
            this.txtFormError.TabIndex = 12;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 268);
            this.Controls.Add(this.txtFormError);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtQnt);
            this.Controls.Add(this.cmbBoxOrder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBoxDestTable);
            this.Controls.Add(this.label1);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxDestTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxOrder;
        private System.Windows.Forms.TextBox txtQnt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label txtFormError;
    }
}