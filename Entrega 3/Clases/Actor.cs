using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
//pro
{
    [Serializable]
    public class Actor : Person
    {
        private List<Video> movies;
        private List<string> awards;
        private int yearsActive;

        public Actor(string name, int age, string lastname, string gender, string nationality, string occupation, List<Video> movies, List<string> awards, int yearsActive)
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
        }


        public List<Video> Movies { get => movies; set => movies = value; }
        public List<string> Awards { get => awards; set => awards = value; }
        public int YearsActive { get => yearsActive; set => yearsActive = value; }
    }

}