
using Spotify.Classes;

List<Track> allTracks = new List<Track>
{
    new Track("Song 1", "Artist 1"),
    new Track("Song 2", "Artist 2"),
    new Track("Song 3", "Artist 3"),
    new Track("Song 4", "Artist 4"),
    new Track("Song 5", "Artist 5"),
    new Track("Song 6", "Artist 2"),
    new Track("Song 7", "Artist 2"),
    new Track("Song 8", "Artist 2"),
    new Track("Song 9", "Artist 9"),
    new Track("Song 10", "Artist 5"),
    new Track("Song 11", "Artist 6"),
    new Track("Song 12", "Artist 7")
};

List<PlayList> playLists = new List<PlayList>();

List<Album> albums = new List<Album>();

List<Friend> friendList = new List<Friend>();

Dictionary<string, List<Track>> tracksByArtist = new Dictionary<string, List<Track>>();

foreach (var track in allTracks)
{
    if (!tracksByArtist.ContainsKey(track.Artist)){
        tracksByArtist[track.Artist] = new List<Track>();
    }

    tracksByArtist[track.Artist].Add(track);
}

foreach (var kvp in tracksByArtist)
{
    string artist = kvp.Key;
    List<Track> tracks = kvp.Value;

    Album album = new Album(artist, tracks);
    albums.Add(album);
}

Track track1 = new Track("Song 13", "Artist 13");
Track track2 = new Track("Song 14", "Artist 14");
Track track3 = new Track("Song 15", "Artist 13");
Track track4 = new Track("Song 16", "Artist 15");
Track track5 = new Track("Song 17", "Artist 9");
Track track6 = new Track("Song 7", "Artist 2");


PlayList playList1 = new PlayList();
PlayList playList2 = new PlayList();
PlayList playList3 = new PlayList();

playList1.Tracks.Add(track1);
playList1.Tracks.Add(track2);
playList2.Tracks.Add(track3);
playList2.Tracks.Add(track4);
playList3.Tracks.Add(track5);
playList3.Tracks.Add(track6);


Friend friend1 = new Friend("Peter", playList1);
Friend friend2 = new Friend("Mike", playList2);
Friend friend3 = new Friend("Karel", playList3);

friendList.Add(friend1);
friendList.Add(friend2);
friendList.Add(friend3);


bool running = true;
int currentTrackIndex = 0;
bool isPlaying = false;

bool isAllTracks = true;
bool isPlaylist = false;
bool isAlbum = false;
PlayList currentPlaylist = new PlayList();
Album currentAlbum = null;




