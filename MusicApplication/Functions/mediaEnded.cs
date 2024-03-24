using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicApplication.Functions
{
    class mediaEnded
    {
        public mediaEnded(MainWindow main)
        {
            if (main.isLoop)
            {
                main.mediaElement.Position = TimeSpan.Zero;
                main.mediaElement.Play();
            }
            else if (main.isShuffle)
            {
                Random random = new Random();
                new playSong(main, main.allSong[random.Next(0, main.allSong.Count - 1)]);
            }
            else
            {
                main.playBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/play.png"));
                new forward(main);
            }
        }
    }
}
