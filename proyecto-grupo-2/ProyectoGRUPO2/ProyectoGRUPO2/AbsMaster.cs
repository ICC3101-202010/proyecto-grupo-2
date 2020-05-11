using System;
using System.Collections.Generic;
using System.Threading;
namespace ProyectoGRUPO2
{
    //hola gente
    public class AbsMaster //PROBANDO NUEVAMENTE - ALVARO
    {
        private string gender;
        private string publicationYear;
        private int numReproduction;
        private string title;
        private int duration;
        private int memory;
        private string study;
        private string keyword;

        public AbsMaster()
        {

        }

        protected string Gender { get => gender; set => gender = value; }
        protected string PublicationYear { get => publicationYear; set => publicationYear = value; }
        protected int NumReproduction { get => numReproduction; set => numReproduction = value; }
        protected string Title { get => title; set => title = value; }
        protected int Duration { get => duration; set => duration = value; }
        protected int Memory { get => memory; set => memory = value; }
        protected string Study { get => study; set => study = value; }
        protected string Keyword { get => keyword; set => keyword = value; }

        public bool addImage(string imagen)
        {
            return true;
        }
        public bool AddLike()
        {
            return true;
        }
        public bool AddCalification()
        {
            return true;
        }
        public bool AddReprodution()
        {
            return true;
        }
        public bool AddListReprodution()
        {
            return true;
        }
    }
}
