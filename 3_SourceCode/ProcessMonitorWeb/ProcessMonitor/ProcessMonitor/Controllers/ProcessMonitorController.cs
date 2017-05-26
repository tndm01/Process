using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcessMonitor.Models;
using System.Net;

namespace ProcessMonitor.Controllers
{
    public class ProcessMonitorController : Controller
    {
        ProcessMonitorEntities MonitorEntity;
        // GET: ProcessMonitor
        public ActionResult Index()
       {
            MonitorEntity = new ProcessMonitorEntities();
            List<CUM> ListCum = MonitorEntity.CUMs.Where(e => e.MSTram == "TRAM001").ToList();
            ViewBag.TongSoCum = ListCum.Count;
            foreach (var i in ListCum)
            {
                List<GetThongTinTrangThaiThietBi_Result> ListMay = MonitorEntity.GetThongTinTrangThaiThietBi(i.MSCum).ToList();
                ViewData[i.MSCum] = ListMay;



            }
            return View(ListCum);
        }
        public ActionResult TableReload(string id,string number)
        {
            MonitorEntity = new ProcessMonitorEntities();
            List<GetThongTinTrangThaiThietBi_Result> ListMay = new List<GetThongTinTrangThaiThietBi_Result>();
             ListMay = MonitorEntity.GetThongTinTrangThaiThietBi(id).ToList();
             
             return PartialView("TabTable", ListMay);
        }

        public ActionResult Details(string maMT)
        {
            if (maMT == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorEntity = new ProcessMonitorEntities();
            var timMayTinh = MonitorEntity.MAYTINHs.Where(e => e.MaMT == maMT);
            MAYTINH maytinh = new MAYTINH();
            if (timMayTinh != null && timMayTinh.Count() > 0)
                maytinh = timMayTinh.FirstOrDefault();

            if (maytinh == null)
            {
                return HttpNotFound();
            }
            List<GetThongTinTrangThaiThietBi_Result> ListMay = MonitorEntity.GetThongTinTrangThaiThietBi(maytinh.MSCum).ToList();
            if(ListMay==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData[maMT] = ListMay.Where(u => u.MaMT == maMT).ToList();

            List<GetThongTinLichSuTrangThaiThietBi_Result> ListLichSu = MonitorEntity.GetThongTinLichSuTrangThaiThietBi(maMT).ToList();

            ViewData[maMT + "LichSu"] = ListLichSu;
            ViewData[maMT + "tenCum"] = MonitorEntity.CUMs.Where(u => u.MSCum == maytinh.MSCum).Select(e => e.TenCum).FirstOrDefault();
            return View(maytinh);
            

        }

        public ActionResult Devices(string maTB)
        {
            if (maTB == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonitorEntity = new ProcessMonitorEntities();
            var timThietBi = MonitorEntity.THIETBIs.Where(e => e.MaTB == maTB);           
            THIETBI thietbi = new THIETBI();
            if (timThietBi != null && timThietBi.Count() > 0)
                thietbi = timThietBi.FirstOrDefault();
            var timMayTinh = MonitorEntity.MAYTINHs.Where(e => e.MaMT == thietbi.MaMT).FirstOrDefault();
            if (thietbi == null)
            {
                return HttpNotFound();
            }
            List<GetThongTinTrangThaiChiTietCuaThietBi_Result> result = MonitorEntity.GetThongTinTrangThaiChiTietCuaThietBi(thietbi.MaTB).ToList();

            ViewData[maTB] = result;

            //List<GetThongTinLichSuTrangThaiThietBi_Result> ListLichSu = MonitorEntity.GetThongTinLichSuTrangThaiThietBi(maTB).ToList();

            //ViewData[maTB + "LichSu"] = ListLichSu;
            ViewData[maTB + "tenCum"] = MonitorEntity.CUMs.Where(u => u.MSCum == timMayTinh.MSCum).Select(e => e.TenCum).FirstOrDefault();
            ViewData[maTB + "loaiThietBi"] = MonitorEntity.LOAITHIETBIs.Where(u => u.MaLoaiTB == thietbi.MaLoaiTB).Select(e => e.TenLoaiTB).FirstOrDefault();
            ViewData[maTB + "tenMayTinh"] = MonitorEntity.MAYTINHs.Where(u => u.MaMT == thietbi.MaMT).Select(e => e.TenMT).FirstOrDefault();
            return View(thietbi);

        }
    }
}