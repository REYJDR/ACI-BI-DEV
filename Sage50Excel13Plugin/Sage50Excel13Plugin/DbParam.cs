using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sage50Excel13Plugin
{
    class DbParam
    {

        private string hostaname;
        private string dbname;
        private string user;
        private string password;

        public string Hostaname { get => hostaname; set => hostaname = value; }
        public string Dbname { get => dbname; set => dbname = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }


        public void SetValueOnFile()
        {
            File.WriteAllText("Sage50db.txt", string.Empty);

            TextWriter file = new StreamWriter("Sage50db.txt");

            // write lines of text to the file
            file.WriteLine(Hostaname);
            file.WriteLine(dbname);
            file.WriteLine(User);
            file.WriteLine(Password);

            // close the stream     
            file.Close();

        }

        public void GetValueFromFile()
        {

            // create reader & open file
            TextReader file = new StreamReader("Sage50db.txt");

            Hostaname = file.ReadLine();
            dbname = file.ReadLine();
            User = file.ReadLine();
            Password = file.ReadLine();


            // close the stream
            file.Close();

        }

        public string ConString()
        {
            string strConn;
            string path = Sage50db.txt.Text;

            // create reader & open file
           if (File.Exists("Sage50db.txt"){

                TextReader file = new StreamReader("Sage50db.txt");

                Hostaname = file.ReadLine();
                dbname = file.ReadLine();
                User = file.ReadLine();
                Password = file.ReadLine();

                strConn = "Driver={Pervasive ODBC Client Interface};" +
                                    "servername=" + Hostaname + ";dbq=" + dbname + ";" +
                                    "uid=" + User + ";" +
                                    "pwd=" + Password;

                // close the stream
                file.Close();


            }


            return strConn;
        }




    }
}
