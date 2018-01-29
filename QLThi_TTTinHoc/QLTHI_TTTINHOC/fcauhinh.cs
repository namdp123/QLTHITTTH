using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHI_TTTINHOC
{
    public partial class fcauhinh : DevComponents.DotNetBar.Office2007RibbonForm
    {
        CauHinh cauhinh = new CauHinh();
        public fcauhinh()
        {
            InitializeComponent();
          
        }

        private void bLuu_Click(object sender, EventArgs e)
        {
            cauhinh.SaveConfig(cboServer.Text, textBox1.Text, textBox2.Text, cboDataBase.Text);
            this.Close();
            Program.fdangnhap.Show();
        }

        private void cboServer_DropDown(object sender, EventArgs e)
        {
            cboServer.DataSource = cauhinh.GetServerName();
            cboServer.DisplayMember = "ServerName";
        }

        private void cboDataBase_DropDown(object sender, EventArgs e)
        {
            cboDataBase.DataSource = cauhinh.GetDBName(cboServer.Text, textBox1.Text, textBox2.Text);
            cboDataBase.DisplayMember = "name";
        }

       
    }
}
