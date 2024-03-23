using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicApplication.Functions
{
    class shuffle
    {
        public shuffle(MainWindow main)
        {
            if (main.isShuffle)
            {
                main.shuffleBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/shuffle.png"));
                main.isShuffle = false;
            }
            else
            {
                main.shuffleBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/shuffleEnable.png"));
                main.isShuffle = true;
            }
        }
    }
}
