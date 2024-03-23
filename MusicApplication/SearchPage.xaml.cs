using MusicApplication.Functions;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApplication
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        MainWindow main { get; set; }
        public SearchPage(MainWindow main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            listSong.Items.Clear();
            string search = searchTB.Text;
            if(search == "")
            {
                return;
            }
            string[] word = search.Split(' ');

            search = "";

            foreach (string w in word)
            {
                if (w != "")
                {
                    search = search + w + " ";
                }
            }

            search = search.Trim();

            var result = from Song song in main.allSong
                          where song.nameSong.ToLower().Contains(search.ToLower())
                          select song;

            List<Song> listResult = result.ToList<Song>(); 
            for (int i = 0;i< listResult.Count();i++)
            {
                listResult[i].Index = i+1;
                this.listSong.Items.Add(listResult[i]);
            }
            

        }

        private void playSongBTN_Click(object sender, RoutedEventArgs e)
        {
            new playSongFromListSong(main,this.listSong, sender);
        }
    }
}
