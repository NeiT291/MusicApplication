using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MusicApplication.Models
{
    public class Song
    {
        public int Index { get; set; }
        public BitmapImage artwork {  get; set; }
        public string path { get; set; }
        public string nameSong { get; set; }
        public string author { get; set; }
        public string album { get; set; }
        public string durationString { get; set; }
        public double duration { get; set; }
        public Song() { }
        public Song(int Index, BitmapImage artwork, string path, string nameSong, string author, string album, string durationString, double duration)
        {
            this.Index = Index;
            this.artwork = artwork;
            this.path = path;
            this.nameSong = nameSong;
            this.author = author;
            this.album = album;
            this.durationString = durationString;
            this.duration = duration;
        }
    }
}
