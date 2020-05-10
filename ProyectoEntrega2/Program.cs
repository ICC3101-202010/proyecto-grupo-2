using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
namespace ProyectoGrupo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Creamos todos los objetos necesarios
            DataBase database = new DataBase();
            Server server = new Server(database);
            MailSender mailSender = new MailSender();
            SMSSender smsSender = new SMSSender();

            User user = new User();  //creamos el objeto de la nueva clase
            PrintAndReceive printAndReceive = new PrintAndReceive();
            




            //Suscribir los que escuchan los eventos

            //1- Suscribir OnRegistrado de mailSender para que escuche el evento Registrado enviado por servidor
            server.Registered += mailSender.OnRegistered;
            //2- Suscribir OnCambiadaContrasena de mailSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += mailSender.OnPasswordChanged;
            //3- Suscribir OnCambiadaContrasena de smsSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += smsSender.OnPasswordChanged;


            mailSender.EmailSented += user.OnEmailSent; //llamo a los nuevos metodos y eventos creados
            user.EmailVerified += user.EmailVerified;

            // Controla la ejecucion mientras el usuario no quiera salir
            bool exec = true;
            while (exec)
            {
                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() { "Registrarse", "LogIn", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();
                        server.Register();
                        if (user.Plan == "1")
                        {
                            user.AddProfile();
                        }//Perfil agregado
                        break;



                    case "LogIn":
                        Console.Clear();
                        server.InicioSecion();
                        string plan = Console.ReadLine();
                        user.Plan = plan;

                        Console.WriteLine(user.Plan);

                        if (  user.Plan == "1") // ESTO SE TIENE QUE ARREGLAR
                        {
                            printAndReceive.BasicPlan();
                        } 




                        int x = 2;//hacer que esto sea dependiento de su plan

                        if (x == 2)
                        {
                            printAndReceive.PrintMenuPrincipal();
                            int ma;

                            ma = int.Parse(Console.ReadLine());



                            if (ma == 1)
                            {
                                printAndReceive.PrintMenu1();
                            }
                            if (ma == 2)
                            {
                                printAndReceive.PrintMenu2();
                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }
                            if (ma == 3)
                            {
                                printAndReceive.PrintMenu3();

                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }

                            //completar dependiento de metodos
                            if (ma == 4)
                            {
                                printAndReceive.PrintMenu4();
                            }
                            if (ma == 5)
                            {
                                printAndReceive.PrintMenu5();
                            }
                            if (ma == 6)
                            {
                                printAndReceive.PrintMenu6();
                                int me;
                                me = int.Parse(Console.ReadLine());
                                if (me == 1)
                                {



                                }
                                if (me == 2) { }
                                if (me == 3) { }
                                if (me == 4)
                                { }
                                if (me == 5) { }
                                if (me == 6)
                                {
                                    server.ChangePassword();

                                    break;
                                }


                            }
                            if (ma == 7)
                            {
                                printAndReceive.PrintMenu7();
                                break;
                            }

                        }
                        break;


                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        // Metodo para mostrar las opciones posibles
        private static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }

            return options[Convert.ToInt16(Console.ReadLine())];
        }
    }
}
