using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class ListaLibros
    {
        //Clase Singleton
        private static ListaLibros _instancia;
        public List<Libro> listalibros { get; private set; }  

        // Constructor privado para que no se pueda crear desde fuera
        private ListaLibros()
        {
            listalibros = new List<Libro>();
        }
        // Método público para acceder a la única instancia
        public static ListaLibros Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new ListaLibros();
                }
                return _instancia;
            }
        }
        
        public void agregarLibro(Libro nuevoLibro)
        {
            listalibros.Add(nuevoLibro);
        }
    }
}
