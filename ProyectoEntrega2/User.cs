using System;
using System.Threading;
using System.Collections.Generic;

namespace ProyectoGrupo2

{

    public class User : Person
    {
        private string mail;
        private string paymentInfo;
        private string plan;
        private DateTime registrationDate;

        public User(string name, int age, string lastname, string gender, string nationality, string occupation, string mail, string paymentInfo, string plan, DateTime registrationDate)
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

        }

        public User()
        {
        }




        // Atributo BaseDatos


        public int EmailVerified { get; internal set; }
        public string Mail { get => mail; set => mail = value; }
        public string PaymentInfo { get => paymentInfo; set => paymentInfo = value; }
        public string Plan { get => plan; set => plan = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }



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

        public void AddProfile() //tiene que guardarse sus gustos 
        {
            Console.WriteLine("ds2s2"); //para agregar 1 PERFIL
            Console.WriteLine("Nombre Perfil?");

            Console.WriteLine("Actor Favorito: "); // Se va guardando en cada perfil. Respectivamente
            Console.WriteLine("Director favorito: "); // Se va guardando en cada perfil. Respectivamente
            Console.WriteLine("Cantante Favorito: ");
            Console.WriteLine("Grupo Favorito: ");
            Console.WriteLine("Cancion Favorita: ");// Se va guardando en cada perfil. Respectivamente

            // Mas adelante se tendra que implementar por opciones.
        }
        public void AddProfiles()
        {
            Console.WriteLine(); //para agregar usuarios plan FAMILIAR ,Hacer lista de listas
            Console.WriteLine("Nombre Perfil?");

            Console.WriteLine("Actor Favorito: "); // Se va guardando en cada perfil. Respectivamente
            Console.WriteLine("Director favorito: "); // Se va guardando en cada perfil. Respectivamente
            Console.WriteLine("Cantante Favorito: ");
            Console.WriteLine("Grupo Favorito: ");
            Console.WriteLine("Cancion Favorita: ");// Se va guardando en cada perfil. Respectivamente
        }
        public bool EliminarPerfil()
        {
            return true;
        }
        public bool CambiarPlan()
        {
            return true;
        }
        public bool CambiarCorreo()
        {
            return true;
        }
        public bool CambiarContraseña()
        {
            return true;
        }
        public bool CambiarInfoPago()
        {
            return true;
        }
        public bool CambiarTipoPerfil()
        {
            return true;
        }
        public bool CambiarIngoPerfil()
        {
            return true;
        }



    }
}