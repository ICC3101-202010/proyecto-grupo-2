﻿using System;
using System.Collections.Generic;
namespace ProyectoGrupo2
{
    public class PlaylistVideoEmptyClass
    {
        private string typeFile;
        public List<string> Playlist;
        public List<string> PlaylistFav;
        public PlaylistVideoEmptyClass(string file)
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
//g