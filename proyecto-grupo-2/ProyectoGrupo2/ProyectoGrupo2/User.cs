using System;
using System.Threading;
using System.Collections.Generic;

namespace ProyectoGrupo2

{

    public class User:Person
    {
        private string mail;
        private string paymentInfo;
        private string plan;
        private DateTime registrationDate;
        private List<ProfilelUser> profiles;

   
        public User(string name, int age, string lastname, string gender, string nationality, string occupation, string mail, string paymentInfo, string plan, DateTime registrationDate, List<ProfilelUser> profiles)
        {
            this.Name = name;
            this.Age = age;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Nationality = nationality;
            this.Occupation = occupation;
            this.Mail = mail;
            this.PaymentInfo = paymentInfo;
            this.Plan = plan;
            this.RegistrationDate = registrationDate;
            this.Profiles = profiles;
        }

        public int EmailVerified { get; internal set; }
        public string Mail { get => mail; set => mail = value; }
        public string PaymentInfo { get => paymentInfo; set => paymentInfo = value; }
        public string Plan { get => plan; set => plan = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public List<ProfilelUser> Profiles { get => profiles; set => profiles = value; }


        public delegate void EmailVerifiEventHandler(object source, EventArgs args);
        
        public event EmailVerifiEventHandler EmailVerifi;

        protected virtual void OnEmailVerified(User user, EventArgs args)
        {
            OnEmailVerified(this, new EventArgs());  

        }
        
        public void OnEmailSent(object source, EventArgs args)
        {

            Console.WriteLine("¿Desea verificar el correo ?\n\n");
            Console.WriteLine("1) SI");
            Console.WriteLine("2)NO");
            string a = Console.ReadLine();
            int num = Convert.ToInt32(a);
            if (num == 1)
            {

                OnEmailVerified(this, new EventArgs());

            }

            if (num != 2 && num != 1)
            {
                Thread.Sleep(2000);
                Console.WriteLine("opcion ingresada invalida, se volvera al menu principal");
                Thread.Sleep(2000);
            }

        }


    }
}