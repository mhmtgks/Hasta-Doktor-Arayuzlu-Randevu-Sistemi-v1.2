using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_ALPHA
{
    public partial class ziyaret : Form
    {
        public ziyaret()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoktorMenü ertu = new DoktorMenü();
            ertu.ShowDialog();
            this.Close();
        }

        private void ziyaret_Load(object sender, EventArgs e)
        {
            DataSet dst = DBislemleri.ziyaretler();
            dataGridView1.DataSource = dst.Tables[0];
            DataGridViewColumn column = dataGridView1.Columns[1];
            DataGridViewColumn columnn = dataGridView1.Columns[0];
            DataGridViewColumn column1 = dataGridView1.Columns[2];
            DataGridViewColumn column2 = dataGridView1.Columns[4];
            DataGridViewColumn column3 = dataGridView1.Columns[5];
            DataGridViewColumn column4 = dataGridView1.Columns[6];
            column.Width = 0;
            column1.Width = 0;
            column2.Width = 0;
            column3.Width = 0;
            column4.Width = 0;
            columnn.Width = 0;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tarih = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
                string dnotu = (string)dataGridView1.SelectedRows[0].Cells[4].Value;
                textBox1.Text = tarih;
                richTextBox1.Text = dnotu;
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch (InvalidCastException) { }
        }
    }
}
