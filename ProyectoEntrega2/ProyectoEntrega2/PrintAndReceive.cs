using System;
namespace ProyectoGrupo2
{
    public class PrintAndReceive
    {
        public PrintAndReceive()
        {
        }
        public void PrintMenuPrincipal()
        {
            Console.WriteLine("BIENVENIDO A SPOTFLIX");
            Console.WriteLine("1)Mi musica");
            Console.WriteLine("2)Playlist musica");//
            Console.WriteLine("3)playlis video");
            Console.WriteLine("4)Buscar Musica");
            Console.WriteLine("5)Buscar Video");

            Console.WriteLine("6)ajustes");
            Console.WriteLine("7)salir");
        }

        public void PrintMenu1()
        { }
        public void PrintMenu2()
        {
            Console.WriteLine("1)Mis Playlist");
            Console.WriteLine("2)Crear nueva Playlist");
            Console.WriteLine("3)Eliminar playlist");
        }
        public void PrintMenu3()
        {
            Console.WriteLine("1)Mis Playlist");
            Console.WriteLine("2)Crear nueva Playlist");
            Console.WriteLine("3)Eliminar playlist");
        }
        public void PrintMenu4()
        {

            Console.WriteLine("1)Busqueda por compositor)");
            Console.WriteLine("2)Busqueda por integrante)");
            Console.WriteLine("3)Busqueda por evaluacion");
            Console.WriteLine("4)Busqueda por palabra clave");
        }
        public void PrintMenu5()
        {
            Console.WriteLine("1)Busqueda por actores)");
            Console.WriteLine("2)Busqueda por caracteristica)");
            Console.WriteLine("3)Busqueda por evaluacion");
            Console.WriteLine("4)Busqueda por palabra clave");
        }
        public void PrintMenu6()
        {
            Console.WriteLine("1)Cambiar Perfil");
            Console.WriteLine("2)Agregar Perfil");
            Console.WriteLine("3)Eliminar Perfil");
            Console.WriteLine("4)Cambiar Plan");
            Console.WriteLine("5)Cambiar Target Pay");
            Console.WriteLine("6)Cambiar contraseña");//funcionando

        }
        public void PrintMenu7()
        {
            Console.WriteLine("Gracias , volvera al menu de inicio");

        }


    }



}
