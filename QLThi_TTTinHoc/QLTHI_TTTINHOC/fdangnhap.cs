using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHI_TTTINHOC
{
    public partial class fdangnhap : DevComponents.DotNetBar.Office2007RibbonForm
    {
        CauHinh cauhinh = new CauHinh();
        QL_NGUOIDUNG nd = new QL_NGUOIDUNG();
        string tendangnhap;

        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }

      
        public fdangnhap()
        {
            InitializeComponent();
          
        }
        public void ProcessConfig()
        {
            if (Program.fcauhinh == null || Program.fcauhinh.IsDisposed)
            {
                Program.fcauhinh = new fcauhinh();
            }
            this.Visible = false;
            Program.fcauhinh.Show();


        }
        public void ProcessLogin()
        {
            fMain.username = textBox1.Text;
         
            LoginResult result;
            if (textBox1.Text == "Ad")
            {
                result = nd.Check_User(textBox1.Text, textBox2.Text);
            }
            else
            {
                string chuoi = Encrypt(textBox1.Text, textBox2.Text);
                result = nd.Check_User(textBox1.Text, chuoi);
            }
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + label1.Text + " Hoặc " + label2.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
            {
                Program.mainForm = new fMain();
            }
            this.Visible = false;
            Program.mainForm.Show();
        }
        private void fdangnhap_Load(object sender, EventArgs e)
        {
         
        }
        public static string Encrypt(string value, string publickKey)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            byte[] bytesIn = Encoding.UTF8.GetBytes(value);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bytesKey = Encoding.UTF8.GetBytes(publickKey);
            Array.Resize(ref bytesKey, des.Key.Length);
            Array.Resize(ref bytesKey, des.IV.Length);
            des.Key = bytesKey;
            des.IV = bytesKey;
            MemoryStream msOut = new MemoryStream();
            ICryptoTransform desdecrypt = des.CreateEncryptor();
            CryptoStream cryptStreem = new CryptoStream(msOut, desdecrypt,
           CryptoStreamMode.Write);
            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            byte[] bytesOut = msOut.ToArray();
            cryptStreem.Close();
            msOut.Close();
            return Convert.ToBase64String(bytesOut);
        }

        private void bDN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + label1.Text.ToLower());
                this.textBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("Không được bỏ trống" + label2.Text.ToLower());
                this.textBox2.Focus();
                return;
            }
            int kq = cauhinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập

            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                ProcessConfig();
            }
        }

        private void bHuy_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

      
    }
}
