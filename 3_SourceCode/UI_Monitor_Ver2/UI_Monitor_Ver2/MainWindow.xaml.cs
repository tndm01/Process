using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using ITD.Minitor.ViewModel.Object;
using ITD.Minitor.ViewModel.ViewModel;
using ITD.Minitor.ViewModel.ViewTemplate;
using ITD.Monitor.Common;
using ITD.Monitor.Common.NLogHelper;
using UI_Monitor_Ver2.View;

namespace UI_Monitor_Ver2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string tabName = "CUM001";
        private DataTable listThietBi = new DataTable();
        private ThietBiViewModel oThietBiViewModel = new ThietBiViewModel();
        private MayTinhViewModel oMayTinhViewModel = new MayTinhViewModel();
        private ViewTemplateColunm vtp = new ViewTemplateColunm();

        public MainWindow()
        {
            InitializeComponent();
            vtp.StatisticView(oMayTinhViewModel.loadDataStatus("CUM001"), lblLanALL, lblLanON, lblLanOFF);
            vtp.StatisticView(oMayTinhViewModel.loadDataStatus("CUM002"), lblHkALL, lblHkON, lblHkOFF);
            vtp.StatisticView(oMayTinhViewModel.loadDataStatus("CUM003"), lblNdALL, lblNdON, lblNdOFF);
            setHeadre();
            this.btnMayLan.Focus();
            DetailView(oMayTinhViewModel.loadDataStatus(tabName));
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.dateText.Content = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            }, this.Dispatcher);
        }

        private void setHeadre()
        {
            var cellTemplate_Computer = Application.Current.FindResource("cellTemplate_Computer") as DataTemplate;

            gridViewControl.Columns.Clear();
            //Bind header cứng
            gridViewControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Mã máy tính"),
                    CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("MaMT"),
                });
            gridViewControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("IP"),
                    CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("IP"),
                });
            gridViewControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Thời gian"),
                    CellTemplate = ViewTemplateColunm.getDataTemplate_FistColumn("ThoiGian"),
                });
            gridViewControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader("Trạng thái"),
                    CellTemplate = cellTemplate_Computer,
                });
            //bind header động có trong cụm
            listThietBi = oThietBiViewModel.GetDataThietBi(tabName);
            for (int i = 0; i < listThietBi.Rows.Count; i++)
            {
                gridViewControl.Columns.Add(
                new GridViewColumn
                {
                    HeaderTemplate = ViewTemplateColunm.getDataTemplate_ColumnHeader(listThietBi.Rows[i]["TenHead"].ToString()),
                    CellTemplate = ViewTemplateColunm.getDataTemplate(i),
                    Width = 130
                });
            }
        }

        private void DetailView(List<Computer> oComputers)
        {
            lvVDS.Items.Clear();
            foreach (var item in oComputers)
            {
                lvVDS.Items.Add(item);
            }
        }

        private void btnHauKiem_Click(object sender, RoutedEventArgs e)
        {
            tabName = "CUM002";
            DetailView(oMayTinhViewModel.loadDataStatus(tabName));
            txtThongtinTab.Content = "Thông tin trạng thái các thiết bị máy hậu kiểm";
        }

        private void btnNhanDang_Click(object sender, RoutedEventArgs e)
        {
            tabName = "CUM003";
            DetailView(oMayTinhViewModel.loadDataStatus(tabName));
            txtThongtinTab.Content = "Thông tin trạng thái các thiết bị máy nhận dạng";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfigView cib = new ConfigView();
            cib.ShowDialog();
        }

        private void btnMayLan_Click(object sender, RoutedEventArgs e)
        {
            tabName = "CUM001";
            DetailView(oMayTinhViewModel.loadDataStatus(tabName));
            txtThongtinTab.Content = "Thông tin trạng thái các thiết bị máy làn";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string keyword = StringHelper.ChangeWords(SearchTermTextBox.Text);
                List<Computer> listSearch = oMayTinhViewModel.loadDataStatus(tabName);
                var search = from a in listSearch
                             where a.MaMT.Contains(keyword) ||
                                   a.ThietBi.Any(x => x.Contains(keyword)) ||
                                   a.IP.StartsWith(keyword) || a.IP.EndsWith(keyword)
                             select a;
                lvVDS.Items.Clear();
                foreach (var item in search)
                {
                    lvVDS.Items.Add(item);
                }
            }
            catch(Exception ex)
            {
                NLogHelper.Error(ex);
            }
        }

        private void lvVDS_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChiTiet frChiTiet = new ChiTiet();
            int index = lvVDS.SelectedIndex;
            Computer temp = (Computer)lvVDS.Items[index];
            temp.Cum = tabName;
            temp.Tram = "Long phước";
            frChiTiet.Source = temp;
            frChiTiet.Show();
        }
    }
}