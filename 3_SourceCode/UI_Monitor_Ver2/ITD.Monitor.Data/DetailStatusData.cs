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
    public class DetailStatusData
    {
        public DataTable GetDataChiTietTrangThaiThietBi(string MaMT, DateTime ThoiGian)
        {
            DataTable listDataChiTietTrangThaiThietBi = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
                {
                    //SqlCommand cmd = new SqlCommand("SP_GetDataThietBi", con);
                    SqlCommand cmd = new SqlCommand("SP_GetDataChiTietTrangThaiThietBi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaMT", MaMT);
                    cmd.Parameters.AddWithValue("@ThoiGian", ThoiGian);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(listDataChiTietTrangThaiThietBi);
                    return listDataChiTietTrangThaiThietBi;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return listDataChiTietTrangThaiThietBi;
        }
    }
}
