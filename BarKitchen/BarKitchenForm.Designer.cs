namespace Bar
{
    partial class Form1
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
            this.lstBarPreparing = new System.Windows.Forms.ListView();
            this.btnBarToPrep = new System.Windows.Forms.Button();
            this.btnBarDone = new System.Windows.Forms.Button();
            this.btnKitchenDone = new System.Windows.Forms.Button();
            this.btnKitchenToPrep = new System.Windows.Forms.Button();
            this.lstKitchenPreparing = new System.Windows.Forms.ListView();
            this.lstBarPending = new System.Windows.Forms.ListView();
            this.lstKitchenPending = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bar";
            // 
            // lstBarPreparing
            // 
            this.lstBarPreparing.Location = new System.Drawing.Point(12, 245);
            this.lstBarPreparing.Name = "lstBarPreparing";
            this.lstBarPreparing.Size = new System.Drawing.Size(233, 111);
            this.lstBarPreparing.TabIndex = 3;
            this.lstBarPreparing.UseCompatibleStateImageBehavior = false;
            // 
            // btnBarToPrep
            // 
            this.btnBarToPrep.Location = new System.Drawing.Point(95, 192);
            this.btnBarToPrep.Name = "btnBarToPrep";
            this.btnBarToPrep.Size = new System.Drawing.Size(75, 23);
            this.btnBarToPrep.TabIndex = 5;
            this.btnBarToPrep.Text = "v";
            this.btnBarToPrep.UseVisualStyleBackColor = true;
            // 
            // btnBarDone
            // 
            this.btnBarDone.Location = new System.Drawing.Point(95, 362);
            this.btnBarDone.Name = "btnBarDone";
            this.btnBarDone.Size = new System.Drawing.Size(75, 23);
            this.btnBarDone.TabIndex = 6;
            this.btnBarDone.Text = "Done";
            this.btnBarDone.UseVisualStyleBackColor = true;
            // 
            // btnKitchenDone
            // 
            this.btnKitchenDone.Location = new System.Drawing.Point(405, 362);
            this.btnKitchenDone.Name = "btnKitchenDone";
            this.btnKitchenDone.Size = new System.Drawing.Size(75, 23);
            this.btnKitchenDone.TabIndex = 11;
            this.btnKitchenDone.Text = "Done";
            this.btnKitchenDone.UseVisualStyleBackColor = true;
            // 
            // btnKitchenToPrep
            // 
            this.btnKitchenToPrep.Location = new System.Drawing.Point(405, 192);
            this.btnKitchenToPrep.Name = "btnKitchenToPrep";
            this.btnKitchenToPrep.Size = new System.Drawing.Size(75, 23);
            this.btnKitchenToPrep.TabIndex = 10;
            this.btnKitchenToPrep.Text = "v";
            this.btnKitchenToPrep.UseVisualStyleBackColor = true;
            // 
            // lstKitchenPreparing
            // 
            this.lstKitchenPreparing.Location = new System.Drawing.Point(323, 245);
            this.lstKitchenPreparing.Name = "lstKitchenPreparing";
            this.lstKitchenPreparing.Size = new System.Drawing.Size(233, 111);
            this.lstKitchenPreparing.TabIndex = 12;
            this.lstKitchenPreparing.UseCompatibleStateImageBehavior = false;
            // 
            // lstBarPending
            // 
            this.lstBarPending.Location = new System.Drawing.Point(16, 62);
            this.lstBarPending.Name = "lstBarPending";
            this.lstBarPending.Size = new System.Drawing.Size(233, 111);
            this.lstBarPending.TabIndex = 13;
            this.lstBarPending.UseCompatibleStateImageBehavior = false;
            // 
            // lstKitchenPending
            // 
            this.lstKitchenPending.Location = new System.Drawing.Point(323, 62);
            this.lstKitchenPending.Name = "lstKitchenPending";
            this.lstKitchenPending.Size = new System.Drawing.Size(233, 111);
            this.lstKitchenPending.TabIndex = 14;
            this.lstKitchenPending.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(319, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kitchen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Preparing";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Preparing";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Pending";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Pending";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 395);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstKitchenPending);
            this.Controls.Add(this.lstBarPending);
            this.Controls.Add(this.lstKitchenPreparing);
            this.Controls.Add(this.btnKitchenDone);
            this.Controls.Add(this.btnKitchenToPrep);
            this.Controls.Add(this.btnBarDone);
            this.Controls.Add(this.btnBarToPrep);
            this.Controls.Add(this.lstBarPreparing);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Bar and Kitchen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstBarPreparing;
        private System.Windows.Forms.Button btnBarToPrep;
        private System.Windows.Forms.Button btnBarDone;
        private System.Windows.Forms.Button btnKitchenDone;
        private System.Windows.Forms.Button btnKitchenToPrep;
        private System.Windows.Forms.ListView lstKitchenPreparing;
        private System.Windows.Forms.ListView lstBarPending;
        private System.Windows.Forms.ListView lstKitchenPending;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

