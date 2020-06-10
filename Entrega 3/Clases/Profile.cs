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


        public Profile(string nameProfile, string profileType, List<string> pleasuresMusic, List<string> pleasuresMovies, List<PlaylistSpotifai> playlistCanciones, List<PlaylistVideoEmptyClass> playlistVideos, List<SongClass> playlistFavoritasCanciones, List<Video> playlistFavoritasVideos)
        {
            this.NameProfile = nameProfile;
            this.ProfileType = profileType;
            this.PleasuresMusic = pleasuresMusic;
            this.PleasuresMovies = pleasuresMovies;
            this.PlaylistCanciones = playlistCanciones;
            this.PlaylistVideos = playlistVideos;
            this.PlaylistFavoritasCanciones = playlistFavoritasCanciones;
            this.PlaylistFavoritasVideos = playlistFavoritasVideos;
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
    }
}