using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MusicApplication.Functions
{
    class loop
    {
        public loop(MainWindow main, object sender)
        {
            Image loopImage = (Image)((Button)sender).Content;
            if (main.mediaPlayer.settings.getMode("loop"))
            {
                loopImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/loop.png"));
                main.mediaPlayer.settings.setMode("loop", false);
            }
            else
            {
                loopImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/loopEnable.png"));
                main.mediaPlayer.settings.setMode("loop", true);
            }
        }
    }
}
