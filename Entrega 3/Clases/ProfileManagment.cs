using System;
using System.Collections.Generic;
using System.Threading;
namespace Entrega_3.Clases
{
    [Serializable]
    public class ProfileManagment
    {
        private List<Profile> profiles = new List<Profile>();

        public ProfileManagment()
        {

        }

        public List<Profile> Profiles { get => profiles; set => profiles = value; }

        public bool DeleteProfile()
        {
            Console.WriteLine("Lista de perfiles: ");
            int x = 1;
            foreach (Profile c in profiles)
            {
                Console.WriteLine(x + ") Nombre: " + c.NameProfile);
            }
            while (true)
            {
                if (profiles.Count == 0)
                {
                    Console.WriteLine("No hay perfiles para eliminar");
                    break;
                }
                else
                {
                    Console.WriteLine("Seleccione el numero del perfil que desea eliminar: ");
                    string l = Console.ReadLine();
                    int numperfil = Int32.Parse(l);
                    if (numperfil > profiles.Count || numperfil == 0)
                    {
                        Console.WriteLine("El numero no es valido, vuelva a ingresarlo");

                    }
                    else
                    {
                        Console.WriteLine("El perfil a eliminar es: " + profiles[numperfil - 1].NameProfile);


                        while (true)
                        {
                            Console.WriteLine("Esta seguro de eliminar? \n1)si\n2)no\nopcion: ");
                            string vv = Console.ReadLine();
                            int seguro = Int32.Parse(vv);
                            if (seguro == 1)
                            {
                                Console.WriteLine("Eliminando...");
                                Thread.Sleep(2000);
                                profiles.Remove(profiles[numperfil - 1]);
                                Console.WriteLine("Perfil eliminado");
                                return true;
                            }
                            else if (seguro == 2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opcion no valida, por favor escribala denuevo");
                            }
                        }

                        break;
                    }
                }

            }
            return false;




        }
        public bool ChangeProfile()
        {
            Console.WriteLine("Lista de perfiles: ");
            int x = 1;
            foreach (Profile c in profiles)
            {
                Console.WriteLine(x + ") Nombre: " + c.NameProfile);
                x++;
            }
            while (true)
            {
                if (profiles.Count == 0)
                {
                    Console.WriteLine("No hay perfiles para cambiar");
                    break;
                }
                else
                {
                    Console.WriteLine("Seleccione el numero del perfil que desea cambiar: ");
                    string l = Console.ReadLine();
                    int num_per = Int32.Parse(l);
                    int numperfil = Int32.Parse(l) - 1;
                    if (num_per > profiles.Count || num_per == 0)
                    {
                        Console.WriteLine("El numero no es valido, vuelva a ingresarlo");

                    }
                    else
                    {

                        while (true)
                        {
                            Console.WriteLine("Esta seguro de cambiar? \n1)si\n2)no\nopcion: ");
                            string vv = Console.ReadLine();
                            int seguro = Int32.Parse(vv);
                            if (seguro == 1)
                            {
                                Console.WriteLine("Menu: \n1)Cambiar tipo de perfil \n2)Cambiar nombre de perfil \n3)Cambiar gustos musicales \n4)Cambiar gustos peliculas");
                                bool a = true;
                                while (a)
                                {
                                    string op = Console.ReadLine();
                                    int opcion = Int32.Parse(op);
                                    switch (opcion)
                                    {
                                        case 1:

                                            while (true)
                                            {
                                                Console.WriteLine("El perfil es " + profiles[numperfil].ProfileType + ". Desea cambiarlo? \n1)si\n2)no\nopcion: ");
                                                string cambio = Console.ReadLine();
                                                int cam = Int32.Parse(cambio);
                                                if (cam == 1)
                                                {
                                                    if (profiles[numperfil].ProfileType == "publico")
                                                    {
                                                        profiles[numperfil].ProfileType = "privado";

                                                    }
                                                    else if (profiles[numperfil].ProfileType == "privado")
                                                    {
                                                        profiles[numperfil].ProfileType = "publico";
                                                    }
                                                    Console.WriteLine("El perfil " + profiles[numperfil].NameProfile + " ,ahora es " + profiles[numperfil].ProfileType);

                                                    break;
                                                }
                                                else if (cam == 2)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida, por favor escribala denuevo");
                                                }
                                            }
                                            a = false;

                                            break;
                                        case 2:

                                            while (true)
                                            {
                                                Console.WriteLine("El perfil se llama " + profiles[numperfil].NameProfile + " .Desea cambiarlo? \n1)si\n2)no\nopcion: ");
                                                string opNom = Console.ReadLine();
                                                int optionNom = Int32.Parse(opNom);
                                                if (optionNom == 1)
                                                {
                                                    Console.WriteLine("Escriba el nuevo nombre del perfil: ");
                                                    string nuevonombre = Console.ReadLine();
                                                    profiles[numperfil].NameProfile = nuevonombre;
                                                    break;
                                                }
                                                else if (optionNom == 2)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida, por favor escribala denuevo");
                                                }
                                            }
                                            a = false;
                                            break;
                                        case 3:
                                            string[] categorias = { "pop", "romantica", "rock", "metal", "clasica", "country", "latino", "reggae", "disco", "hip-hop", "indie", "chill", "folk", "arabe", "infantil", "cristiana", "soul", "jazz", "punk", "funk", "k-pop" };
                                            Console.WriteLine("III) Ingrese el nuemro de sus 5 generos de musica favoritos: ");
                                            int k = 1;

                                            foreach (string g in categorias)
                                            {
                                                Console.WriteLine(k + ") " + g);
                                                k++;
                                            }
                                            List<string> gustosMusica = new List<string>();
                                            int i = 0;
                                            while (i < 5)
                                            {
                                                string num = Console.ReadLine();
                                                int seleccion = Int32.Parse(num);
                                                if (seleccion < 22 && seleccion > 0)
                                                {
                                                    gustosMusica.Add(categorias[seleccion - 1]);
                                                    Console.WriteLine("Gusto añadido: " + categorias[seleccion - 1]);
                                                    i++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                                                }

                                            }
                                            profiles[numperfil].PleasuresMusic = gustosMusica;
                                            Console.WriteLine("Los nuevos gustos musicales son: ");
                                            int p = 1;
                                            foreach (string tt in profiles[numperfil].PleasuresMusic)
                                            {
                                                Console.WriteLine(p + ") " + tt);
                                                p++;
                                            }

                                            a = false;
                                            break;
                                        case 4:
                                            string[] categoriaspelis = { "terror", "ciencia-ficcion", "romantica", "comedia", "drama", "belicas", "anime", "psicologicas", "crimen", "fantasia", "clasicos", "policiacas", "documentales", "historicas", "biograficas", "catastrofes", "eroticas", "independientes", "mockbuster", "religiosas", "thriller" };
                                            Console.WriteLine("IV) Ingrese el numero de sus 5 categorias de pelicula favoritos: ");
                                            int j = 1;

                                            foreach (string b in categoriaspelis)
                                            {
                                                Console.WriteLine(j + ") " + b);
                                                j++;
                                            }

                                            List<string> gustosPeliculas = new List<string>();
                                            int h = 0;
                                            while (h < 5)
                                            {
                                                string n = Console.ReadLine();
                                                int seleccionpelis = Int32.Parse(n);
                                                if (seleccionpelis < 22 && seleccionpelis > 0)
                                                {
                                                    gustosPeliculas.Add(categoriaspelis[seleccionpelis - 1]);
                                                    Console.WriteLine("Gusto añadido: " + categoriaspelis[seleccionpelis - 1]);
                                                    h++;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                                                }

                                            }
                                            profiles[numperfil].PleasuresMovies = gustosPeliculas;
                                            Console.WriteLine("Los nuevos gustos de peliculas son: ");
                                            int r = 1;
                                            foreach (string ww in profiles[numperfil].PleasuresMovies)
                                            {
                                                Console.WriteLine(r + ") " + ww);
                                                r++;
                                            }
                                            a = false;
                                            break;

                                        default:
                                            Console.WriteLine("Opcion no valida, vuelva a ingresarla");
                                            break;


                                    }
                                }
                                break;
                            }
                            else if (seguro == 2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opcion no valida, por favor escribala denuevo");
                            }
                        }

                        break;
                    }
                }

            }


