using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using Excel = Microsoft.Office.Interop.Excel;

namespace Sage50Excel13Plugin
{
    public partial class Form1 : Form
    {
        DbConnetion dbConn = new DbConnetion();

        public Form1()
        {
            InitializeComponent();
            PopulateCboBox();
        }

        public void PopulateCboBox()
        {

            dbConn.StartConn();
            DataTable data = new DataTable();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                string query = "SELECT " +
                               " LineItem.ItemID" +
                               " FROM JrnlHdr " +
                               " INNER JOIN JrnlRow ON JrnlHdr.PostOrder = JrnlRow.PostOrder " +
                               " INNER JOIN LineItem ON LineItem.ItemRecordNumber = JrnlRow.ItemRecordNumber " +
                               " INNER JOIN Customers ON Customers.CustomerRecordNumber = JrnlRow.CustomerRecordNumber " +
                               " WHERE " +
                               " JrnlHdr.JrnlKey_Journal = '3' AND JrnlHdr.MainAmount > ABS(AmountPaid) AND JrnlRow.RowType = '0'"+
                               " Group by ItemID Order by ItemID ASC ";

                dbConn.Query(query).Fill(data);

                CboItemlist.DataSource    = data;
                CboItemlist.ValueMember   = "ItemID";
                CboItemlist.DisplayMember = "ItemID"; 
            }
        }

        private void BtnGetreport_Click(object sender, EventArgs e)
        {
            string itemId = Convert.ToString(CboItemlist.SelectedValue);

            DbConnetion dbConn = new DbConnetion();
            
            Excel._Worksheet objSheet;

            double[]  sumAmount  = new double[6];
            Dictionary<string,double> custAmount = new Dictionary<string,double>();
            string Customers = "";
            string valToCell = "";
            

            try
            {
               
                objSheet = Globals.ThisAddIn.Application.ActiveSheet;
                objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[999, 7]].Clear();
                
                //STAR BD CONNETION
                dbConn.StartConn();

                if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
                {


                    //TABLE STYLING
                    objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, 7]].Merge();
                    objSheet.Cells[1, 1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 7]].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 7]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    objSheet.Range[objSheet.Cells[5, 2], objSheet.Cells[999, 7]].NumberFormat = "#,###.00";

                    //TABLE HEADER
                    objSheet.Cells[1, 1]= "SALDO DE CxC POR ITEM ID";
                    objSheet.Cells[5, 1] = "Customer";
                    objSheet.Cells[5, 2] = "0-30";
                    objSheet.Cells[5, 3] = "31-60";
                    objSheet.Cells[5, 4] = "61-90";
                    objSheet.Cells[5, 5] = "91-120";
                    objSheet.Cells[5, 6] = "120+";
                    objSheet.Cells[5, 7] = "Total";

                    DataTable data = new DataTable();
                    string query = "SELECT " +
                                    " Customers.Customer_Bill_Name, " +
                                    " JrnlHdr.TransactionDate, " +
                                    " sum(ABS(JrnlRow.Amount)) as Amount, " +
                                    " sum(JrnlHdr.AmountPaid) as Paid,  " +
                                    " sum(JrnlHdr.MainAmount) as InvoiceAmount" +
                                    " FROM JrnlHdr " +
                                    " INNER JOIN JrnlRow ON JrnlHdr.PostOrder = JrnlRow.PostOrder " +
                                    " INNER JOIN LineItem ON LineItem.ItemRecordNumber = JrnlRow.ItemRecordNumber " +
                                    " INNER JOIN Customers ON Customers.CustomerRecordNumber = JrnlRow.CustomerRecordNumber " +
                                    " WHERE JrnlHdr.JrnlKey_Journal = '3' " +
                                    " AND JrnlHdr.MainAmount > ABS(AmountPaid) " +
                                    " AND JrnlRow.RowType = '0' " +
                                    " AND LineItem.ItemID = '" + itemId + "' " +
                                    " Group by TransactionDate , Customer_Bill_Name" +
                                    " Order by Customers.Customer_Bill_Name;";
                                    
                                  
                    dbConn.Query(query).Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        int i = 0;
                        
                            while (i < data.Rows.Count) { 




                            string dateTrx = data.Rows[i].ItemArray[1].ToString(); //Transaction Date

                            double days = (DateTime.Today - Convert.ToDateTime(dateTrx)).TotalDays; //Days Expired

                                if (days <= 30)
                                {
                                

                                     valToCell = SumValue((string)(objSheet.Cells[i + 6, 2] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                     objSheet.Cells[i + 6, 2] = valToCell;

                                }
                                if (days > 30 & days <= 60)
                                {
                                    valToCell = SumValue((string)(objSheet.Cells[i + 6, 3] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[i + 6, 3] = valToCell;
                                }
                                if (days > 60 & days <= 90)
                                {
                                    valToCell = SumValue((string)(objSheet.Cells[i + 6, 4] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[i + 6, 4] = valToCell;
                                }
                                if (days > 90 & days <= 120)
                                {
                                    valToCell = SumValue((string)(objSheet.Cells[i + 6, 5] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[i + 6, 5] = valToCell;
                                }

                                if (days > 120) 
                                {
                                    valToCell = SumValue((string)(objSheet.Cells[i + 6, 6] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[i + 6, 6] = valToCell;
                                }

                                objSheet.Cells[i + 6, 7].Formula = "=Sum(B" + (i+6) + ":F" + (i + 6) + ")"; //Total

                            if (data.Rows[i].ItemArray[0] != null)
                            {
                                if (Customers != data.Rows[i].ItemArray[0].ToString())
                                {
                                    objSheet.Cells[i + 6, 1] = data.Rows[i].ItemArray[0].ToString(); //Customers
                                    Customers = data.Rows[i].ItemArray[0].ToString();
                                    i++;

                                }

                            }


                        }
                    }
                   objSheet.Columns.AutoFit();

                }
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }

        }

        public string SumValue(string val1 , string val2)
        {
            string cellValue;
            double sum;

            if (val1 == null) { val1 = "0"; }

            sum =  Convert.ToDouble(val1) + Convert.ToDouble(val2);
            cellValue = Convert.ToString(sum);

        return cellValue;
        }
    }
}
