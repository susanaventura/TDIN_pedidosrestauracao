namespace StatisticsView
{
    partial class StatisticsViewForm
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
            this.listBoxMostSold = new System.Windows.Forms.ListBox();
            this.listBoxMostProfit = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalProfit = new System.Windows.Forms.Label();
            this.labelTotalSales = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statistics";
            // 
            // listBoxMostSold
            // 
            this.listBoxMostSold.FormattingEnabled = true;
            this.listBoxMostSold.Location = new System.Drawing.Point(6, 93);
            this.listBoxMostSold.Name = "listBoxMostSold";
            this.listBoxMostSold.Size = new System.Drawing.Size(120, 147);
            this.listBoxMostSold.TabIndex = 1;
            // 
            // listBoxMostProfit
            // 
            this.listBoxMostProfit.FormattingEnabled = true;
            this.listBoxMostProfit.Location = new System.Drawing.Point(132, 93);
            this.listBoxMostProfit.Name = "listBoxMostProfit";
            this.listBoxMostProfit.Size = new System.Drawing.Size(120, 147);
            this.listBoxMostProfit.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Most Sold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Most Profit";
            // 
            // labelTotalProfit
            // 
            this.labelTotalProfit.AutoSize = true;
            this.labelTotalProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProfit.Location = new System.Drawing.Point(97, 9);
            this.labelTotalProfit.Name = "labelTotalProfit";
            this.labelTotalProfit.Size = new System.Drawing.Size(81, 17);
            this.labelTotalProfit.TabIndex = 6;
            this.labelTotalProfit.Text = "Total Profit:";
            // 
            // labelTotalSales
            // 
            this.labelTotalSales.AutoSize = true;
            this.labelTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalSales.Location = new System.Drawing.Point(97, 40);
            this.labelTotalSales.Name = "labelTotalSales";
            this.labelTotalSales.Size = new System.Drawing.Size(83, 17);
            this.labelTotalSales.TabIndex = 7;
            this.labelTotalSales.Text = "Total Sales:";
            // 
            // StatisticsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 247);
            this.Controls.Add(this.labelTotalSales);
            this.Controls.Add(this.labelTotalProfit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxMostProfit);
            this.Controls.Add(this.listBoxMostSold);
            this.Controls.Add(this.label1);
            this.Name = "StatisticsViewForm";
            this.Text = "Statistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxMostSold;
        private System.Windows.Forms.ListBox listBoxMostProfit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalProfit;
        private System.Windows.Forms.Label labelTotalSales;
    }
}

