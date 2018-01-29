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
    public partial class fDangKy : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();
        public fDangKy()
        {
            InitializeComponent();
        }

        private void comboBoxEx1_DropDown(object sender, EventArgs e)
        {
            var khoa = from k in qlthi.KHOAHOCs select new {k.makhoa,k.tenkhoa};
            comboBoxEx1.DataSource = khoa;
            comboBoxEx1.DisplayMember = "tenkhoa";
            comboBoxEx1.ValueMember = "makhoa";
        }

      
        private void btDangKy_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    if (ktDangKy(comboBoxEx1.SelectedValue.ToString(), dataGridView1.Rows[i].Cells[0].Value.ToString(), comboBoxEx2.SelectedValue.ToString()) < 1)
                    {
                        DANGKY dk = new DANGKY();
                        dk.mahocvien = comboBoxEx2.SelectedValue.ToString();
                        dk.mamon = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        dk.makhoa = comboBoxEx1.SelectedValue.ToString();
                        dk.diem = null;
                        qlthi.DANGKies.InsertOnSubmit(dk);
                        qlthi.SubmitChanges();
                    }
                }
            }
            MessageBox.Show("Đăng ký thành công");
            loadDangKy();
        }

       
        private void buttonX3_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (dataGridViewX1.Rows[i].Selected == true)
                {
                    
                    DANGKY _XoaDK = qlthi.DANGKies.Where(hv => (hv.makhoa == dataGridViewX1.Rows[i].Cells[0].Value.ToString() && hv.mamon == dataGridViewX1.Rows[i].Cells[1].Value.ToString() && hv.mahocvien == dataGridViewX1.Rows[i].Cells[2].Value.ToString())).FirstOrDefault();
                    if (_XoaDK != null)
                    {
                        qlthi.DANGKies.DeleteOnSubmit(_XoaDK);
                        qlthi.SubmitChanges();

                    }
                }
            }
            MessageBox.Show("Xóa thành công");
            loadDangKy();
        }

        private void fDangKy_Load(object sender, EventArgs e)
        {
            loadHocVien();
            dataGridViewX1.AutoGenerateColumns = false;
            loadDangKy();
           
        }

        private void comboBoxEx1_SelectedValueChanged(object sender, EventArgs e)
        {
            var mon = (from m in qlthi.MONHOC_KHOAHOCs join mh in qlthi.MONHOCs on m.mamon equals mh.mamon where m.makhoa == comboBoxEx1.SelectedValue.ToString() select new {mh.mamon, mh.tenmonhoc,mh.sotc,mh.siso,mh.thoigianbd,mh.thoigiankt}).Distinct();

            dataGridView1.DataSource = mon;
        }
        public void loadHocVien()
        {
            var hocvien = from h in qlthi.HOCVIENs select h.mahocvien;
            comboBoxEx2.DataSource = hocvien;

           
        }
        public int ktDangKy(string makhoa, string mamon,string mahocvien)
        {
            var dangky = (from dk in qlthi.DANGKies where dk.makhoa == makhoa && dk.mamon == mamon && dk.mahocvien == mahocvien select dk).Count();
            return dangky;
        }
        public void loadDangKy()
        {
            var dk = from d in qlthi.DANGKies join m in qlthi.MONHOCs on d.mamon equals m.mamon select new { d.makhoa, m.tenmonhoc, d.mahocvien, m.thoigianbd, m.thoigiankt };
            dataGridViewX1.DataSource = dk;
        }

      

        
    }
}
