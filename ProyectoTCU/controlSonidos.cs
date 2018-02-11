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
            SoundPlayer s = new SoundPlayer(Properties.Resources.perderjuego_audio);
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