while (running)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("0.Shut Down");
    Console.WriteLine("1.Play");
    Console.WriteLine("2.Pauze");
    Console.WriteLine("3.Next");
    Console.WriteLine("4.Previous");
    Console.WriteLine("5.Create New Playlist");
    Console.WriteLine("6.Show Playlist");
    Console.WriteLine("7.Add Track To Playlist");
    Console.WriteLine("8.Show All Albums");
    Console.WriteLine("9.Show Friends");

    int input;
    bool validation = int.TryParse(Console.ReadLine(), out input);

    if (validation)
    {

        switch (input)
        {
            case 0:
                running = false; 
                break;

            case 1:
                if (!isPlaying)
                {
                    // Plays the current track
                    isPlaying = true;
                    Console.WriteLine("---------------------");
                    if (isAllTracks)
                    {
                        Console.WriteLine($"Now playing: {allTracks[currentTrackIndex].Title} - {allTracks[currentTrackIndex].Artist}");
                    }
                    if (isPlaylist)
                    {
                        Console.WriteLine($"Now playing: {currentPlaylist.Tracks[currentTrackIndex].Title} - {currentPlaylist.Tracks[currentTrackIndex].Artist}");
                    }
                    if (isAlbum)
                    {
                        Console.WriteLine($"Now playing: {currentAlbum.Tracks[currentTrackIndex].Title} - {currentAlbum.Tracks[currentTrackIndex].Artist}");
                    }
                        Console.WriteLine("---------------------");

                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Music is already playing.");
                    Console.WriteLine("---------------------");
                }
                break;

            case 2:
                if (isPlaying)
                {
                    // Pause the current track
                    isPlaying = false;
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Music paused.");
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Music is not playing.");
                    Console.WriteLine("---------------------");
                }
                break;

            case 3:
                if (isPlaying)
                {
                    if (isAllTracks)
                    {
                        currentTrackIndex++;
                        if (currentTrackIndex >= allTracks.Count)
                        {
                            currentTrackIndex = 0;
                        }
                    }
                    if (isPlaylist)
                    {
                        currentTrackIndex++;
                        if (currentTrackIndex >= currentPlaylist.Tracks.Count)
                        {
                            currentTrackIndex = 0;
                        }
                    }
                    if (isAlbum)
                    {
                        currentTrackIndex++;
                        if (currentTrackIndex >= currentAlbum.Tracks.Count)
                        {
                            currentTrackIndex = 0;
                        }
                    }

                    Console.WriteLine("---------------------");

                    if (isAllTracks)
                    {
                        Console.WriteLine($"Now playing: {allTracks[currentTrackIndex].Title} - {allTracks[currentTrackIndex].Artist}");
                    }
                    if (isPlaylist)
                    {
                        Console.WriteLine($"Now playing: {currentPlaylist.Tracks[currentTrackIndex].Title} - {currentPlaylist.Tracks[currentTrackIndex].Artist}");
                    }
                    if (isAlbum)
                    {
                        Console.WriteLine($"Now playing: {currentAlbum.Tracks[currentTrackIndex].Title} - {currentAlbum.Tracks[currentTrackIndex].Artist}");
                    }
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Music is not playing.");
                    Console.WriteLine("---------------------");
                }
                break;

            case 4:
                Console.WriteLine("Previous");
                if (currentTrackIndex == 0)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("You are already at the beginning of the playlist");
                    Console.WriteLine("---------------------");
                }
                else
                {
                    // Move to the previous track
                    currentTrackIndex--;

                    if (isAllTracks)
                    {
                    Console.WriteLine("---------------------");
                    Console.WriteLine($"Now playing: {allTracks[currentTrackIndex].Title} - {allTracks[currentTrackIndex].Artist}");
                    Console.WriteLine("---------------------");
                    }
                    if (isPlaying)
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Now playing: {currentAlbum.Tracks[currentTrackIndex].Title} - {currentAlbum.Tracks[currentTrackIndex].Artist}");
                        Console.WriteLine("---------------------");
                    }

                }
                break;

            case 5:
                Console.WriteLine("---------------------");
                Console.WriteLine("Create New Playlist");
                Console.WriteLine("---------------------");

                // Maak een nieuwe afspeellijst aan
                PlayList newPlayList = new PlayList();
                playLists.Add(newPlayList);

                // Vraag de gebruiker om een naam voor de afspeellijst in te voeren
                Console.WriteLine("---------------------");
                Console.WriteLine("Enter a name for the new playlist:");
                Console.WriteLine("---------------------");
                newPlayList.Title = Console.ReadLine();
                break;

            case 6:
                Console.WriteLine("---------------------");
                Console.WriteLine("Show Playlists");
                Console.WriteLine("---------------------");
                if (playLists.Count == 0)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("There are no playlists available.");
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Available playlists:");
                    Console.WriteLine("---------------------");
                    for (int i = 0; i < playLists.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {playLists[i].Title}");
                    }

                    Console.WriteLine("---------------------");
                    Console.WriteLine("Enter the number of the playlist to play:");
                    Console.WriteLine("---------------------");
                    int playlistNumber;
                    int trackNumber;
                    bool validPlaylistNumber = int.TryParse(Console.ReadLine(), out playlistNumber);

                    if (validPlaylistNumber && playlistNumber > 0 && playlistNumber <= playLists.Count)
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Available tracks:");
                        Console.WriteLine("---------------------");
                        // Get the selected playlist
                        PlayList selectedPlaylist = playLists[playlistNumber - 1];

                        for (int i = 0; i < selectedPlaylist.Tracks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {selectedPlaylist.Tracks[i].Title} - {selectedPlaylist.Tracks[i].Artist}");
                        }

                        Console.WriteLine("---------------------");
                        Console.WriteLine("Enter the number of the track for options:");
                        Console.WriteLine("---------------------");

                        bool validTrackNumber = int.TryParse(Console.ReadLine(), out trackNumber);

                        if (validTrackNumber && trackNumber > 0 && trackNumber <= selectedPlaylist.Tracks.Count)
                        {
                            Track selectedTrack = selectedPlaylist.Tracks[trackNumber - 1];

                            Console.WriteLine("---------------------");
                            Console.WriteLine("What do you want to do:");
                            Console.WriteLine("1.Play track");
                            Console.WriteLine("2.Delete track");
                            Console.WriteLine("---------------------");

                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    // Play the selected playlist
                                    Console.WriteLine($"Playing playlist '{selectedPlaylist.Title}':");
                                    foreach (var track in selectedPlaylist.Tracks)
                                    {
                                        Console.WriteLine("---------------------");
                                        Console.WriteLine($"In playlist: {track.Title} - {track.Artist}");
                                        Console.WriteLine("---------------------");
                                    }

                                    Console.WriteLine($"Now playing: {selectedTrack.Title} by {selectedTrack.Artist}");

                                    isAllTracks = false;
                                    isPlaylist = true;
                                    currentPlaylist = selectedPlaylist;
                                    currentTrackIndex = trackNumber - 1;
                                    break;
                                case 2:
                                    selectedPlaylist.Tracks.RemoveAt(trackNumber - 1);

                                    Console.WriteLine("---------------------");
                                    Console.WriteLine($"{selectedTrack.Title} by {selectedTrack.Artist} is deleted from {selectedPlaylist.Title}");
                                    Console.WriteLine("---------------------");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Invalid playlist number");
                            Console.WriteLine("---------------------");
                        }

                    }
                    else
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Invalid playlist number.");
                        Console.WriteLine("---------------------");
                    }
                }
                break;

            case 7:
                Console.WriteLine("---------------------");
                Console.WriteLine("Add Track to Playlist");
                Console.WriteLine("---------------------");
                if (playLists.Count == 0)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("There are no playlists available.");
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Available playlists:");
                    Console.WriteLine("---------------------");
                    for (int i = 0; i < playLists.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {playLists[i].Title}");
                    }

                    Console.WriteLine("Enter the number of the playlist to add a track to:");
                    int playlistNumber;
                    bool validPlaylistNumber = int.TryParse(Console.ReadLine(), out playlistNumber);

                    if (validPlaylistNumber && playlistNumber > 0 && playlistNumber <= playLists.Count)
                    {
                        // Get the selected playlist
                        PlayList selectedPlaylist = playLists[playlistNumber - 1];

                        // Ask for track details
                        Console.WriteLine("Enter track title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter track artist:");
                        string artist = Console.ReadLine();

                        // Create a new track object
                        Track newTrack = new Track(title, artist); // Update with relevant track properties

                        // Add the new track to the selected playlist
                        allTracks.Add(newTrack);
                        selectedPlaylist.Tracks.Add(newTrack);

                        Console.WriteLine("---------------------");
                        Console.WriteLine($"Track '{title}' by '{artist}' added to playlist '{selectedPlaylist.Title}'.");
                        Console.WriteLine("---------------------");
                    }
                    else
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Invalid playlist number. Please try again.");
                        Console.WriteLine("---------------------");
                    }
                }
                break;

            case 8:
                Console.WriteLine("---------------------");
                Console.WriteLine("Show albums");
                Console.WriteLine("---------------------");
                if (albums.Count == 0)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("There are no albums available.");
                    Console.WriteLine("---------------------");
                }
                else
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Available albums:");
                    for (int i = 0; i < albums.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {albums[i].Artist}");
                    }
                    Console.WriteLine("---------------------");


                    Console.WriteLine("Enter the number of the album:");
                    int albumNumber;
                    int answer;
                    int trackNumber;
                    bool validAlbumNumber = int.TryParse(Console.ReadLine(), out albumNumber);

                    if (validAlbumNumber && albumNumber > 0 && albumNumber <= albums.Count)
                    {
                        // Get the selected album
                        Album selectedAlbum = albums[albumNumber - 1];

                        Console.WriteLine("---------------------");
                        Console.WriteLine("What Would you like to do:");
                        Console.WriteLine("1.Add album to playlist");
                        Console.WriteLine("2.Play album");
                        Console.WriteLine("---------------------");

                        int option = Convert.ToInt32(Console.ReadLine());

                        switch (option)
                        {
                            case 1:
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Available playlists:");
                            for (int i = 0; i < playLists.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {playLists[i].Title}");
                            }
                            Console.WriteLine("---------------------");

                            Console.WriteLine("Enter the number of the playlist to add all tracks to:");
                            int playlistNumber;
                            bool validPlaylistNumber = int.TryParse(Console.ReadLine(), out playlistNumber);

                            if (validPlaylistNumber && playlistNumber > 0 && playlistNumber <= playLists.Count)
                                {
                                // Get the selected playlist
                                PlayList selectedPlaylist = playLists[playlistNumber - 1];

                                Console.WriteLine(selectedPlaylist.Title);

                                // Loop through all tracks in the selected album and add them to the playlist
                                foreach (Track track in selectedAlbum.Tracks)
                                {
                                    selectedPlaylist.Tracks.Add(track);
                                }

                                Console.WriteLine("---------------------");
                                Console.WriteLine($"All tracks from album '{selectedAlbum.Artist}' added to playlist '{selectedPlaylist.Title}'.");
                                Console.WriteLine("---------------------");
                            }
                            else
                            {
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Invalid playlist number");
                                Console.WriteLine("---------------------");
                            }
                                break;
                            case 2:
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Available Albums:");

                                for (int i = 0; i < selectedAlbum.Tracks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {selectedAlbum.Tracks[i].Title}");
                                }

                                Console.WriteLine("---------------------");
                                Console.WriteLine("Enter the number of the track to play:");

                                bool validTrackNumber = int.TryParse(Console.ReadLine(), out trackNumber);

                                if (validTrackNumber && trackNumber > 0 && trackNumber <= selectedAlbum.Tracks.Count)
                                {
                                    isPlaylist = false;
                                    isAllTracks = false;
                                    isAlbum = true;

                                    Track selectedTrack = selectedAlbum.Tracks[trackNumber - 1];

                                    currentAlbum = selectedAlbum;
                                    currentTrackIndex = trackNumber - 1;

                                    // Play the selected playlist
                                    Console.WriteLine($"Playing album '{selectedAlbum.Artist}':");
                                    foreach (var track in selectedAlbum.Tracks)
                                    {
                                        Console.WriteLine("---------------------");
                                        Console.WriteLine($"In playlist: {track.Title} - {track.Artist}");
                                        Console.WriteLine("---------------------");
                                    }
                                        Console.WriteLine($"Now playing: {selectedTrack.Title} by {selectedTrack.Artist}");

                                }
                                break;
                            default:
                                Console.WriteLine("---------------------");
                                Console.WriteLine("That is not a valid option");
                                Console.WriteLine("---------------------");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("---------------------");
                        Console.WriteLine("Invalid album number");
                        Console.WriteLine("---------------------");
                    }
                }
                break;
            case 9:
                Console.WriteLine("---------------------");
                Console.WriteLine("Your friends:");
                Console.WriteLine("---------------------");

                //Gets all the friends
                for (int i = 0; i < friendList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{friendList[i].Name}");
                }
                Console.WriteLine("---------------------");

                Console.WriteLine("Enter the number of a friend to check:");

                int friendNumber;

                bool validFriendNumber = int.TryParse(Console.ReadLine(), out friendNumber);

                if (validFriendNumber && friendNumber > 0 && friendNumber <= friendList.Count)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("What do you want to do:");
                    Console.WriteLine("1.Check playlist");
                    Console.WriteLine("2.Compare playlist");
                    Console.WriteLine("3.Add playlist to my playlist");
                    Console.WriteLine("---------------------");

                    int option = Convert.ToInt32(Console.ReadLine());

                    Friend currentFriend = friendList[friendNumber - 1];

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("---------------------");
                            for (int i = 0; i < currentFriend.PlayList.Tracks.Count; i++)
                            {
                                Console.WriteLine($"In playlist: {currentFriend.PlayList.Tracks[i].Title} - {currentFriend.PlayList.Tracks[i].Artist}");
                            }
                            Console.WriteLine("---------------------");

                            break;
                        case 2:
                            Console.WriteLine("---------------------");
                            for (int i = 0; i < playLists.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{playLists[i].Title}");
                            }
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Enter a number of a playlist to compare");

                            int playListNumber;
                            bool validPlayListNumber = int.TryParse(Console.ReadLine(), out playListNumber);

                            if (validPlayListNumber && playListNumber > 0 && playListNumber <= playLists.Count)
                            {
                                PlayList playListToCompare = playLists[playListNumber - 1];
                                List<Track> matchingTracks = new List<Track>();

                                foreach (var myTrack in playListToCompare.Tracks)
                                {
                                    foreach (var friendTrack in currentFriend.PlayList.Tracks)
                                    {
                                        if (friendTrack.Title == myTrack.Title && friendTrack.Artist == myTrack.Artist)
                                        {
                                            matchingTracks.Add(myTrack);
                                        }
                                    }
                                }

                                Console.WriteLine("---------------------");
                                Console.WriteLine("Matching tracks:");
                                foreach (var track in matchingTracks)
                                {
                                    Console.WriteLine($"{track.Title} - {track.Artist}");
                                }
                                Console.WriteLine("---------------------");
                            }
                            else
                            {
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Invaled number");
                                Console.WriteLine("---------------------");

                            }
                            break;
                        case 3:
                            Console.WriteLine("---------------------");
                            for (int i = 0; i < playLists.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}.{playLists[i].Title}");
                            }
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Enter a number of a playlist to add to");

                            int playListAddNumber;
                            bool validPlayListAddNumber = int.TryParse(Console.ReadLine(), out playListAddNumber);

                            if (validPlayListAddNumber && playListAddNumber > 0 && playListAddNumber <= playLists.Count)
                            {
                                PlayList playListResult = playLists[playListAddNumber - 1];

                                Console.WriteLine("---------------------");

                                var missingTracks = currentFriend.PlayList.Tracks.Where(x => playListResult.Tracks.Any(y => y.Title == x.Title && y.Artist == x.Artist)).ToList();

                                playListResult.Tracks.AddRange(missingTracks);

                                foreach (var track in missingTracks)
                                {
                                    playListResult.Tracks.Add(track);
                                    Console.WriteLine($"{track.Title} - {track.Artist} has been added to {playListResult.Title}");
                                }
                                Console.WriteLine("---------------------");
                            }
                            break;
                    }
                }

                break;
        }
    }
    else
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Please enter a valid number");
        Console.WriteLine("---------------------");
    }




}

