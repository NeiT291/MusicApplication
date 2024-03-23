using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;

namespace MusicApplication.Functions
{
    class playAndPause
    {
        public playAndPause(MainWindow main)
        {
            
            if (main.isPlaying)
            {
                
                main.playBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/play.png"));
                main.mediaElement.Pause();
                main.isPlaying = false;
                main.timer.Stop();
            }
            else
            {
                main.playBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));
                main.mediaElement.Play();
                main.isPlaying = true;
                main.timer.Start();
            }
        }
    }
}
