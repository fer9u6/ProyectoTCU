using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace ProyectoTCU
{
    public partial class classroom2 : Form
    {
        Classroom cla;
        int boxActual,rondas;
        Dictionary<Bitmap, SoundPlayer> imagenesYsonidos;
        List<Bitmap> imagenesUsadas;
        List<int> iAsignadas; // indices de la lista de objetos que fueron asignados para una ronda 
        List<Bitmap> imagenesObjetos;
        List<int> ordenpBox;
        SortedList<int,SoundPlayer> sAsignados;// sonidos asignados para una ronda(indice de sonido de objeto,sonido de preposicion)
        Dictionary<PictureBox,SoundPlayer> parejas; //sonidos de preposicion asociados a un picturebox
        List<PictureBox> pboxList;

        public classroom2()
        {
            InitializeComponent();
            boxActual = 0;
            rondas = 1;
            imagenesYsonidos = new Dictionary<Bitmap, SoundPlayer>(); // de objetos
            imagenesUsadas = new List<Bitmap>();
            imagenesObjetos = new List<Bitmap>();
            parejas = new Dictionary<PictureBox,SoundPlayer>();
            iAsignadas = new List<int>();
            sAsignados = new SortedList<int, SoundPlayer>();
            pboxList = new List<PictureBox>();
            ordenpBox = new List<int>();

            Bitmap bs = (Bitmap)Properties.Resources.blue_scissors_;
            Bitmap book = (Bitmap)Properties.Resources.Book;
            Bitmap books = (Bitmap)Properties.Resources.books;
            Bitmap pencil = (Bitmap)Properties.Resources.pencil;
            Bitmap redbook = (Bitmap)Properties.Resources.redbook;
            Bitmap glue = (Bitmap)Properties.Resources.glue;
            Bitmap eraser = (Bitmap)Properties.Resources.eraser;
            Bitmap sharp = (Bitmap)Properties.Resources.sharpener;
            Bitmap colorpencils = (Bitmap)Properties.Resources.colorpencils;
            Bitmap backpack = (Bitmap)Properties.Resources.backpack;
            Bitmap notebook = (Bitmap)Properties.Resources.yellow_notebook;
            Bitmap pen = (Bitmap)Properties.Resources.pen_silver;
            Bitmap rule = (Bitmap)Properties.Resources.rule;
            Bitmap crayons = (Bitmap)Properties.Resources.clipart_crayons_1862;

            pboxList.Add(pictureBoxon);
            pboxList.Add(pictureBoxondesk);
            pboxList.Add(pictureBoxnextto);
            pboxList.Add(pictureBoxbetween);
            pboxList.Add(pictureBoxinfrontofb);
            pboxList.Add(pictureBoxunder);
            pboxList.Add(pictureBinfrontoftrue);
            


            imagenesObjetos.Add(bs);
            imagenesObjetos.Add(book);
            imagenesObjetos.Add(books);
            imagenesObjetos.Add(pencil);
            imagenesObjetos.Add(redbook);
            imagenesObjetos.Add(glue);
            imagenesObjetos.Add(eraser);
            imagenesObjetos.Add(sharp);
            imagenesObjetos.Add(colorpencils);
            imagenesObjetos.Add(backpack);
            imagenesObjetos.Add(pen);
            imagenesObjetos.Add(notebook);
            imagenesObjetos.Add(rule);
            imagenesObjetos.Add(crayons);

            SoundPlayer onthedeskaudio = new SoundPlayer(Properties.Resources.on_the_desk_audio);
            SoundPlayer onthetableaudio = new SoundPlayer(Properties.Resources.on_the_table_audio);
            SoundPlayer nexttoaudio = new SoundPlayer(Properties.Resources.next_to_the_desk_audio);
            SoundPlayer betweenaudio = new SoundPlayer(Properties.Resources.between_the_b_and_t_audio);
            SoundPlayer behindaudio = new SoundPlayer(Properties.Resources.behind_the_chair_audio);
            SoundPlayer infrontofaudio = new SoundPlayer(Properties.Resources.in_front_of_the_board_audio);
            SoundPlayer underaudio = new SoundPlayer(Properties.Resources.under_the_table);
            SoundPlayer booksaudio = new SoundPlayer(Properties.Resources.books_audio);
            SoundPlayer redbookaudio = new SoundPlayer(Properties.Resources.red_book_audio);
            SoundPlayer colorpencilsaudio = new SoundPlayer(Properties.Resources.color_pencils_audio);
            SoundPlayer eraseraudio = new SoundPlayer(Properties.Resources.eraser_audio);
            SoundPlayer scissorsaudio = new SoundPlayer(Properties.Resources.scissors_audio);
            SoundPlayer sharpeneraudio = new SoundPlayer(Properties.Resources.sharpener_audio);
            SoundPlayer pencilaudio = new SoundPlayer(Properties.Resources.pencil_audio);
            SoundPlayer glueaudio = new SoundPlayer(Properties.Resources.glue_audio);
            SoundPlayer bacpackaudio = new SoundPlayer(Properties.Resources.backpack_audio);
            SoundPlayer penaudio = new SoundPlayer(Properties.Resources.pen_audio);
            SoundPlayer notebookaudio = new SoundPlayer(Properties.Resources.notebook_audio);
            SoundPlayer bookaudio = new SoundPlayer(Properties.Resources.book_audio);
            SoundPlayer ruleaudio = new SoundPlayer(Properties.Resources.rule_audio);
            SoundPlayer crayonsaudio = new SoundPlayer(Properties.Resources.crayons_audio);


            //preposiciones
            parejas.Add(pictureBoxondesk, onthedeskaudio);
            parejas.Add( pictureBoxon, onthetableaudio);
            parejas.Add(pictureBoxnextto, nexttoaudio);
            parejas.Add(pictureBoxbetween, betweenaudio);
            parejas.Add(pictureBoxinfrontofb, behindaudio);
            parejas.Add(pictureBoxunder, underaudio);
            parejas.Add(pictureBinfrontoftrue,infrontofaudio);

            imagenesYsonidos.Add(books, booksaudio);
            imagenesYsonidos.Add(bs, scissorsaudio);
            imagenesYsonidos.Add(book, bookaudio);
            imagenesYsonidos.Add(pencil, pencilaudio);
            imagenesYsonidos.Add(redbook, redbookaudio);
            imagenesYsonidos.Add(glue, glueaudio);
            imagenesYsonidos.Add(eraser, eraseraudio);
            imagenesYsonidos.Add(sharp, sharpeneraudio);
            imagenesYsonidos.Add(colorpencils, colorpencilsaudio);
            imagenesYsonidos.Add(backpack, bacpackaudio);
            imagenesYsonidos.Add(pen, penaudio);
            imagenesYsonidos.Add(notebook, notebookaudio);
            imagenesYsonidos.Add(rule,ruleaudio);
            imagenesYsonidos.Add(crayons, crayonsaudio);

            asignar();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            cla = new Classroom();
            this.Hide();
            cla.Show();
        }

        private void asignar()
        {
            Random rn = new Random();
            //se elige un sonido
            int imagenN;
            int limite = 6;
            for (int i = 0; i <= limite; i++)
            {
                imagenN = rn.Next(0, imagenesObjetos.Count);
                while (imagenesUsadas.Contains(imagenesObjetos[imagenN]))
                {
                    imagenN = rn.Next(0, imagenesObjetos.Count);
                }
                iAsignadas.Add(imagenN);
                imagenesUsadas.Add(imagenesObjetos[imagenN]);
            }
            //imagenes se sacan de la lista de imagenes imagenesObjetos 
            //asigna imagenes a los diferentes picture box
            pictureBoxbetween.Image = imagenesObjetos[iAsignadas[0]];
            pictureBoxinfrontofb.Image = imagenesObjetos[iAsignadas[1]];
            pictureBoxnextto.Image = imagenesObjetos[iAsignadas[2]];
            pictureBoxon.Image = imagenesObjetos[iAsignadas[3]];
            pictureBoxondesk.Image = imagenesObjetos[iAsignadas[4]];
            pictureBoxunder.Image = imagenesObjetos[iAsignadas[5]];
            pictureBinfrontoftrue.Image = imagenesObjetos[iAsignadas[6]];
            //orden de los sonidos
            //el sonido del objeto se obtiene de del dicionario imagenesYsonidos, se envia el indice de la lista de imagenesObjetos
            sAsignados.Add(iAsignadas[0],parejas[pictureBoxbetween]);
            sAsignados.Add(iAsignadas[1], parejas[pictureBoxbetween]);
            sAsignados.Add(iAsignadas[2], parejas[pictureBoxbetween]);
            sAsignados.Add(iAsignadas[3], parejas[pictureBoxbetween]);
            sAsignados.Add(iAsignadas[4], parejas[pictureBoxbetween]);
            sAsignados.Add(iAsignadas[5], parejas[pictureBoxbetween]);
            //(imagenesYsonidos[imagenesObjetos[iAsignadas[0]]])

            //orden picture box
            int pb= rn.Next(0,pboxList.Count);
            List<int> lista = new List<int>();
            for (int i = 0; i <= 6; i++)
            {
                while (lista.Contains(pb))
                {
                    pb = rn.Next(0, pboxList.Count);
                }
                ordenpBox.Add(pb);
                lista.Add(pb);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sonido
            PictureBox pb = pboxList[boxActual];
            SoundPlayer soundP = parejas[pb];
            Bitmap i = (Bitmap)pb.Image;
            SoundPlayer soundO = imagenesYsonidos[i];
            reproducirSonidoObjeto(soundO);
            try
            {
                soundP.Play();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }


        private void reproducirSonidoObjeto(SoundPlayer k)
        {
            try
            {
                k.Play();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            System.Threading.Thread.Sleep(1000);
        }

        private void pictureBoxon_Click(object sender, EventArgs e)
        {
            //metodo que comprueba respuesta corresta
            PictureBox actual = sender as PictureBox;
            if (pboxList[boxActual]==actual)
            {
                MessageBox.Show("Correct answer");
                boxActual++;
                if (boxActual == 7) // ya se acabo la ronda
                {
                    rondas++;
                    boxActual = 0;
                    ordenpBox.Clear();
                    sAsignados.Clear();
                    iAsignadas.Clear();
                    if (rondas == 3)
                    {
                        MessageBox.Show("Congratulations!! Play the next level");
                        //siguienteNivel();
                    }
                    else
                    {
                        asignar();
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Bad answer");
            }
        }
    }
}

