﻿using Microsoft.Win32;
using MusicApplication.Models;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TagLib;
using Path = System.IO.Path;
using System.Drawing;
using System.Resources;
using System.Windows.Threading;
using MusicApplication.Functions;
using System.Net;
using System.Net.Http;
using System.Windows.Media.TextFormatting;

namespace MusicApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Song> allSong = new List<Song>();
        public List<Song> playlist = new List<Song>();
        public List<string> pathLibrarys = new List<string>();
        public int playlistIndex = -1;
        public bool isPlaying = false;
        public bool isLoop = false;
        public bool isShuffle = false;

        public DispatcherTimer timer = new DispatcherTimer();
        
        
        
        public MainWindow()
        {
            InitializeComponent();
            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            LoadPathLibrary();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            sliderSong.Value = mediaElement.Position.TotalSeconds;
            songPosition.Content = mediaElement.Position.ToString(@"mm\:ss");
        }

        private void addLibraryBTN_Click(object sender, RoutedEventArgs e)
        {
            new addLibrary(this);
            System.IO.File.WriteAllText("../../../LibraryPath.txt", "");
            System.IO.File.WriteAllLinesAsync("../../../LibraryPath.txt", pathLibrarys);
        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
            new search(this);
        }

        private void listLibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLibrary.SelectedItem == null)
            {
                return;
            }
            nameLibrarySelected.Text = listLibrary.SelectedValue.ToString();
            listSong.ItemsSource = null;
            listSong.Items.Clear();
            listSong.ItemsSource = new loadSongs().loadFromPath(pathLibrarys[listLibrary.SelectedIndex]);
        }

        private void listSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            new addSongToPlaylist(this);
        }

        private async void playBTN_Click(object sender, RoutedEventArgs e)
        {
            new playAndPause(this);
        }

        private void loopBTN_Click(object sender, RoutedEventArgs e)
        {

            new loop(this, sender);
        }

        private void playSongBTN_Click(object sender, RoutedEventArgs e)
        {
            new playSongFromListSong(this,this.listSong, sender);
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            new changeVolume(this);
        }

        private void volumeBTN_Click(object sender, RoutedEventArgs e)
        {
            new mute(this);
            
        }

        private void homeBTN_Click(object sender, RoutedEventArgs e)
        {
            new home(this);
        }

        private void playlistBTN_Click(object sender, RoutedEventArgs e)
        {
            new playlist(this);
        }

        private void forwardBTN_Click(object sender, RoutedEventArgs e)
        {
            new forward(this);
        }

        private void backwardBTN_Click(object sender, RoutedEventArgs e)
        {
           new backward(this);
        }

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            songDuration.Content = mediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }

        private void sliderSong_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mediaElement.Position = new TimeSpan(0, 0, 0, (int)sliderSong.Value);
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            new mediaEnded(this);
        }

        private void shuffleBTN_Click(object sender, RoutedEventArgs e)
        {
            new shuffle(this);
        }
        public void LoadPathLibrary()
        {
            string[] Paths = System.IO.File.ReadAllLines("../../../LibraryPath.txt");

            foreach (string Path in Paths)
            {
                if (Directory.Exists(Path))
                {
                    pathLibrarys.Add(Path);
                    listLibrary.Items.Add(System.IO.Path.GetFileName(Path));
                }
            }
            System.IO.File.WriteAllLinesAsync("../../../LibraryPath.txt", pathLibrarys);
        }

        private void deleteLibrary(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = listLibrary.Items.IndexOf(button.DataContext);
            pathLibrarys.RemoveAt(index);
            listLibrary.Items.RemoveAt(index);
            System.IO.File.WriteAllLinesAsync("../../../LibraryPath.txt", pathLibrarys);
        }
    }
}