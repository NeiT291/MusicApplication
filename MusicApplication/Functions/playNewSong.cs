using MusicApplication.Models;
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
    class playNewSong
    {
        public playNewSong(MainWindow main,ListBox listSong, object sender)
        {
            Song song = (Song)((ListBoxItem)listSong.ContainerFromElement((Button)sender)).Content;

            Image playImage = (Image)main.playBTN.Content;
            playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));
            main.mediaPlayer.URL = song.path;
            main.sliderSong.Maximum = song.duration;

            main.isPlayingSongArtwork.Source = song.artwork;
            if (song.artwork == null)
            {
                main.isPlayingSongArtwork.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/music.png"));
            }
            main.isPlayingSongName.Content = song.nameSong;
            main.isPlayingAuthor.Content = song.author;

            main.mediaPlayer.settings.volume = 10;
        }
    }
}
