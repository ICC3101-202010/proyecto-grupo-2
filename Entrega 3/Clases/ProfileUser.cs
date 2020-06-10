using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Entrega_3.Clases
{
    [Serializable] // Necesario para poder importar canciones y videos. Necesito guardar usuarios.
    public class ProfilelUser
    {

        private List<ProfilelUser> followedProfile;
        private List<ProfilelUser> followers;
        private List<PlaylistVideoEmptyClass> followedPlaylistVideo;
        private List<PlaylistSpotifai> followedPlaylistSongs;
        private List<Singer> followedSingers;
        private List<Actor> followedActors;
        private List<Director> followedDirectors;
        private List<Album> followedDisk;
        private List<SongClass> downloadsSongs;
        private List<SongClass> likesSongs;
        private List<Video> likesVideos;

        public ProfilelUser(List<ProfilelUser> followers, List<PlaylistVideoEmptyClass> followedPlaylistVideo, List<PlaylistSpotifai> followedPlaylistSongs, List<ProfilelUser> followedProfile, List<Singer> followedSingers, List<Actor> followedActors, List<Director> followedDirectors, List<Album> followedDisk, List<SongClass> downloadsSongs, List<SongClass> likesSongs, List<Video> likesVideos)
        {
            this.Followers = followers;
            this.FollowedPlaylistVideo = followedPlaylistVideo;
            this.FollowedPlaylistSongs = followedPlaylistSongs;
            this.followedProfile = followedProfile;
            this.FollowedSingers = followedSingers;
            this.FollowedActors = followedActors;
            this.FollowedDirectors = followedDirectors;
            this.FollowedDisk = followedDisk;
            this.DownloadsSongs = downloadsSongs;
            this.LikesSongs = likesSongs;
            this.LikesVideos = likesVideos;

        }

        public ProfilelUser()
        {

        }

        public List<ProfilelUser> Followers { get => followers; set => followers = value; }
        public List<PlaylistVideoEmptyClass> FollowedPlaylistVideo { get => followedPlaylistVideo; set => followedPlaylistVideo = value; }
        public List<PlaylistSpotifai> FollowedPlaylistSongs { get => followedPlaylistSongs; set => followedPlaylistSongs = value; }
        public List<Singer> FollowedSingers { get => followedSingers; set => followedSingers = value; }
        public List<Actor> FollowedActors { get => followedActors; set => followedActors = value; }
        public List<Director> FollowedDirectors { get => followedDirectors; set => followedDirectors = value; }
        public List<Album> FollowedDisk { get => followedDisk; set => followedDisk = value; }
        public List<SongClass> DownloadsSongs { get => downloadsSongs; set => downloadsSongs = value; }
        public List<SongClass> LikesSongs { get => likesSongs; set => likesSongs = value; }
        public List<Video> LikesVideos { get => likesVideos; set => likesVideos = value; }

        public List<ProfilelUser> FollowedProfile { get => followedProfile; set => followedProfile = value; }


        public bool CreatePlaylistSong()
        {
            return true;
        }
        public bool CreatePlaylistVideo()
        {
            return true;
        }
        public bool SeePlaylist()
        {
            return true;
        }
        public bool SeeDownloads()
        {
            return true;
        }
        public bool EditLikes()
        {
            return true;
        }
        public bool DeletePlaylistSong()
        {
            return true;
        }
        public bool DeletePlaylistVideo()
        {
            return true;
        }
        public bool DeleteSongsFavorites()
        {
            return true;
        }
        public bool DeleteFollowed()
        {
            return true;
        }

        public bool Download(SongClass song)
        {
            string fileName = song.Title + ".txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(song.Title);
            writer.WriteLine(song.Singer);
            writer.WriteLine(song.Album);
            writer.WriteLine(song.Gender);
            writer.WriteLine(song.Composer);
            writer.WriteLine(song.PublicationYear);
            writer.WriteLine(song.Duration);
            writer.WriteLine(song.Memory);
            writer.WriteLine(song.Study);
            writer.WriteLine(song.Keyword);
            //writer.WriteLine(song.Lyrics);
            writer.WriteLine(song.Format);

            Console.WriteLine("Cancion descargada con exito");
            downloadsSongs.Add(song);

            writer.Close();
            return true;
        }


    }
}
