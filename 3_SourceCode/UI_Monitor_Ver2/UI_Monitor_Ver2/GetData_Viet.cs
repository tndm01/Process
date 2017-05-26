using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_Monitor_Ver2
{
    public class GetData_Viet
    {
        public static DataTable GetDataTrangThaiThietBi()
        {
            DataTable listTRANGTHAITB = new DataTable("ProcessMonitor");
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetData_Viet", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@MaMT", MaMT);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listTRANGTHAITB);
                    return listTRANGTHAITB;
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return listTRANGTHAITB;
        }
    }
}
