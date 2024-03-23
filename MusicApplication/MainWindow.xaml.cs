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
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            sliderSong.Value = mediaElement.Position.TotalSeconds;
            songPosition.Content = mediaElement.Position.ToString(@"mm\:ss");
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
            new addSongToPlaylist(this);
        }

        private void playBTN_Click(object sender, RoutedEventArgs e)
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
            nameLibrarySelected.Text = "Bài hát của bạn";
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
            if (isLoop)
            {
                mediaElement.Position = TimeSpan.Zero;
                mediaElement.Play();
            }else if (isShuffle)
            {
                Random random = new Random();
                new playSong(this, allSong[random.Next(0, allSong.Count)]);
            }else
            {
                playBTNImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/play.png"));
                new forward(this);
            }
        }

        private void shuffleBTN_Click(object sender, RoutedEventArgs e)
        {
            new shuffle(this);
        }
    }
}