﻿using System;
using System.Collections.Generic;

namespace ProyectoGrupo2
{
    public class Album
    {
<<<<<<< HEAD
        //ALVARO NUEVi
=======
        //ALVARO NUEVa
>>>>>>> dd1773ca4be6d1068bd8dd29ecb6fda0c49c8f37
        private string nameAlbum;
        private string gender;
        private string producer;  
         
        private List<SongClass> listSongs;
        private Singer singer;
        private DateTime publicationDate;

        public Album()
        {
        }

        public string NameAlbum { get => nameAlbum; set => nameAlbum = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Producer { get => producer; set => producer = value; }
        public List<SongClass> ListSongs { get => listSongs; set => listSongs = value; }
        public Singer Singer { get => singer; set => singer = value; }
        public DateTime PublicationDate { get => publicationDate; set => publicationDate = value; }
    }
}