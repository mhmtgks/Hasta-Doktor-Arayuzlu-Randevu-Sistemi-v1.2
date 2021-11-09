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
    public partial class Kayıtol : Form
    {
        public Kayıtol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc =textBox1.Text;
            string şifre = textBox4.Text;
            string ad = textBox3.Text;
            string soyad = textBox2.Text;
            string adres = richTextBox1.Text;
            string tarih = dateTimePicker1.Value.ToShortDateString();
            int tip = 0;
            DBislemleri.Ekle(ad, soyad, tc, adres, tarih);//giriş kontrol fonksiyonu ile gönderip form 2 yi açtırt
            int id=DBislemleri.idçekme(tc);
            DBislemleri.girişEkle(tc, şifre, tip,id);
            if (DBislemleri.girisKontrol(tc, şifre) == true)
            {
                this.Hide();
                HastaAnaMenü f2 = new HastaAnaMenü();
                f2.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }
    }
}
