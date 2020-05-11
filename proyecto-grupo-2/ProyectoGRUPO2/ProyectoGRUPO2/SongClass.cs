using System;
namespace ProyectoGRUPO2
{
    [Serializable]
    public class SongClass : AbsMaster
    {
        private string composer;
        private string singer;
        private string album; //AGERGAR A SUS RESPECTIVAS CLASES
        private string lyrics;
        private string format;

        public SongClass(string gender, string publicationYear,
                     string title, int duration, int memory, string study, string keyword,
                     string composer, string singer, string album, string lyrics, string format)
        {
            this.Gender = gender; // listo
            this.PublicationYear = publicationYear;//listo
          
            this.Title = title;//Listo
            this.Duration = duration;//Predeterminada
            this.Memory = memory;//Cada cancion pesa un nuero random [1-50]
            this.Study = study;// Listo
            this.Keyword = keyword; //Listo
            this.Composer = composer; //Listo
            this.Singer = singer; // Listo
            this.Album = album; // Listo
            this.Lyrics = lyrics;//EN veremos.
            this.Format = format; // Listo


        }
        public string Format { get => format; set => format = value; }
        public string Composer { get => composer; set => composer = value; }
        public string Singer { get => singer; set => singer = value; }
        public string Album { get => album; set => album = value; }
        public string Lyrics { get => lyrics; set => lyrics = value; }

        public void AddDate()
        {

        }

    }
}//rfddhh