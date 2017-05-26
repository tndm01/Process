using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRandomData
{
   public class Tool
        
    {
        DB db;
        public Tool()
        {
            db = new DB();
        }
        public DataTable LayID()
        {
            string strSQL = "Select ID from TRANGTHAITB";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public DataTable LayMATB()
        {
            string strSQL = "Select MaTB from TRANGTHAITB";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
        public DataTable LayMaTrangThai()
        {
            string strSQL = "Select MaTrangThai from TRANGTHAI";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
    }
}
