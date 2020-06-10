using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
{
    [Serializable]
    public class Singer : Person
    {
        private List<SongClass> songs;
        private List<Album> album;
        private List<string> awards;
        private string voiceType;
        private string genders;
        private int yearsActive;
        private List<string> discographic;

        public Singer(List<SongClass> songs, List<Album> album, List<string> awards, string voiceType, string genders, int yearsActive, List<string> discographic, string name, int age, string lastname, string gender, string nationality, string occupation)
        {
            this.Name = name;
            this.Age = age;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Nationality = nationality;
            this.Occupation = occupation;
            this.Songs = songs;
            this.Album = album;
            this.Awards = awards;
            this.VoiceType = voiceType;
            this.Genders = genders;
            this.YearsActive = yearsActive;
            this.Discographic = discographic;
        }


        public List<SongClass> Songs { get => songs; set => songs = value; }
        public List<Album> Album { get => album; set => album = value; }
        public List<string> Awards { get => awards; set => awards = value; }
        public string VoiceType { get => voiceType; set => voiceType = value; }
        public string Genders { get => genders; set => genders = value; }
        public int YearsActive { get => yearsActive; set => yearsActive = value; }
        public List<string> Discographic { get => discographic; set => discographic = value; }
    }

}