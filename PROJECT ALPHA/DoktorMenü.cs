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
    public partial class DoktorMenü : Form
    {
        public DoktorMenü()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fret = new Form1();
            fret.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ziyaret asp = new ziyaret();
            asp.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            tümmuayne arsp = new tümmuayne();
            arsp.ShowDialog();
            this.Close();
        }

        private void DoktorMenü_Load(object sender, EventArgs e)
        {
            DataSet dst = DBislemleri.güncelranddr();
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
                int hastaid = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                DBislemleri.bilgiyüklemehst(hastaid);
                textBox1.Text = DBislemleri.tc;
                textBox2.Text = DBislemleri.dt;
                textBox3.Text = DBislemleri.soyadı;
                textBox4.Text = DBislemleri.adı;
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
            try
            {
                int randid = (int)dataGridView1.SelectedRows[0].Cells[5].Value;
                string dnotuu = richTextBox1.Text;
                DBislemleri.teshis(randid, dnotuu);
                DoktorMenü_Load(sender, e);
            }
            catch (ArgumentOutOfRangeException) { }
            catch (InvalidCastException) { }

        }
    }
}
