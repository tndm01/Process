using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRandomData
{
   public class DB
    {
        SqlDataAdapter da;//Bo dieu phoi du lieu 
        DataSet ds; //Doi tuong chhua CSDL khi giao tiep 
        SqlConnection conn = new SqlConnection("Data Source=10.0.4.192;Initial Catalog=ProcessMonitor;Persist Security Info=True;User ID=sa; Password=123456");
        //Phuong thuc de thuc hien cau lenh strSQL truy vân du lieu 
       public void InsertData(string ID, string MaTB, string ThoiGian, string MoTa, string TrangThai,string MaTrangThai)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_SYNC_UpdateTRANGTHAITBTable", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@MATB", SqlDbType.VarChar, 10).Value = MaTB;
                cmd.Parameters.Add("@THOIGIAN", SqlDbType.DateTime).Value = ThoiGian;
                cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar, 100).Value = MoTa;
                cmd.Parameters.Add("@TRANGTHAI", SqlDbType.Float).Value = TrangThai;
                cmd.Parameters.Add("@MATRANGTHAI", SqlDbType.VarChar, 10).Value = MaTrangThai;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, conn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        
    }
}
