using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITD.Monitor.Data
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