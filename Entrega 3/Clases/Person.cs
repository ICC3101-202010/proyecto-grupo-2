using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
{
    [Serializable]
    public class Person

    {
        private string name;
        private int age;
        private string lastname;
        private string gender;
        private string nationality;
        private string occupation;

        public Person()
        {

        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Occupation { get => occupation; set => occupation = value; }
    }
}