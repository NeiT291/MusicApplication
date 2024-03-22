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
        Window main { get; set; }
        public SearchPage(Window main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if(listSong.Items != null)
            //{
            //    listSong.Items.Clear();
            //}

            string search = searchTB.Text;
            //if (search == "")
            //{
            //    listSong.Items.Clear();
            //}


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

            //Debug.Write(word);
            //var search1 = from Song song in mainView.Songs
            //              where song.Name.ToLower().Contains(search.ToLower())
            //              select song;

            //int count = 1;
            //foreach (Song song in search1)
            //{
            //    SongItem songItem = song.toSongItem();
            //    songItem.Count = count;
            //    songItem.Width = searchListSong.Width - 30;
            //    searchListSong.Controls.Add(songItem);
            //    songItem.Click += new EventHandler(playSongIcon_Click);
            //    count++;
            //}
        }
    }
}
