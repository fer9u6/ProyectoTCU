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
    public partial class MemoryMatch : Form
    {
        Menu4toGrado m4;
        bool play,turno;
        int aciertos;
        PictureBox imagenA1,imagenA2;
        Dictionary<int,int> parejas;
        List<PictureBox> contenedores;
        List<int> imagenesUsadas;
        Bitmap mem =(Bitmap) Properties.Resources.ResourceManager.GetObject("memory");
        Bitmap gray = (Bitmap)Properties.Resources.ResourceManager.GetObject("gray");
        Dictionary<PictureBox, int> asignaciones;// imagen a pictureBox

        public MemoryMatch()
        {
            InitializeComponent();
            play = false;
            turno = false;
            aciertos = 0;
            asignaciones = new Dictionary<PictureBox, int>();
            imagenesUsadas = new List<int>();
            parejas = new Dictionary<int, int>();
            parejas.Add(0,1);
            parejas.Add(2,3);
            parejas.Add(4,5);
            parejas.Add(6,7);
            parejas.Add(8,9);
            parejas.Add(10,11);
            parejas.Add(12,13);
            parejas.Add(14,15);

            contenedores = new List<PictureBox>();
            contenedores.Add(pictureBox1);
            contenedores.Add(pictureBox2);
            contenedores.Add(pictureBox3);
            contenedores.Add(pictureBox4);
            contenedores.Add(pictureBox5);
            contenedores.Add(pictureBox6);
            contenedores.Add(pictureBox7);
            contenedores.Add(pictureBox8);
            contenedores.Add(pictureBox9);
            contenedores.Add(pictureBox10);
            contenedores.Add(pictureBox11);
            contenedores.Add(pictureBox12);
            contenedores.Add(pictureBox13);
            contenedores.Add(pictureBox14);
            contenedores.Add(pictureBox15);
            contenedores.Add(pictureBox16);


        }

        private void backB_Click(object sender, EventArgs e)
        {
            m4 = new Menu4toGrado();
            this.Hide();
            m4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            play = true;
            button1.Visible = false;
            asignar();
        }

        private void asignar()
        {
            Random rn = new Random();
            foreach (PictureBox pb in contenedores) {
                //se elige una imagen
                int imagen;
                imagen = rn.Next(0, imageList1.Images.Count);
                while (imagenesUsadas.Contains(imagen)) {
                    imagen = rn.Next(0, imageList1.Images.Count);
                }
                imagenesUsadas.Add(imagen);

                //se asigna a un contenedor
                // pb.Image = imageList1.Images[imagen];
                asignaciones.Add(pb,imagen);

            }

        }

        private void validar() {
            int i1 = asignaciones[imagenA1];
            int i2 = asignaciones[imagenA2];
            int key=-1;
            if (parejas.ContainsKey(i1)) {
                key = i1;
            }
            if (parejas.ContainsKey(i2))
            {
                key = i2;
            }

            if ( (key != -1) &&(parejas[key] == i2 || parejas[key] == i1))
            {
                aciertos += 1;
                imagenA1.Image = gray;
                imagenA2.Image = gray;
            }
            else {
                //String res = "bad answer";
                //MessageBox.Show(res, "Memory Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                imagenA1.Image = mem;
                imagenA2.Image = mem;
            }

            //fin del juego
            if (aciertos == 8) {
                aciertos =0;
                imagenesUsadas.Clear();
                asignaciones.Clear();
                voltearTodo();
                asignar();
            }

        }

        private void voltearTodo() {
            foreach(PictureBox p in contenedores)
            {
                p.Image = mem;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Control ctrl = sender as Control;
            PictureBox p = sender as PictureBox;
            int imagenAsignada = asignaciones[p];
            p.Image = imageList1.Images[imagenAsignada];
            if (turno == false)
            {
                turno = true;
                imagenA1 = p;
            }
            else {
                turno = false;
                Task taskA = Task.Factory.StartNew(() => voltearI2(p));
                taskA.Wait();
                validar();

            }
        }

        private void voltearI2(PictureBox k) {
            imagenA2 = k;
            System.Threading.Thread.Sleep(2000);
        }
    }
}
