using System;
using System.Collections.Generic;
using System.Threading;

namespace Entrega_3.Clases
{
    [Serializable]
    public class Video
    {
        //private List<Actor> actors;
        private string description;
        private Actor mainActor;//PONERLOS EN SUS CLASES
        private Director director; //
        private string format;
        private List<Video> videos;

        private string gender;
        private string publicationYear;
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

        public Video(string gender, string publicationYear,
                     string title, double duration, int memory, string study, string keyword,
                     string description, Actor mainActor, Director director, string format, int evaluation, int resolution, string url, int nReproduction, int likes)
        {
            this.Gender = gender; // Listo
            this.PublicationYear = publicationYear; // Listo
            this.Title = title; //Listo
            this.Duration = duration;
            this.Memory = memory;
            this.Study = study; // Listo
            this.Keyword = keyword; // Listo
            this.Description = description; // Listo
            this.MainActor = mainActor; // Listo
            //this.Actors = actors; No se como poner aun
            this.Director = director;  //Listo
            this.format = format;
            this.Evaluation = evaluation;
            this.Resolution = resolution;
            this.Url = url;
            this.NReproduction = nReproduction;
            this.Likes = likes;
        }
        public Video()
        {

        }
        public Director Director { get => director; set => director = value; }
        public string Format { get => format; set => format = value; }
        //public List<Actor> Actors { get => actors; set => actors = value; }
        public string Description { get => description; set => description = value; }
        public Actor MainActor { get => mainActor; set => mainActor = value; }
        public List<Video> Videos1 { get => videos; set => videos = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PublicationYear { get => publicationYear; set => publicationYear = value; }
        public string Title { get => title; set => title = value; }
        public double Duration { get => duration; set => duration = value; }
        public int Memory { get => memory; set => memory = value; }
        public string Study { get => study; set => study = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public int Evaluation { get => evaluation; set => evaluation = value; }
        public int Resolution { get => resolution; set => resolution = value; }
        public string Url { get => url; set => url = value; }
        public int NReproduction { get => nReproduction; set => nReproduction = value; }
        public int Likes { get => likes; set => likes = value; }

        public void AddData() //Cambiar UML  void
        {

        }
        public override string ToString()
        {
            Console.WriteLine("ACa puede ver el titulo del video, el director, el genero al que pertenece, año de publicacion, duracion, meoria, estudio de grabacion y su palabra clave. ");
            return Title + " " + Director.Name + " " + Gender + " " + PublicationYear + " " + Duration + " " + Memory + " " + Study + " " + Keyword;
        }

    }
}