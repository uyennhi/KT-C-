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

namespace WindowsFormsApp2
{
    public partial class Themlienlac : Form
    {
        public Themlienlac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\NhomlienlacCT.txt"))

                sw.WriteLine(txtNhom.Text+"#"+textlienlac.Text+"#"+textEmail.Text+"#"+textsdt.Text+"#"+textdiachi.Text);

            Form1 form1 = new Form1();
            
            form1.Refresh();
            form1.dgvTenNhom.Refresh();
            form1.Show();
            this.Close();
        }
    }
}
