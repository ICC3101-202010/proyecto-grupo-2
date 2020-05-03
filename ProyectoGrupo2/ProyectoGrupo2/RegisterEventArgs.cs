using System;
using System.Collections.Generic;
using System.Text;
namespace ProyectoGrupo2
{
    public class RegisterEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerificationLink { get; set; }
        public string Plan { get; set; }
        public string InfoPago { get; set; } //cambiar a ingles

    }
}
