using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITD.Minitor.ViewModel.Object;
using ITD.Monitor.Data;

namespace ITD.Minitor.ViewModel.ViewModel
{
    public class MayTinhViewModel
    {
        private DataTable listMayTinh = new DataTable();
        private DataTable listThietBi = new DataTable();
        private DataTable listStatus = new DataTable();

        private StatusViewModel oStatusViewModel = new StatusViewModel();
        private ThietBiViewModel oThietBiViewModel = new ThietBiViewModel();

        public DataTable GetDataMayTinh(string MSCum)
        {
            try
            {
                MayTinhData oMayTinhData = new MayTinhData();
                var model = oMayTinhData.GetDataMayTinh(MSCum);
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Computer> loadDataStatus(string tabName)
        {
            List<Computer> oComputers = new List<Computer>();
            listThietBi = oThietBiViewModel.GetDataThietBi(tabName);
            //lấy danh sách máy tính có trong cụm
            listMayTinh = GetDataMayTinh(tabName);
            for (int i = 0; i < listMayTinh.Rows.Count; i++)
            {
                string MaMT = listMayTinh.Rows[i]["MaMT"].ToString().Trim();
                //Tạo đối tượng computer
                Computer oComputer = new Computer();
                //lấy list status theo mã máy tính
                listStatus = oStatusViewModel.GetDataTrangThaiThietBi(MaMT);
                if (listStatus.Rows.Count == 0)
                {
                    oComputer.MaMT = MaMT;
                    //xác định trạng thái máy tính khi không có dữ liệu thiết bị
                    if (int.Parse(listMayTinh.Rows[i]["TrangThai"].ToString().Trim()) == 1)
                    {
                        oComputer.TrangThai = "MỞ";
                    }
                    else
                    {
                        oComputer.TrangThai = "TẮT";
                    }
                    oComputer.IP = listMayTinh.Rows[i]["IP"].ToString();
                    oComputer.ThoiGian = listMayTinh.Rows[i]["ThoiCapNhat"].ToString();
                    oComputer.ThietBi = new List<string>(listThietBi.Rows.Count);
                    foreach (var item in listThietBi.Rows)
                    {
                        oComputer.ThietBi.Add("--");
                    }
                }
                else
                {
                    if (int.Parse(listMayTinh.Rows[i]["TrangThai"].ToString().Trim()) == 1)
                    {
                        //lấy danh sách trạng thái thiết bị
                        listStatus = oStatusViewModel.GetDataTrangThaiThietBi(MaMT);
                        oComputer.MaMT = listStatus.Rows[0]["MaMT"].ToString().Trim();
                        oComputer.IP = listStatus.Rows[0]["IP"].ToString();
                        oComputer.ThoiGian = listStatus.Rows[0]["ThoiGian"].ToString();
                        oComputer.TrangThai = "MỞ";
                        //add danh sách thiết bị
                        oComputer.ThietBi = new List<string>(listThietBi.Rows.Count);
                        oComputer.MucDoThietBi = new List<string>(listThietBi.Rows.Count);
                        foreach (DataRow r2 in listThietBi.Rows)
                        {
                            bool isnull = true;
                            foreach (DataRow r1 in listStatus.Rows)
                            {
                                if (r1["MaHead"].ToString() == r2["MaHead"].ToString())
                                {
                                    oComputer.ThietBi.Add(r1["NoiDungCanhBao"].ToString());
                                    oComputer.MucDoThietBi.Add(r1["MucDo"].ToString());
                                    isnull = false;
                                }
                            }
                            if (isnull)
                            {
                                oComputer.ThietBi.Add("--");
                                oComputer.MucDoThietBi.Add("-1");
                            }
                        }
                    }
                    else
                    {
                        oComputer.MaMT = MaMT;
                        oComputer.IP = listStatus.Rows[0]["IP"].ToString();
                        oComputer.ThoiGian = listStatus.Rows[0]["ThoiGian"].ToString();
                        oComputer.TrangThai = "TẮT";
                    }
                }
                //add vô danh sách các computer
                oComputers.Add(oComputer);
            }
            return oComputers;
        }
    }
}
