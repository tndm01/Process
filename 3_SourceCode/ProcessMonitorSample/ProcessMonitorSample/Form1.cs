using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessMonitorSample
{
    public partial class Form1 : Form
    {
        DataTable show = new DataTable();
        FileTransferFtp oFileTransferFtp = new FileTransferFtp();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnSaveFTP_Click(object sender, EventArgs e)
        {
            oFileTransferFtp = new FileTransferFtp(txtFTPHost.Text, 21, txtUser.Text, txtPassword.Text, 60000);
            string showResult = oFileTransferFtp.SessionOptions.HostName + "\n" +
                oFileTransferFtp.SessionOptions.UserName + "\n" +
                oFileTransferFtp.SessionOptions.Password + "\n" +
                oFileTransferFtp.SessionOptions.PortNumber + "\n" +
                oFileTransferFtp.SessionOptions.TimeoutInMilliseconds;
            MessageBox.Show(showResult);
        }
    }
}
