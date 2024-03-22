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
            if (main.playlistPanel.Width.Value == 0)
            {
                main.playlistPanel.Width = new GridLength(300);
            }
            else
            {
                main.playlistPanel.Width = new GridLength(0);
            }
        }
    }
}
