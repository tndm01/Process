using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ITD.Monitor.Data
{
    public class MayTinhData
    {
        public DataTable GetDataMayTinh(string MSCum)
        {
            DataTable listDataMayTinh = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetDataMayTinh", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MSCum", MSCum);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listDataMayTinh);
                    return listDataMayTinh;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listDataMayTinh;
        }
    }
}