namespace Sage50Excel13Plugin
{
    partial class RibAciBI : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibAciBI()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabACI = this.Factory.CreateRibbonTab();
            this.GrpReports = this.Factory.CreateRibbonGroup();
            this.BtnAntItem = this.Factory.CreateRibbonButton();
            this.GrpConfigACI = this.Factory.CreateRibbonGroup();
            this.BtnCondb = this.Factory.CreateRibbonButton();
            this.TabACI.SuspendLayout();
            this.GrpReports.SuspendLayout();
            this.GrpConfigACI.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabACI
            // 
            this.TabACI.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabACI.Groups.Add(this.GrpReports);
            this.TabACI.Groups.Add(this.GrpConfigACI);
            this.TabACI.Label = "ACI  BI";
            this.TabACI.Name = "TabACI";
            // 
            // GrpReports
            // 
            this.GrpReports.Items.Add(this.BtnAntItem);
            this.GrpReports.Label = "Reportes";
            this.GrpReports.Name = "GrpReports";
            // 
            // BtnAntItem
            // 
            this.BtnAntItem.Label = "Antigüedad por Item";
            this.BtnAntItem.Name = "BtnAntItem";
            this.BtnAntItem.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCarteraVencida_Click);
            // 
            // GrpConfigACI
            // 
            this.GrpConfigACI.Items.Add(this.BtnCondb);
            this.GrpConfigACI.Label = "Configuracion";
            this.GrpConfigACI.Name = "GrpConfigACI";
            // 
            // BtnCondb
            // 
            this.BtnCondb.Image = global::Sage50Excel13Plugin.Properties.Resources.Cog;
            this.BtnCondb.Label = "Conexion DB";
            this.BtnCondb.Name = "BtnCondb";
            this.BtnCondb.ShowImage = true;
            this.BtnCondb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCondb_Click);
            // 
            // RibAciBI
            // 
            this.Name = "RibAciBI";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabACI);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibAciBI_Load);
            this.TabACI.ResumeLayout(false);
            this.TabACI.PerformLayout();
            this.GrpReports.ResumeLayout(false);
            this.GrpReports.PerformLayout();
            this.GrpConfigACI.ResumeLayout(false);
            this.GrpConfigACI.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabACI;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpReports;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnAntItem;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpConfigACI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnCondb;
    }

    partial class ThisRibbonCollection
    {
        internal RibAciBI RibAciBI
        {
            get { return this.GetRibbon<RibAciBI>(); }
        }
    }
}
