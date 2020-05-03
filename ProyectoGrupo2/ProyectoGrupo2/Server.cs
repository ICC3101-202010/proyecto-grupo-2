using System;
using System.Collections.Generic;
using System.Threading;

namespace ProyectoGrupo2
{
    public class Server
    {
        // Paso 1: Creamos el delegate para el evento del registro
        public delegate void RegisterEventHandler(object source, RegisterEventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando el usuario se registra
        public event RegisterEventHandler Registered;
        // Paso 3: Publicamos el evento. Notar que cuando se quiere engatillar el evento, se llama OnRegistered(). 
        // Por definicion, debe ser protected virtual. Los parametros que recibe son los necesarios para crear una instancia
        // de la clase  RegisterEventArgs

        
        protected virtual void OnRegistered(string username, string password, string verificationlink, string email,string plan,string infopago)
        {
            // Verifica si hay alguien suscrito al evento
            if (Registered != null)
            {
                // Engatilla el evento
                Registered(this, new RegisterEventArgs() { VerificationLink = verificationlink, Password = password, Username = username, Email = email });

            }
        }















        // Paso 1: Creamos el delegate para el evento del cambio de contrasena
        public delegate void ChangePasswordEventHandler(object source, ChangePasswordEventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando se cambia la contrasena
        public event ChangePasswordEventHandler PasswordChanged;
        // Paso 3: Publicamos el evento. Notar que cuando se quiere engatillar el evento, se llama OnPasswordChanged(). 
        // Por definicion, debe ser protected virtual. Los parametros que recibe son los necesarios para crear una instancia
        // de la clase ChangePasswordEventArgs
        protected virtual void OnPasswordChanged(string username, string email, string number)
        {
            if (PasswordChanged != null)
            {
                PasswordChanged(this, new ChangePasswordEventArgs() { Username = username, Email = email, Number = number });
            }
        }







        // Atributo BaseDatos
        public DataBase Data { get; }
        public int OnEmailVerified { get; internal set; }





        // Constructor
        public Server(DataBase data)
        {
            this.Data = data;
        }












        // Realiza el registro 
        public void Register()
        {
            // Pedimos todos los datos necesarios
            Console.Write("Bienvenido! Ingrese sus datos de registro en PlusCorporation\nUsuario: ");
            string usr = Console.ReadLine();


            Console.Write("Correo: ");
            string email = Console.ReadLine();


            Console.Write("Contraseña: ");
            string psswd = Console.ReadLine();


            Console.Write("Numero de telefono: ");
            string number = Console.ReadLine();

            Console.WriteLine("¿que tipo de plan desea?\n");
            Console.WriteLine("1) Plan basico \n");
            Console.WriteLine("1) Plan Premiun ($3.990)\n");
            Console.WriteLine("2) Plan Familiar 4 personas ($8.990)");
            string plan = Console.ReadLine();


            Console.WriteLine("ingrese num tarjeta");
            string infopago = Console.ReadLine();


            // Genera el link de verificacion para el usuario
            string verificationLink = GenerateLink(usr);
            // Intenta agregar el usuario a la bdd. Si retorna null, se registro correctamente,
            // sino, retorna un string de error, que es el que se muestra al usuario
            string result = Data.AddUser(new List<string>()
                {usr, email, psswd, verificationLink, Convert.ToString(DateTime.Now), number});
            if (result == null)
            {
                // Disparamos el evento
                OnRegistered(usr, psswd, verificationlink: verificationLink, email: email, plan: plan, infopago:infopago);


            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }











        // Realiza el cambio de contrasena
        public void ChangePassword()
        {
            // Pedimos todos los datos necesarios
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            // Intenta realizar el login, si retorna null se logeo correctamente,
            // sino, retorna un string de error que se le muestra al usuario
            string result = Data.LogIn(usr, pswd);
            if (result == null)
            {
                // Pedimos y cambiamos la contrasena
                Console.Write("Ingrese la nueva contrasena: ");
                string newPsswd = Console.ReadLine();
                Data.ChangePassword(usr, newPsswd);
                // Obtenemos los datos del usuario que se logueo y disparamos el evento con los datos necesarios
                List<string> data = Data.GetData(usr);
                OnPasswordChanged(data[0], data[1], data[5]);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }

        // Metodo que genera un link de verificacion, dado un usuario
        private string GenerateLink(string usr)
        {
            Random rnd = new Random();
            string result = "";
            for (int ctr = 0; ctr <= 99; ctr++)
            {
                char rndom = (char)rnd.Next(33, 126);
                result += rndom;
            }
            return "http://pluscorporation.com/verificar-correo.php?=" + usr + "_" + result;
        }
        public void OnemailVerified(object source, EventArgs args)
        {
            Console.WriteLine("Verificacion exitosa!");
            Thread.Sleep(2000);
        }
    }
}
