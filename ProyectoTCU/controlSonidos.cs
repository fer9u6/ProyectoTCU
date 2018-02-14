using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ProyectoTCU
{
    public class controlSonidos
    {
        public void sonidoGanar()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.ganarjuego_audio);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoPerder()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.errorperder_audio);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoGanarSebastian()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.correctSound);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoPerderSebastian()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.wrongSound);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoTerminarBien()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.fireworkSound);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoTerminar()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.crackerSound);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }

        public void sonidoOpcion()
        {
            SoundPlayer s = new SoundPlayer(Properties.Resources.popSound);
            try
            {
                s.Play();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message);
            }
        }


    }
   
}
