using Repaso_parcial.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_parcial.Vistas
{
    public partial class FormABMUsuarios : Form
    {
        public FormABMUsuarios()
        {
            InitializeComponent();
        }
        public void actualizarData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaUsuarios.Instancia.listaUsuarios;
        }
        public void FormABMUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("Seleccione un usuario para borrarlo");
            }

            int indice = dataGridView1.SelectedRows[0].Index;
            ListaUsuarios.Instancia.EliminarUsuario(indice);
            actualizarData();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 0)
            {
                MessageBox.Show("Seleccione un usuario para modificarlo");
            }

            int indice = dataGridView1.SelectedRows[0].Index;
            Usuario usuarioEncontrado = ListaUsuarios.Instancia.listaUsuarios[indice];

            usuarioEncontrado.Email = txtEmail.Text;
            usuarioEncontrado.Password = txtPassword.Text;
            usuarioEncontrado.Nombre = txtNombre.Text;

            actualizarData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                MessageBox.Show(indice.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<Usuario> listaUsuariosGuardar = ListaUsuarios.Instancia.listaUsuarios;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Data/Usuarios1.csv");
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Email;Password;Nombre;Rol");
            foreach (Usuario usuario in listaUsuariosGuardar)
            {
                sw.WriteLine($"{usuario.Email};{usuario.Password};{usuario.Nombre};{usuario.Rol}");
            }

            sw.Close();
            fs.Close();
            MessageBox.Show("Se guardo correctamente el archivo");
            actualizarData();
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (ListaUsuarios.Instancia.listaUsuarios.Count > 0) return;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\Usuarios1.csv");

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();//ignora los encabezados
           

            while ((linea = sr.ReadLine()) != null)
            {
                string[] vLinea = linea.Split(';');
                string email = vLinea[0];
                string password = vLinea[1];
                string nombre = vLinea[2];
                string rol = vLinea[3];

                Usuario nuevoUsuario = new Usuario(nombre, email, password, rol);
                ListaUsuarios.Instancia.AgregarUsuario(nuevoUsuario);
            }

            fs.Close();
            sr.Close();
            actualizarData();
        }
    }
}
