using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Monitor.Data;

namespace ITD.Minitor.ViewModel.ViewModel
{
    public class StatusViewModel
    {
        public DataTable GetDataTrangThaiThietBi(string MaMT)
        {
            try
            {
                StatusData oStatusData = new StatusData();
                var model = oStatusData.GetDataTrangThaiThietBi(MaMT);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
