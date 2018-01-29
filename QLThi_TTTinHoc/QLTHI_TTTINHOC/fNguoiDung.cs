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
    public partial class fNguoiDung : UserControl
    {
        public fNguoiDung()
        {
            InitializeComponent();
        }

        private void nGUOIDUNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);

        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.NGUOIDUNG' table. You can move, or remove it, as needed.
            loadDL();

        }
        private void loadDL()
        {
            this.nGUOIDUNGTableAdapter.Fill(this.dataSet2.NGUOIDUNG);
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            string value = Encrypt(textBoxX1.Text, textBoxX2.Text);
            if (nGUOIDUNGTableAdapter.KTKhoaChinh(textBoxX1.Text) > 0)
            {
                MessageBox.Show("Trung khoa");
                return;
            }
            nGUOIDUNGTableAdapter.Insert(textBoxX1.Text, value,checkBoxX1.Checked);

            loadDL();
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
    }
}
