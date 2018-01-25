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
    public partial class Diseases : Form
    {
        Menu4toGrado m4;
        List<String> enfermedades;
        List<String> cosas;
        public Diseases()
        {
            InitializeComponent();
            enfermedades = new List<string>();
            cosas = new List<string>();

            cosas.Add("Broken arm");
            cosas.Add("Bloody nose");
            cosas.Add("Bruise");
            cosas.Add("Cut");


            enfermedades.Add("cough");
            enfermedades.Add("diarrhea");
            enfermedades.Add("fever");
            enfermedades.Add("headache");
            //vocabulario
            //bandaid

        }

        private void backB_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            this.Hide();
            m4.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playButton.Visible = false;
        }
    }
}
