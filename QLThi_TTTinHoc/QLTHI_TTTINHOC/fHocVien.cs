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
    public partial class fHocVien : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();
        public fHocVien()
        {
            InitializeComponent();
            dataGridViewX1.SelectionChanged += dataGridViewX1_SelectionChanged;
        }

        void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            textBoxX1.Text = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            textBoxX2.Text = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridViewX1.CurrentRow.Cells[2].Value.ToString() == "Nữ")
            {
                radioButton2.Checked = false;
            }
            else
                radioButton1.Checked = true;

            dateTimeInput1.Text = dataGridViewX1.CurrentRow.Cells[3].Value.ToString();
            textBoxX4.Text = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();

            textBoxX3.Text = dataGridViewX1.CurrentRow.Cells[5].Value.ToString();

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            btLuu.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            textBoxX1.Clear();
            textBoxX2.Clear();
            textBoxX3.Clear();
            textBoxX4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimeInput1.ResetText();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dataGridViewX1.Rows.Count;i++)
            {

                if (dataGridViewX1.Rows[i].Selected == true)
                {
                    HOCVIEN _XoaHV = qlthi.HOCVIENs.Where(hv => hv.mahocvien == dataGridViewX1.Rows[i].Cells[0].Value.ToString()).FirstOrDefault();
                    if (_XoaHV != null)
                    {
                        if (ktKhoaNgoai(dataGridViewX1.Rows[i].Cells[0].Value.ToString()) < 1)
                        {
                            qlthi.HOCVIENs.DeleteOnSubmit(_XoaHV);
                            qlthi.SubmitChanges();

                        }
                       
                    }
                }
            }
            MessageBox.Show("Xóa thành công");
            loadHocVien();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            HOCVIEN _SuaHV = qlthi.HOCVIENs.Where(hv => hv.mahocvien == dataGridViewX1.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
            if (_SuaHV != null)
            {
                _SuaHV.tenhocvien = textBoxX2.Text;
                if (radioButton1.Checked == true)
                    _SuaHV.gioitinh = radioButton1.Text;
                else
                    _SuaHV.gioitinh = radioButton2.Text;
                _SuaHV.ngaysinh = dateTimeInput1.Value;
                _SuaHV.dienthoai = textBoxX4.Text;
                _SuaHV.diachi = textBoxX3.Text;
              
                qlthi.SubmitChanges();
                loadHocVien();

            }
            MessageBox.Show("Cập nhật thành công");
        }
        public int  ktKhoaNgoai(string mahv)
        {
            var dangky = (from dk in qlthi.DANGKies where dk.mahocvien == mahv select mahv).Count();
            return dangky;
        }
        public void loadHocVien()
        {
            var hocvien = from hv in qlthi.HOCVIENs select hv;
            dataGridViewX1.DataSource = hocvien;
        }
        private void fHocVien_Load(object sender, EventArgs e)
        {
            loadHocVien();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            HOCVIEN hv = new HOCVIEN();
            hv.mahocvien = textBoxX1.Text;
            hv.tenhocvien = textBoxX2.Text;
            if (radioButton1.Checked == true)
                hv.gioitinh = radioButton1.Text;
            else
                hv.gioitinh = radioButton2.Text;
            hv.ngaysinh = dateTimeInput1.Value;
            hv.dienthoai = textBoxX4.Text;
            hv.diachi = textBoxX3.Text;
            qlthi.HOCVIENs.InsertOnSubmit(hv);
            qlthi.SubmitChanges();
            MessageBox.Show("Thêm thành công");
            loadHocVien();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
