using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ITD.Monitor.Data.cs;

namespace ITD.Monitor.Service
{
    public class ThietBiService
    {
        ThietBiData oThietBiData = new ThietBiData();
        public DataTable GetDataThietBi(string MSCum)
        {
            return oThietBiData.GetDataThietBi(MSCum);
        }
    }
}
