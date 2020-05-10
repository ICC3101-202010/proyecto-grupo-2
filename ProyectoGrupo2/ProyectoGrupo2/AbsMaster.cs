using System;
namespace ProyectoGrupo2
{
    
    public class AbsMaster
    {
        protected string genero;
        protected string añoPublicacion;
        protected int numeroReproducciones;
        protected string titulo;
        protected int duracion;
        protected int memoria;
        protected string estudio;
        protected string palabraClave;

        public AbsMaster() // Alvarin
        {
            
        }
        // Terminar Metodos.
        public bool AgregarImagen(string imagen)
        {
            return true;
        }
        public bool AgregarLike()
        {
            return true;
        }
        public bool AgregarCalificacion()
        {
            return true;
        }
        public bool AgregarReproduccion()
        {
            return true;
        }
        public bool AgregarListaReproduccion()
        {
            return true;
        }
    }
}
//hh