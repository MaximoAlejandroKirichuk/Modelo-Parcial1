using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class ListaUsuarios
    {
        public static List <Usuario> milista = new List<Usuario>();

        public static void AgregarUsuario(Usuario nuevo)
        {
            milista.Add(nuevo);
        }

    }
}
