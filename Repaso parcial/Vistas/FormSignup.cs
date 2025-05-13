using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Repaso_parcial.Modelos;
namespace Repaso_parcial.Vistas
{
    public partial class FormSignup : Form
    {
        public FormSignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Creo el archivo csv
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../Data/Usuarios1.csv");
            
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            //creo la linea y leo la primera
            string linea = sr.ReadLine();
            
            //la primer linea valida
            linea = sr.ReadLine();

            //armo el vector 
            string[] Vlinea = new string[0];
            while (linea != null)
            {
                Vlinea = linea.Split(';');
                //verifico si ya existe email
                if (Vlinea[0] == txtEmail.Text)
                {
                    MessageBox.Show("El email ya existe");
                    sr.Close();
                    fs.Close();
                    return;
                }
                linea = sr.ReadLine();
            }
            sr.Close();
            fs.Close();

            //esto agrega al final
            FileStream fs2 = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            
            //siempre lector hay un solo un administrador 
            sw.WriteLine(txtEmail.Text + ";" + txtPassword.Text + ";" + txtNombre.Text + ";" + "Lector");
            MessageBox.Show("Usuario creado correctamente");
            txtEmail.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
            sw.Close();
            fs2.Close();
        }
    }
}
