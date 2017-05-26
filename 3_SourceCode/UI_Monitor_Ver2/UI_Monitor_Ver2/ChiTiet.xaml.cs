using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ITD.Minitor.ViewModel.Object;
using ITD.Minitor.ViewModel.ViewModel;
using ITD.Minitor.ViewModel.ViewTemplate;
using ITD.Monitor.Common;

namespace UI_Monitor_Ver2
{
    /// <summary>
    /// Interaction logic for ChiTiet.xaml
    /// </summary>
    public partial class ChiTiet : Window
    {
        private DataTable listMayTinh = new DataTable();
        private DataTable listThietBi = new DataTable();
        private DataTable listDetailStatus = new DataTable();
        private DataTable listThoiGian = new DataTable();
        private MayTinhViewModel oMayTinhViewModel = new MayTinhViewModel();
        private ThietBiViewModel oThietBiViewModel = new ThietBiViewModel();
        private ThoiGianViewModel oThoiGianViewModel = new ThoiGianViewModel();
        private DetailStatusViewModel oDetailStatusViewModel = new DetailStatusViewModel();

        private Computer source;

        public Computer Source
        {
            get { return source; }
            set { source = value; }
        }

        public ChiTiet()
        {
            this.InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Content = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            }, this.Dispatcher);
            // Insert code required on object creation below this point.
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitleTenMayTinh.Content = "Máy tính " + source.MaMT;
            lblTenMayTinh.Content = source.MaMT;
            lblIP.Content = source.IP;
            lblCum.Content = source.Cum;
            lblTram.Content = source.Tram;
            lblLanCapNhatCuoi.Content = source.ThoiGian;
            lblTrangThai.Content = source.TrangThai;
            setHeader();
            lvVDS1.Items.Clear();
            lvVDS1.Items.Add(source);
            DetailView(loadKimJongViet());
        }

        private void setHeader()
        {
            var cellTemplate_Computer = Application.Current.FindResource("cellTemplate_Computer") as DataTemplate;
            gridViewHienTaiControl.Columns.Add(
               new GridViewColumn
               {
                   HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Mã máy tính"),
                   CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("MaMT"),
               });
            gridViewHienTaiControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("IP"),
                    CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("IP"),
                });
            gridViewHienTaiControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Thời gian"),
                    CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("ThoiGian"),
                });
            gridViewHienTaiControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Trạng thái"),
                    CellTemplate = cellTemplate_Computer,
                });

            listThietBi = oThietBiViewModel.GetDataThietBi(source.Cum);
            for (int i = 0; i < listThietBi.Rows.Count; i++)
            {
                gridViewHienTaiControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader(listThietBi.Rows[i]["TenHead"].ToString()),
                    CellTemplate = ViewTemplateColunm.getDataTemplate(i),
                    Width = 130
                });
            }

            gridViewLichSuControl.Columns.Add(new GridViewColumn { HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Thời gian"), CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("ThoiGian"), });
            for (int i = 0; i < listThietBi.Rows.Count; i++)
            {
                gridViewLichSuControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader(listThietBi.Rows[i]["TenHead"].ToString()),
                    CellTemplate = ViewTemplateColunm.getDataTemplate(i),
                    Width = 130
                });
            }
        }

        private List<Computer> loadKimJongViet()
        {
            List<Computer> oComputers = new List<Computer>();
            listMayTinh = oMayTinhViewModel.GetDataMayTinh(source.Cum);
            listThoiGian = oThoiGianViewModel.GetDataThoiGian();
            for (int t = 0; t < listThoiGian.Rows.Count; t++)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                Computer oComputer = new Computer();

                string dateString = listThoiGian.Rows[t]["ThoiGian"].ToString();
                var dt = DateTime.ParseExact(dateString, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                DateTime thoigian = DateTime.Parse("2017-04-23 00:00:00.000");
                listDetailStatus = oDetailStatusViewModel.GetDataChiTietTrangThaiThietBi(source.MaMT, dt);
                oComputer.ThoiGian = listThoiGian.Rows[t]["ThoiGian"].ToString();
                oComputer.ThietBi = new List<string>(listThietBi.Rows.Count);
                oComputer.MucDoThietBi = new List<string>(listThietBi.Rows.Count);
                foreach (DataRow r2 in listThietBi.Rows)
                {
                    bool isnull = true;
                    foreach (DataRow r1 in listDetailStatus.Rows)
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
                oComputers.Add(oComputer);
            }
            return oComputers;
        }

        private void DetailView(List<Computer> oComputers)
        {
            lvVDS2.Items.Clear();
            foreach (var item in oComputers)
            {
                lvVDS2.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string keyword = StringHelper.ChangeWords(SearchTermTextBox.Text);
            List<Computer> listSearch = loadKimJongViet();
            var search = from a in listSearch
                         where a.ThietBi.Any(x => x.StartsWith(keyword))
                         select a;
            lvVDS2.Items.Clear();
            foreach (var item in search)
            {
                lvVDS2.Items.Add(item);
            }
        }
    }
}