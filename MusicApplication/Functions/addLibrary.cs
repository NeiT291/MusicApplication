using Microsoft.Win32;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApplication.Functions
{
    class addLibrary
    {
        public addLibrary(MainWindow main)
        {
            Song song = new Song();

            var dialog = new OpenFolderDialog();

            if (dialog.ShowDialog() == true)
            {
                if (main.pathLibrarys.Exists(e => e.Equals(dialog.FolderName)))
                {
                    return;
                }
                main.pathLibrarys.Add(dialog.FolderName);
                main.listLibrary.Items.Add(dialog.SafeFolderName);

                main.allSong.AddRange(new loadSongs().loadFromPath(dialog.FolderName));
            }
        }

    }
}
