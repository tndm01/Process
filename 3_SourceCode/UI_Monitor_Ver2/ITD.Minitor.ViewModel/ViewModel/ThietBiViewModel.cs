using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Monitor.Data;

namespace ITD.Minitor.ViewModel.ViewModel
{
    public class ThietBiViewModel
    {
        public DataTable GetDataThietBi(string MSCum)
        {
            try
            {
                ThietBiData oThietBiData = new ThietBiData();
                var model = oThietBiData.GetDataThietBi(MSCum);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
