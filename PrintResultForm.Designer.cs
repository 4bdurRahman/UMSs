using System;
using System.Drawing;
using System.Windows.Forms;

namespace EducationalInstituteManagementSystem
{
    
    partial class PrintResultForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtResultPreview;
        private Button btnPrint;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtResultPreview = new TextBox();
            this.btnPrint = new Button();
            this.btnClose = new Button();

            // 
            // PrintResultForm
            // 
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Text = "Print Result Card";
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // txtResultPreview
            this.txtResultPreview.Multiline = true;
            this.txtResultPreview.ScrollBars = ScrollBars.Vertical;
            this.txtResultPreview.Location = new Point(20, 20);
            this.txtResultPreview.Size = new Size(660, 500);
            this.txtResultPreview.ReadOnly = true;

            // btnPrint
            this.btnPrint.Location = new Point(450, 540);
            this.btnPrint.Size = new Size(100, 35);
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);

            // btnClose
            this.btnClose.Location = new Point(570, 540);
            this.btnClose.Size = new Size(100, 35);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            this.Controls.Add(txtResultPreview);
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}