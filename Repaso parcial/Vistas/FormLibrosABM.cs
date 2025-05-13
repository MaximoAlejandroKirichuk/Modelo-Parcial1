using Repaso_parcial.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_parcial.Vistas
{
    public partial class FormLibrosABM : Form
    {
        public FormLibrosABM()
        {
            InitializeComponent();
        }
        
        public void ActualizarGrilla() 
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaLibros.Instancia.listalibros;
        }
        public void LimpiarTextBox()
        {
            txtAnio.Clear();
            txtAutor.Clear();
            txtISBN.Clear();
            txtTitulo.Clear();
        }
        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrEmpty(txtAutor.Text))
            {
                MessageBox.Show("Debe completar todos los datos");
                return;
            }
            int isbn = 0;
            int anio = 0;
            try
            {
                isbn = Convert.ToInt32(txtISBN.Text);
                anio = Convert.ToInt32(txtAnio.Text);
            }
            catch
            {
                MessageBox.Show("Ingrese un ISBN o año validos");
                return;
            }
            
            Libro libro = new Libro();
            libro.Titulo = txtTitulo.Text;
            libro.Autor = txtAutor.Text;
            libro.ISBN = isbn;
            libro.Anio = anio;

            if (ListaLibros.Instancia.listalibros.Any(l => l.ISBN == libro.ISBN))
            {
                MessageBox.Show("Ya existe un libro con ese ISBN, pruebe otro ISBN");
                return;
            }

            ListaLibros.Instancia.listalibros.Add(libro);
            LimpiarTextBox(); 
            ActualizarGrilla();
            MessageBox.Show("Libro agregado correctamente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                ListaLibros.Instancia.listalibros.RemoveAt(indice);
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un libro para eliminar");
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                Libro libro = ListaLibros.Instancia.listalibros[indice];
                libro.Titulo = txtTitulo.Text ;
                libro.Autor = txtAutor.Text;
                libro.Anio = Convert.ToInt32(txtAnio.Text);
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione un libro para editar");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int isbnSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ISBN"].Value);
                MessageBox.Show("ISBN seleccionado: " + isbnSeleccionado);
            }
        }

        private void btnGuardarLista_Click(object sender, EventArgs e)
        {
            //siempre creo una nueva lista

            List<Libro> listaGuardar = ListaLibros.Instancia.listalibros;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\Libros.csv");

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                // Encabezado 
                sw.WriteLine("Titulo;Autor;Anio;ISBN");

                // Escribir cada libro como línea CSV
                foreach (Libro libro in listaGuardar)
                {
                    sw.WriteLine($"{libro.Titulo};{libro.Autor};{libro.Anio};{libro.ISBN}");
                }
            }
        }

        public void CargarDatos()
        {
            if (ListaLibros.Instancia.listalibros.Count > 0) return;

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\Data\Libros.csv");
            FileStream fs = new FileStream(path,FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();
            
            while ((linea = sr.ReadLine()) != null)
            {
                string[] vLinea = linea.Split(';');
                string titulo = vLinea[0];
                string autor = vLinea[1];
                int anio = Convert.ToInt32(vLinea[2]);
                int isbn = Convert.ToInt32(vLinea[3]);
                

                Libro nuevoLibro = new Libro(titulo, autor, isbn,anio);
                ListaLibros.Instancia.agregarLibro(nuevoLibro);
                
            }


        }

        private void FormLibrosABM_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ActualizarGrilla();
        }
    }
}
