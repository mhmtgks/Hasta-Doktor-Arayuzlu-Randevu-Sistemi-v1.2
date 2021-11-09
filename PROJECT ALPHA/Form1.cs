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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kadi = textBox1.Text;
            string sifre = textBox2.Text;

            if (DBislemleri.girisKontrol(kadi, sifre) == true)
            {
                if (DBislemleri.tipçekme(kadi) == 0) { 
                this.Hide();
                HastaAnaMenü f2 = new HastaAnaMenü();
                f2.ShowDialog();
                this.Close(); }
                else
                {
                    this.Hide();
                    DoktorMenü dmm = new DoktorMenü();
                    dmm.ShowDialog();
                    this.Close();
                }
            }
            else
                MessageBox.Show("giriş geçersiz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kayıtol f3 = new Kayıtol();
            f3.ShowDialog();
            this.Close();

        }


    }
}
