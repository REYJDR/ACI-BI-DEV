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
using System.Threading;
using System.Globalization;

namespace Sage50Excel13Plugin
{
    public partial class FormRepAntItem : Form
    {
   
       private DbConnetion dbConn = new DbConnetion();
       private int percentage;
       BackgroundWorker bgw  ;
       ProgressBar proBar = new ProgressBar();

        public FormRepAntItem()
        {

            
            InitializeComponent();
            InitBwWorker();
            PopulateCboBox();
        }


        public void PopulateCboBox()
        {
            System.Data.DataTable data = new System.Data.DataTable();

            dbConn.StartConn();
 
            if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
            {

                string query = "SELECT " +
                               " ItemID" +
                               " FROM LineItem " +
                               " Group by ItemID " +
                               " Order by ItemID ASC ";

            
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
            
            this.Hide();

            if (bgw.IsBusy != true)
            {
                bgw.RunWorkerAsync();
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

        //BACKGROUNDWORKER
            public void InitBwWorker()
            {
                bgw = new BackgroundWorker();
                bgw.WorkerSupportsCancellation = true;
                bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
                bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
                bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
                bgw.WorkerReportsProgress = true;
               

            }

            public BackgroundWorker formWorker
            {
                get
                {
                    return bgw;
                }
            }


            private void bgw_DoWork(object sender, DoWorkEventArgs e)
            {

            BackgroundWorker bgw = sender as BackgroundWorker;

            CheckForIllegalCrossThreadCalls = false;

                    //Proceso principal
                    if(!bgw.CancellationPending){

                        ExtractData();
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                   
            }


            void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                
                proBar.ProgressBarVal(e.ProgressPercentage,e.UserState.ToString());
            }

            void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Error == null)
                {
                   
                    proBar.FinishProcess();
                    this.Close();
                }
                else
                {
                   MessageBox.Show(e.Error.ToString(), "Error");
                    this.Close();
                 }

            }
        //BACKGROUNDWORKER


        private void  ExtractData()
        {   
            
            System.Data.DataTable data = new System.Data.DataTable();

            Excel._Worksheet objSheet;
            objSheet = Globals.ThisAddIn.Application.ActiveSheet;

            string invoice = "";
            string valToCell = "";
            string itemFilter = "";
            string selection = "";
            string itemId = Convert.ToString(CboItemlist.SelectedValue);

            //ALL CHECKED
            if (!checkTodos.Checked)
            {
                itemFilter = " AND LineItem.ItemID = '" + itemId + "' ";
                selection = itemId;
                objSheet.Name = "SALDO DE CxC " + selection;
            }
            else
            {
                selection = "TODOS";
                objSheet.Name = "SALDO DE CxC " + selection;
            }

            
            

            try
            {
                               

                //Report to BackgroundWorker
                percentage = 10 * 100 / 100;
                bgw.ReportProgress(percentage, 10);
                
                //STAR BD CONNETION
                dbConn.StartConn();

                if (dbConn.StartConn().State == System.Data.ConnectionState.Open)
                {
                    
                    data.Clear();

                    string query = "SELECT DISTINCT " +
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


                    //Report to BackgroundWorker
                    percentage = 20 * 100 / 100;
                    bgw.ReportProgress(percentage, 20);

                    //Start query to DB
                    objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[9999, 10]].Clear();

                    dbConn.Query(query).Fill(data);


                    //Report to BackgroundWorker
                    percentage = 100 * 100 / 100;
                    bgw.ReportProgress(percentage, 100);


                    if (data.Rows.Count > 0)
                    {
                        int i = 0;
                        int n = i;

                        //INI TABLE STYLING

                            //COLOR
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[data.Rows.Count+5, 10]].Interior.Color = ColorTranslator.ToOle(Color.White);
                            objSheet.Range[objSheet.Cells[6, 4], objSheet.Cells[data.Rows.Count + 5, 10]].Interior.Color = ColorTranslator.ToOle(Color.WhiteSmoke);
                            objSheet.Range[objSheet.Cells[6, 1], objSheet.Cells[data.Rows.Count + 5, 4]].Interior.Color = ColorTranslator.ToOle(Color.LemonChiffon);
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, 10]].Interior.Color = ColorTranslator.ToOle(Color.DarkSeaGreen);
                            objSheet.Cells[3, 1].Interior.Color = ColorTranslator.ToOle(Color.DarkSeaGreen);
                            objSheet.Cells[3, 2].Interior.Color = ColorTranslator.ToOle(Color.WhiteSmoke);
                            objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 10]].Interior.Color = ColorTranslator.ToOle(Color.DarkSeaGreen);

