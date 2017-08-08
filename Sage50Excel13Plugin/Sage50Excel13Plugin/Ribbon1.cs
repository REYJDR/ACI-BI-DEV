using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using System.Data.Odbc;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Sage50Excel13Plugin
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void BtnCarteraVencida_Click(object sender, RibbonControlEventArgs e)
        {
            new Form1().ShowDialog();
        }
    }

 }
 

