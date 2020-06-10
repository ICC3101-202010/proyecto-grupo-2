using System;
using System.Collections.Generic;
using System.IO;

namespace Entrega_3.Clases
{
    [Serializable]
    public class SongClass
    {
        private string composer;
        private Singer singer;
        private Album album; //AGERGAR A SUS RESPECTIVAS CLASES
        private string format;
        private List<SongClass> canciones;

        //Atributos AbsMaster
        private string gender;
        private string publicationYear; //Tiene que ser DAte time
        private string title;
        private double duration;
        private int memory;
        private string study;
        private string keyword;

        private int evaluation;
        private int resolution;

        private string url;
        private int nReproduction;
        private int likes;

        public string Composer { get => composer; set => composer = value; }
        public Singer Singer { get => singer; set => singer = value; }
        public Album Album { get => album; set => album = value; }
        public string Format { get => format; set => format = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PublicationYear { get => publicationYear; set => publicationYear = value; }
        public string Title { get => title; set => title = value; }
        public double Duration { get => duration; set => duration = value; }
        public int Memory { get => memory; set => memory = value; }
        public string Study { get => study; set => study = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public List<SongClass> Canciones { get => canciones; set => canciones = value; }
        public int Evaluation { get => evaluation; set => evaluation = value; }
        public int Resolution { get => resolution; set => resolution = value; }
        public string Url { get => url; set => url = value; }
        public int NReproduction { get => nReproduction; set => nReproduction = value; }
        public int Likes { get => likes; set => likes = value; }

        public SongClass(string gender, string publicationYear,
                     string title, double duration, int memory, string study, string keyword,
                     string composer, Singer singer, Album album, string format, int evaluation, int resolution, string url, int nReproduction, int likes)
        {
            this.Gender = gender; // listo
            this.PublicationYear = publicationYear;//listo

            this.Title = title;//Listo
            this.Duration = duration;//Predeterminada
            this.Memory = memory;//Cada cancion pesa un nuero random [1-50]
            this.Study = study;// Listo
            this.Keyword = keyword; //Listo
            this.Composer = composer; //Listo
            this.Singer = singer; // Listo
            this.Album = album; // Listo
            this.Format = format; // Listo
            this.Evaluation = evaluation;
            this.Resolution = resolution;
            this.Url = url;
            this.NReproduction = nReproduction;
            this.Likes = likes;
        }
        public SongClass()
        {

        }
        public override string ToString()
        {
            Console.WriteLine("Aca puede ver el titutlo de la cancion, el compositor, genero, año de publicacion, duracion, memoria de la misma, estudio donde se grabo, palabra clase, cantante, album y la letra que usted añadio.");
            return Title + " " + Composer + " " + Gender + " " + PublicationYear + " " + Duration + " " + Memory + " " + Study + " " + Keyword + " " + Singer.Name + " " + Album.NameAlbum;
        }
    }
}