using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Monitor_Ver2.DBHelper
{
    public class DBConnection
    {
        protected SqlConnection conn = new SqlConnection();
        public DBConnection()
        {
            try
            {

                conn.ConnectionString = @"Data Source=DESKTOP-4LNR8GO\SQLEXPRESS;Initial Catalog=Synchronization_ETC;Integrated Security=True";

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
