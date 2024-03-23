using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace MusicApplication.Functions
{
    class loadSongs
    {
        public List<Song> loadFromPath(string path)
        {
            List<Song> songs = new List<Song>();
            var files = Directory.GetFiles(path, "*.mp3");
            for (int i = 0; i < files.Length; i++)
            {
                Song song = new Song();

                song.Index = i + 1;

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
                else
                {
                    song.artwork = new BitmapImage(new System.Uri("pack://application:,,,/icon/music.png"));
                }

                song.nameSong = tagFile.Tag.Title;
                if (tagFile.Tag.Title == null)
                {
                    song.nameSong = Path.GetFileNameWithoutExtension(files[i]);
                }

                song.author = tagFile.Tag.Performers.FirstOrDefault();
                song.album = tagFile.Tag.Album;
                song.path = files[i];
                song.duration = Math.Truncate(tagFile.Properties.Duration.TotalSeconds);
                
                song.durationString = tagFile.Properties.Duration.ToString(@"mm\:ss");

                songs.Add(song);
            }
            return songs;
        }
        public List<Song> loadAllSong(List<string> paths)
        {
            List<Song> allSong = new List<Song>();
            for (int i = 0; i < paths.Count; i++)
            {
                allSong.AddRange(loadFromPath(paths[i]));
            }
            return allSong;
        }
        public void test(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;
            MessageBox.Show(mediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }
    }
}
