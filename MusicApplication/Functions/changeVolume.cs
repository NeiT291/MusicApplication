using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MusicApplication.Functions
{
    class changeVolume
    {
        public changeVolume(MainWindow main)
        {
            main.mediaPlayer.settings.volume = Convert.ToInt32(main.sliderVolume.Value);
            if (main.sliderVolume.Value < 30)
            {
                main.volumeBTN_Icon.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/low_volume.png"));
            }
            else if (main.sliderVolume.Value < 70)
            {
                main.volumeBTN_Icon.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/medium_volume.png"));
            }
            else
            {
                main.volumeBTN_Icon.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/hight_volume.png"));
            }
        }
    }
}
