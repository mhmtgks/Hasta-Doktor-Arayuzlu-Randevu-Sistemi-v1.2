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
    public partial class Geçmişrandevularım : Form
    {
        public Geçmişrandevularım()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HastaAnaMenü ral = new HastaAnaMenü();
            ral.ShowDialog();
            this.Close();
        }

        private void Geçmişrandevularım_Load(object sender, EventArgs e)
        {
            DataSet dst = DBislemleri.güncelrand();
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
            DataSet dst1 = DBislemleri.eskirand();
            dataGridView2.DataSource = dst1.Tables[0];
            DataGridViewColumn column122 = dataGridView2.Columns[1];
            DataGridViewColumn columnn2 = dataGridView2.Columns[0];
            DataGridViewColumn column12 = dataGridView2.Columns[2];
            DataGridViewColumn column22 = dataGridView2.Columns[4];
            DataGridViewColumn column32 = dataGridView2.Columns[5];
            DataGridViewColumn column42 = dataGridView2.Columns[6];
            column122.Width = 0;
            column12.Width = 0;
            column22.Width = 0;
            column32.Width = 0;
            column42.Width = 0;
            columnn2.Width = 0;


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tarih = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
                int doktorid = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
                int polid = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                string polad = DBislemleri.poladdı(polid);
                string dadı= DBislemleri.dradi(doktorid);
                textBox1.Text = tarih;
                textBox2.Text = dadı;
                textBox3.Text = polad;
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tarih = (string)dataGridView2.SelectedRows[0].Cells[3].Value;
                int doktorid = (int)dataGridView2.SelectedRows[0].Cells[2].Value;
                int polid = (int)dataGridView2.SelectedRows[0].Cells[1].Value;
                string dadı = DBislemleri.dradi(doktorid);
                string polad = DBislemleri.poladdı(polid);
                textBox1.Text = tarih;
                textBox2.Text = dadı;
                textBox3.Text = polad;
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
    }
}
