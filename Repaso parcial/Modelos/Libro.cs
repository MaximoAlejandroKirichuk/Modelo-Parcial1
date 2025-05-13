using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class Libro 
    {
		private string _titulo;

		public string Titulo
		{
			get { return _titulo; }
			set { _titulo = value; }
		}

		private string _autor;

		public string Autor
		{
			get { return _autor; }
			set { _autor = value; }
		}

		private int _isbn;

		public int ISBN
		{
			get { return _isbn; }
			set { _isbn = value; }
		}

		private int _anio;

		public int Anio
		{
			get { return _anio; }
			set { _anio = value; }
		}

        //metodos


        public Libro()
        {
            
        }
        public Libro(string titulo, string autor, int isbn, int anio)
        {
            this.Titulo = titulo;
			this.Autor = autor;
			this.Anio = anio;
			this.ISBN = isbn;
        }
    }
}
