namespace Sage50Excel13Plugin
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabAci = this.Factory.CreateRibbonTab();
            this.GrpReportes = this.Factory.CreateRibbonGroup();
            this.BtnCarteraVencida = this.Factory.CreateRibbonButton();
            this.GrpConfiguracion = this.Factory.CreateRibbonGroup();
            this.BtnConexion = this.Factory.CreateRibbonButton();
            this.TabAci.SuspendLayout();
            this.GrpReportes.SuspendLayout();
            this.GrpConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabAci
            // 
            this.TabAci.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabAci.Groups.Add(this.GrpReportes);
            this.TabAci.Groups.Add(this.GrpConfiguracion);
            this.TabAci.Label = "ACI - BI";
            this.TabAci.Name = "TabAci";
            // 
            // GrpReportes
            // 
            this.GrpReportes.Items.Add(this.BtnCarteraVencida);
            this.GrpReportes.Label = "Reportes";
            this.GrpReportes.Name = "GrpReportes";
            // 
            // BtnCarteraVencida
            // 
            this.BtnCarteraVencida.Label = "Cartera Vencida";
            this.BtnCarteraVencida.Name = "BtnCarteraVencida";
            this.BtnCarteraVencida.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCarteraVencida_Click);
            // 
            // GrpConfiguracion
            // 
            this.GrpConfiguracion.Items.Add(this.BtnConexion);
            this.GrpConfiguracion.Label = "Configuracion";
            this.GrpConfiguracion.Name = "GrpConfiguracion";
            // 
            // BtnConexion
            // 
            this.BtnConexion.Image = global::Sage50Excel13Plugin.Properties.Resources.Cog;
            this.BtnConexion.Label = "Conexion";
            this.BtnConexion.Name = "BtnConexion";
            this.BtnConexion.ShowImage = true;
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabAci);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.TabAci.ResumeLayout(false);
            this.TabAci.PerformLayout();
            this.GrpReportes.ResumeLayout(false);
            this.GrpReportes.PerformLayout();
            this.GrpConfiguracion.ResumeLayout(false);
            this.GrpConfiguracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabAci;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpReportes;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnCarteraVencida;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpConfiguracion;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnConexion;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
