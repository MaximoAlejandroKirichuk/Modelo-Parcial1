using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_parcial.Modelos
{
    public class Usuario
    {
		private string _nombre;

		public string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private string _rol;

		public string Rol
		{
			get { return _rol; }
			set { _rol = value; }
		}


        //metodos
        public Usuario(string nombre,string email, string Password, string rol)
        {
			this.Nombre = nombre;
			this.Email = email;
            this.Password = Password;
			this.Rol = rol;
        }

    }
}
