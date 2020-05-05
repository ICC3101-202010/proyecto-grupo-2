using System;
using System.Collections.Generic;

namespace ProyectoGrupo2
{
    public class CancionClass : AbsMaster
    {
        private string _compositor;
        private string _cantante;
        private string _discografia;
        private string _letra; //FUNCION AGREGADA
        public CancionClass(string genero, string anioPublicacion, int numeroReproducciones,
                     string titulo, int duracion, int memoria, string estudio, string palabraClave,
                     string compositor, string cantante, string discografia, string letra)
        {
            this.genero = genero;
            this.anioPublicacion = anioPublicacion;
            this.numeroReproducciones = numeroReproducciones;
            this.titulo = titulo;
            this.duracion = duracion;
            this.memoria = memoria;
            this.estudio = estudio;
            this.palabraClave = palabraClave;

            this._compositor = compositor;
            this._cantante = cantante;
            this._discografia = discografia;

        }
        public void AgregarDatos()
        {

        }

    }
}
