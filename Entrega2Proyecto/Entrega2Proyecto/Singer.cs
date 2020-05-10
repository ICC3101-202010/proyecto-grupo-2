using System.Collections.Generic;

namespace ProyectoGrupo2
{
     public class Singer : Person
    {
        private List<Video> movies;
        private List<SongClass> songs;
        private List<Disk> disks;
        private List<string> awards;
        private string voiceType;
        private string genders;
        private int yearsActive;
        private List<string> discographic;

        public Singer(List<Video> movies, List<SongClass> songs, List<Disk> disks, List<string> awards, string voiceType, string genders, int yearsActive, List<string> discographic,string name, int age, string lastname, string gender, string nationality, string occupation, List<Video> movies, List<string> awards, int yearsActive)
        {
            this.Name = name;
            this.Age = age;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Nationality = nationality;
            this.Occupation = occupation;
            this.Movies = movies;
            this.Awards = awards;
            this.YearsActive = yearsActive;
            this.Movies = movies;
            this.Songs = songs;
            this.Disks = disks;
            this.Awards = awards;
            this.VoiceType = voiceType;
            this.Genders = genders;
            this.YearsActive = yearsActive;
            this.Discographic = discographic;
        }

        public List<Video> Movies { get => movies; set => movies = value; }
        public List<SongClass> Songs { get => songs; set => songs = value; }
        public List<Disk> Disks { get => disks; set => disks = value; }
        public List<string> Awards { get => awards; set => awards = value; }
        public string VoiceType { get => voiceType; set => voiceType = value; }
        public string Genders { get => genders; set => genders = value; }
        public int YearsActive { get => yearsActive; set => yearsActive = value; }
        public List<string> Discographic { get => discographic; set => discographic = value; }
    }
    
}