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
    public class ThoiGianData
    {
        public DataTable GetDataThoiGian()
        {
            DataTable listDataThoiGian = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    //SqlCommand cmd = new SqlCommand("SP_GetDataThietBi", con);
                    SqlCommand cmd = new SqlCommand("SP_GetDataThoiGianLichSu", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@MSCum", MSCum);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listDataThoiGian);
                    return listDataThoiGian;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listDataThoiGian;
        }
    }
}
