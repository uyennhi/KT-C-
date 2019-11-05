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
    public partial class Form1 : Form
    {
        string pathDataNhom = Application.StartupPath + @"\DATA\Nhomlienlac.txt";
        string pathDataNhomCT = Application.StartupPath + @"\DATA\NhomlienlacCT.txt";
        List<TenNhom> tenNhom;
        private ThemNhom themNhom;
        public Form1()
        {
            InitializeComponent();
            
            pathDataNhom = Application.StartupPath + @"\DATA\Nhomlienlac.txt";
            
            dgvTenNhom.AutoGenerateColumns = false;
            dgvTenNhomCT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTenNhom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //   List<TenNhom> a = TenNhom.GetListFromFile(pathDataNhom);
            //   List<TenNhom> a = TenNhom.GetListFromFile(pathDataNhom);
            tenNhom = TenNhom.GetListFromFile(pathDataNhom);
            //  for (int i = 0; i < a.Count; i++)
            //   {
            //  Console.WriteLine(a[i]);
            //      MessageBox.Show(a[i].tennhom);
            //  }
            if(tenNhom == null)
            {
                throw new Exception(" Không tồn tại ");
            }
            else { 
            bdsTenNhom.DataSource = tenNhom;
            dgvTenNhom.DataSource = bdsTenNhom;
            }
            
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            themNhom = new ThemNhom();
            themNhom.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTenNhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dgvTenNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvTenNhom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                string justClickedcell = dgvTenNhom.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                dgvTenNhomCT.AutoGenerateColumns = false;
                List<TenNhomCT> abc = TenNhomCT.GetListFromFile(pathDataNhomCT, justClickedcell);
                if(abc == null)
                {
                    return;
                }
                bdsTenNhomCT.DataSource = abc;
                dgvTenNhomCT.DataSource = bdsTenNhomCT;

            }
        }

        private void dgvTenNhomCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTenNhomCT.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgvTenNhomCT.CurrentRow.Selected = true;
                lbtenLienLac.Text = dgvTenNhomCT.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
              //  lbdiachi.Text = dgvTenNhomCT.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                lbemail.Text = dgvTenNhomCT.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                lbsodienthoai.Text = dgvTenNhomCT.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                string sdt = dgvTenNhomCT.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                List<TenNhomCT> abc = TenNhomCT.GetListFromFilesdt(pathDataNhomCT, sdt);
                lbdiachi.Text = abc[0].diachi;




            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvTenNhom.SelectedRows.Count < 0)
            {

                //MessageBox.Show(dgvTenNhom.SelectedRows[0].Index.ToString());
                return;
                MessageBox.Show("Chọn ô cần xóa");
            }
            else
            {
                int indexDgvTenNhom = dgvTenNhom.SelectedRows[0].Index;
                if (dgvTenNhom.SelectedRows.Count > 0)
                {
                 //   MessageBox.Show(indexDgvTenNhom.ToString());
                    dgvTenNhom.Rows.RemoveAt(dgvTenNhom.SelectedRows[0].Index);
                    
                    string[] Lines = File.ReadAllLines(pathDataNhom);
                    string deletedNhom = Lines[indexDgvTenNhom];
                    //  MessageBox.Show(indexDgvTenNhom.ToString(Lines[4]));
                  //  MessageBox.Show(Lines.Length.ToString());
                    File.Delete(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\Nhomlienlac.txt");// Deleting the file
                    using (StreamWriter sw = File.AppendText(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\Nhomlienlac.txt"))

                    {
                     
                        for(int i = 0; i < Lines.Length; i++)
                        {
                            if (i != indexDgvTenNhom)
                            {
                                sw.WriteLine(Lines[i]);
                            }
                            
                        }
                    }


                    string[] LinesCT = File.ReadAllLines(pathDataNhomCT);
                    File.Delete(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\NhomlienlacCT.txt");// Deleting the file
                    using (StreamWriter sw = File.AppendText(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\NhomlienlacCT.txt"))

                    {
                        foreach (string line in LinesCT)
                        {
                            if (line.IndexOf(deletedNhom) >= 0)
                            {
                                //Skip the line
                                continue;
                            }
                            else
                            {
                                sw.WriteLine(line);
                            }
                        }
                    }
                    dgvTenNhomCT.DataSource = null;
                  //  dataGridView1.Rows.Clear();
                  //  dataGridView1.Refresh();

                }

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            

            if (dgvTenNhomCT.SelectedRows.Count < 0)
            {

                //MessageBox.Show(dgvTenNhom.SelectedRows[0].Index.ToString());
                MessageBox.Show("Chọn ô cần xóa");
                return;
                
            }
            else
            {
                if (dgvTenNhomCT.SelectedRows.Count > 0)
                {
                    int indexDgvTenNhomCT = dgvTenNhomCT.SelectedRows[0].Index;
                    string[] LinesCT = File.ReadAllLines(pathDataNhomCT);
                    File.Delete(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\NhomlienlacCT.txt");// Deleting the file
                    using (StreamWriter sw = File.AppendText(@"D:\C#\DungApp\WindowsFormsApp2\WindowsFormsApp2\DATA\NhomlienlacCT.txt"))

                    {

                        string sdt = dgvTenNhomCT.Rows[indexDgvTenNhomCT].Cells["Column4"].FormattedValue.ToString();
                        foreach (string line in LinesCT)
                        {
                            if (line.IndexOf(sdt) >= 0)
                            {
                                //Skip the line
                                continue;
                            }
                            else
                            {
                                sw.WriteLine(line);
                            }
                        }
                       
                    }
                    dgvTenNhomCT.Rows.RemoveAt(dgvTenNhomCT.SelectedRows[0].Index);
                }
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Themlienlac them = new Themlienlac();
            them.ShowDialog();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
        // Sự kiện tìm theo tên nhóm sau khi enter textbox;
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tenNhom = tbsearch.Text;
            List<TenNhomCT> contactNames = TenNhomCT.GetListFromFile(pathDataNhomCT, tenNhom);
            if (contactNames == null)
            {
                MessageBox.Show("Nhóm không tồn tại, Vui lòng nhập chính xác tên nhóm.");
                return;
            }
            bdsTenNhomCT.DataSource = contactNames;
            dgvTenNhomCT.DataSource = bdsTenNhomCT;
        }
    }
}