                            //FONT BOLD
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, 10]].EntireRow.Font.Bold = true;
                            objSheet.Cells[3, 1].EntireRow.Font.Bold = true;
                            objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 10]].EntireRow.Font.Bold = true;

                            //MERGED CELLS
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[1, 10]].Merge();

                            //TEXT ALIGN
                            objSheet.get_Range("A1", "A1").Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        
                            //BORDER
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[data.Rows.Count + 5, 10]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[data.Rows.Count + 5, 10]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                            objSheet.Range[objSheet.Cells[1, 1], objSheet.Cells[data.Rows.Count + 5, 10]].Borders.Color = ColorTranslator.ToOle(Color.White);

                            //CURRENCY CELLS
                            objSheet.Range[objSheet.Cells[5, 4], objSheet.Cells[data.Rows.Count+5, 10]].NumberFormat = "#,###.00";

                            //FILTER
                            objSheet.Range[objSheet.Cells[5, 1], objSheet.Cells[5, 10]].Autofilter();

                        //END TABLE STYLING


                        //TABLE HEADER
                        objSheet.Cells[1, 1] = "SALDO DE CxC POR ITEM ID";
                        objSheet.Cells[3, 1] = "Selección";
                        objSheet.Cells[3, 2] = selection;
                        objSheet.Cells[5, 1] = "Customer";
                        objSheet.Cells[5, 2] = "Invoice #";
                        objSheet.Cells[5, 3] = "Date";
                        objSheet.Cells[5, 4] = "Status";
                        objSheet.Cells[5, 5] = "0-30";
                        objSheet.Cells[5, 6] = "31-60";
                        objSheet.Cells[5, 7] = "61-90";
                        objSheet.Cells[5, 8] = "91-120";
                        objSheet.Cells[5, 9] = "120+";
                        objSheet.Cells[5, 10] = "Total";

                        //WORKSHEET NAME 
                        objSheet.Name = "SALDO DE CxC " + selection;

                        while (i < data.Rows.Count)
                        {


                            if (data.Rows[i].ItemArray[0] != null)
                            {
                                string dateTrx = data.Rows[i].ItemArray[2].ToString(); //Transaction Date

                                 

                                double days = (DateTime.Today - Convert.ToDateTime(dateTrx)).TotalDays; //Days Expired


                                if (invoice != data.Rows[i].ItemArray[0].ToString())
                                {


                                    objSheet.Cells[i + 6, 2] = data.Rows[i].ItemArray[1].ToString(); //Invoice Number
                                    invoice = data.Rows[i].ItemArray[1].ToString();

                                    n = i;
                                }

                                objSheet.Cells[n + 6, 1] = data.Rows[i].ItemArray[0].ToString(); //Customers
                                objSheet.Cells[n + 6, 3] = Convert.ToDateTime(dateTrx).ToString("yyyy-MM-dd");//Transaction Date


                                //Report to BackgroundWorker
                                percentage = i * 100 / data.Rows.Count;
                                bgw.ReportProgress(percentage, i);



                                if (Convert.ToDouble(data.Rows[i].ItemArray[4]) == 0.00)
                                {

                                    objSheet.Cells[n + 6, 4] = "Pendiente de pago"; //Status
                                    objSheet.Cells[n + 6, 4].Interior.Color = ColorTranslator.ToOle(Color.LightSalmon);

                                }
                                else
                                {
                                    objSheet.Cells[n + 6, 4] = "Parcialmente pagado"; //Status
                                    objSheet.Cells[n + 6, 4].Interior.Color = ColorTranslator.ToOle(Color.LightGreen);

                                }




                                //EXPIRE DAY
                                if (days <= 30)
                                {

                                    valToCell = SumValue((objSheet.Cells[n + 6, 5] as Excel.Range).Value, data.Rows[i].ItemArray[3].ToString());

                                    objSheet.Cells[n + 6, 5] = valToCell;

                                }
                                if (days > 30 & days <= 60)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 6] as Excel.Range).Value, data.Rows[i].ItemArray[3].ToString());

                                    objSheet.Cells[n + 6, 6] = valToCell;
                                }
                                if (days > 60 & days <= 90)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 7] as Excel.Range).Value, data.Rows[i].ItemArray[3].ToString());

                                    objSheet.Cells[n + 6, 7] = valToCell;
                                }
                                if (days > 90 & days <= 120)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 8] as Excel.Range).Value, data.Rows[i].ItemArray[3].ToString());

                                    objSheet.Cells[n + 6, 8] = valToCell;
                                }

                                if (days > 120)
                                {
                                    valToCell = SumValue((objSheet.Cells[n + 6, 9] as Excel.Range).Value, data.Rows[i].ItemArray[3].ToString());

                                    objSheet.Cells[n + 6, 9] = valToCell;
                                }


                                objSheet.Cells[n + 6, 10].Formula = "=Sum(E" + (n + 6) + ":I" + (n + 6) + ")"; //Total


                                i++;



                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("No existen datos que procesar para esta seleccion");
                    }

                    //elimina lineas en blanco
                    Excel.Range range = objSheet.UsedRange;
                    int rowcount = range.Rows.Count;
                    for (int l = 6; l < rowcount; l++)
                    {
                        Excel.Range rg = objSheet.get_Range("A" + l.ToString());
                        if (Convert.ToString(rg.Value2) == null)
                        {
                            ((Excel.Range)objSheet.Range["A" + l.ToString(), "Z" + l.ToString()]).EntireRow.Delete(null);
                            l--;
                            rowcount--;
                        }
                    }



                    //ACOMODA LAS CELDAS
                    objSheet.Columns.AutoFit();

                    //Close ProgresssBar
                    proBar.FinishProcess();

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


    }
}
