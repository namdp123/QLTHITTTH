using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHI_TTTINHOC
{
    static class Program
    {

        public static fMain mainForm = null;
        public static fdangnhap fdangnhap = null;
        public static fcauhinh fcauhinh = null;
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fdangnhap = new fdangnhap();
            mainForm = new fMain();
            Application.Run(fdangnhap);
           
         
        }
    }
}
