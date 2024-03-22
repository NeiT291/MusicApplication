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
    class play
    {
        public play(MainWindow main, object sender)
        {
            if (main.mediaPlayer.playState == WMPLib.WMPPlayState.wmppsUndefined)
            {
                return;
            }
            else if (main.mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Image playImage = (Image)((Button)sender).Content;
                playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/play.png"));
                main.mediaPlayer.controls.pause();
            }
            else
            {
                Image playImage = (Image)((Button)sender).Content;
                playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));
                main.mediaPlayer.controls.play();
            }
        }
    }
}
