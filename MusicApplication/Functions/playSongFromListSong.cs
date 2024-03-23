using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace MusicApplication.Functions
{
    class playSongFromListSong
    {
        public playSongFromListSong(MainWindow main,ListBox listSong, object sender)
        {
            Song song = (Song)((ListBoxItem)listSong.ContainerFromElement((Button)sender)).Content;

            main.playBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));

            main.mediaElement.Source = new Uri(song.path);
            main.mediaElement.Play();
            main.timer.Start();
            main.isPlaying = true;

            main.sliderSong.Maximum = song.duration;
            main.isPlayingSongArtwork.Source = song.artwork;
            main.isPlayingSongName.Content = song.nameSong;
            main.isPlayingAuthor.Content = song.author;
        }
    }
}
