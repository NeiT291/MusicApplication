using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MusicApplication.Functions
{
    class mute
    {
        public mute(MainWindow main)
        {
            if (main.mediaPlayer.settings.mute)
            {
                main.mediaPlayer.settings.mute = false;
                main.volumeBTN_Icon.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/medium_volume.png"));
            }
            else
            {
                main.mediaPlayer.settings.mute = true;
                main.volumeBTN_Icon.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/mute.png"));
            }
        }
    }
}
