using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITD.Monitor.Data.cs
{
    public class StatusData
    {
        public DataTable GetDataTrangThaiThietBi(string MaMT)
        {
            DataTable listDataTrangThaiThietBi = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetDataTrangThaiThietBi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaMT", MaMT);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listDataTrangThaiThietBi);
                    return listDataTrangThaiThietBi;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listDataTrangThaiThietBi;
        }
    }
}
