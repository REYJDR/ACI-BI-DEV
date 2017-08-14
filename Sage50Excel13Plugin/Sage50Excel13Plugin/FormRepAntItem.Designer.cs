namespace Sage50Excel13Plugin
{
    partial class FormRepAntItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRepAntItem));
            this.label1 = new System.Windows.Forms.Label();
            this.CboItemlist = new System.Windows.Forms.ComboBox();
            this.BtnGetreport = new System.Windows.Forms.Button();
            this.checkTodos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item ID";
            // 
            // CboItemlist
            // 
            this.CboItemlist.FormattingEnabled = true;
            this.CboItemlist.Location = new System.Drawing.Point(66, 27);
            this.CboItemlist.Name = "CboItemlist";
            this.CboItemlist.Size = new System.Drawing.Size(142, 21);
            this.CboItemlist.TabIndex = 4;
            // 
            // BtnGetreport
            // 
            this.BtnGetreport.Location = new System.Drawing.Point(204, 69);
            this.BtnGetreport.Name = "BtnGetreport";
            this.BtnGetreport.Size = new System.Drawing.Size(87, 26);
            this.BtnGetreport.TabIndex = 3;
            this.BtnGetreport.Text = "Consultar";
            this.BtnGetreport.UseVisualStyleBackColor = true;
            this.BtnGetreport.Click += new System.EventHandler(this.BtnGetreport_Click_1);
            // 
            // checkTodos
            // 
            this.checkTodos.AutoSize = true;
            this.checkTodos.Location = new System.Drawing.Point(235, 31);
            this.checkTodos.Name = "checkTodos";
            this.checkTodos.Size = new System.Drawing.Size(56, 17);
            this.checkTodos.TabIndex = 7;
            this.checkTodos.Text = "Todos";
            this.checkTodos.UseVisualStyleBackColor = true;
            this.checkTodos.CheckedChanged += new System.EventHandler(this.checkTodos_CheckedChanged);
            // 
            // FormRepAntItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 104);
            this.Controls.Add(this.checkTodos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CboItemlist);
            this.Controls.Add(this.BtnGetreport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRepAntItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Filtro antigüedad por Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboItemlist;
        private System.Windows.Forms.Button BtnGetreport;
        private System.Windows.Forms.CheckBox checkTodos;
    }
}