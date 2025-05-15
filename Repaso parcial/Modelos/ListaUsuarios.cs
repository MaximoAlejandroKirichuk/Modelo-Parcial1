using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class ListaUsuarios
    {
        private static ListaUsuarios _instancia;

        public List<Usuario> listaUsuarios { get; private set; }


        private ListaUsuarios()
        {
            listaUsuarios = new List<Usuario>();
        }

        public static ListaUsuarios Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new ListaUsuarios();
                }

                return _instancia;
            }
        }

        public void AgregarUsuario(Usuario nuevo)
        {
            listaUsuarios.Add(nuevo);
        }

        public void EliminarUsuario(int indiceBorrar)
        {
            listaUsuarios.RemoveAt(indiceBorrar);
        }
        
      

    }
}