            return true;
        }
        public bool AddProfile()
        {
            Console.WriteLine("Complete la siguiente información: \nI)Nombre del perfil: ");
            string nombre = Console.ReadLine();
            string tipoperfil;

            while (true)
            {
                Console.WriteLine("II)Tipo perfil(escriba 1 o 2):\n  1)Perfil publico\n  2)Perfil privado ");
                string op = Console.ReadLine();
                int perfil = Int32.Parse(op);

                if (perfil == 1)
                {
                    tipoperfil = "publico";
                    break;
                }
                else if (perfil == 2)
                {
                    tipoperfil = "privado";
                    break;
                }
                else
                {
                    Console.WriteLine("opcion no valida, vuelva a ingresarla");
                }
            }
            string[] categorias = { "pop", "romantica", "rock", "metal", "clasica", "country", "latino", "reggae", "disco", "hip-hop", "indie", "chill", "folk", "arabe", "infantil", "cristiana", "soul", "jazz", "punk", "funk", "k-pop" };
            Console.WriteLine("III) Ingrese el nuemro de sus 5 generos de musica favoritos: ");
            int k = 1;

            foreach (string a in categorias)
            {
                Console.WriteLine(k + ") " + a);
                k++;
            }
            List<string> gustosMusica = new List<string>();
            int i = 0;
            while (i < 5)
            {
                string num = Console.ReadLine();
                int seleccion = Int32.Parse(num);
                if (seleccion < 22 && seleccion > 0)
                {
                    gustosMusica.Add(categorias[seleccion - 1]);
                    Console.WriteLine("Gusto añadido: " + categorias[seleccion - 1]);
                    i++;
                }
                else
                {
                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                }

            }
            Thread.Sleep(2000);
            string[] categoriaspelis = { "terror", "ciencia-ficcion", "romantica", "comedia", "drama", "belicas", "anime", "psicologicas", "crimen", "fantasia", "clasicos", "policiacas", "documentales", "historicas", "biograficas", "catastrofes", "eroticas", "independientes", "mockbuster", "religiosas", "thriller" };
            Console.WriteLine("IV) Ingrese el numero de sus 5 categorias de pelicula favoritos: ");
            int j = 1;

            foreach (string b in categoriaspelis)
            {
                Console.WriteLine(j + ") " + b);
                j++;
            }

            List<string> gustosPeliculas = new List<string>();
            int h = 0;
            while (h < 5)
            {
                string n = Console.ReadLine();
                int seleccionpelis = Int32.Parse(n);
                if (seleccionpelis < 22 && seleccionpelis > 0)
                {
                    gustosPeliculas.Add(categoriaspelis[seleccionpelis - 1]);
                    Console.WriteLine("Gusto añadido: " + categoriaspelis[seleccionpelis - 1]);
                    h++;
                }
                else
                {
                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                }

            }

            //Profile per = new Profile(nombre, tipoperfil, gustosMusica, gustosPeliculas);

            Console.WriteLine("Agregando perfil...");
            //profiles.Add(per);
            Thread.Sleep(2000);
            Console.WriteLine("Perfil agregado");
            return true;
        }

        public bool SeeProfile()
        {
            if (profiles.Count > 0)
            {

                int y = 1;
                foreach (Profile c in profiles)
                {
                    Console.WriteLine(y + ") Nombre: " + c.NameProfile);
                    Console.WriteLine("Tipo perfil: " + c.ProfileType);
                    Console.WriteLine("Gustos musicales: ");
                    int m = 1;
                    foreach (string a in c.PleasuresMusic)
                    {
                        Console.WriteLine(m + ") " + a);
                        m++;
                    }

                    Console.WriteLine("\nGustos peliculas: ");
                    int t = 1;
                    foreach (string g in c.PleasuresMovies)
                    {
                        Console.WriteLine(t + ") " + g);
                        t++;
                    }
                    y++;
                }
                return true;
            }
            else
            {
                Console.WriteLine("No hay perfiles");
                return false;
            }
        }

    }


}
