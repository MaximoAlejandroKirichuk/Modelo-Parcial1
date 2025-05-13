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
    public partial class FormLectura : Form
    {
        public FormLectura()
        {
            InitializeComponent();
        }

        public void CargaDatos()
        {

            if (ListaLibros.Instancia.listalibros.Count > 0) return; 

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data\Libros.csv");
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                string[] vLinea = linea.Split(';');
                string titulo = vLinea[0];
                string autor = vLinea[1];
                int anio = Convert.ToInt32(vLinea[2]);
                int isbn = Convert.ToInt32(vLinea[3]);

                
                
                Libro nuevoLibro = new Libro(titulo, autor, isbn, anio);
                
                ListaLibros.Instancia.agregarLibro(nuevoLibro);
                
            }


        }
        public void actualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaLibros.Instancia.listalibros;
        }
        private void FormLectura_Load(object sender, EventArgs e)
        {
            CargaDatos();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarGrilla();
        }
    }
}
