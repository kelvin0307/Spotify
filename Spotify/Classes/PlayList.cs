using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Classes
{
    public class PlayList
    {
        public string Title { get; set; }
        public List<Track>? Tracks = new List<Track>();
    }
}
