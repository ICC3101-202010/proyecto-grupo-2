using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
{
    [Serializable]
    public class PlaylistSpotifai
    {
        private List<SongClass> cancionesPlaylist;
        private string privacidad;

        //Agregadas Alvaro
        private string nombre; //nombre de la playlist creada

        public string Nombre { get => nombre; set => nombre = value; }
        public List<SongClass> CancionesPlaylist { get => cancionesPlaylist; set => cancionesPlaylist = value; }
        public string Privacidad { get => privacidad; set => privacidad = value; }

        public PlaylistSpotifai(string nombre, List<SongClass> cancionesPlaylist, string privacidad)
        {
            this.nombre = nombre;
            this.CancionesPlaylist = cancionesPlaylist;
            this.Privacidad = privacidad;
        }

        public PlaylistSpotifai()
        {
        }

        public override string ToString()
        {
            return Nombre+":" + Privacidad;
        }
    }
}