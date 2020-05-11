using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ProyectoGRUPO2
{
    public class SMSSender
    {
        public void OnPasswordChanged(object source, ChangePasswordEventArgs e)
        {
            Thread.Sleep(2000);
            Console.WriteLine($"\nSMS enviado a {e.Number}: \n {e.Username}, te notificamos que la contrasena de tu cuenta PlusCorp ha sido cambiada. \n");
            Thread.Sleep(2000);
        }
    }
}
