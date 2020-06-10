using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Entrega_3.Clases

{
    [Serializable]//Serializar usuarios.
    public class User : Person
    {
        private string mail;
        private string paymentInfo;
        private string plan;
        private DateTime registrationDate;
        private string nameUser;
        private string password;
        private int numPhone;
        private List<User> usuarios;
        private List<Profile> profiles;

        public User(string nameUser, int numPhone, string password, string name, int age, string lastname, string gender, string nationality, string occupation, string mail, string paymentInfo, string plan, DateTime registrationDate, List<Profile> profiles)
        {
            this.NumPhone = numPhone;
            this.Password = password;
            this.NameUser = nameUser;
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

        public User()
        {

        }


        // Atributo BaseDatos


        public int EmailVerified { get; internal set; }
        public string Mail { get => mail; set => mail = value; }
        public string PaymentInfo { get => paymentInfo; set => paymentInfo = value; }
        public string Plan { get => plan; set => plan = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public string NameUser { get => nameUser; set => nameUser = value; }
        public string Password { get => password; set => password = value; }
        public int NumPhone { get => numPhone; set => numPhone = value; }
        public List<User> Usuarios { get => usuarios; set => usuarios = value; }
        public List<Profile> Profiles { get => profiles; set => profiles = value; }

        public delegate void EmailVerifiEventHandler(object source, EventArgs args);

        public event EmailVerifiEventHandler EmailVerifi;

        protected virtual void OnEmailVerified(User user, EventArgs args)
        {
            OnEmailVerified(this, new EventArgs());

        }

        public void OnEmailSent(object source, EventArgs args)
        {



        }


        public bool CambiarPlan()
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

        public int GuardarUsuario() // Falta parte del forms. Minuto 9:15
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)//Si es que el usuario agrego un archivo para guardar.
                {
                    Stream st = File.Open(dialog.FileName, FileMode.Create);
                    var binfor = new BinaryFormatter();
                    binfor.Serialize(st, this); // --> hace referencia a toda la clase
                    return 0; //Todo salio bien
                }
                else
                {
                    return 1; //En caso de que no

                }
            }
            catch
            {
                return 2;
            }
        }

    }
}