using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Monitor.Data;

namespace ITD.Minitor.ViewModel.ViewModel
{
    public class DetailStatusViewModel
    {
        public DataTable GetDataChiTietTrangThaiThietBi(string MaMT, DateTime ThoiGian)
        {
            try
            {
                DetailStatusData oDetailStatusData = new DetailStatusData();
                var model = oDetailStatusData.GetDataChiTietTrangThaiThietBi(MaMT, ThoiGian);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
