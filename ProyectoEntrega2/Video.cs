using System;
using System.Collections.Generic;

namespace ProyectoGrupo2
{
    public class Video : AbsMaster
    {
        private string category;
        private List<Actor> actors;
        private string description;
        //CAMBIAR LOS SUBTITUTLOS, DARSELOS A CANCION.
        private Actor mainActor;
        public Video(string gender, string publicationYear, int numReproduction,
                     string title, int duration, int memory, string study, string keyword, string category,
                     string description, Actor mainActor, List<Actor> actors)
        {
            this.Gender = gender;
            this.PublicationYear = publicationYear;
            this.NumReproduction = numReproduction;
            this.Title = title;
            this.Duration = duration;
            this.Memory = memory;
            this.Study = study;
            this.Keyword = keyword;
            this.Category = category;
            this.Description = description;
            this.MainActor = mainActor;
            this.Actors = actors;
        }

        public string Category { get => category; set => category = value; }
        public List<Actor> Actors { get => actors; set => actors = value; }
        public string Description { get => description; set => description = value; }
        public Actor MainActor { get => mainActor; set => mainActor = value; }

        public void AddData() //Cambiar UML  void
        {

        }

    }
}
//gghh