using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Functions
{
    class search
    {
        public search(MainWindow main) 
        {
            if (main.searchView.Content != null)
            {
                return;
            }
            main.searchView.Content = new SearchPage(main);
        }
    }
}
