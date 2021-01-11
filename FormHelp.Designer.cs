namespace Rip_Ice
{
    partial class FormHelp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dGridViewhelp = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewhelp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dGridViewhelp);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 519);
            this.panel1.TabIndex = 0;
            // 
            // dGridViewhelp
            // 
            this.dGridViewhelp.AllowUserToAddRows = false;
            this.dGridViewhelp.AllowUserToDeleteRows = false;
            this.dGridViewhelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridViewhelp.Location = new System.Drawing.Point(3, 3);
            this.dGridViewhelp.MultiSelect = false;
            this.dGridViewhelp.Name = "dGridViewhelp";
            this.dGridViewhelp.ReadOnly = true;
            this.dGridViewhelp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridViewhelp.Size = new System.Drawing.Size(723, 514);
            this.dGridViewhelp.TabIndex = 1;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 523);
            this.Controls.Add(this.panel1);
            this.Name = "FormHelp";
            this.Text = "Soluzioni Adottate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHelp_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.FormHelp_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.FormHelp_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridViewhelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGridViewhelp;
    }
}