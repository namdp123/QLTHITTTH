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
    public partial class fmonhoc : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();
        public fmonhoc()
        {
            InitializeComponent();
        }
        public void loadDL()
        {
            var monhoc = from mh in qlthi.MONHOCs select mh;
            dataGridViewX1.DataSource = monhoc;
            
        }
        public int ktKhoa(string mamon)
        {
            var kt = (from mh in qlthi.MONHOCs select mh.mamon == mamon).Count();
            return kt;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (ktKhoa(textBoxX1.Text) > 0)
            {
                MessageBox.Show("Trùng khóa");
            }
            else
            {
                MONHOC mh = new MONHOC();
                mh.mamon = textBoxX1.Text;
                mh.tenmonhoc = textBoxX2.Text;
                qlthi.MONHOCs.InsertOnSubmit(mh);
            }
        }

        private void fmonhoc_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AutoGenerateColumns = false;
            loadDL();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
             for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (dataGridViewX1.Rows[i].Selected)
                {

                    MONHOC _MHXoa = qlthi.MONHOCs.Where(mh => mh.mamon == dataGridViewX1.Rows[i].Cells[0].Value.ToString()).FirstOrDefault();
                    if (_MHXoa != null)
                    {
                        qlthi.MONHOCs.DeleteOnSubmit(_MHXoa);
                    }
                }
            }
            MessageBox.Show("Xóa thành công");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            MONHOC _MHSua = qlthi.MONHOCs.Where(mh => mh.mamon == dataGridViewX1.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
            if (_MHSua != null)
            {
                _MHSua.tenmonhoc = textBoxX2.Text;
            


            }
            MessageBox.Show("Sửa thành công");
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            qlthi.SubmitChanges();
            loadDL();
        }

      
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxEx2_DropDown_1(object sender, EventArgs e)
        {
            var khoahoc = from k in qlthi.KHOAHOCs select k.makhoa;
            comboBoxEx2.DataSource = khoahoc;
        }

        private void btTim_Click_1(object sender, EventArgs e)
        {
            var monhoc = from mh in qlthi.MONHOC_KHOAHOCs join m in qlthi.MONHOCs on mh.mamon equals m.mamon where mh.makhoa == comboBoxEx2.SelectedValue.ToString() select new { m.mamon, m.magv, m.tenmonhoc, m.siso, m.sotc, m.thoigianbd, m.thoigiankt };
            dataGridViewX1.DataSource = monhoc;
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            if (ktKhoa(textBoxX1.Text) > 0)
            {
                MessageBox.Show("Trùng khóa");
            }
            else
            {
                MONHOC mh = new MONHOC();
                mh.mamon = textBoxX1.Text;
                mh.magv = "";
               
                mh.tenmonhoc = textBoxX2.Text;
                mh.siso =Convert.ToInt32( txtSiSo.Text);
                mh.sotc = Convert.ToInt32(txtSTC.Text);
                mh.thoigianbd = dateTimeInput1.Value;
                mh.thoigiankt = dateTimeInput2.Value;
                qlthi.MONHOCs.InsertOnSubmit(mh);
            }
        }
    }
}
