using System;
using System.Collections.Generic;
using System.Linq;

namespace Entrega_3.Clases
//probando denuevo en conjunto
//sodsojdaofsojaa
{
    [Serializable]
    public class SearchClass
    {
        //Lo cambie a void (AS)
        public void SearchForTitle(string answer, List<SongClass> canciones, List<Video> videos)
        {
            string answer2 = answer.ToUpper(); //Ponerlo en el FORMS
            var title = from s in canciones //Filtro por Titutlo de la cancion. Y video.
                        where s.Title.ToUpper() == answer2
                        select s;
            var title2 = from s in videos
                         where s.Title.ToUpper() == answer2
                         select s;
            foreach (SongClass ojb2 in title)
            {
                //listCanciones.Items.Add(ojb2);
            }
            foreach (Video ojb2 in title2)
            {
                //listCanciones.Items.Add(ojb2);
            }

        }
        public void SearchKeyWord(string answer, List<SongClass> canciones, List<Video> videos)
        {
            var keyWord = from s in canciones //Filtro por palabra clave
                          where s.Keyword == answer
                          select s;
            var keyword2 = from s in videos
                           where s.Keyword == answer
                           select s;
            foreach (SongClass x in keyWord)
            {
                //listCanciones.Items.Add(x);
            }
            foreach (Video z in keyword2)
            {
                //listCanciones.Items.Add(z);
            }
        }
        public void SearchForPerson(string answer, List<SongClass> canciones, List<Video> videos)
        {
            var persona = from s in canciones
                          where s.Singer.Name == answer || s.Composer == answer
                          select s;
            var persona2 = from s in videos
                           where s.Director.Name == answer || s.MainActor.Name == answer
                           select s;
            foreach (SongClass x in persona)
            {
                //listCanciones.Items.Add(x);
            }
            foreach (Video z in persona2)
            {
                //listCanciones.Items.Add(z);
            }
        }
        public void SearchForCharacteristic(string answer, List<SongClass> canciones, List<Video> videos)
        {
            //Busqueda por caracteristica de personas. Se buscara director en videos y singer en canciones.
            // En Ambos se buscara por Gender o Nacionalidad
            var person = from s in canciones
                         where s.Singer.Gender == answer || s.Singer.Nationality == answer
                         select s;
            var person2 = from s in videos
                          where s.Director.Gender == answer || s.Director.Nationality == answer
                          select s;
            foreach (SongClass x123 in person)
            {
                //listCanciones.Items.Add(x123);
            }
            foreach (Video z123 in person2)
            {
                //listCanciones.Items.Add(z123);
            }
        }

        public void SearchForCategory(string answer, List<SongClass> canciones, List<Video> videos)
        {
            var category = from s in canciones //Categoria = Genero de musica, en el caso de video a que tipo pertenece.
                           where s.Gender == answer
                           select s;
            var category2 = from s in videos
                            where s.Gender == answer
                            select s;

            foreach (SongClass y2 in category)
            {
                //listCanciones.Items.Add(y2);
            }
            foreach (Video z1 in category2)
            {
                //listCanciones.Items.Add(z1);
            }
        }
        public void SearchResVideoEvaluation(int entero, List<SongClass> canciones, List<Video> videos)
        {
            //Buscar por resolucion de video o cancion
            var resolution = from s in canciones
                             where s.Resolution == entero
                             select s;
            var resolution2 = from s in videos
                              where s.Resolution == entero
                              select s;
            foreach (SongClass x in resolution)
            {
                //listCanciones.Items.Add(x);
            }
            foreach (Video z in resolution2)
            {
                //listCanciones.Items.Add(z);
            }

            //Buscar por nota definida.
            var nota = from s in canciones
                       where s.Evaluation == entero
                       select s;
            var nota2 = from s in videos
                        where s.Evaluation == entero
                        select s;
            foreach (SongClass x in nota)
            {
                //listCanciones.Items.Add(x);
            }
            foreach (Video z in nota2)
            {
                //listCanciones.Items.Add(z);
            }
        }
        public void SearchForMulti(string[] listaStr, List<SongClass> canciones, List<Video> videos)
        {
            var Multi1 = from s in canciones //Genero y palabra clave
                         where (s.Gender == listaStr[0] && s.Keyword == listaStr[1]) || (s.Gender == listaStr[1] && s.Keyword == listaStr[0])
                         select s;
            var multi2 = from s in videos
                         where (s.Gender == listaStr[0] && s.Keyword == listaStr[1]) || (s.Gender == listaStr[1] && s.Keyword == listaStr[0])
                         select s;
            foreach (SongClass j in Multi1)
            {
                //listCanciones.Items.Add(j);
            }
            foreach (Video j in multi2)
            {
                //listCanciones.Items.Add(j);
            }
            //Palabra clave y persona
            var Mezcla = from s in canciones
                         where (s.Keyword == listaStr[0] && (s.Singer.Name == listaStr[1] || s.Composer == listaStr[1])) || (s.Keyword == listaStr[1] && (s.Singer.Name == listaStr[0] || s.Composer == listaStr[0]))
                         select s;
            var Mezcla2 = from s in videos
                          where (s.Keyword == listaStr[0] && (s.Director.Name == listaStr[1] || s.MainActor.Name == listaStr[1])) || (s.Keyword == listaStr[1] && (s.Director.Name == listaStr[0] || s.MainActor.Name == listaStr[0]))
                          select s;
            foreach (SongClass j in Mezcla)
            {
                //listCanciones.Items.Add(j);
            }
            foreach (Video j in Mezcla2)
            {
                //listCanciones.Items.Add(j);
            }

            //Palabra clave y caracteristica de la persona.
            var anakin = from s in canciones
                         where (s.Keyword == listaStr[0] && (s.Singer.Gender == listaStr[1] || s.Singer.Nationality == listaStr[1])) || (s.Keyword == listaStr[1] && (s.Singer.Gender == listaStr[0] || s.Singer.Nationality == listaStr[0]))
                         select s;
            var anakin2 = from s in videos
                          where (s.Keyword == listaStr[0] && (s.Director.Gender == listaStr[1] || s.Director.Nationality == listaStr[1])) || (s.Keyword == listaStr[1] && (s.Director.Gender == listaStr[0] || s.Director.Nationality == listaStr[0]))
                          select s;
            foreach (SongClass j in anakin)
            {
                //listCanciones.Items.Add(j);
            }
            foreach (Video j in anakin2)
            {
                //listCanciones.Items.Add(j);
            }
        }



    }
}