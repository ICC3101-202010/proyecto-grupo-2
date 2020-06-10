using System;
using System.Collections.Generic;

namespace Entrega_3.Clases
{



    public class DataBase
    {

        // Diccionario para guardar todos los registros
        // Los datos de cada registro se guardan en List<string> con formato [usuario, correo, password, linkVerificacion, fecha, numero]
        private Dictionary<int, List<string>> registered;

        // Constructor
        public DataBase()
        {
            registered = new Dictionary<int, List<string>>();
        }

        // Metodo para cambiar la contrasena de usr por newpsswds
        public void ChangePassword(string usr, string newpsswd)
        {
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usr)
                {
                    user[2] = newpsswd;
                }
            }
        }

        public void ChangeEmail(string usr, string newpsswd)
        {
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usr)
                {
                    user[1] = newpsswd;
                }
            }
        }


        public void ChangeTargetPay(string usr, string newpsswd)
        {
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usr)
                {
                    user[5] = newpsswd;
                }
            }
        }
        public void ChangePlan(string usr, string newpsswd)
        {
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usr)
                {
                    user[4] = newpsswd;
                }
            }
        }


        public void IniciarSecion(string usr)
        {
            foreach (List<string> user in this.registered.Values)
            {

            }





        }
        // Metodo para realizar el LogIn
        public string LogIn(string usrname, string password)
        {
            string description = null;
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usrname && user[2] == password)
                {
                    return description;
                }
            }
            return "Usuario o contrasena incorrecta";
        }








        // Metodo para agregar un nuevo usuario, verificando ademas que no exista
        public string AddUser(List<string> data)
        {
            string description = null;
            foreach (List<string> value in this.registered.Values)
            {
                if (data[0] == value[0])
                {
                    description = "El nombre de usuario especificado ya existe";
                }
                else if (data[1] == value[1])
                {
                    description = "El correo ingresado ya existe";
                }
            }
            if (description == null)
            {
                this.registered.Add(registered.Count + 1, data);
            }
            return description;
        }

        // Metodo para obtener los datos de usr
        public List<string> GetData(string usr)
        {
            foreach (List<string> user in this.registered.Values)
            {
                if (user[0] == usr)
                {
                    return user;
                }
            }

            return new List<string>();
        }


    }
}