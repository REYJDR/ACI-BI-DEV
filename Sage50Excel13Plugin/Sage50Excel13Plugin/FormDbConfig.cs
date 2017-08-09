using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sage50Excel13Plugin
{    
    public partial class FormDbConfig : Form
    {


        private DbParam conParams;


        public FormDbConfig()
        {
            InitializeComponent();
            InitValue();
        }


        private void InitValue()
        {
            conParams = new DbParam();
            conParams.GetValueFromFile();

            textHost.Text = conParams.Hostaname;
            textDb.Text   = conParams.Dbname;
            textUser.Text = conParams.User;
            textPass.Text = conParams.Password;


        }

        private void BtnDbSave_Click(object sender, EventArgs e)
        {

            /*INI READ AND SAVE CONNECTION PARAMETERS*/
            conParams.Hostaname = textHost.Text;
            conParams.User = textUser.Text;
            conParams.Password = textPass.Text;
            conParams.Dbname = textDb.Text;
            /*END READ AND SAVE CONNECTION PARAMETERS*/



            //Test BD CONNETION
            DbConnetion dbConn = new DbConnetion();
            try
            {   
                /*Abre conexion para test*/
                dbConn.StartConn();

                /*Save params values */
                conParams.SetValueOnFile();
            }
            catch(Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");

            }
            

        }
    }
}
