using System;
using System.Collections.Generic;

namespace Entrega_3.Clases
{
    [Serializable]
    public class Profile
    {

        private string nameProfile;
        private string profileType;
        private List<string> pleasuresMusic;
        private List<string> pleasuresMovies;
        private List<PlaylistSpotifai> playlistCanciones;
        private List<PlaylistVideoEmptyClass> playlistVideos;
        private List<SongClass> playlistFavoritasCanciones;
        private List<Video> playlistFavoritasVideos;
        private List<Profile> seguidos;
        private List<Profile> seguidores;
        private List<PlaylistSpotifai> playlistCancionSeguidas;
        private List<PlaylistVideoEmptyClass> playlistVideoSeguidas;
        private List<Album> albumSeguidos;
        private List<Actor> actoresSeguidos;
        private List<Singer> cantantesSeguidos;
        private List<Director> directoresSeguidos;


        public Profile(string nameProfile, string profileType, List<string> pleasuresMusic, List<string> pleasuresMovies, List<PlaylistSpotifai> playlistCanciones, List<PlaylistVideoEmptyClass> playlistVideos, List<SongClass> playlistFavoritasCanciones, List<Video> playlistFavoritasVideos, List<Profile> seguidos, List<Profile> seguidores, List<PlaylistSpotifai> playlistCancionSeguidas, List<PlaylistVideoEmptyClass> playlistVideoSeguidas, List<Album> albumSeguidos, List<Actor> actoresSeguidos, List<Singer> cantantesSeguidos, List<Director> directoresSeguidos)
        {
            this.NameProfile = nameProfile;
            this.ProfileType = profileType;
            this.PleasuresMusic = pleasuresMusic;
            this.PleasuresMovies = pleasuresMovies;
            this.PlaylistCanciones = playlistCanciones;
            this.PlaylistVideos = playlistVideos;
            this.PlaylistFavoritasCanciones = playlistFavoritasCanciones;
            this.PlaylistFavoritasVideos = playlistFavoritasVideos;
            this.Seguidos = seguidos;
            this.Seguidores = seguidores;
            this.PlaylistCancionSeguidas = playlistCancionSeguidas;
            this.PlaylistVideoSeguidas = playlistVideoSeguidas;
            this.AlbumSeguidos = albumSeguidos;
            this.ActoresSeguidos = actoresSeguidos;
            this.CantantesSeguidos = cantantesSeguidos;
            this.DirectoresSeguidos = directoresSeguidos;
        }
        public Profile()
        {

        }

        public string NameProfile { get => nameProfile; set => nameProfile = value; }
        public string ProfileType { get => profileType; set => profileType = value; }
        public List<string> PleasuresMusic { get => pleasuresMusic; set => pleasuresMusic = value; }
        public List<string> PleasuresMovies { get => pleasuresMovies; set => pleasuresMovies = value; }
        public List<PlaylistSpotifai> PlaylistCanciones { get => playlistCanciones; set => playlistCanciones = value; }
        public List<PlaylistVideoEmptyClass> PlaylistVideos { get => playlistVideos; set => playlistVideos = value; }
        public List<SongClass> PlaylistFavoritasCanciones { get => playlistFavoritasCanciones; set => playlistFavoritasCanciones = value; }
        public List<Video> PlaylistFavoritasVideos { get => playlistFavoritasVideos; set => playlistFavoritasVideos = value; }
        public List<Profile> Seguidos { get => seguidos; set => seguidos = value; }
        public List<Profile> Seguidores { get => seguidores; set => seguidores = value; }
        public List<PlaylistSpotifai> PlaylistCancionSeguidas { get => playlistCancionSeguidas; set => playlistCancionSeguidas = value; }
        public List<PlaylistVideoEmptyClass> PlaylistVideoSeguidas { get => playlistVideoSeguidas; set => playlistVideoSeguidas = value; }
        public List<Album> AlbumSeguidos { get => albumSeguidos; set => albumSeguidos = value; }
        public List<Actor> ActoresSeguidos { get => actoresSeguidos; set => actoresSeguidos = value; }
        public List<Singer> CantantesSeguidos { get => cantantesSeguidos; set => cantantesSeguidos = value; }
        public List<Director> DirectoresSeguidos { get => directoresSeguidos; set => directoresSeguidos = value; }
        public override string ToString()
        {
            return nameProfile + " " + profileType;
        }
    }
}