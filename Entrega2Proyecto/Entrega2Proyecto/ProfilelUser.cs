using System;
using System.Collections.Generic;
using System.Globalization;


namespace ProyectoGrupo2
{
    public class ProfilelUser
    {
    
        private List<ProfilelUser> followedProfile;
        private List<ProfilelUser> followers;
        private List<PlaylistVideoEmptyClass> followedPlaylistVideo;
        private List<PlaylistSpotifai> followedPlaylistSongs;
        private List<Singer> followedSingers;
        private List<Actor> followedActors;
        private List<Director> followedDirectors;
        private List<disk> followedDisk;
        private List<SongClass> downloadsSongs;

        private List<SongClass> likesSongs;
        private List<Video> likesVideos;
        private string profileType;

        public ProfilelUser(List<ProfilelUser> followers, List<PlaylistVideoEmptyClass> followedPlaylistVideo, List<PlaylistSpotifai> followedPlaylistSongs, List<ProfilelUser> followedProfile, List<Singer> followedSingers, List<Actor> followedActors, List<Director> followedDirectors, List<disk> followedDisk, List<SongClass> downloadsSongs, List<SongClass> likesSongs, List<Video> likesVideos, string profileType)
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
            this.ProfileType = profileType;        
        }

        public List<ProfilelUser> Followers { get => followers; set => followers = value; }
        public List<PlaylistVideoEmptyClass> FollowedPlaylistVideo { get => followedPlaylistVideo; set => followedPlaylistVideo = value; }
        public List<PlaylistSpotifai> FollowedPlaylistSongs { get => followedPlaylistSongs; set => followedPlaylistSongs = value; }
        public List<Singer> FollowedSingers { get => followedSingers; set => followedSingers = value; }
        public List<Actor> FollowedActors { get => followedActors; set => followedActors = value; }
        public List<Director> FollowedDirectors { get => followedDirectors; set => followedDirectors = value; }
        public List<disk> FollowedDisk { get => followedDisk; set => followedDisk = value; }
        public List<SongClass> DownloadsSongs { get => downloadsSongs; set => downloadsSongs = value; }
        public List<SongClass> LikesSongs { get => likesSongs; set => likesSongs = value; }
        public List<Video> LikesVideos { get => likesVideos; set => likesVideos = value; }
        
        public List<ProfilelUser> FollowedUser { get => followedUser; set => followedUser = value; }
        public string ProfileType { get => profileType; set => profileType = value; }

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
        //UML


    }
}