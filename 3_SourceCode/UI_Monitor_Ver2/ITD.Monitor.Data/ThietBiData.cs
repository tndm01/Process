using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Monitor.Data
{
    public class ThietBiData
    {
        public DataTable GetDataThietBi(string MSCum)
        {
            DataTable listDataThietBi = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    //SqlCommand cmd = new SqlCommand("SP_GetDataThietBi", con);
                    SqlCommand cmd = new SqlCommand("SP_GetHeader_VIET", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MSCum", MSCum);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listDataThietBi);
                    return listDataThietBi;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listDataThietBi;
        }
    }
}
