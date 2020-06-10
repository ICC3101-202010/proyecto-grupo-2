using System;
using System.Collections.Generic;

namespace Entrega_3.Clases

{ //Probando probando
    [Serializable]
    public class Album 
    {


        private string nameAlbum;
        private string gender;
        private string producer;

        private List<SongClass> listSongs;
        private Singer singer;
        private DateTime publicationDate;

        public Album()
        {
        }

        public Album(string nameAlbum, string gender, string producer, Singer singer, DateTime publicationDate)
        {
            this.nameAlbum = nameAlbum;
            this.gender = gender;
            this.producer = producer;
            this.singer = singer;
            this.publicationDate = publicationDate;
        }

        public string NameAlbum { get => nameAlbum; set => nameAlbum = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Producer { get => producer; set => producer = value; }
        public List<SongClass> ListSongs { get => listSongs; set => listSongs = value; }
        public Singer Singer { get => singer; set => singer = value; }
        public DateTime PublicationDate { get => publicationDate; set => publicationDate = value; }


    }
}
