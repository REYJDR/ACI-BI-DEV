using Microsoft.Office.Interop.Excel;
using SuccessFV2.Vistas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//
using Excel = Microsoft.Office.Interop.Excel;
namespace SuccessFV2.Controlador
{ 
    class ReporteEmpleados
    {
        
        


        public void procesar(SqlConnection conetos,string Sdiv)
        {

            Excel.Application ap = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
            Workbook wrk = ap.ActiveWorkbook;
            Worksheet wrksh = wrk.Sheets[1];

            System.Data.DataTable data = new System.Data.DataTable();
            string sql = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'SF_EmpIteracion3'";
            SqlDataAdapter datos = new SqlDataAdapter(sql, conetos);
            datos.Fill(data);

           

            if (data.Rows.Count > 0)
            {
               
                for (int i = 0; i < data.Rows.Count; i++)
                {
                
                        wrksh.Cells[1, i + 1] = data.Rows[i].ItemArray[0].ToString();
                  
                    
                }
                wrksh.Range["A1"].EntireRow.Font.Bold = true;
                wrksh.Range["A1"].EntireRow.Activate();
            }


            System.Data.DataTable data2 = new System.Data.DataTable();
            //string sql2 = "select * from SF_EmpIteracion3 where [SUBDIVISION] = '" + Sdiv + "'";
            string sql2 = "select * from SF_EmpIteracion3";
            SqlDataAdapter datos2 = new SqlDataAdapter(sql2, conetos);
            datos2.Fill(data2);

            int conta2 = data.Rows.Count * data2.Rows.Count;
            BarraProgreso barraProgreso = new BarraProgreso();
            barraProgreso.lblTexto.Text = "Actualizando Catálogos....";
            barraProgreso.prbBarraProgreso.Maximum = conta2;
            barraProgreso.Show();

            if (data2.Rows.Count > 0)
            {
                int conta = 0;
                for (int j = 0; j < data.Rows.Count; j++)
                {
                    for (int i = 0; i < data2.Rows.Count; i++)
                    {
                        if (data2.Rows[i].ItemArray[j] != null)
                        {
                            wrksh.Cells[i + 2, j + 1] = data2.Rows[i].ItemArray[j].ToString();
                        }
                        barraProgreso.prbBarraProgreso.Increment(1);
                    }
                    conta = conta + data2.Rows.Count;
                    barraProgreso.lblTexto.Text = "Descargando reporte de empleados" + conta.ToString() + " de " + conta2.ToString() + "...";
                    barraProgreso.Refresh();
                }
                barraProgreso.Visible = false;
            }
            wrksh.Columns.AutoFit();
        }

        internal void procesar(object conector, object sdiv)
        {
            throw new NotImplementedException();
        }
    }
}
