using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Functions
{
    class backward
    {
        public backward(MainWindow main)
        {
            if (main.playlistIndex - 1 < 0)
            {
                return;
            }
            
            main.playlistIndex--;
            new playSong(main, main.playlist[main.playlistIndex]);
            main.listPlayList.Items.Clear();
            for (int i = main.playlistIndex + 1; i < main.playlist.Count; i++)
            {
                main.listPlayList.Items.Add(main.playlist[i]);
            }
        }
    }
}
