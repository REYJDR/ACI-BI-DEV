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
        DbParam param = new DbParam();
 

        public OdbcConnection StartConn()
        {

            OdbcConnection con = new OdbcConnection(param.ConString());

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
