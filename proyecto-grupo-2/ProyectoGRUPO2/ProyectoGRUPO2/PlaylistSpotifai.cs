using System;
using System.Collections.Generic;
using System.Threading;
namespace ProyectoGRUPO2
{
    public class PlaylistSpotifai
    {
        private string typeFile;
        public List<string> Playlist;
        public List<string> PlaylistFav;
        public PlaylistSpotifai(string file)
        {
            this.typeFile = file;
            Playlist = new List<string>();
            PlaylistFav = new List<string>();
        }

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