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

            /*Save params values */
            conParams.SetValueOnFile();


            //Test BD CONNETION
            DbConnetion dbConn = new DbConnetion();

            /*Abre conexion para test*/
            dbConn.StartConn();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
                {


                    MessageBox.Show("Test de conexión exitoso", "Test de conexión");
                }
            

        }
    }
}
