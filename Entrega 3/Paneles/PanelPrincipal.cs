using Entrega_3.Paneles;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

namespace Entrega_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        Clases.DataBase database = new Clases.DataBase();

        Clases.MailSender mailSender = new Clases.MailSender();

        Clases.User user = new Clases.User();
        DateTime hora = new DateTime();

        Clases.ProfilelUser perfi2 = new Clases.ProfilelUser();
        double intervalo = 1000;

        //SongClass cancion = new SongClass(); Ya instancie este objeto.
        //Video video = new Video(); // YA instancie
        Clases.ProfileManagment profileManagment = new Clases.ProfileManagment();
        IDictionary<Clases.User, List<Clases.Profile>> diccUserProfiles = new Dictionary<Clases.User, List<Clases.Profile>>();
        List<Clases.User> usuarios = new List<Clases.User>();
        Clases.Serialization serializar = new Clases.Serialization();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormsRegistro panelregistro = new FormsRegistro();
            panelregistro.Show();
        }

        private void button2_Click(object sender, EventArgs e) //Login. Al momento de apretar Login se tienen que cargar todos los usuarios.
        {
            string a = "c";//suponemos es premiun
            string b = "b";//suponemos es familiar
            List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("POR FAVOR RELLENE AMBOS DATOS");
            }

            else if (deserializarUser.Count > 0)//aca hay que poner que se verifique el inicio de secion
            {
                int error = 1;
                int avanzar = 0;
                Clases.User us = new Clases.User();
                for (int d = 0; d < deserializarUser.Count; d++)
                {
                    error--;
                    if (deserializarUser[d].NameUser == txtUsuario.Text && deserializarUser[d].Password ==txtContraseña.Text)
                    {
                        us = deserializarUser[d];
                        avanzar++;
                    }
                    else
                    {
                        error++;
                    }

                }
                if (error > 0)
                {
                    MessageBox.Show("Usuario o contraseña invalida");
                }
                if(avanzar > 0)
                {
                    this.Hide();
                    FormAplicacion formAplicacion = new FormAplicacion(us);
                    formAplicacion.Show();
                }


            } 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnVolverNormalidad.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVolverNormalidad_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnVolverNormalidad.Visible = false;
            btnMaximizar.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
