using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Classes
{
    class Friend
    {
        public string Name { get; set; }
        public PlayList PlayList = new PlayList();

        public Friend(string name, PlayList playList)
        {
            Name = name;
            PlayList = playList;
        }
    }
}
