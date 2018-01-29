using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLTHI_TTTINHOC
{
    public partial class fThemNguoiDungVaoNhom : UserControl
    {
        public fThemNguoiDungVaoNhom()
        {
            InitializeComponent();
        }

    

        private void fThemNguoiDungVaoNhom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.NGUOIDUNG_NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNG_NHOMNGUOIDUNGTableAdapter.Fill(this.dataSet2.NGUOIDUNG_NHOMNGUOIDUNG);
            // TODO: This line of code loads data into the 'dataSet2.NGUOIDUNG_NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNG_NHOMNGUOIDUNGTableAdapter.Fill(this.dataSet2.NGUOIDUNG_NHOMNGUOIDUNG);
            
            // TODO: This line of code loads data into the 'dataSet2.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet2.NHOMNGUOIDUNG);
          

        }

        public void loadDL()
        {
            string manhom = comboBoxEx1.SelectedValue.ToString();
            try
            {
                this.nGUOIDUNG_NHOMNGUOIDUNGDKTableAdapter.Fill_DK(this.dataSet2.NGUOIDUNG_NHOMNGUOIDUNGDK, manhom);
                this.nGUOIDUNGDKTableAdapter.FillDK(this.dataSet2.NGUOIDUNGDK, manhom);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDL();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string tenDN=nGUOIDUNGDKDataGridView.CurrentRow.Cells[0].Value.ToString();
            string manhom = comboBoxEx1.SelectedValue.ToString();
            nGUOIDUNG_NHOMNGUOIDUNGTableAdapter.Insert1(tenDN, manhom);
            loadDL();
            MessageBox.Show("Thành công");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            string tenDN = nGUOIDUNG_NHOMNGUOIDUNGDKDataGridView.CurrentRow.Cells[0].Value.ToString();
            string manhom = nGUOIDUNG_NHOMNGUOIDUNGDKDataGridView.CurrentRow.Cells[1].Value.ToString();
            nGUOIDUNG_NHOMNGUOIDUNGTableAdapter.delete(tenDN, manhom);
            loadDL();
            MessageBox.Show("Thành công");
        }

        private void nGUOIDUNG_NHOMNGUOIDUNGDKDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
     
    }
        
}
