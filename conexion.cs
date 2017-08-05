using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SuccessFV2.Model
{
    class conexion
    {

        private static SqlConnection conector;
        string datosConexion = "Data Source = 192.168.47.66;"
            + "Initial Catalog = IZZI_Work; Integrated Security = false; UID = sarh; PWD=4dqu3m;";


        System.Data.DataTable campo;
        System.Data.DataTable area;


        public conexion()
        {
            conector = new SqlConnection();
            Conector.ConnectionString = datosConexion;
            Conector = conector;
        }
        public conexion(SqlConnection conector)
        {
            Conector = conector;
        }

        public SqlConnection Conector
        {
            get
            {
                return conector;
            }

            set
            {
                conector = value;
            }
        }

        

        public string obtenerDivision(string txtUsuario,string txtContrasenia)
        {
            System.Data.DataTable data = new System.Data.DataTable();
            string sql = "select div from SF_Users where usu = '" + txtUsuario + "' and pass = '" + txtContrasenia + "'";
            SqlDataAdapter datos = new SqlDataAdapter(sql, conector);
            datos.Fill(data);
            if(data.Rows.Count == 0)
                {
                string sdiv ="null";
                return sdiv;
            }else {
                string sdiv = data.Rows[0].ItemArray[0].ToString();
                return sdiv;
            }
        }

    }
    
}
