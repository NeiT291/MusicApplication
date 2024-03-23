using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Functions
{
    class forward
    {
        public forward(MainWindow main)
        {
            if (main.playlistIndex + 1 >= main.playlist.Count)
            {
                return;
            }
            
            main.playlistIndex++;
            new playSong(main, main.playlist[main.playlistIndex]);
            main.listPlayList.Items.Clear();
            for (int i = main.playlistIndex + 1; i < main.playlist.Count; i++)
            {
                main.listPlayList.Items.Add(main.playlist[i]);
            }
        }
    }
}
