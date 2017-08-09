using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;

namespace Sage50Excel13Plugin
{
    public partial class RibAciBI
    {
        private void RibAciBI_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void BtnCarteraVencida_Click(object sender, RibbonControlEventArgs e)
        {
            new FormRepAntItem().ShowDialog();
        }

        private void BtnCondb_Click(object sender, RibbonControlEventArgs e)
        {
            new FormDbConfig().ShowDialog();
        }

        private void BtnInfo_Click(object sender, RibbonControlEventArgs e)
        {
            new FormInformation().ShowDialog();
        }
    }
}
