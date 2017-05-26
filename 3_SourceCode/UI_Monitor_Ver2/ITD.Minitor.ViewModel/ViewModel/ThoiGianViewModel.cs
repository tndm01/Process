using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Monitor.Data;

namespace ITD.Minitor.ViewModel.ViewModel
{
    public class ThoiGianViewModel
    {
        public DataTable GetDataThoiGian()
        {
            try
            {
                ThoiGianData oThoiGianData = new ThoiGianData();
                var model = oThoiGianData.GetDataThoiGian();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
