using System;
using System.Collections.Generic;
using System.Threading;

namespace Entrega_3.Clases
{
    [Serializable]
    public class PlaylistVideoEmptyClass
    {

        private string name;
        private List<Video> videosPlaylist;
        private string privacidad;

        public PlaylistVideoEmptyClass(string name, List<Video> videosPlaylist, string privacidad)
        {
            this.Name = name;
            this.VideosPlaylist = videosPlaylist;
            this.Privacidad = privacidad;
        }
        public PlaylistVideoEmptyClass()
        {

        }

        public string Name { get => name; set => name = value; }
        public List<Video> VideosPlaylist { get => videosPlaylist; set => videosPlaylist = value; }
        public string Privacidad { get => privacidad; set => privacidad = value; }

        public override string ToString()
        {
            return Name + ":" + Privacidad;
        }
    }
}