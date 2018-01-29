using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace QLTHI_TTTINHOC
{
    public partial class fdoimatkhau : UserControl
    {
        public fdoimatkhau()
        {
            InitializeComponent();
        }
        qlndDataContext qlnd = new qlndDataContext();
        QL_NGUOIDUNG nd = new QL_NGUOIDUNG();
        fdangnhap d = new fdangnhap();
        fMain m = new fMain();
        private void fdoimatkhau_Load(object sender, EventArgs e)
        {
            txtuser.Text = user;
        }
        private string t;
        private string user;
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtxacnhan_Validating(object sender, CancelEventArgs e)
        {
            if (txtpassmoi.Text != txtxacnhan.Text)
            {
                errorProvider1.SetError(txtxacnhan, "Không khớp mật khẩu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        QL_NGUOIDUNG ql = new QL_NGUOIDUNG();

        public void ProcessChangepass()
        {
            fMain.username = txtuser.Text;

            LoginResult result;
            if (txtuser.Text == "Ad")
            {
                result = nd.Check_User(txtuser.Text, txtpasscu.Text);
            }
            else
            {
                string chuoi = Encrypt(txtuser.Text, txtpasscu.Text);
                result = nd.Check_User(txtuser.Text, chuoi);
            }
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu ");
                return;
            }
            // Account had been disabled
            this.Visible = false;
            NGUOIDUNG n = timnd(txtuser.Text);
            n.matkhau = Encrypt(txtuser.Text, txtpassmoi.Text);
            qlnd.SubmitChanges();
            MessageBox.Show("Đổi thành công!");
            m.Close();
            d.Show();

        }
        public NGUOIDUNG timnd(string tendangnhap)
        {
            NGUOIDUNG nd = qlnd.NGUOIDUNGs.Where(t => t.tendangnhap == tendangnhap).FirstOrDefault();
            return nd;

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
        private void frmdangki_Load(object sender, EventArgs e)
        {

        }
    }
}
