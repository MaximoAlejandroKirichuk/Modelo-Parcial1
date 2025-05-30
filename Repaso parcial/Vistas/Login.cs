﻿using Repaso_parcial.Modelos;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Data/Usuarios1.csv");
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string linea = sr.ReadLine();
            string[] vLinea = new string[0];

            while (linea != null)
            {
                vLinea = linea.Split(';');
                //esto sirve para encontrar a la persona dentro del archivo
                string email = vLinea[0];
                string password = vLinea[1];
                string nombre = vLinea[2];
                string rol = vLinea[3];

                if (email == txtEmail.Text && password == txtContrasenia.Text)
                {
                    //no necesito recorrer mas el archivo por eso lo cierro
                    sr.Close();
                    fs.Close();
                    //creo un usuario depende de que rol tenga
                    Form1 form1 = new Form1();
                    if (rol == "Administrador")
                    {
                        Administrador administradorActual = new Administrador(nombre, email, password, rol);
                        form1.UsuarioActivo = administradorActual;
                    }

                    if (rol == "Lector")
                    {
                        Lector lectorActual = new Lector(nombre, email, password, rol);
                        form1.UsuarioActivo = lectorActual;
                    }
                    form1.ShowDialog();
                    return; // Detengo la ejecución acá

                }
                linea = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            MessageBox.Show("Credenciales incorrectas.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSignup formSignup = new FormSignup();
            formSignup.ShowDialog();
        }
    }
}
