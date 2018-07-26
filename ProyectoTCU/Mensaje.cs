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
        bool active;
        public Mensaje()
        {
            InitializeComponent();
             active = false;
        }

        public void looseMesaje() {
            active = true;
            panel1.BackColor = Color.Red;
            pictureBox1.Image = Properties.Resources.sceptic;
            label1.ForeColor = Color.Red;
            label1.Text = "Try again";
            panel1.Visible = true;
            pictureBox1.Visible = true;
            this.Text = "Game over";
            this.Show();

        }

        public void winMesaje()
        {
            active = true;
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
            active = true;
            label1.Text = m;
            label1.ForeColor = Color.DarkViolet;
            label1.Font = new Font("Tahoma", 14, FontStyle.Bold);
            panel1.Visible = false;
            pictureBox1.Visible = false;
            this.BackColor = Color.Silver;
            this.Text = "Instructions";
            this.Show();

        }

        /**
         * Devuelve el estado active que indica si este form esta show o hide en pantalla.
         **/
        public bool getState() {
            return active;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            active = false;
            this.Hide();
        }
    }
}
