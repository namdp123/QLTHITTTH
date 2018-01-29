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
    public partial class fPhanQuyen :UserControl
    {
        public fPhanQuyen()
        {
            InitializeComponent();
        }

        private void nHOMNGUOIDUNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMNGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);

        }

        private void fPhanQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.PHANQUYEN' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dataSet2.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet2.NHOMNGUOIDUNG);

        }

      

        private void nHOMNGUOIDUNGDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (nHOMNGUOIDUNGDataGridView.CurrentRow != null)
            {
                string manhom = nHOMNGUOIDUNGDataGridView.CurrentRow.Cells[0].Value.ToString();
                try
                {
                    this.dM_MANHINHDKTableAdapter.FillDK(this.dataSet2.DM_MANHINHDK, manhom);
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            string manhom = nHOMNGUOIDUNGDataGridView.CurrentRow.Cells[0].Value.ToString();
            for (int i = 0; i < dM_MANHINHDKDataGridView.Rows.Count - 1; i++)
            {
                string mamh = dM_MANHINHDKDataGridView.Rows[i].Cells[0].Value.ToString();
                bool _coquyen = false;
                try
                {
                    _coquyen = bool.Parse(dM_MANHINHDKDataGridView.Rows[i].Cells[2].Value.ToString());
                }
                catch
                {
                    _coquyen = false;
                }
                int? kq = pHANQUYENTableAdapter.KiemTraKhoaChinh(mamh, manhom);
                if (kq == null || kq.Value == 0)
                {
                    pHANQUYENTableAdapter.them(mamh, manhom, _coquyen);
                   
                }
                else
                {
                    pHANQUYENTableAdapter.Sua(_coquyen, manhom, mamh);
                }
            }
            MessageBox.Show("Thanh công");
        }

       

       

      

      
    }
}
