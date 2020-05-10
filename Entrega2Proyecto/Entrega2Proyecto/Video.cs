using System;
using System.Collections.Generic;

namespace ProyectoGrupo2
{
    public class Video : AbsMaster
    {
        private string _categoria;
        private List<string> actores;
        private string _descripcion;
        //CAMBIAR LOS SUBTITUTLOS, DARSELOS A CANCION.
        private string _actorPrincipal;
        public Video(string genero, string añoPublicacion, int numeroReproducciones,
                     string titulo, int duracion, int memoria, string estudio, string palabraClave, string categoria,
                     string descripcion, string actorPrincipal)
        {
            this.genero = genero;
            this.añoPublicacion = añoPublicacion;
            this.numeroReproducciones = numeroReproducciones;
            this.titulo = titulo;
            this.duracion = duracion;
            this.memoria = memoria;
            this.estudio = estudio;
            this.palabraClave = palabraClave;

            this._categoria = categoria;
            this._descripcion = descripcion;
            this._actorPrincipal = actorPrincipal;

            actores = new List<string>();
        }
        public void AgregarDatos() //Cambiar UML  void
        {

        }

    }
}
