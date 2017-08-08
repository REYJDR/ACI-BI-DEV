namespace Sage50Excel13Plugin
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
            this.BtnGetreport = new System.Windows.Forms.Button();
            this.CboItemlist = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGetreport
            // 
            this.BtnGetreport.Location = new System.Drawing.Point(237, 23);
            this.BtnGetreport.Name = "BtnGetreport";
            this.BtnGetreport.Size = new System.Drawing.Size(87, 26);
            this.BtnGetreport.TabIndex = 0;
            this.BtnGetreport.Text = "Consultar";
            this.BtnGetreport.UseVisualStyleBackColor = true;
            this.BtnGetreport.Click += new System.EventHandler(this.BtnGetreport_Click);
            // 
            // CboItemlist
            // 
            this.CboItemlist.FormattingEnabled = true;
            this.CboItemlist.Location = new System.Drawing.Point(70, 23);
            this.CboItemlist.Name = "CboItemlist";
            this.CboItemlist.Size = new System.Drawing.Size(121, 21);
            this.CboItemlist.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 61);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CboItemlist);
            this.Controls.Add(this.BtnGetreport);
            this.Name = "Form1";
            this.Text = "Filtros de Reporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGetreport;
        private System.Windows.Forms.ComboBox CboItemlist;
        private System.Windows.Forms.Label label1;
    }
}