using System.Windows.Forms;

namespace MultiThreadFormDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.doSomething = new System.Windows.Forms.Label();
            this.cancel = new Label();
            this.labelRed1 = new System.Windows.Forms.Label();
            this.labelRed2 = new System.Windows.Forms.Label();
            this.labelRed3 = new System.Windows.Forms.Label();
            this.labelRed4 = new System.Windows.Forms.Label();
            this.labelRed5 = new System.Windows.Forms.Label();
            this.labelRed6 = new System.Windows.Forms.Label();
            this.labelBlue1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download Async";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Download Sync";
            // 
            // doSomething
            // 
            this.doSomething.AutoSize = true;
            this.doSomething.Location = new System.Drawing.Point(45, 100);
            this.doSomething.Name = "doSomething";
            this.doSomething.Size = new System.Drawing.Size(179, 31);
            this.doSomething.TabIndex = 6;
            this.doSomething.Text = "Do Something";
            this.doSomething.Click += this.DoSomething;           
            // 
            // cancel
            // 
            this.cancel.AutoSize = true;
            this.cancel.Location = new System.Drawing.Point(45, 66);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(179, 31);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Cancel";
            this.cancel.Click += this.Cancel;
            // 
            // labelRed1
            // 
            this.labelRed1.AutoSize = true;
            this.labelRed1.Location = new System.Drawing.Point(328, 66);
            this.labelRed1.Name = "labelRed1";
            this.labelRed1.Size = new System.Drawing.Size(82, 31);
            this.labelRed1.TabIndex = 7;
            this.labelRed1.Text = "00";
            // 
            // labelRed2
            // 
            this.labelRed2.AutoSize = true;
            this.labelRed2.Location = new System.Drawing.Point(488, 66);
            this.labelRed2.Name = "labelRed2";
            this.labelRed2.Size = new System.Drawing.Size(82, 31);
            this.labelRed2.TabIndex = 7;
            this.labelRed2.Text = "00";
            // 
            // labelRed3
            // 
            this.labelRed3.AutoSize = true;
            this.labelRed3.Location = new System.Drawing.Point(588, 66);
            this.labelRed3.Name = "labelRed3";
            this.labelRed3.Size = new System.Drawing.Size(82, 31);
            this.labelRed3.TabIndex = 7;
            this.labelRed3.Text = "00";
            // 
            // labelRed4
            // 
            this.labelRed4.AutoSize = true;
            this.labelRed4.Location = new System.Drawing.Point(688, 66);
            this.labelRed4.Name = "labelRed4";
            this.labelRed4.Size = new System.Drawing.Size(82, 31);
            this.labelRed4.TabIndex = 7;
            this.labelRed4.Text = "00";
            // 
            // labelRed5
            // 
            this.labelRed5.AutoSize = true;
            this.labelRed5.Location = new System.Drawing.Point(788, 66);
            this.labelRed5.Name = "labelRed5";
            this.labelRed5.Size = new System.Drawing.Size(82, 31);
            this.labelRed5.TabIndex = 7;
            this.labelRed5.Text = "00";
            // 
            // labelRed6
            // 
            this.labelRed6.AutoSize = true;
            this.labelRed6.Location = new System.Drawing.Point(988, 66);
            this.labelRed6.Name = "labelRed6";
            this.labelRed6.Size = new System.Drawing.Size(82, 31);
            this.labelRed6.TabIndex = 7;
            this.labelRed6.Text = "00";
            // 
            // labelBlue1
            // 
            this.labelBlue1.AutoSize = true;
            this.labelBlue1.Location = new System.Drawing.Point(328, 119);
            this.labelBlue1.Name = "labelBlue1";
            this.labelBlue1.Size = new System.Drawing.Size(82, 31);
            this.labelBlue1.TabIndex = 8;
            this.labelBlue1.Text = "00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 450);
            this.Controls.Add(this.labelBlue1);
            this.Controls.Add(this.labelRed1);
            this.Controls.Add(this.labelRed2);
            this.Controls.Add(this.labelRed3);
            this.Controls.Add(this.labelRed4);
            this.Controls.Add(this.labelRed5);
            this.Controls.Add(this.labelRed6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.doSomething);
            this.Controls.Add(this.cancel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label doSomething;
        private Label cancel;
        private Label labelRed1;
        private Label labelRed2;
        private Label labelRed3;
        private Label labelRed4;
        private Label labelRed5;
        private Label labelRed6;
        private Label labelBlue1;
    }
}

