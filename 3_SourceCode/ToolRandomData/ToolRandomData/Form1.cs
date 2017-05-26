using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToolRandomData
{
    public partial class Form1 : Form
    {
        Tool tl = new Tool();


        public Form1()
        {
            InitializeComponent();
        }


        public void ShowID()
        {
            DataTable dt = tl.LayID();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ID";
            comboBox1.ValueMember = "ID";

        }
        public void ShowMaTB()
        {
            DataTable dt = tl.LayMATB();
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "MaTB";
            comboBox2.ValueMember = "MaTB";

        }
        //public void ShowMaTrangThai()
        //{
        //    DataTable dt = tl.LayMaTrangThai();
        //    comboBox3.DataSource = dt;
        //    comboBox3.DisplayMember = "MaTrangThai";
        //    comboBox3.ValueMember = "MaTrangThai";

        //}


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ShowID();
                ShowMaTB();
                // ShowMaTrangThai();


                // Timer tm = new Timer();
                //timer1.Interval = int.Parse(txtInterval.Text);
                txtInterval.Text = Convert.ToString(timer1.Interval);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            // Random tb = new Random();

            timer1.Start();



        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ArrayList
            //Random rb = new Random();
            //txtTrangThai.Text = Convert.ToString(rb.Next(1, 10));
            try
            {
                Random tb = new Random();

                if (comboBox2.Text == "TB0001")
                {
                    ArrayList trangthai = new ArrayList();
                    trangthai.Add("TT001");
                    trangthai.Add("TT004");
                    trangthai.Add("TT008");
                    trangthai.Add("TT009");
                    trangthai.Add("TT011");
                    int i = tb.Next(0, trangthai.Count);
                    txtMaTrangThai.Text = trangthai[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0002")
                {
                    ArrayList trangthai1 = new ArrayList();
                    trangthai1.Add("TT001");
                    trangthai1.Add("TT004");
                    trangthai1.Add("TT008");
                    trangthai1.Add("TT009");
                    trangthai1.Add("TT011");

                    int i = tb.Next(0, trangthai1.Count);
                    txtMaTrangThai.Text = trangthai1[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0003")
                {
                    ArrayList trangthai3 = new ArrayList();
                    trangthai3.Add("TT001");

                    trangthai3.Add("TT008");
                    trangthai3.Add("TT009");
                    trangthai3.Add("TT011");

                    int i = tb.Next(0, trangthai3.Count);
                    txtMaTrangThai.Text = trangthai3[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0004")
                {
                    ArrayList trangthai4 = new ArrayList();
                    trangthai4.Add("TT001");

                    trangthai4.Add("TT008");
                    trangthai4.Add("TT009");
                    trangthai4.Add("TT011");

                    int i = tb.Next(0, trangthai4.Count);
                    txtMaTrangThai.Text = trangthai4[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0005")
                {
                    ArrayList trangthai5 = new ArrayList();
                    trangthai5.Add("TT002");
                    trangthai5.Add("TT003");
                    trangthai5.Add("TT004");
                    trangthai5.Add("TT005");
                    trangthai5.Add("TT006");
                    trangthai5.Add("TT007");
                    trangthai5.Add("TT010");
                    trangthai5.Add("TT011");
                    int i = tb.Next(0, trangthai5.Count);
                    txtMaTrangThai.Text = trangthai5[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0006")
                {
                    ArrayList trangthai6 = new ArrayList();
                    trangthai6.Add("TT002");
                    trangthai6.Add("TT003");
                    trangthai6.Add("TT004");
                    trangthai6.Add("TT005");
                    trangthai6.Add("TT006");
                    trangthai6.Add("TT007");
                    trangthai6.Add("TT010");
                    trangthai6.Add("TT011");
                    int i = tb.Next(0, trangthai6.Count);
                    txtMaTrangThai.Text = trangthai6[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0028")
                {
                    ArrayList trangthai7 = new ArrayList();
                    trangthai7.Add("TT002");
                    trangthai7.Add("TT003");
                    trangthai7.Add("TT004");
                    trangthai7.Add("TT005");
                    trangthai7.Add("TT006");
                    trangthai7.Add("TT007");
                    trangthai7.Add("TT010");
                    trangthai7.Add("TT011");
                    int i = tb.Next(0, trangthai7.Count);
                    txtMaTrangThai.Text = trangthai7[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0029")
                {
                    ArrayList trangthai8 = new ArrayList();
                    trangthai8.Add("TT001");
                    trangthai8.Add("TT008");
                    trangthai8.Add("TT009");
                    trangthai8.Add("TT011");
                    int i = tb.Next(0, trangthai8.Count);
                    txtMaTrangThai.Text = trangthai8[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0015")
                {
                    ArrayList trangthai12 = new ArrayList();
                    trangthai12.Add("TT001");
                    trangthai12.Add("TT008");
                    trangthai12.Add("TT009");
                    trangthai12.Add("TT011");
                    int i = tb.Next(0, trangthai12.Count);
                    txtMaTrangThai.Text = trangthai12[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0030")
                {
                    ArrayList trangthai9 = new ArrayList();
                    trangthai9.Add("TT002");
                    trangthai9.Add("TT003");
                    trangthai9.Add("TT004");
                    trangthai9.Add("TT005");
                    trangthai9.Add("TT006");
                    trangthai9.Add("TT007");
                    trangthai9.Add("TT010");
                    trangthai9.Add("TT011");
                    int i = tb.Next(0, trangthai9.Count);
                    txtMaTrangThai.Text = trangthai9[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0031")
                {
                    ArrayList trangthai10 = new ArrayList();
                    trangthai10.Add("TT002");
                    trangthai10.Add("TT003");
                    trangthai10.Add("TT004");
                    trangthai10.Add("TT005");
                    trangthai10.Add("TT006");
                    trangthai10.Add("TT007");
                    trangthai10.Add("TT010");
                    trangthai10.Add("TT011");
                    int i = tb.Next(0, trangthai10.Count);
                    txtMaTrangThai.Text = trangthai10[i].ToString().Trim();
                }
                else if (comboBox2.Text == "TB0032")
                {
                    ArrayList trangthai11 = new ArrayList();
                    trangthai11.Add("TT002");
                    trangthai11.Add("TT003");
                    trangthai11.Add("TT004");
                    trangthai11.Add("TT005");
                    trangthai11.Add("TT006");
                    trangthai11.Add("TT007");
                    trangthai11.Add("TT010");
                    trangthai11.Add("TT011");
                    int i = tb.Next(0, trangthai11.Count);
                    txtMaTrangThai.Text = trangthai11[i].ToString().Trim();
                }

                DB oDB = new DB();

                oDB.InsertData(comboBox1.Text, comboBox2.Text, dtpThoiGian.Text, txtMoTa.Text, txtTrangThai.Text, txtMaTrangThai.Text);
            }
            catch (Exception ex)

            {
                ex.ToString();
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
