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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibAciBI));
            this.TabACI = this.Factory.CreateRibbonTab();
            this.GrpReports = this.Factory.CreateRibbonGroup();
            this.BtnAntItem = this.Factory.CreateRibbonButton();
            this.GrpConfigACI = this.Factory.CreateRibbonGroup();
            this.BtnCondb = this.Factory.CreateRibbonButton();
            this.BtnInfo = this.Factory.CreateRibbonButton();
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
            resources.ApplyResources(this.TabACI, "TabACI");
            this.TabACI.Name = "TabACI";
            // 
            // GrpReports
            // 
            this.GrpReports.Items.Add(this.BtnAntItem);
            resources.ApplyResources(this.GrpReports, "GrpReports");
            this.GrpReports.Name = "GrpReports";
            // 
            // BtnAntItem
            // 
            this.BtnAntItem.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.BtnAntItem, "BtnAntItem");
            this.BtnAntItem.Image = global::Sage50Excel13Plugin.Properties.Resources.Products;
            this.BtnAntItem.Name = "BtnAntItem";
            this.BtnAntItem.ShowImage = true;
            this.BtnAntItem.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCarteraVencida_Click);
            // 
            // GrpConfigACI
            // 
            this.GrpConfigACI.Items.Add(this.BtnCondb);
            this.GrpConfigACI.Items.Add(this.BtnInfo);
            resources.ApplyResources(this.GrpConfigACI, "GrpConfigACI");
            this.GrpConfigACI.Name = "GrpConfigACI";
            // 
            // BtnCondb
            // 
            this.BtnCondb.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.BtnCondb, "BtnCondb");
            this.BtnCondb.Image = global::Sage50Excel13Plugin.Properties.Resources.Cog;
            this.BtnCondb.Name = "BtnCondb";
            this.BtnCondb.ShowImage = true;
            this.BtnCondb.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnCondb_Click);
            // 
            // BtnInfo
            // 
            this.BtnInfo.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            resources.ApplyResources(this.BtnInfo, "BtnInfo");
            this.BtnInfo.Image = global::Sage50Excel13Plugin.Properties.Resources.Button_White_Info;
            this.BtnInfo.Name = "BtnInfo";
            this.BtnInfo.ShowImage = true;
            this.BtnInfo.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnInfo_Click);
            // 
            // RibAciBI
            // 
            this.Name = "RibAciBI";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabACI);
            resources.ApplyResources(this, "$this");
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
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpReports;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnAntItem;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GrpConfigACI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnCondb;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabACI;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnInfo;
    }

    partial class ThisRibbonCollection
    {
        internal RibAciBI RibAciBI
        {
            get { return this.GetRibbon<RibAciBI>(); }
        }
    }
}
