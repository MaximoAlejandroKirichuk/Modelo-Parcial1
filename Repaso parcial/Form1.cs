using Repaso_parcial.Modelos;
using Repaso_parcial.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_parcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //variable global 
        private Usuario _usuarioActivo;

        public Usuario UsuarioActivo
        {
            get { return _usuarioActivo; }
            set { _usuarioActivo = value; }
        }

        public void EsconderMenuTrip()
        {
            registroLibroToolStripMenuItem.Visible = false;
            lecturaToolStripMenuItem.Visible = true;
            aBMUsuToolStripMenuItem.Visible = false;
        }
        public void MostrarMenuTrip()
        {
            registroLibroToolStripMenuItem.Visible = true;
            lecturaToolStripMenuItem.Visible = true;
            aBMUsuToolStripMenuItem.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if(UsuarioActivo.Rol == "Administrador")
            {
                MostrarMenuTrip();
            }
            if(UsuarioActivo.Rol == "Lector")
            {
                EsconderMenuTrip();
            }
        }

        private void registroLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLibrosABM formLibrosABM = new FormLibrosABM();
            formLibrosABM.ShowDialog();
        }

        private void lecturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLectura formLectura = new FormLectura();
            formLectura.ShowDialog();
        }

        private void aBMUsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormABMUsuarios formABMUsuarios = new FormABMUsuarios();
            formABMUsuarios.ShowDialog();
        }
    }
}
