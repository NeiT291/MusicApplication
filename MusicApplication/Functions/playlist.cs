using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApplication.Functions
{
    class playlist
    {
        public playlist(MainWindow main)
        {
            if (main.playlistPandel.Width.Value == 0)
            {
                main.playlistPandel.Width = new GridLength(300);
            }
            else
            {
                main.playlistPandel.Width = new GridLength(0);
            }
        }
    }
}
