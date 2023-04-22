using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Classes
{
    class Album
    {
        public string Artist { get; set; }
        public List<Track> Tracks { get; set; }

        public Album(string artist, List<Track> tracks)
        {
            Artist = artist;
            Tracks = tracks;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }
    }
}
