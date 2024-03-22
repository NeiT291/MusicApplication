using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Functions
{
    class home
    {
        public home(MainWindow main)
        {
            main.searchView.NavigationService.RemoveBackEntry();
            main.searchView.Content = null;
            main.allSong = new loadSongs().loadAllSong(main.pathLibrarys);

            main.listSong.ItemsSource = null;
            main.listSong.Items.Clear();
            
            for(int i = 0; i < main.allSong.Count; i++)
            {
                main.allSong[i].Index = i + 1;
                main.listSong.Items.Add(main.allSong[i]);
            }
           
        }
    }
}
