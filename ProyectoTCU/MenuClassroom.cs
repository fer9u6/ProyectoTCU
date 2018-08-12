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
    public partial class MenuClassroom : Form
    {
        ClassroomVocabulary cv;
        Prepositions p;
        Classroom c;
        Menu1erGrado m1;
        Mensaje mensaje;
        public MenuClassroom()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            mensaje = new Mensaje();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //vocabulary
            cv = new ClassroomVocabulary();
            this.Hide();
            cv.Show();


        }

        private void ButtonMoreV_Click(object sender, EventArgs e)
        {
            p = new Prepositions();
            this.Hide();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = new Classroom();
            this.Hide();
            c.Show();
            mensaje.neutralMensaje("Listen the sound and click \non the right object.");
        }

        private void backB_Click(object sender, EventArgs e)
        {
            m1 = new Menu1erGrado();
            this.Hide();
            m1.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
