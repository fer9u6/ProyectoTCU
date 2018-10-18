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
    public partial class Menu5toGrado : Form
    {
        MenuPrincipal mp;
        Parejas5toGrado par;
        Preguntas5toGrado preg;
        funcionesOrganos fo;

        public Menu5toGrado()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.Closed += (s, ev) => Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //functions of human organs
            fo = new funcionesOrganos();
            this.Hide();
            fo.Show();
            Mensaje ms = new Mensaje();
            ms.neutralMensaje("Associate the human organ with\n its respective function");
            
        }

        private void backB_MouseHover(object sender, EventArgs e)
        {
            backB.Size = new Size(75,65);
        }

        private void backB_MouseLeave(object sender, EventArgs e)
        {
            backB.Size = new Size(70,60);
        }

        private void backB_Click(object sender, EventArgs e)
        {
            mp = new MenuPrincipal();
            mp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            par = new Parejas5toGrado();
            par.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            preg = new Preguntas5toGrado();
            preg.Show();
            this.Hide();
        }
    }
}
