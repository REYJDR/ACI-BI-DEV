namespace Sage50Excel13Plugin
{
    partial class FormDbConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDbConfig));
            this.BtnDbSave = new System.Windows.Forms.Button();
            this.textHost = new System.Windows.Forms.TextBox();
            this.textDb = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblDb = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnDbSave
            // 
            this.BtnDbSave.Location = new System.Drawing.Point(272, 85);
            this.BtnDbSave.Name = "BtnDbSave";
            this.BtnDbSave.Size = new System.Drawing.Size(75, 23);
            this.BtnDbSave.TabIndex = 0;
            this.BtnDbSave.Text = "Guardar";
            this.BtnDbSave.UseVisualStyleBackColor = true;
            this.BtnDbSave.Click += new System.EventHandler(this.BtnDbSave_Click);
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(95, 10);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(165, 20);
            this.textHost.TabIndex = 1;
            // 
            // textDb
            // 
            this.textDb.Location = new System.Drawing.Point(95, 36);
            this.textDb.Name = "textDb";
            this.textDb.Size = new System.Drawing.Size(165, 20);
            this.textDb.TabIndex = 2;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(95, 62);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(165, 20);
            this.textUser.TabIndex = 3;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(95, 88);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(165, 20);
            this.textPass.TabIndex = 4;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(13, 19);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(46, 13);
            this.lblHost.TabIndex = 5;
            this.lblHost.Text = "Servidor";
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(12, 46);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(77, 13);
            this.lblDb.TabIndex = 6;
            this.lblDb.Text = "Base de Datos";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(13, 69);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "Usuario";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(13, 95);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 8;
            this.lblPass.Text = "Contraseña";
            // 
            // FormDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 127);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblDb);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.textDb);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.BtnDbSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDbConfig";
            this.Text = "Conexion Sage Peachtree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDbSave;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.TextBox textDb;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblDb;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
    }
}