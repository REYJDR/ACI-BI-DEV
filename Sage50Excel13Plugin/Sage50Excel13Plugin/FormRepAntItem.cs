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
using Microsoft.Office.Interop.Excel;


namespace Sage50Excel13Plugin
{
    public partial class FormRepAntItem : Form
    {
        DbConnetion dbConn = new DbConnetion();

        public FormRepAntItem()
        {
            InitializeComponent();
            PopulateCboBox();
        }

        public void PopulateCboBox()
        {

            dbConn.StartConn();
            System.Data.DataTable data = new System.Data.DataTable();

            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                string query = "SELECT " +
                               " LineItem.ItemID" +
                               " FROM JrnlHdr " +
                               " INNER JOIN JrnlRow ON JrnlHdr.PostOrder = JrnlRow.PostOrder " +
                               " INNER JOIN LineItem ON LineItem.ItemRecordNumber = JrnlRow.ItemRecordNumber " +
                               " INNER JOIN Customers ON Customers.CustomerRecordNumber = JrnlRow.CustomerRecordNumber " +
                               " WHERE " +
                               " JrnlHdr.JrnlKey_Journal = '3' AND JrnlHdr.MainAmount > ABS(AmountPaid) AND JrnlRow.RowType = '0'" +
                               " Group by ItemID Order by ItemID ASC ";

                dbConn.Query(query).Fill(data);

                CboItemlist.DataSource = data;
                CboItemlist.ValueMember = "ItemID";
                CboItemlist.DisplayMember = "ItemID";
            }
        }


        public string SumValue(object val1, string val2)
        {
            string cellValue;
            double sum;


            if (val1 == null) { val1 = 0; }

            sum = Convert.ToDouble(val1) + Convert.ToDouble(val2);
            cellValue = Convert.ToString(sum);

            return cellValue;
        }

        private void BtnGetreport_Click_1(object sender, EventArgs e)
        {


            DbConnetion dbConn = new DbConnetion();

            Excel._Worksheet objSheet;

            Dictionary<string, double> custAmount = new Dictionary<string, double>();
            string Customers = "";
            string valToCell = "";
            double[] sumAmount = new double[6];
            string itemId = Convert.ToString(CboItemlist.SelectedValue);
            string itemFilter = "";

            //ALL CHECKED
            if (!checkTodos.Checked)
            {
                itemFilter = " AND LineItem.ItemID = '" + itemId + "' ";
            }

            try
            {

                objSheet = Globals.ThisAddIn.Application.ActiveSheet;
                objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[999, 8]].Clear();

                //STAR BD CONNETION
                dbConn.StartConn();

                if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
                {


                    //INI TABLE STYLING
                        //HEADER COLOR
                        objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 8]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                    //MERGED CELLS
                    objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, 7]].Merge();
                    
                        //TEXT ALIGN
                        objSheet.Cells[1, 1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 2]].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        objSheet.Range[objSheet.Cells[5, 3], objSheet.Cells[5, 8]].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                        //BORDER
                        objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 8]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                        //CURRENCY CELLS
                        objSheet.Range[objSheet.Cells[5, 3], objSheet.Cells[999, 8]].NumberFormat = "#,###.00";
                    //END TABLE STYLING

                    //TABLE HEADER
                    objSheet.Cells[1, 1] = "SALDO DE CxC POR ITEM ID";
                    objSheet.Cells[5, 1] = "Customer";
                    objSheet.Cells[5, 2] = "Invoice #";
                    objSheet.Cells[5, 3] = "0-30";
                    objSheet.Cells[5, 4] = "31-60";
                    objSheet.Cells[5, 5] = "61-90";
                    objSheet.Cells[5, 6] = "91-120";
                    objSheet.Cells[5, 7] = "120+";
                    objSheet.Cells[5, 8] = "Total";

                    System.Data.DataTable data = new System.Data.DataTable();
                    string query = "SELECT " +
                                    " Customers.Customer_Bill_Name, " +
                                    " JrnlHdr.Reference, " +
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
                                    itemFilter +
                                    " Group by TransactionDate , Customer_Bill_Name, Reference" +
                                    " Order by Customers.Customer_Bill_Name;";


                    dbConn.Query(query).Fill(data);

                    if (data.Rows.Count > 0)
                    {
                        int i = 0;
                        int n = i;


                        while (i < data.Rows.Count)
                        {


                            if (data.Rows[i].ItemArray[0] != null)
                            {
                                string dateTrx = data.Rows[i].ItemArray[1].ToString(); //Transaction Date

                                double days = (DateTime.Today - Convert.ToDateTime(dateTrx)).TotalDays; //Days Expired



                                if (Customers != data.Rows[i].ItemArray[0].ToString())
                                {
                                    objSheet.Cells[i + 6, 1] = data.Rows[i].ItemArray[0].ToString(); //Customers
                                    objSheet.Cells[i + 6, 2] = data.Rows[i].ItemArray[1].ToString(); //Invoice Number
                                    Customers = data.Rows[i].ItemArray[0].ToString();

                                    n = i;
                                }
                                else
                                {
                                    n = n;
                                }

                                if (days <= 30)
                                {

                                    valToCell = SumValue((objSheet.Cells[n + 6, 3] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[n + 6, 3] = valToCell;

                                }
                                if (days > 30 & days <= 60)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 4] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[n + 6, 4] = valToCell;
                                }
                                if (days > 60 & days <= 90)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 5] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[n + 6, 5] = valToCell;
                                }
                                if (days > 90 & days <= 120)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 6] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[n + 6, 6] = valToCell;
                                }

                                if (days > 120)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 7] as Excel.Range).Value, data.Rows[i].ItemArray[2].ToString());

                                    objSheet.Cells[n + 6, 7] = valToCell;
                                }


                                objSheet.Cells[n + 6, 8].Formula = "=Sum(B" + (n + 7) + ":F" + (n + 7) + ")"; //Total


                                i++;



                            }


                        }
                    }

                    //elimina lineas en blanco
                    Excel.Range range = objSheet.UsedRange;
                    int rowcount = range.Rows.Count;
                    for (int l = 6; l < rowcount; l++)
                    {
                        Excel.Range rg = objSheet.get_Range("A" + l.ToString());
                        if (Convert.ToString(rg.Value2) == null)
                        {
                            ((Excel.Range)objSheet.Range["A" + l.ToString(), "F" + l.ToString()]).EntireRow.Delete(null);
                            l--;
                            rowcount--;
                        }
                    }

                    //ACOMODA LAS CELDAS
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



        private void checkTodos_CheckedChanged(object sender, EventArgs e)
        {

            if (checkTodos.Checked)
            {
                CboItemlist.Hide();

            }
            else
            {
                CboItemlist.Show();

            }


        }
    }
}
