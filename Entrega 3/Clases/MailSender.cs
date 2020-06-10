using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entrega_3.Clases
{
    [Serializable]
    public class MailSender
    {
        public void OnRegistered(object source, RegisterEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}: \n Gracias por registrarte, {e.Username}!\n Por favor, para poder verificar tu correo, has click en: {e.VerificationLink}\n");
            Thread.Sleep(2000);
            OnEmailSented(); //para ver si quiere hacer la confirmacion ,Se dispara luego que el usuario se regristro correctamente
        }

        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nCorreo enviado a {e.Email}:  \n {e.Username}, te notificamos que la contrasena de tu cuenta PlusCorp ha sido cambiada. \n");
            Thread.Sleep(2000);
        }

        //aqui creare el evento de EmailSent

        // Paso 1: Creamos el delegate para el evento del enviarmail
        public delegate void EmailSentEventHandler(object source, EventArgs args);
        // Paso 2: Creamos el evento que se engatilla cuando el usuario se registra
        public event EmailSentEventHandler EmailSented;

        protected virtual void OnEmailSented() //(1)
        {
            EmailSented(this, EventArgs.Empty);  //lanza el evento despues del correo de confirmacion


        }
    }
}