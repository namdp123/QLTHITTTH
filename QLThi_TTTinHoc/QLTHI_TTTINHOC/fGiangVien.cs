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
    public partial class fGiangVien : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();
        public fGiangVien()
        {
            InitializeComponent();
        }
        public static void ClearGroup(Control.ControlCollection TapControls)
        {
            try
            {
                foreach (Control c in TapControls)
                {
                    Type s = c.GetType();

                    switch (s.Name)
                    {

                        case "TextBoxX":
                            ((DevComponents.DotNetBar.Controls.TextBoxX)c).Text = "";
                            break;
                        case "ComboBoxX":
                            ((DevComponents.DotNetBar.Controls.ComboBoxEx)c).SelectedIndex = -1;
                            break;
                        case "CheckBoxX":
                            ((DevComponents.DotNetBar.Controls.CheckBoxX)c).Checked = false;
                            break;
                        case "RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int ktKhoa(string magv)
        {
            var kt = (from gv in qlthi.GIANGVIENs where (gv.magv == magv) select gv.magv).Count();
            return kt;
        }
        public void loadDL()
        {
            var GiangVien = from gv in qlthi.GIANGVIENs select gv;
            dataGridViewX1.DataSource = GiangVien;

        }
        private void btThem_Click(object sender, EventArgs e)
        {
             if (ktKhoa(textBoxX1.Text) > 0)
            {
                MessageBox.Show("Trùng mã");
                return;
            }
            else
            {
                GIANGVIEN gv = new GIANGVIEN();
                gv.magv = textBoxX1.Text;
                gv.tengv = textBoxX2.Text;
                gv.dienthoai = textBoxX3.Text;
                gv.diachi = textBoxX6.Text;
                if (radioButton1.Checked == true)
                    gv.gioitinh = radioButton1.Text;
                else
                    gv.gioitinh = radioButton2.Text;
                gv.trinhdo = textBoxX5.Text;
                gv.ngayvaolam = dateTimeInput1.Value;
                qlthi.GIANGVIENs.InsertOnSubmit(gv);
                ClearGroup(panelEx1.Controls);
                MessageBox.Show("Thêm thành công");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (dataGridViewX1.Rows[i].Selected)
                {

                    GIANGVIEN _GVXoa = qlthi.GIANGVIENs.Where(gv => gv.magv == dataGridViewX1.Rows[i].Cells[0].Value.ToString()).FirstOrDefault();
                    if (_GVXoa != null)
                    {
                        qlthi.GIANGVIENs.DeleteOnSubmit(_GVXoa);
                    }
                }
            }
            MessageBox.Show("Xóa thành công");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            GIANGVIEN _GVSua = qlthi.GIANGVIENs.Where(gv => gv.magv == dataGridViewX1.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
            if (_GVSua != null)
            {
                _GVSua.tengv = textBoxX2.Text;
                _GVSua.dienthoai = textBoxX3.Text;
                _GVSua.diachi = textBoxX6.Text;
                if (radioButton1.Checked == true)
                    _GVSua.gioitinh = radioButton1.Text;
                else
                    _GVSua.gioitinh = radioButton2.Text;
                _GVSua.trinhdo = textBoxX5.Text;
                _GVSua.ngayvaolam = dateTimeInput1.Value;


            }
            MessageBox.Show("Sửa thành công");
        }

        private void btLuu_Click(object sender, EventArgs e)
        {

            qlthi.SubmitChanges();
            loadDL();
        }

        private void fGiangVien_Load(object sender, EventArgs e)
        {
            loadDL();
        }
    }
}
