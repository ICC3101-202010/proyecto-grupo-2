using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO; //Agregadas Para la serializacion
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap; // Para cargar formato UML


namespace ProyectoGRUPO2
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
                            user.AddProfile();              // datos del usuario 


                        }//Perfil agregado

                        if (user.Plan == "2")

                        {
                            user.AddProfile();



                        }


                        if (user.Plan == "3")
                        {
                            user.AddProfiles();
                        }



                        break;



                    case "LogIn":
                        Console.Clear();
                        server.InicioSecion();
                        string plan = Console.ReadLine();
                        user.Plan = plan;

                        Console.WriteLine(user.Plan);

                        if (user.Plan == "1") // ESTO SE TIENE QUE ARREGLAR
                        {
                            printAndReceive.MenuBasicPlan();
                            int ma;
                            ma = int.Parse(Console.ReadLine());

                            if (ma == 1) { }
                            if (ma == 2) { }


                            if (ma == 3)
                            {


                            }



                            if (ma == 4)
                            {
                                printAndReceive.PrintMenu7();
                            }

                        }





                        int x = 2;//hacer que esto sea dependiento de su plan

                        if (x == 2)//plan Premiun
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
                                printAndReceive.PrintMenu7();
                                int me;

                                me = int.Parse(Console.ReadLine());
                                if (me == 1)
                                {



                                }
                                if (me == 2) { }
                                if (me == 3)
                                {
                                    server.ChangePassword();

                                    break;

                                }
                                if (me == 4)
                                {
                                    break;
                                }

                            }
                            //if (ma == 7)
                            //{
                            // printAndReceive.PrintMenu8();
                            //  break;
                            //}

                        }






                        if (x == 3)//plan familiar
                        {
                            //escoger usuario 1,2,3 o 4
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
                                if (me == 7)
                                {
                                    break;
                                }

                            }
                            //if (ma == 7)
                            // {
                            //printAndReceive.PrintMenu8();
                            //  break;
                            //}
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
        //------------ AGREGAR USUARIO --------------------------------------------------------
        //Metodo para agregar usuarios y quede guardados. 
        //Ver como se agrega, debido que esta registrado.
        //Ver con mati
        static public void AddUser(List<User> usuario)
        {
            Console.WriteLine("nada");
        }

        //Metodo para guardar el usuario registrado.
        //Se tiene que hacer cada vez que se registra un usuario. 
        //Subir usuario.
        static private void SaveUser(List<User> usuario)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, usuario);
            stream.Close();
        }

        //Metodo para subir las personas una vez cerrado el programa.
        //Se tiene que uniciar automaticamente una vez abierto el programa.
        static private List<User> LoadUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<User> usuario = (List <User>) formatter.Deserialize(stream);
            stream.Close();
            return usuario;
        } 

        //Metodo Para mostrar los perfiles.
        //Puede servir para buscar los distintos perfiles.
        static public void ShowProfileUser(List<ProfilelUser> perfil)
        {
            foreach(ProfilelUser persona in perfil)
            {
                Console.WriteLine(persona);
            }
            Console.WriteLine(" ");
        }
        //------------ IMPORTAR CANCION ----------------------------------------------
        static public void AddSong(List<SongClass> cancion)
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Cantante: ");
            string lastName = Console.ReadLine();
            Console.Write("Año publicacion: ");
            int age = int.Parse(Console.ReadLine());
            // Arreglar despues.
            //cancion.Add(new SongClass(name, lastName, age));

        }

        //Metodos para Serializar canciones
        static private void SaveSong(List<SongClass> cancion)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, cancion);
            stream.Close();
        }
        //Deserializacion de cancion.
        static private List<SongClass> LoadSong()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<SongClass> cancion = (List<SongClass>)formatter.Deserialize(stream);
            stream.Close();
            return cancion;
        }
        //------------ IMPORTAR VIDEO ----------------------------------------
        static public void AddVideo(List<Video> video)
        {
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Cantante: ");
            string lastName = Console.ReadLine();
            Console.Write("Año publicacion: ");
            int age = int.Parse(Console.ReadLine());
            // Arreglar despues.
            //cancion.Add(new SongClass(name, lastName, age));

        }

        //Metodos para Serializar Videos
        static private void SaveVideo(List<Video> video)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, video);
            stream.Close();
        }
        //Deserializacion de Video.
        static private List<Video> LoadVideo()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<Video> video = (List<Video>)formatter.Deserialize(stream);
            stream.Close();
            return video;
        }
    }
}