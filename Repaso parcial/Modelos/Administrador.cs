using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class Administrador : Usuario
    {
        //ESTO SIRVE PARA 
        public Administrador(string nombre, string email, string password, string rol):base(nombre, email, password, rol)
        {
            this.Nombre = nombre;
            this.Email = email;
            this.Password = password;
            this.Rol = rol;
        }

    }
}
