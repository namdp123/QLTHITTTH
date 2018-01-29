using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLTHI_TTTINHOC
{
    public partial class fMain : DevComponents.DotNetBar.Office2007RibbonForm
    {
        fdangnhap fdn = new fdangnhap();
        DevComponents.DotNetBar.TabControl tabControl1 = new DevComponents.DotNetBar.TabControl();
       
        public static string username = string.Empty;
      
        public fMain()
        {
            InitializeComponent();
            tabControl1.TabItemClose += tabControl1_TabItemClose;
            
           
        }

        void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            TabItem t = tabControl1.SelectedTab;
            tabControl1.Tabs.Remove(t);
            if (tabControl1.Controls.Count -1 == 0)
                panel1.Controls.Clear();
        
        }
     
          
        public void AddForm(string tabname,UserControl f)
       {
           tabControl1.CloseButtonOnTabsVisible = true;
          
           panel1.Controls.Add(tabControl1);
           tabControl1.Dock = DockStyle.Fill;
           foreach (TabItem tab in tabControl1.Tabs)
           {
               if (tab.Text ==tabname)
               {
                   tabControl1.SelectedTab = tab;
                   return;
                  
               }
           }
           TabControlPanel newTabPanel = new TabControlPanel();
           TabItem newTabPage = new TabItem(components);
           newTabPanel.Dock = DockStyle.Fill;

           newTabPage.AttachedControl = newTabPanel;
           newTabPage.Text = tabname;
           f.Dock = DockStyle.Fill;
           tabControl1.Controls.Add(newTabPanel);
           tabControl1.Tabs.Add(newTabPage);
           newTabPage.AttachedControl.Controls.Add(f);
           
                  
        
       }
           
        
        private void buttonItem13_Click(object sender, EventArgs e)
        {
         
         
        }

        private void btLapLichThi_Click(object sender, EventArgs e)
        {

            fLapLichThi f = new fLapLichThi();
            AddForm(btLapLichThi.Text, f);
           
            
        }
       
        private void fMain_Load(object sender, EventArgs e)
        {

            DataTable nhomND = nGUOIDUNG_DK_TDNTableAdapter.GetMaNhom(username);
            foreach (DataRow manhom in nhomND.Rows)
            {

                DataTable dsQuyen = dM_MANHINHDKTableAdapter.GetMaManHinh(manhom[0].ToString());
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbonControl1.Items, mh[1].ToString(), bool.Parse(mh[2].ToString()));
                }
            }

        }

        private void FindMenuPhanQuyen(SubItemsCollection subItemsCollection, string p1, bool p2)
        {
           
            foreach (RibbonTabItem t in subItemsCollection)
            {
             
               
               foreach (Control c in t.Panel.Controls)
               {
                   if(c.Text ==p1)
                        c.Enabled = p2;
                  
               }
                
            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            fXemLichThi fxl = new fXemLichThi();
            AddForm("Xem lịch thi", fxl);
        }

        private void btMonHoc_Click(object sender, EventArgs e)
        {
            fmonhoc fmh = new fmonhoc();
            AddForm("Môn Học", fmh);
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            fDangKy fdk = new fDangKy();
            AddForm("Đăng Ký", fdk);
        }

        private void btGiangVien_Click(object sender, EventArgs e)
        {
            fGiangVien fgv = new fGiangVien();
            AddForm("Giảng Viên", fgv);
        }

        private void btThemNguoiDung_Click(object sender, EventArgs e)
        {
            fNguoiDung fnd = new fNguoiDung();
            AddForm("Người Dùng", fnd);
        }

        private void btThemVaoNhom_Click(object sender, EventArgs e)
        {
            fThemNguoiDungVaoNhom ftn = new fThemNguoiDungVaoNhom();
            AddForm("Thêm người dùng", ftn);
        }

        private void btPhanQuyen_Click(object sender, EventArgs e)
        {
            fPhanQuyen fpq = new fPhanQuyen();
            AddForm("Phân quyền", fpq);
        }

        private void btNhomNguoiDung_Click(object sender, EventArgs e)
        {
            fnhomnguoidung fnd = new fnhomnguoidung();
            AddForm("Nhóm ngừoi dung", fnd);
        }

    

        private void btDangNhap_Click(object sender, EventArgs e)
        
        {
         
            fdn.ShowDialog();

            DataTable nhomND = nGUOIDUNG_DK_TDNTableAdapter.GetMaNhom(username);
            foreach (DataRow manhom in nhomND.Rows)
            {

                DataTable dsQuyen = dM_MANHINHDKTableAdapter.GetMaManHinh(manhom[0].ToString());
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbonControl1.Items, mh[1].ToString(), bool.Parse(mh[2].ToString()));
                }
            }

        
            
            
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            fHocVien fhv = new fHocVien();
            AddForm("Học viên", fhv);
        }

       
        


      

      

       

       
     
    }
}
