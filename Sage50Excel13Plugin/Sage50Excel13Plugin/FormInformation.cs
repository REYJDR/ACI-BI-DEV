using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sage50Excel13Plugin
{
    public partial class FormInformation : Form
    {
        public FormInformation()
        {
            InitializeComponent();
            InitInfoText();
        }

        public void InitInfoText()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();

            lblTitle.Text =  ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute), false)).Title;
            lblDescription.Text = ((AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute), false)).Description;
            lblCompany.Text = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute( assembly, typeof(AssemblyCompanyAttribute), false)).Company;
            lblProduct.Text = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute), false)).Product;
            lblCopyRight.Text = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute), false)).Copyright;
            lblVersion.Text = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
   
        }


    }
}
