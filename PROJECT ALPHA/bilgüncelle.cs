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
    public partial class bilgüncelle : Form
    {
        public bilgüncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            string adı = textBox5.Text;
            string soyadı = textBox4.Text;
            string dt = textBox2.Text;
            string adr = richTextBox1.Text;
            DBislemleri.Guncelle(adı, soyadı, tc, adr, dt);
            MessageBox.Show("KAYDEDİLDİ!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HastaAnaMenü ral = new HastaAnaMenü();
            ral.ShowDialog();
            this.Close();
        }


        private void bilgüncelle_Activated(object sender, EventArgs e)
        {

        }

        private void bilgüncelle_Load(object sender, EventArgs e)
        {
            DBislemleri.bilgiyükleme();
            textBox1.Text = DBislemleri.tc;
            textBox5.Text = DBislemleri.adı;
            textBox4.Text = DBislemleri.soyadı;
            textBox2.Text = DBislemleri.dt;
            richTextBox1.Text = DBislemleri.adres;
        }
    }
}
