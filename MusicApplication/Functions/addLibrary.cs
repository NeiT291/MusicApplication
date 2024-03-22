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
                if (main.pathLibrary.Exists(e => e.Equals(dialog.FolderName)))
                {
                    return;
                }
                main.pathLibrary.Add(dialog.FolderName);
                main.listLibrary.Items.Add(dialog.SafeFolderName);
            }
        }

    }
}
