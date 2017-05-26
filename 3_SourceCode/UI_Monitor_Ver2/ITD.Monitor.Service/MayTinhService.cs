using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ITD.Monitor.Data.cs;

namespace ITD.Monitor.Service
{
    public class MayTinhService
    {
        MayTinhData oMayTinhData = new MayTinhData();
        public DataTable GetDataMayTinh(string MSCum)
        {
            return oMayTinhData.GetDataMayTinh(MSCum);
        }
    }
}
