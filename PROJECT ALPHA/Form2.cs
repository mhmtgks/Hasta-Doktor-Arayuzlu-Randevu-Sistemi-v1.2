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
    public partial class HastaAnaMenü : Form
    {
        public HastaAnaMenü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            randevuAl ral = new randevuAl();
            ral.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            bilgüncelle bil = new bilgüncelle();
            bil.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Geçmişrandevularım gr = new Geçmişrandevularım();
            gr.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            randevugüncelle rxg = new randevugüncelle();
            rxg.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 zte = new Form1();
            zte.ShowDialog();
            this.Close();
        }
    }
}
