using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Classes
{
    public class Track
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Track(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }
    }
}
