using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace QLTHI_TTTINHOC
{
    public partial class fLapLichThi : UserControl
    {
        QLTHIDataContext qlthi = new QLTHIDataContext();

        public fLapLichThi()
        {
            InitializeComponent();
        }

       

        private void comboBoxEx2_DropDown(object sender, EventArgs e)
        {
            var KHOA = from m in qlthi.KHOAHOCs select m.makhoa;
            comboBoxEx2.DataSource = KHOA;
        }

        private void fLapLichThi_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AutoGenerateColumns = false;
            var lich = from l in qlthi.LICHTHIs select l;
            dataGridViewX1.DataSource = lich;
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btLapLich_Click(object sender, EventArgs e)
        {
            if (ktTrungKhoa(comboBoxEx2.SelectedValue.ToString()) > 0)
            {
                MessageBox.Show("Khóa học này đã được xếp lịch thi");
                return;
            }
            
            Random random= new Random();
            var GiaoVien = from gv in qlthi.GIANGVIENs select gv.magv;
            List<string> g = GiaoVien.ToList();
          
            int tietthi = 0;
            int succhua =Convert.ToInt32( txtSucChua.Text);
            string khoa = comboBoxEx2.SelectedValue.ToString();

            var Phong = from phong in qlthi.PHONGHOCs select phong.maphong;
  
            DateTime ngaythi = dateTimeInput1.Value;

            List<string> p = Phong.ToList();
            var monhoc = from mh in qlthi.MONHOC_KHOAHOCs
                         join m in qlthi.MONHOCs on mh.mamon equals m.mamon
                         where mh.makhoa == khoa
                         select new { mh.mamon,m.thoigianthi};

            List<string> hocvientrongngay = new List<string>();

            foreach (var m in monhoc)
            {
               
                var hocvien = from hv in qlthi.DANGKies where hv.makhoa == khoa && hv.mamon == m.mamon select hv.mahocvien;
                
                List<String> h = hocvien.ToList();
                if (ktTrungNgay(hocvientrongngay, h) == 0)
                {
                    tietthi += 2;
                    hocvientrongngay.Clear();
                }
                else
                {
                    tietthi = 1;
                    ngaythi = ngaythi.AddDays(1);
                    hocvientrongngay.Clear();
                }
                int dem = 0;
                for (int i = 0; i < p.Count; i++)
                {
                     string magv = g[random.Next(g.Count)];
                    while (ktTrungGio(p[i], ngaythi, tietthi, magv) > 0)
                    {
                         magv = g[random.Next(g.Count)];
                    }
                    while (ktSoBuoi(magv, ngaythi) > 2)
                    {
                        magv = g[random.Next(g.Count)];
                    }
                    while (ktTrungTiet(ngaythi,tietthi,magv) > 0)
                    {
                        magv = g[random.Next(g.Count)];
                    }
                    for (int j = 0; j < h.Count; )
                    {
                        dem++;
                        LICHTHI _lichthi = new LICHTHI();
                        _lichthi.mahocvien = h[j];
                        _lichthi.makhoa = khoa;
                        _lichthi.mamon = m.mamon;
                        _lichthi.magv = magv;
                        _lichthi.maphong = p[i];
                        _lichthi.ngaythi = ngaythi;
                        _lichthi.tietthi = tietthi;
                        _lichthi.thoiluong =m.thoigianthi;
                        hocvientrongngay.Add(h[j]);
                        qlthi.LICHTHIs.InsertOnSubmit(_lichthi);
                        qlthi.SubmitChanges();
                        h.RemoveAt(j);
                        if (dem == succhua)
                        {
                            dem = 0;
                            break;
                        }
                    }
                    if (h.Count ==0)
                        break;

                }
               

                


            }

            var lich = from l in qlthi.LICHTHIs select l;
            dataGridViewX1.DataSource = lich;
            MessageBox.Show("Tạo thành công");
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public int ktSoBuoi(string magv, DateTime ngaythi)
        {
            var kt = (from k in qlthi.LICHTHIs where k.ngaythi == ngaythi && k.magv == magv select k).Distinct().Count();
            return kt;
        }
        public int ktTrungGio(string maphong,DateTime ngaythi, int tietthi,string magv)
        {
            var kt = (from k in qlthi.LICHTHIs where k.maphong == maphong && k.ngaythi == ngaythi && k.tietthi == tietthi && k.magv == magv select k).Distinct().Count();
            return kt;
        }
        public int ktTrungTiet( DateTime ngaythi, int tietthi, string magv)
        {
            var kt = (from k in qlthi.LICHTHIs where  k.ngaythi == ngaythi && k.tietthi == tietthi && k.magv == magv select k).Distinct().Count();
            return kt;
        }
        public int ktTrungNgay(List<String> hocvientrongngay, List<String> dshvthi)
        {
            for (int i = 0; i < hocvientrongngay.Count; i++)
            {
                for (int j = 0; j < dshvthi.Count; j++) 
                {
                    if (hocvientrongngay[i] == dshvthi[j])
                    {
                        return 1;
                        
                    }

                }
            }
            return 0;
        }
        public int ktTrungKhoa(string makhoa)
        {
            var kiemtra = (from kt in qlthi.LICHTHIs where kt.makhoa == makhoa select kt.makhoa).Distinct().Count();
            return kiemtra;
        }

      

       
    }
}
