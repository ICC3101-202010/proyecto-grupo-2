using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
{
    [Serializable]
    public class Server
    {
        private List<User> usersList = new List<User>();
        public List<User> UsersList { get => usersList; set => usersList = value; }

        public delegate void RegisterEventHandler(object source, RegisterEventArgs args);
        public event RegisterEventHandler Registered;

        protected virtual void OnRegistered(string username, string password, string verificationlink, string email, string plan, string infopago)
        {
            if (Registered != null)
            {

                Registered(this, new RegisterEventArgs() { VerificationLink = verificationlink, Password = password, Username = username, Email = email, Plan = plan, InfoPayment = infopago });

            }
        }


        public delegate void ChangePasswordEventHandler(object source, ChangePasswordEventArgs args);
        public event ChangePasswordEventHandler PasswordChanged;
        protected virtual void OnPasswordChanged(string username, string email, string number)
        {
            if (PasswordChanged != null)
            {
                PasswordChanged(this, new ChangePasswordEventArgs() { Username = username, Email = email, Number = number });
            }
        }

        public DataBase Data { get; }
        public int OnEmailVerified { get; internal set; }


        public Server(DataBase data)
        {
            this.Data = data;
        }






        public void ChangePassword()
        {
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {

                Console.Write("Ingrese la nueva contrasena: ");
                string newPsswd = Console.ReadLine();
                Data.ChangePassword(usr, newPsswd);
                List<string> data = Data.GetData(usr);
                OnPasswordChanged(data[0], data[1], data[5]);
                Console.WriteLine("Contraseña cambiada con exito\n");
                Thread.Sleep(2000);
                Console.WriteLine("secion cerrada, para continuar ingrese nuevamente");
                Thread.Sleep(2000);
            }
            else
            {

                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }
        public void ChangeEmail()
        {
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {

                Console.Write("Ingrese el nuevo Email: ");
                string newPsswd = Console.ReadLine();
                Data.ChangeEmail(usr, newPsswd);
                List<string> data = Data.GetData(usr);

                Console.WriteLine("Email cambiado con exito\n");
                Thread.Sleep(2000);
                Console.WriteLine("secion cerrada, para continuar ingrese nuevamente");
                Thread.Sleep(2000);
            }
            else
            {

                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }

        public void ChangeTargetPay()
        {
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {

                Console.Write("Ingrese el nuevo Numero de su tarjeta: ");
                string newPsswd = Console.ReadLine();
                Data.ChangeTargetPay(usr, newPsswd);
                List<string> data = Data.GetData(usr);

                Console.WriteLine("Medio de pago cambiado con exito\n");
                Thread.Sleep(2000);
                Console.WriteLine("secion cerrada, para continuar ingrese nuevamente");
                Thread.Sleep(2000);
            }
            else
            {

                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }



        public void ChangePlan()
        {
            Console.WriteLine("Al hacer esto se perdera toda su informacion ");
            Thread.Sleep(2000);
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {

                Console.WriteLine("ingrese tipo de plan\n");
                Console.WriteLine("1)plan Basico \n");
                Console.WriteLine("2)plan premiun (personal) $3,990\n");
                Console.WriteLine("3)plan familiar (4 usuarios) $7,990\n");
                string op = Console.ReadLine();
                int plan = Int32.Parse(op);

                string newPsswd = Console.ReadLine();
                Data.ChangePlan(usr, newPsswd);
                List<string> data = Data.GetData(usr);

                Console.WriteLine("Medio de pago cambiado con exito\n");
                Thread.Sleep(2000);
                Console.WriteLine("acontinuacion complete ");
                Thread.Sleep(2000);
            }
            else
            {

                Console.WriteLine("[!] ERROR: " + result + "\n");

            }
        }








        public bool InicioSecion(string usr, string pswd)
        {

            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {
                Console.WriteLine("inicio sesion exitoso");
                return true;
            }
            else
            {
                Console.WriteLine("[!] ERROR: " + result + "\n");
                return false;
            }

        }

        public void Register(string usr, string email, string psswd, string number, string planSeleccionado, string infopago)
        {


            string verificationLink = GenerateLink(usr);
            string result = Data.AddUser(new List<string>()
                {usr, email, psswd, verificationLink, Convert.ToString(DateTime.Now), number});

            if (result == null)
            {

                OnRegistered(usr, psswd, verificationlink: verificationLink, email: email, plan: planSeleccionado, infopago);


            }
            else
            {

                Console.WriteLine("[!] ERROR: " + result + "\n");
            }


        }



        private string GenerateLink(string usr)
        {
            Random rnd = new Random();
            string result = "";
            for (int ctr = 0; ctr <= 99; ctr++)
            {
                char rndom = (char)rnd.Next(33, 126);
                result += rndom;
            }
            return "http://spotflix.com/verificar-correo.php?=" + usr + "_" + result;
        }

        public void OnemailVerified(object source, EventArgs args)
        {
            Console.WriteLine("Verificacion exitosa!");
            Thread.Sleep(2000);
        }
    }
}