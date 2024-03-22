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

namespace MusicApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> pathLibrary = new List<string>();
        WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addLibraryBTN_Click(object sender, RoutedEventArgs e)
        {
            Song song = new Song();

            var dialog = new OpenFolderDialog();
            
            if(dialog.ShowDialog() == true)
            {
                if (pathLibrary.Exists(e => e.Equals(dialog.FolderName)))
                {
                    return;
                }
                this.pathLibrary.Add(dialog.FolderName);
                listLibrary.Items.Add(dialog.SafeFolderName);
            }
        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void listLibrary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameLibrarySelected.Text = listLibrary.SelectedValue.ToString();

            List<Song> songs = new List<Song>();
            
            var files = Directory.GetFiles(pathLibrary[listLibrary.SelectedIndex], "*.mp3");
            for (int i = 0;i< files.Length;i++)
            {
                Song song = new Song();

                song.Index = i + 1;

                IWMPMedia media = mediaPlayer.newMedia(files[i]);

                TagLib.File tagFile = TagLib.File.Create(files[i]);

                var firstPicture = tagFile.Tag.Pictures.FirstOrDefault();

                if (firstPicture != null)
                {
                    byte[] pData = firstPicture.Data.Data;
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(pData);
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    image.Freeze();
                    song.artwork = image;
                }

                song.nameSong = tagFile.Tag.Title;
                if (tagFile.Tag.Title == null)
                {
                    song.nameSong = Path.GetFileNameWithoutExtension(files[i]);
                }

                song.author = tagFile.Tag.Performers.FirstOrDefault();
                song.album = tagFile.Tag.Album;
                song.path = files[i];
                song.duration = media.duration;
                song.durationString = media.durationString;
                songs.Add(song);
            }
            
            listSong.ItemsSource = songs;
        }

        private void listSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void playBTN_Click(object sender, RoutedEventArgs e)
        {
            if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsUndefined)
            {
                return;
            }
            else if (mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Image playImage = (Image)((Button)sender).Content;
                playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/play.png"));
                dispatcherTimer.Stop();
                mediaPlayer.controls.pause();
            }
            else
            {
                Image playImage = (Image)((Button)sender).Content;
                playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));
                mediaPlayer.controls.play();
                dispatcherTimer.Start();
            }
        }

        private void loopBTN_Click(object sender, RoutedEventArgs e)
        {

            Image loopImage = (Image)((Button)sender).Content;
            loopImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/loopEnable.png"));
        }
        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    sliderSong.Value = mediaPlayer.controls.currentPosition;
        //}

        private void sliderSong_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.controls.currentPosition = sliderSong.Value;
        }

        private void playSongBTN_Click(object sender, RoutedEventArgs e)
        {
            Song song = (Song)((ListBoxItem)listSong.ContainerFromElement((Button)sender)).Content;

            Image playImage = (Image)playBTN.Content;
            playImage.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/pause.png"));
            mediaPlayer.URL = song.path;
            sliderSong.Maximum = song.duration;

            isPlayingSongArtwork.Source = song.artwork;
            if(song.artwork == null) {
                isPlayingSongArtwork.Source = new BitmapImage(new System.Uri("pack://application:,,,/icon/music.png"));
            }
            isPlayingSongName.Content = song.nameSong;
            isPlayingAuthor.Content = song.author;

            mediaPlayer.settings.volume = 10;
        }
    }
}