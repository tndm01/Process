using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ITD.Monitor.Data.cs;

namespace ITD.Monitor.Service
{
    public class StatusService
    {
        StatusData oStatusData = new StatusData();
        public DataTable GetDataTrangThaiThietBi(string MaMT)
        {
            return oStatusData.GetDataTrangThaiThietBi(MaMT);
        }
    }
}
