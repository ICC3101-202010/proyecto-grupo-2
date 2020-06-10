using System;
using System.Collections.Generic;
using System.Threading;

namespace Entrega_3.Clases
{
    [Serializable]
    public class PrintAndReceive
    {
        public PrintAndReceive()
        {
        }
        public void PrintMenuPrincipal()//para usuarios premiun y plan familiar 
        {
            Console.WriteLine("BIENVENIDO A SPOTFLIX");
            Console.WriteLine("1)Mi musica");
            Console.WriteLine("2)Playlist musica");//
            Console.WriteLine("3)playlis video");
            Console.WriteLine("4)Buscar Musica");
            Console.WriteLine("5)Buscar Video");
            Console.WriteLine("6)Importar Cancion");
            Console.WriteLine("7)Importar Video");
            Console.WriteLine("8)ajustes");
            Console.WriteLine("9)salir");
        }

        public void MenuBasicPlan() //para usuarios plan basico
        {

            Console.WriteLine("BIENVENIDO A SPOTFLIX");
            Console.WriteLine("1) Buscar Cancion");
            Console.WriteLine("2)Buscar Video");

            Console.WriteLine("3)ajustes");
            Console.WriteLine("4)salir");

        }

        public void PrintMenu1BP() { }
        public void PrintMenu2BP() { }


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

            Console.WriteLine("1)Busqueda por compositor"); //Listo
            Console.WriteLine("2)Busqueda por integrante");
            Console.WriteLine("3)Busqueda por cantante"); //Listo
            Console.WriteLine("4)Busqueda por palabra clave"); //Listo
        }
        public void PrintMenu5()
        {
            Console.WriteLine("1)Busqueda por director"); //Listo
            Console.WriteLine("2)Busqueda por caracteristica");
            Console.WriteLine("3)Busqueda por evaluacion");
            Console.WriteLine("4)Busqueda por palabra clave"); //Listo
        }
        public void PrintMenu6()//ajustes solo para plan familiar
        {
            Console.WriteLine("1)Cambiar Perfil");
            Console.WriteLine("2)Agregar Perfil");
            Console.WriteLine("3)Eliminar Perfil");
            Console.WriteLine("4)Cambiar Plan");
            Console.WriteLine("5)Cambiar Tarjeta de pago");
            Console.WriteLine("6)Cambiar contraseña");
            Console.WriteLine("7)Cambiar email");
            Console.WriteLine("8)Volver");

        }
        public void PrintMenu61()//ajustes solo para premiun y basic
        {
            Console.WriteLine("1)Cambiar Plan");
            Console.WriteLine("2)Cambiar Tarjeta de pago");
            Console.WriteLine("3)Cambiar contraseña");
            Console.WriteLine("4)cambiar Email");
            Console.WriteLine("5)Volver");
        }

        public void PrintMenu7()
        {
            Console.WriteLine("Gracias , volvera al menu de inicio");

        }

    }

}