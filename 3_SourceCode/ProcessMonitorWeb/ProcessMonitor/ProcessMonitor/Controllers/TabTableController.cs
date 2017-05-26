using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProcessMonitor.Models;

namespace ProcessMonitor.Controllers
{
    public class TabTableController : Controller
    {
        
        // GET: TabTable
        public ActionResult Index()
        {
            return View();
        }
        public  string TableHeader(List<GetThongTinTrangThaiThietBi_Result> model)
        {
            string htmlstr = "";
            var groupLTB = model.GroupBy(u => new { u.MaHead, u.TenHead,u.uuTien }).Select(grp => new
                 {
                     MaHead = grp.Key.MaHead,
                     TenHead = grp.Key.TenHead,
                     uuTien=grp.Key.uuTien,
                     total = grp.Count()

                 }).OrderBy(t => t.uuTien).ToList();

            if (groupLTB != null)
            {

                foreach (var ltb in groupLTB)
                {
                    htmlstr += "<th>" + @ltb.TenHead + "</th>";
                }

            }
            return htmlstr;
        }
        public string htmlOnclickMT(string s,string cl,string mamt)
        {
            string html = "";
            try
            {
                html= "<td class=\"" + cl + "\" onclick=\"window.open('/ProcessMonitor/Details?maMT="+ mamt+"')\">" + s + "</td>";
            }
            catch
            {

            }
                return html;
        }
        public string htmlOnclickTB(string s,string matb,string noidung,string cl)
        {
            string html = "";
              try
              {
                  html = "<td onclick=\"window.open('/ProcessMonitor/Devices?maTB="+ matb + "')\"><span class=\"" + cl + "\"></span><p hidden>Lỗi</p>" + noidung + "</td>";
           
              }
            catch
              {

              }

             return html;
        }
        public string TableBody(List<GetThongTinTrangThaiThietBi_Result> model)
        {
            string htmlStr = "";
            var groupTenTB = model.GroupBy(u => new { u.MaHead, u.TenHead, u.uuTien }).Select(grp => new
            {
                MaHead = grp.Key.MaHead,
                TenHead = grp.Key.TenHead,
                uuTien = grp.Key.uuTien,
                total = grp.Count()

            }).OrderBy(t => t.uuTien).ToList();
           var groupMayTinh = model.GroupBy(u => u.MaMT).Select(grp => new
            {
                MaMT = grp.Key,

                total = grp.Count()

            }).ToList();
            int stt = 0;
            foreach (var i in groupMayTinh)
            {
                stt++;
                var listTB = model.Where(u => u.MaMT == i.MaMT).OrderBy(t => t.uuTien).ToList();
                htmlStr += "<tr style=\"cursor:pointer\">";
                htmlStr += htmlOnclickMT(stt.ToString(), "", i.MaMT);
                htmlStr += htmlOnclickMT(listTB[0].TenMT, "", i.MaMT);
                htmlStr += htmlOnclickMT(listTB[0].ThoiCapNhat.ToString(), "", i.MaMT);
                if (listTB[0].TrangThai == 1)
                {
                    htmlStr += htmlOnclickMT("Mở", "connecting_device", i.MaMT);
                    foreach (var ttb in groupTenTB)
                    {
                        var tb = listTB.Where(u => u.MaHead == ttb.MaHead).FirstOrDefault();
                        if (tb != null)
                        {


                            switch (tb.MucDo)
                            {
                                case null:
                                    {
                                        htmlStr += "<td><div><span class=\"glyphicon glyphicon-remove\"></span><p hidden>Lỗi</p>N/A</div></td>";
                                        break;
                                    }
                                case 2:
                                    {
                                        htmlStr += htmlOnclickTB(tb.TenTB, tb.MaTB, tb.NoiDungCanhBao, "glyphicon glyphicon-remove");
                                        break;
                                    }
                                case 1:
                                    {
                                        htmlStr += htmlOnclickTB(tb.TenTB, tb.MaTB, tb.NoiDungCanhBao, "glyphicon glyphicon-bell");
                                        break;
                                    }
                                default:
                                    {
                                        htmlStr += htmlOnclickTB(tb.TenTB, tb.MaTB, "Bình thường", "glyphicon glyphicon-ok");
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            htmlStr += "<td>-------</td>";
                        }
                    }
                             
                    }
                
                else
                {
                    htmlStr += htmlOnclickMT("Tắt", "disconnect_device", i.MaMT);
                    foreach (var ltb in groupTenTB)
                    {
                      
                        htmlStr += "<td><span class=\"glyphicon glyphicon-remove\"></span> <span>N/A</span><p hidden>Lỗi</p> </td>";
                        
                    }
                }
                
            }
                    htmlStr += "</tr>";
            
            return htmlStr;
        }
     
    }
}