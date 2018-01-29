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
    public partial class fnhomnguoidung : UserControl
    {
        public fnhomnguoidung()
        {
            InitializeComponent();
        }

        private void nHOMNGUOIDUNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMNGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet2);

        }

        private void fnhomnguoidung_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            loadDL();

        }
        private void loadDL()
        {
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet2.NHOMNGUOIDUNG);

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (this.nHOMNGUOIDUNGTableAdapter.KTKhoaChinh(textBoxX1.Text) > 0)
            {
                MessageBox.Show("Trung khoa");
                return;
            }
            nHOMNGUOIDUNGTableAdapter.Insert(textBoxX1.Text, textBoxX2.Text);
            loadDL();
            textBoxX1.Clear();
            textBoxX2.Clear();
        }
    }
}
