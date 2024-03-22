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
        }
    }
}
