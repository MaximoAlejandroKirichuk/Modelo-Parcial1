using Repaso_parcial.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        List <Libro> listalibros = new List<Libro>();
        public void ActualizarGrilla() 
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listalibros;
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

            if (listalibros.Any(l => l.ISBN == libro.ISBN))
            {
                MessageBox.Show("Ya existe un libro con ese ISBN, pruebe otro ISBN");
                return;
            }

            listalibros.Add(libro);
            ActualizarGrilla();
            MessageBox.Show("Libro agregado correctamente");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int indice = dataGridView1.SelectedRows[0].Index;
                listalibros.RemoveAt(indice);
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
                Libro libro = listalibros[indice];
                txtTitulo.Text = libro.Titulo;
                txtAutor.Text = libro.Autor;
                txtAnio.Text = libro.Anio.ToString();
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
    }
}
