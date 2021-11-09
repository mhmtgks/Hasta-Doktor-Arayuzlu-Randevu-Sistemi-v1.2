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
    public partial class randevugüncelle : Form
    {
        public randevugüncelle()
        {
            InitializeComponent();
        }
        public static int randids;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HastaAnaMenü ral = new HastaAnaMenü();
            ral.ShowDialog();
            this.Close();
        }

        private void randevugüncelle_Load(object sender, EventArgs e)
        {
            DataSet dst = DBislemleri.güncelrand();
            dataGridView1.DataSource = dst.Tables[0];
            DataGridViewColumn column = dataGridView1.Columns[1];
            DataGridViewColumn columnn = dataGridView1.Columns[0];
            DataGridViewColumn column1 = dataGridView1.Columns[2];
            DataGridViewColumn column2 = dataGridView1.Columns[4];
            DataGridViewColumn column3 = dataGridView1.Columns[5];
            DataGridViewColumn column4 = dataGridView1.Columns[6];
            DataGridViewColumn column5 = dataGridView1.Columns[3];
            column.Width = 0;
            column1.Width = 0;
            column2.Width = 0;
            column3.Width = 0;
            column4.Width = 0;
            columnn.Width = 0;
            column5.Width = 460;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string tarih = (string)dataGridView1.SelectedRows[0].Cells[3].Value;
                int doktorid = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
                int polid = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
                randids = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
                string dadı = DBislemleri.dradi(doktorid);
                string hastadı = DBislemleri.hastadı();
                string sehiradddı = DBislemleri.sehiradııı();
                string poladı = DBislemleri.poladdı(polid);
                textBox1.Text = sehiradddı;
                textBox2.Text = hastadı;
                textBox3.Text = poladı;
                textBox4.Text = dadı;
                dateTimePicker1.Value = Convert.ToDateTime(tarih);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch (InvalidCastException)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBislemleri.randsil(randids);
            randevugüncelle_Load(sender,e);
        }
    }
}
