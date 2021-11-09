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
    public partial class randevuAl : Form
    {
        public randevuAl()
        {
            InitializeComponent();
        }
        public int ilcc = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int did = (int)dataGridView1.SelectedRows[0].Cells[1].Value;
            int polidi = (int)(dataGridView2.SelectedRows[0].Cells[1].Value);
            string tarihh = dateTimePicker1.Value.ToShortDateString();
            string doktornotu = "";
            int saat = (int)comboBox3.SelectedValue;
            DataSet dstt = DBislemleri.randkontrol(did, tarihh, saat);
            if (dstt.Tables[0].Rows.Count>0)
                MessageBox.Show("Gün Doluuu!!!");
            else {
                DBislemleri.Eklerand(did, polidi, tarihh, doktornotu,saat);
                MessageBox.Show("KAYDEDİLDİ!!!");
                    }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HastaAnaMenü ral = new HastaAnaMenü();
            ral.ShowDialog();
            this.Close();
        }

        private void randevuAl_Load(object sender, EventArgs e)
        {
            DataSet ds = DBislemleri.sehirlericekk();
            comboBox1.DisplayMember = "sehiradı";
            comboBox1.ValueMember = "sehirid";
            comboBox1.DataSource = ds.Tables[0];
            DataSet dst = DBislemleri.polcek();
            dataGridView2.DataSource = dst.Tables[0];
            if (dst.Tables[0].Rows.Count == 0)
                MessageBox.Show("Kayıt Yok");
            DataGridViewColumn columnn = dataGridView2.Columns[0];
            DataGridViewColumn column = dataGridView2.Columns[1];
            columnn.Width = 230;
            column.Width = 0;
            DataSet dstt = DBislemleri.saatcek();
            comboBox3.DisplayMember = "saatler";
            comboBox3.ValueMember = "id";
            comboBox3.DataSource = dstt.Tables[0];
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int sehiridd = (int)comboBox1.SelectedValue;
            DataSet ds2 = DBislemleri.hastcekk(sehiridd);
            dataGridView3.DataSource = ds2.Tables[0];
            if (ds2.Tables[0].Rows.Count == 0)
                MessageBox.Show("Kayıt Yok");
            DataGridViewColumn column = dataGridView3.Columns[1];
            DataGridViewColumn columnn = dataGridView3.Columns[0];
            column.Width = 0;
            columnn.Width = 225;
        }


        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
           if (dataGridView2.SelectedRows.Count > 0)
           {
                int hastidid = (int)dataGridView3.SelectedRows[0].Cells[1].Value;
                int polidi = (int)(dataGridView2.SelectedRows[0].Cells[1].Value);
               
                DataSet dat = DBislemleri.drcek(hastidid, polidi);
                dataGridView1.DataSource = dat.Tables[0];
                /*if (dat.Tables[0].Rows.Count == 0)
                    MessageBox.Show("Kayıt Yok");*/
                DataGridViewColumn columnn = dataGridView1.Columns[0];
                DataGridViewColumn column = dataGridView1.Columns[1];
                columnn.Width = 230;
                column.Width = 230;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
               /* int polidi = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
                int hastidid = (int)dataGridView3.SelectedRows[0].Cells[0].Value;
                DataSet dat = DBislemleri.drcek(hastidid, polidi);
                dataGridView1.DataSource = dat.Tables[0];
                if (dat.Tables[0].Rows.Count == 0)
                    MessageBox.Show("Kayıt Yok");
                DataGridViewColumn columnn = dataGridView1.Columns[0];
                DataGridViewColumn column = dataGridView1.Columns[1];
                columnn.Width = 230;
                column.Width = 230;*/
            
        }
    }
}
