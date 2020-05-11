using System;
using System.Collections.Generic;
using System.Threading;
namespace ProyectoGRUPO2
{
    public class PlaylistVideoEmptyClass
    {
        private string typeFile;
        private string namePlaylist;
        private List<Video> playlist;
        private List<Video> playlistFav;

        public PlaylistVideoEmptyClass(string typeFile, List<Video> playlist, List<Video> playlistFav, string namePlaylist)
        {
            this.TypeFile = typeFile;
            Playlist = playlist;
            PlaylistFav = playlistFav;
            this.NamePlaylist = namePlaylist;
        }

        public string TypeFile { get => typeFile; set => typeFile = value; }
        public List<Video> Playlist { get => playlist; set => playlist = value; }
        public List<Video> PlaylistFav { get => playlistFav; set => playlistFav = value; }
        public string NamePlaylist { get => namePlaylist; set => namePlaylist = value; }

        public bool AddPlaylist()
        {
            return true;
        }
        public bool AddPlaylistFav()
        {
            return true;
        }
        public bool AddQueu()
        {
            return true;
        }
    }
}