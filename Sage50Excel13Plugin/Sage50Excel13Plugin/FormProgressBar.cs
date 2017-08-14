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
    public partial class FormProgressBar : Form
    {

        FormRepAntItem formRep;

        public FormProgressBar()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormClosed += new FormClosedEventHandler(FormProgressBar_FormClosed);
            
            
        }


        public void SetBarVal(int i,string text)
        {
            progressBar.Value = i;
            lblProgressBar.Text = text;
                        
        }

        void FormProgressBar_FormClosed(object sender, FormClosedEventArgs e)
        {   
            
            try
            {   
                //Form de reportes
                formRep = new FormRepAntItem();

                if (formRep.formWorker.IsBusy)
                {
                    //barckgroundWorker RepAntItem
                    formRep.formWorker.CancelAsync();
                    formRep.formWorker.Dispose();

                }

                

            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message, "Error");
            }
          



        }

    }
}
