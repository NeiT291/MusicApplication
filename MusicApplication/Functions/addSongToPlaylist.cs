using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MusicApplication.Functions
{
    class addSongToPlaylist
    {
        public addSongToPlaylist(MainWindow main) 
        {
            if (main.listSong.SelectedItem == null)
            {
                return;
            }
            Song song = (Song)main.listSong.SelectedItem;

            main.playlist.Add(song);

            main.listPlayList.Items.Clear();

            for (int i = main.playlistIndex + 1; i < main.playlist.Count; i++)
            {
                main.listPlayList.Items.Add(main.playlist[i]);
            }
        }
    }
}
