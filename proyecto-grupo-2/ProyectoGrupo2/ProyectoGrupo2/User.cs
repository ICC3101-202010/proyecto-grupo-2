using System;
using System.Threading;

namespace Lab5Poo

{

    public class User //(2)
    {
        public int EmailVerified { get; internal set; }


        //aqui creare el evento de EmailVerified

        // Paso 1: Creamos el delegate para el evento de verificar mail
        public delegate void EmailVerifiEventHandler(object source, EventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando el usuario se registra
        public event EmailVerifiEventHandler EmailVerifi;

        protected virtual void OnEmailVerified(User user, EventArgs args)
        {
            OnEmailVerified(this, new EventArgs());  //lanza el evento despues del correo de confirmacion

        }
        //crearemos el metodo



        public void OnEmailSent(object source, EventArgs args)  //este solamente es lanzado cuando el usuario se registra correctamente y se coloca en mailsender despues de que se registro correctamente




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