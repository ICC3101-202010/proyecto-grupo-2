using System;
using System.Collections.Generic;
using System.Threading;
namespace ProyectoGRUPO2
{
    [Serializable]
    public class Video : AbsMaster
    {
        //private List<Actor> actors;
        private string description;
        private string mainActor;//PONERLOS EN SUS CLASES
        private string director; //
        private string format;

        public Video(string gender, string publicationYear,
                     string title, int duration, int memory, string study, string keyword,
                     string description, string mainActor, string director, string format)
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
        }
        public  string Director { get => director; set => director = value; }
        public string Format { get => format; set => format = value; }
        //public List<Actor> Actors { get => actors; set => actors = value; }
        public string Description { get => description; set => description = value; }
        public string MainActor { get => mainActor; set => mainActor = value; }

        public void AddData() //Cambiar UML  void
        {

        }

    }
}
//gghh