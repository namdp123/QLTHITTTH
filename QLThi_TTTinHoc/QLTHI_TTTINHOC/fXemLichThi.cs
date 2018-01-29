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
    public partial class fXemLichThi : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();
        public fXemLichThi()
        {
            InitializeComponent();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var lich = from l in qlthi.LICHTHIs
                           join hv in qlthi.HOCVIENs on l.mahocvien equals hv.mahocvien
                           where l.makhoa == comboBoxEx1.SelectedValue.ToString() && l.mamon == comboBoxEx2.SelectedValue.ToString() && l.maphong == comboBoxEx3.SelectedValue.ToString()
                           select new { Tenhv = hv.tenhocvien, mahv = hv.mahocvien, ngaysinh = hv.ngaysinh };
                dataGridViewX1.DataSource = lich;
            }
            else
            {
                var lich = (from l in qlthi.LICHTHIs
                            join gv in qlthi.GIANGVIENs on l.magv equals gv.magv

                            where l.makhoa == comboBoxEx6.SelectedValue.ToString() && l.magv == textBoxX1.Text
                            orderby l.ngaythi, l.tietthi
                            select new { gv.magv, gv.tengv, l.ngaythi, l.tietthi, l.maphong }).Distinct();
                dataGridViewX1.DataSource = lich;
            }
        }

        private void btIn_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            if (radioButton2.Checked == true)
            {
                string khoa = comboBoxEx1.SelectedValue.ToString();
                string phong = comboBoxEx3.SelectedValue.ToString();
                string mon = comboBoxEx2.SelectedValue.ToString();
                var nt =( from n in qlthi.LICHTHIs where n.makhoa == khoa && n.maphong == phong && n.mamon == mon select n.ngaythi).FirstOrDefault().ToShortDateString();
                var tt = (from t in qlthi.LICHTHIs where t.makhoa == khoa && t.maphong == phong && t.mamon == mon select t.tietthi).FirstOrDefault().ToString() ;
              
                if (dataGridViewX1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất");
                    return;
                }

                List<lichthi> pListLichthi = new List<lichthi>();

                // Đổ dữ liệu vào danh sách
                foreach (DataGridViewRow item in dataGridViewX1.Rows)
                {
                    lichthi i = new lichthi();
                    i.HoTen = item.Cells[1].Value.ToString();
                    i.MaHV = item.Cells[2].Value.ToString();
                    i.NgaySinh = item.Cells[3].Value.ToString();
                    pListLichthi.Add(i);
                }
                string path = string.Empty;

                excel.ExportLichThi(pListLichthi, ref path, false, khoa, phong, mon, nt,tt);
                if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
            else
            {
                string magv = textBoxX1.Text;
                var ten = from t in qlthi.GIANGVIENs where t.magv == magv select new { tengv = t.tengv };
                string tengv = dataGridViewX1.Rows[0].Cells[2].Value.ToString();
                string khoa = comboBoxEx6.SelectedValue.ToString();
                if (dataGridViewX1.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất");
                    return;
                }

                List<lichthiGV> pListLichthi = new List<lichthiGV>();

                // Đổ dữ liệu vào danh sách
                foreach (DataGridViewRow item in dataGridViewX1.Rows)
                {
                    lichthiGV i = new lichthiGV();
                    i.Ngaythi = item.Cells[3].Value.ToString();
                    i.Tietthi = item.Cells[4].Value.ToString();
                    i.Phongthi = item.Cells[5].Value.ToString();
                    pListLichthi.Add(i);
                }
                string path = string.Empty;

                excel.ExportLichThiGV(pListLichthi, ref path, false, khoa, tengv);
                if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void fXemLichThi_Load(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
        }

        private void comboBoxEx1_DropDown(object sender, EventArgs e)
        {
            var khoa = from k in qlthi.KHOAHOCs select k.makhoa;
            comboBoxEx1.DataSource = khoa;
        }

        private void comboBoxEx1_SelectedValueChanged(object sender, EventArgs e)
        {
            var mon = (from m in qlthi.LICHTHIs where m.makhoa == comboBoxEx1.SelectedValue.ToString() select m.mamon).Distinct();
            comboBoxEx2.Enabled = true;
            comboBoxEx2.DataSource = mon;
        }

        private void comboBoxEx2_SelectedValueChanged(object sender, EventArgs e)
        {
            var phong = (from p in qlthi.LICHTHIs where p.mamon == comboBoxEx2.SelectedValue.ToString() && p.makhoa == comboBoxEx1.SelectedValue.ToString() select p.maphong).Distinct();
            comboBoxEx3.Enabled = true;
            comboBoxEx3.DataSource = phong;
        }

        private void comboBoxEx6_DropDown(object sender, EventArgs e)
        {
            var khoa = from k in qlthi.KHOAHOCs select k.makhoa;
            comboBoxEx6.DataSource = khoa;
        }

        private void comboBoxEx3_DropDown(object sender, EventArgs e)
        {
           
        }

       
    }
}
