using Microsoft.Win32;
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
using WMPLib;
using System.Resources;
using System.Windows.Threading;
using MusicApplication.Functions;

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
        public WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void addLibraryBTN_Click(object sender, RoutedEventArgs e)
        {
            new addLibrary(this);
        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
            new search(this);
        }

        private void listLibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameLibrarySelected.Text = listLibrary.SelectedValue.ToString();
            listSong.ItemsSource = null;
            listSong.Items.Clear();
            listSong.ItemsSource = new loadSongs().loadFromPath(pathLibrarys[listLibrary.SelectedIndex]);
        }

        private void listSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listSong.SelectedItem == null) 
            {
                return;
            }
            Song song = (Song)listSong.SelectedItem;
            playlist.Add(song);
            
            mediaPlayer.currentPlaylist.appendItem(mediaPlayer.newMedia(song.path));

            listPlayList.Items.Add(song);
        }

        private void playBTN_Click(object sender, RoutedEventArgs e)
        {
            new play(this, sender);
        }

        private void loopBTN_Click(object sender, RoutedEventArgs e)
        {

            new loop(this, sender);
        }
        

        private void sliderSong_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.controls.currentPosition = sliderSong.Value;
        }

        private void playSongBTN_Click(object sender, RoutedEventArgs e)
        {
            new playNewSong(this,this.listSong, sender);
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
            nameLibrarySelected.Text = "Bài hát của bạn";
            new home(this);
        }

        private void playlistBTN_Click(object sender, RoutedEventArgs e)
        {
            new playlist(this);
        }

        private void forwardBTN_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.controls.next();
        }

        private void backwardBTN_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.controls.previous();
        }
    }
}