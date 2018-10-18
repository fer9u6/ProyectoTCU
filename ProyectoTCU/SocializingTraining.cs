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
    public partial class SocializingTraining : Form
    {

        Menu4toGrado m4;

        int imagenActual;

        public SocializingTraining()
        {

            InitializeComponent();
            imagenActual = 0;
        }

        private void SocializingTraining_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            m4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imagenActual = imagenActual + 1;
            if (imagenActual == imageList1.Images.Count) { imagenActual = 0; }
            pictureBox1.Image = imageList1.Images[imagenActual];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imagenActual = imagenActual - 1;
            if (imagenActual == -1) { imagenActual = imageList1.Images.Count-1; }
            pictureBox1.Image = imageList1.Images[imagenActual];
        }
    }
}