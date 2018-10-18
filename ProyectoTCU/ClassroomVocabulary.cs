using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace ProyectoTCU
{
    public partial class ClassroomVocabulary : Form
    {

        
        Dictionary<Image, SoundPlayer> imagenSonido;
        Prepositions p;
        MenuClassroom mc;
        public ClassroomVocabulary()
        {
            WindowState = FormWindowState.Maximized;
            InitializeComponent();

            Image bp = new Bitmap(Properties.Resources.backpack);

            imagenSonido = new Dictionary<Image, SoundPlayer>();

            imagenSonido.Add(bp, new SoundPlayer(Properties.Resources.backpack_audio));
            imagenSonido.Add(Properties.Resources.pencil,new SoundPlayer(Properties.Resources.pencil_audio));
            imagenSonido.Add(Properties.Resources.Book, new SoundPlayer(Properties.Resources.book_audio));
            imagenSonido.Add(Properties.Resources.colorpencils,new SoundPlayer(Properties.Resources.color_pencils_audio));
            imagenSonido.Add(Properties.Resources.eraser, new SoundPlayer(Properties.Resources.eraser_audio));
            imagenSonido.Add(Properties.Resources.blue_scissors_, new SoundPlayer(Properties.Resources.scissors_audio));
            imagenSonido.Add(Properties.Resources.sharpener, new SoundPlayer(Properties.Resources.sharpener_audio));
            imagenSonido.Add(Properties.Resources.glue, new SoundPlayer(Properties.Resources.glue_audio));
            imagenSonido.Add(Properties.Resources.pen_silver, new SoundPlayer(Properties.Resources.pen_audio));
            imagenSonido.Add(Properties.Resources.yellow_notebook, new SoundPlayer(Properties.Resources.notebook_audio));
            imagenSonido.Add(Properties.Resources.clipart_crayons_1862, new SoundPlayer(Properties.Resources.crayons_audio));
            imagenSonido.Add(Properties.Resources.rule, new SoundPlayer(Properties.Resources.rule_audio));
            imagenSonido.Add(Properties.Resources.board, new SoundPlayer(Properties.Resources.board_audio));
            imagenSonido.Add(Properties.Resources.book_case, new SoundPlayer(Properties.Resources.bookcase_audio));
            imagenSonido.Add(Properties.Resources.chair, new SoundPlayer(Properties.Resources.chair_audio));
            imagenSonido.Add(Properties.Resources.crayons, new SoundPlayer(Properties.Resources.crayons_audio));
            imagenSonido.Add(Properties.Resources.table, new SoundPlayer(Properties.Resources.table_audio));

            pictureBox1.Image = imagenSonido.ElementAt(0).Key;
            pictureBoxbook.Image = imagenSonido.ElementAt(2).Key;
            pictureBoxcolorpencil.Image = imagenSonido.ElementAt(3).Key;
            pictureBoxpencil.Image = imagenSonido.ElementAt(1).Key;
            pictureBoxcrayons.Image = imagenSonido.ElementAt(10).Key;
            pictureBoxeraser.Image = imagenSonido.ElementAt(4).Key;
            pictureBoxglue.Image = imagenSonido.ElementAt(7).Key;
            pictureBoxpen.Image = imagenSonido.ElementAt(8).Key;
            pictureBoxscissors.Image = imagenSonido.ElementAt(5).Key;
            pictureBoxsharpener.Image = imagenSonido.ElementAt(6).Key;
            pictureBoxnotebook.Image = imagenSonido.ElementAt(9).Key;
            pictureBoxtable.Image = imagenSonido.ElementAt(16).Key;
            pictureBoxboard.Image = imagenSonido.ElementAt(12).Key;
            pictureBoxbookcase.Image = imagenSonido.ElementAt(13).Key;
            pictureBoxchair.Image = imagenSonido.ElementAt(14).Key;
            pictureBoxrule.Image = imagenSonido.ElementAt(11).Key;



        }

        private void ClassroomVocabulary_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_sonido(object sender, EventArgs e)
        {
            PictureBox pb =sender as PictureBox;
            
            try
            {
                imagenSonido[pb.Image].Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void ButtonMoreV_Click(object sender, EventArgs e)
        {
            p = new Prepositions();
            this.Hide();
            p.Show();
        }

        private void backB_Click(object sender, EventArgs e)
        {
            mc = new MenuClassroom();
            this.Hide();
            mc.Show();
        }

        
    }
}
