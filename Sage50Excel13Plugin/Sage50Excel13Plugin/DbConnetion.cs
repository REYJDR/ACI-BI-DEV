using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;


namespace Sage50Excel13Plugin
{

    
    class DbConnetion
    {


        public string strConn = "Driver={Pervasive ODBC Client Interface};"+
                                "servername=localhost;dbq=HiedraYBambuSA;" +
                                "uid=Peachtree;"+
                                "pwd=admin123";

        public OdbcConnection StartConn()
        {

            OdbcConnection con = new OdbcConnection(strConn);

            con.Open();

            return con;
        }

        public OdbcDataAdapter Query(string query)
        {
            OdbcDataAdapter datos = new OdbcDataAdapter(query, StartConn());
 
            return datos;
        }

    }
}
