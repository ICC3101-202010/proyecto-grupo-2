using System;
using System.Collections.Generic;

namespace ProyectoGrupo2

{

    public class ProfileManagment
    {
        private List<ProfilelUser> profiles;

        public ProfileManagment()
        {

        }

        public List<ProfilelUser> Profiles { get => profiles; set => profiles = value; }

        public bool DeleteProfile()
        {
            return true;
        }
        public bool ChangeProfile()
        {
            return true;
        }
        public bool AddProfile()
        {
            return true;
        }

    }


}
