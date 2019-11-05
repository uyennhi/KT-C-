using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.DAL.Entity;

namespace WindowsFormsApp2
{
    public partial class ThemNhom : Form
    {
        string pathDataNhom = Application.StartupPath + @"\DATA\Nhomlienlac.txt";
        public ThemNhom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TenNhom> a = TenNhom.GetListFromFile(pathDataNhom);
            for(int i = 0; i < a.Count; i++)
            {
                if(a[i].tennhom == txtadd.Text)
                {
                    MessageBox.Show("Không thể thêm nhóm đã tồn tại");
                    return;
                }
            }

            using (StreamWriter sw = File.AppendText(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\Nhomlienlac.txt"))

                sw.WriteLine(txtadd.Text);

            Form1 form1 = new Form1();
            form1.Refresh();

            form1.Show();
            this.Close();
        }
    }
}
