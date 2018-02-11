using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTCU
{
    public partial class Mensaje : Form
    {
        public Mensaje()
        {
            InitializeComponent();
        }

        public void looseMesaje() {
            panel1.BackColor = Color.Red;
            pictureBox1.Image = Properties.Resources.sad;
            label1.ForeColor = Color.Red;
            label1.Text = "You loose!";
            panel1.Visible = true;
            pictureBox1.Visible = true;
            this.Text = "Game over";
            this.Show();

        }

        public void winMesaje()
        {
            panel1.BackColor = Color.Yellow;
            pictureBox1.Image = Properties.Resources.joyful;
            label1.ForeColor = Color.Yellow;
            label1.Text = "You win!";
            panel1.Visible = true;
            pictureBox1.Visible = true;
            this.Text = "Game over";
            this.Show();

        }

        public void neutralMensaje(String m) {
            label1.Text = m;
            label1.ForeColor = Color.DarkViolet;
            label1.Font = new Font("Tahoma", 14, FontStyle.Bold);
            panel1.Visible = false;
            pictureBox1.Visible = false;
            this.BackColor = Color.Silver;
            this.Text = "Instructions";
            this.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
