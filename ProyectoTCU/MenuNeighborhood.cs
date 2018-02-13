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
    public partial class MenuNeighborhood : Form
    {

        Neighborhood nei;
        ListenPlaces lp;
        PrepositionsCity pc;
        Menu1erGrado m1;

        public MenuNeighborhood()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lp = new ListenPlaces();
            this.Hide();
            lp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pc = new PrepositionsCity();
            this.Hide();
            pc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nei = new Neighborhood();
            this.Hide();
            nei.Show();
            Mensaje mensaje = new Mensaje();
            mensaje.neutralMensaje("Look at the map and choose \nthe right option");
        }

        private void backB_Click(object sender, EventArgs e)
        {
            m1 = new Menu1erGrado();
            this.Hide();
            m1.Show();
        }
    }
}
