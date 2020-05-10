using System;
using System.Collections.Generic;

namespace ProyectoGrupo2
{
    public class SongClass : AbsMaster
    {
        private string composer;
        private Singer singer;
        private Album album;
        private string lyrics;
        
    
        public SongClass(string gender, string publicationYear, int numReproduction,
                     string title, int duration, int memory, string study, string keyword,
                     string composer, Singer singer, Album album, string lyrics)
        {
            this.Gender = gender;
            this.PublicationYear = publicationYear;
            this.NumReproduction = numReproduction;
            this.Title = title;
            this.Duration = duration;
            this.Memory = memory;
            this.Study = study;
            this.Keyword = keyword;
            this.Composer = composer;
            this.Singer = singer;
            this.Album = album;
            this.Lyrics = lyrics;
       

        }

        public string Composer { get => composer; set => composer = value; }
        public Singer Singer { get => singer; set => singer = value; }
        public Album Album { get => album; set => album = value; }
        public string Lyrics { get => lyrics; set => lyrics = value; }

        public void AddDate()
        {

        }

    }
}//rfddhh