using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sage50Excel13Plugin
{
    class ProgressBar
    {
        FormProgressBar proForm = new FormProgressBar();


        public void ProgressBarVal(int i,string text)
        {
            proForm.Show();
            proForm.SetBarVal(i,text+" %");
        }

        public void FinishProcess()
        {
            
            proForm.Hide();
        }



    }
}
