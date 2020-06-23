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
using System.Runtime.InteropServices;

namespace Entrega_3.Paneles
{
    public partial class guardarpaneles : Form
    {

        public guardarpaneles()
        {
            InitializeComponent();
        }
        Clases.Serialization serializar = new Clases.Serialization();
        Clases.DataBase database = new Clases.DataBase();

        Clases.MailSender mailSender = new Clases.MailSender();

        Clases.User user = new Clases.User();
        DateTime hora = new DateTime();

        Clases.ProfilelUser perfi2 = new Clases.ProfilelUser();
        double intervalo = 1000;

        //SongClass cancion = new SongClass(); Ya instancie este objeto.
        //Video video = new Video();  YA instancie
        List<Clases.User> todosUsuarios = new List<Clases.User>();

        Clases.ProfileManagment profileManagment = new Clases.ProfileManagment();
        List<Clases.Profile> perfiles = new List<Clases.Profile>();
        Clases.User usuarioEscogido; 
        Clases.User usuarioEscogido2;
        Clases.User usuarioEscogido3;
        List<Clases.User> usuarios;
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            label52.Text = "-";
            label55.Text = "-";
            label45.Text = "-";
            label50.Text = "-";
            label46.Text = "-";
            label51.Text = "-";
            label58.Text = "-";
            label44.Text = "-";
            label53.Text = "-";
            label49.Text = "-";
            label37.Text = "-";
            label57.Text = "-";
            txtNumeroTarjeta.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txtCodigoSeguridadTarjeta.Text = "";
            txtNombreR.Text = "";
            txtANombreUsuarioR.Text = "";
            txtConfirmacionContraseñaR.Text = "";
            txtContraseñaR.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtEmailR.Text = "";
            comboBox2.SelectedItem = null;
            txtNombreR.Text = "";
            textBox2.Text = "";
            TxtApellidoR.Text = "";
            textBox1.Text = "";

            txtnumerocelularr.Text = "";
            txtnacionalidadR.Text = "";
            txtgeneroR.Text = "";
            txtnombreUsuarioR.Text = "";
            txtocupacionR.Text = "";
            txtpsswd.Text = "";
            txtemail.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
            if (panel3.Visible == true)
            {
                panel3.Visible = false;

            }
            else
            {
                panel3.Visible = true;
            }
            if (panel4.Visible == true)
            {
                panel4.Visible = false;

            }
            
            //Deserializar usuarios 
            usuarios = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count(); a++)
            {
                listBox1.Items.Add(usuarios[a].NameUser);
            }
            

        }

        private void btncrearusuario_Click(object sender, EventArgs e)
        {
            
            if (panel5.Visible == true)
            {
                panel7.Visible = false;
                panel6.Visible = false;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;
                

            }
            else
            {
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
                
            }






            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            label52.Text = "-";
            label55.Text = "-";
            label45.Text = "-";
            label50.Text = "-";
            label46.Text = "-";
            label51.Text = "-";
            label58.Text = "-";
            label44.Text = "-";
            label53.Text = "-";
            label49.Text = "-";
            label37.Text = "-";
            label57.Text = "-";
            txtNumeroTarjeta.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txtCodigoSeguridadTarjeta.Text = "";
            txtNombreR.Text = "";
            txtANombreUsuarioR.Text = "";
            txtConfirmacionContraseñaR.Text = "";
            txtContraseñaR.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtEmailR.Text = "";
            comboBox2.SelectedItem = null;
            txtNombreR.Text = "";
            textBox2.Text = "";
            TxtApellidoR.Text = "";
            textBox1.Text = "";

            txtnumerocelularr.Text = "";
            txtnacionalidadR.Text = "";
            txtgeneroR.Text = "";
            txtnombreUsuarioR.Text = "";
            txtocupacionR.Text = "";
            txtpsswd.Text = "";
            txtemail.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
        }

        private void btnverusuarios_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            label52.Text = "-";
            label55.Text = "-";
            label45.Text = "-";
            label50.Text = "-";
            label46.Text = "-";
            label51.Text = "-";
            label58.Text = "-";
            label44.Text = "-";
            label53.Text = "-";
            label49.Text = "-";
            label37.Text = "-";
            label57.Text = "-";
            txtNumeroTarjeta.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txtCodigoSeguridadTarjeta.Text = "";
            txtNombreR.Text = "";
            txtANombreUsuarioR.Text = "";
            txtConfirmacionContraseñaR.Text = "";
            txtContraseñaR.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtEmailR.Text = "";
            comboBox2.SelectedItem = null;
            txtNombreR.Text = "";
            textBox2.Text = "";
            TxtApellidoR.Text = "";
            textBox1.Text = "";

            txtnumerocelularr.Text = "";
            txtnacionalidadR.Text = "";
            txtgeneroR.Text = "";
            txtnombreUsuarioR.Text = "";
            txtocupacionR.Text = "";
            txtpsswd.Text = "";
            txtemail.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
            usuarios = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count(); a++)
            {
                listBox2.Items.Add(usuarios[a].NameUser);
            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;


            }
            else
            {
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
            }
            if (panel9.Visible==true)
            {
                panel9.Visible = false;
            }
            //Deserializar usuarios 
           
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;

            }
            if (panel5.Visible == true)
            {
                panel5.Visible = false;

            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            label52.Text = "-";
            label55.Text = "-";
            label45.Text = "-";
            label50.Text = "-";
            label46.Text = "-";
            label51.Text = "-";
            label58.Text = "-";
            label44.Text = "-";
            label53.Text = "-";
            label49.Text = "-";
            label37.Text = "-";
            label57.Text = "-";
            txtNumeroTarjeta.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txtCodigoSeguridadTarjeta.Text = "";
            txtNombreR.Text = "";
            txtANombreUsuarioR.Text = "";
            txtConfirmacionContraseñaR.Text = "";
            txtContraseñaR.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtEmailR.Text = "";
            comboBox2.SelectedItem = null;
            txtNombreR.Text = "";
            textBox2.Text = "";
            TxtApellidoR.Text = "";
            textBox1.Text = "";

            txtnumerocelularr.Text = "";
            txtnacionalidadR.Text = "";
            txtgeneroR.Text = "";
            txtnombreUsuarioR.Text = "";
            txtocupacionR.Text = "";
            txtpsswd.Text = "";
            txtemail.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
        }

        private void btnVolverTarjeta_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void btnContinuarTarjeta_Click(object sender, EventArgs e)
        {
            //Mostrar panel para modificar
            if (listBox1.SelectedItem != null)
            {
                panel3.Visible = true;
                panel4.Visible = true;
                if (panel5.Visible == true || panel6.Visible == true || panel7.Visible == true || panel8.Visible== true || panel9.Visible == true)
                {
                    panel5.Visible = false;
                    panel5.Visible = false;
                    panel5.Visible = false;
                    panel5.Visible = false;
                    panel5.Visible = false;


                }
                label33.Text = "Modificara el usuario: " + usuarioEscogido.NameUser;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario");
            }
            

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            List<Clases.User> deserializarUser = new List<Clases.User>();

            int errores = 0;
            try
            {
                deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            }
            catch
            {


            }
            try
            {
                Int32.Parse(textBox2.Text);
            }

            catch (FormatException)
            {
                MessageBox.Show("El formato del celular no es valido");
                errores++;

            }
            if (txtANombreUsuarioR.Text != "" && deserializarUser.Count > 0)
            {

                for (int a = 0; a < deserializarUser.Count; a++)
                {
                    if (deserializarUser[a].NameUser == txtANombreUsuarioR.Text)
                    {
                        MessageBox.Show("Nombre de usuario ya existente");
                        errores++;
                        break;
                    }

                }
            }
            if (txtEmailR.Text != "" && deserializarUser.Count > 0)
            {
                for (int b = 0; b < deserializarUser.Count; b++)
                {
                    if (true == txtANombreUsuarioR.Text.Contains(deserializarUser[b].Mail))
                    {
                        MessageBox.Show("Usuario ya registrado");
                        errores++;

                    }

                }
            }
            if (txtContraseñaR.Text != txtConfirmacionContraseñaR.Text)
            {
                MessageBox.Show("sus contraseñas no coinciden");

            }
            else if (txtEmailR.ToString().Contains("@") == false)
            {
                MessageBox.Show("El correo es invalido");

            }
            else if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Fecha de nacimiento invalida ");

            }
            else if ((DateTime.Now.Year - 1) - dateTimePicker1.Value.Year < 14)
            {
                MessageBox.Show("Para registrarse debe ser mayor de 15 años ");

            }
            else if (txtEmailR.ToString().Contains(".com") == false && txtEmailR.ToString().Contains(".cl") == false)
            {
                MessageBox.Show("El correo es invalido");

            }

            else if (txtANombreUsuarioR.Text == "" || txtConfirmacionContraseñaR.Text == "" || txtContraseñaR.Text == "" || dateTimePicker1.Value == DateTime.Now || txtEmailR.Text == "" ||
                     comboBox2.SelectedItem == null || txtNombreR.Text == " " || textBox2.Text == "" || TxtApellidoR.Text == "" || textBox1.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("RELLENE TODOS LOS DATOS");
            }

            else if (errores == 0)
            {
                label5.Visible = false;
                panel6.Visible = true;      //aca agregar verificar si no se equivoca en la confirmacion de contraseña, que el nombre de usuario no exista ....
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
         
            string usr = txtANombreUsuarioR.Text;
            int number = Int32.Parse(textBox2.Text);

            string psswd = txtContraseñaR.Text;
            string name = txtNombreR.Text;
            string lastname = TxtApellidoR.Text;
            string gender = comboBox2.SelectedItem.ToString();
            string nationality = comboBox1.SelectedItem.ToString();
            string ocuppation = textBox1.Text;
            string email = txtEmailR.Text;
            DateTime birthDate = dateTimePicker1.Value;

            DateTime dateRegister = DateTime.Now;
            int edad;
            List<Clases.Video> videosComprados = new List<Clases.Video>();
            if (birthDate.Month < dateRegister.Month)
            {

                edad = (dateRegister.Year - 1) - birthDate.Year;
            }
            else if (birthDate.Month == dateRegister.Month)
            {
                if (birthDate.Day < dateRegister.Day)
                {
                    edad = (dateRegister.Year - 1) - birthDate.Year;
                }
                else
                {
                    edad = dateRegister.Year - birthDate.Year;
                }
            }
            else
            {
                edad = dateRegister.Year - birthDate.Year;
            }



            if (radioButton1.Checked == true)//plan basico
            {
                MessageBox.Show("Registro con Existo! Plan basico seleccionado, no se realizaran cargos en su tarjeta");


                string planSeleccionado = "Basico";
                string infopago = "";

                Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, birthDate, perfiles, videosComprados);
                List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
                if (deserializarUser.Count > 0)
                {
                    for (int c = 0; c < deserializarUser.Count; c++)
                    {
                        todosUsuarios.Add(deserializarUser[c]);
                    }
                }
                todosUsuarios.Add(usuario);
                serializar.Serialize(todosUsuarios, File.Open("data.bin", FileMode.Create));

                panel6.Visible = false;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;
                panel2.Visible = false;


                /*
                int res = usuario.GuardarUsuario(); // Variable Resultado

                switch (res)
                {
                    case 0:
                        MessageBox.Show("todo correcto");
                        break;
                    case 1:
                        MessageBox.Show("Se cancelo la operacion");
                        break;
                    case 2:
                        MessageBox.Show("Error, no se pudo guardar el objeto.");
                        break;
                }
                */
            }
            else if (radioButton4.Checked == true)
            {
                panel7.Visible = true;
            }
            else if (radioButton5.Checked == true)
            {
                panel7.Visible = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opcion");
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel7.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtNumeroTarjeta.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || txtCodigoSeguridadTarjeta.Text == "")
            {
                MessageBox.Show("PARA CONTINUAR RELLENE TODOS LOS DATOS");
            }

            else
            {
                Form1 forms1 = new Form1();
                string usr = txtANombreUsuarioR.Text;
                int number = Int32.Parse(textBox2.Text);

                string psswd = txtContraseñaR.Text;
                string name = txtNombreR.Text;

                string lastname = TxtApellidoR.Text;
                string gender = comboBox2.SelectedItem.ToString();
                string nationality = comboBox1.SelectedItem.ToString();
                string ocuppation = textBox1.Text;
                string email = txtEmailR.Text;
                DateTime birthDate = dateTimePicker1.Value;

                DateTime dateRegister = DateTime.Now;
                int edad;
                List<Clases.Video> videosComprados = new List<Clases.Video>();
                if (birthDate.Month < dateRegister.Month)
                {

                    edad = (dateRegister.Year - 1) - birthDate.Year;
                }
                else if (birthDate.Month == dateRegister.Month)
                {
                    if (birthDate.Day < dateRegister.Day)
                    {
                        edad = (dateRegister.Year - 1) - birthDate.Year;
                    }
                    else
                    {
                        edad = dateRegister.Year - birthDate.Year;
                    }
                }
                else
                {
                    edad = dateRegister.Year - birthDate.Year;
                }

                if (radioButton4.Checked == true) //plan premiun
                {


                    panel2.Visible = true;
                    string planSeleccionado = "Premium";

                    int cvv = 0;
                    int error2 = 0;
                    List<int> numeros = new List<int>();
                    for (int a = 0; a < 10; a++)
                    {
                        numeros.Add(a);
                    }

                    if (txtNumeroTarjeta.Text != "")
                    {
                        for (int b = 0; b < txtNumeroTarjeta.Text.Length; b++)
                        {
                            if (numeros.Contains((int)Char.GetNumericValue(txtNumeroTarjeta.Text[b])) == true)
                            {

                            }
                            else
                            {
                                error2++;
                            }
                        }
                    }

                    try
                    {

                        cvv += Int32.Parse(txtCodigoSeguridadTarjeta.Text);
                    }
                    catch (FormatException)
                    {

                        error2 += 1;
                    }



                    //Agregar el usario a una lista de usuarios
                    if (error2 == 0)
                    {
                        string infopago = txtNumeroTarjeta.Text;
                        Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, birthDate, perfiles, videosComprados);

                        List<Clases.User> deserializarUser = new List<Clases.User>();

                        try
                        {
                            deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
                            MessageBox.Show("Usuario Registrado con exito");
                        }
                        catch (System.Runtime.Serialization.SerializationException)
                        {

                        }
                        if (deserializarUser.Count > 0)
                        {
                            for (int c = 0; c < deserializarUser.Count; c++)
                            {
                                todosUsuarios.Add(deserializarUser[c]);
                            }
                        }
                        
                        todosUsuarios.Add(usuario);
                        serializar.Serialize(todosUsuarios, File.Open("data.bin", FileMode.Create));

                        
                    }
                    else
                    {
                        MessageBox.Show("Error, ingrese nuevamente su forma de pago");

                    }
                }
                else if (radioButton5.Checked == true)//plan familiar
                {

                    int cvv = 0;
                    int error3 = 0;
                    List<int> numeros = new List<int>();
                    for (int a = 0; a < 10; a++)
                    {
                        numeros.Add(a);
                    }

                    string planSeleccionado = "Familiar";
                    if (txtNumeroTarjeta.Text != "")
                    {
                        for (int b = 0; b < txtNumeroTarjeta.Text.Length; b++)
                        {
                            if (numeros.Contains((int)Char.GetNumericValue(txtNumeroTarjeta.Text[b])) == true)
                            {

                            }
                            else
                            {
                                error3++;
                            }
                        }
                    }



                    try
                    {

                        cvv += Int32.Parse(txtCodigoSeguridadTarjeta.Text);
                    }
                    catch (FormatException)
                    {

                        error3 += 1;
                    }

                    if (error3 == 0)
                    {
                        string infopago = txtNumeroTarjeta.Text;
                        //Agregar el usario a una lista de usuarios
                        List<Clases.User> deserializarUser = new List<Clases.User>();
                        Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, birthDate, perfiles, videosComprados);
                        try
                        {
                            deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
                            MessageBox.Show("Usuario Registrado con exito");
                            panel8.Visible = false;
                            panel7.Visible = false;
                            panel6.Visible = false;
                            panel5.Visible = false;
                            panel4.Visible = false;
                            panel3.Visible = false;
                        }
                        catch (System.Runtime.Serialization.SerializationException)
                        {

                        }
                        if (deserializarUser.Count > 0)
                        {
                            for (int c = 0; c < deserializarUser.Count; c++)
                            {
                                todosUsuarios.Add(deserializarUser[c]);
                            }
                        }
                        todosUsuarios.Add(usuario);
                        serializar.Serialize(todosUsuarios, File.Open("data.bin", FileMode.Create));
                        

                    }
                    else
                    {
                        MessageBox.Show("Error, ingrese nuevamente su forma de pago");
                    }



                }

            }
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarios = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a< usuarios.Count;a++)
            {
                if (listBox1.SelectedItem!= null)
                {
                    if (usuarios[a].NameUser == listBox1.SelectedItem.ToString())
                    {
                        usuarioEscogido = usuarios[a];
                        break;
                    }
                }
                   
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cambiar nombre
            List < Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            
            if (txtnombre.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Name = txtnombre.Text;
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Nombre cambiado");
                        break;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cambiar Apellido
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtapellido.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Lastname = txtapellido.Text;
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Apellido cambiado");
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Cambiar email
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtemail.Text != "")
            {
                if (txtemail.ToString().Contains("@") == false)
                {
                    MessageBox.Show("El correo es invalido");

                }
                else if (txtemail.ToString().Contains(".com") == false && txtemail.ToString().Contains(".cl") == false)
                {
                    MessageBox.Show("El correo es invalido");

                }
                else
                {
                    for (int a = 0; a < user.Count; a++)
                    {
                        if (user[a].NameUser == usuarioEscogido.NameUser)
                        {

                            user[a].Mail = txtemail.Text;
                            serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                            MessageBox.Show("Mail cambiado");
                            break;
                        }
                    }
                }
               

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cambiar contraseña
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtpsswd.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Password = txtpsswd.Text;
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Contraseña cambiada");
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void btncambiarp_Click(object sender, EventArgs e)
        {
            //Cambiar ocupacion
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtocupacionR.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Occupation = txtocupacionR.Text;
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Ocupación cambiada");
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //cambiar nombre de usuario
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            int errores = 0;
            if (txtnombreUsuarioR.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == txtANombreUsuarioR.Text)
                    {   
                        errores++;
                        break;
                    }

                }
                if (errores == 0)
                {
                    for (int a = 0; a < user.Count; a++)
                    {
                        if (user[a].NameUser == usuarioEscogido.NameUser)
                        {
                            user[a].NameUser = txtnombreUsuarioR.Text;
                            serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                            MessageBox.Show("Nombre de usuario cambiado");
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario ya existente");
                }
                

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Cambiar genero
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtgeneroR.SelectedItem != null)
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Gender = txtgeneroR.SelectedItem.ToString();
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Genero cambiado");
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Cambiar nacionalidad
            
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (txtnacionalidadR.SelectedItem != null)
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        user[a].Nationality = txtnacionalidadR.SelectedItem.ToString();
                        serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                        MessageBox.Show("Nacionalidad cambiada");
                        break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Cambiar numero de celu
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            if (txtnumerocelularr.Text != "")
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        try
                        {
                            user[a].NumPhone = Int32.Parse(txtnumerocelularr.Text);
                            serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                            MessageBox.Show("Numero de celular cambiado");
                            break;
                        }
                        catch(FormatException)
                        {
                            MessageBox.Show("Ingrese un formato valido");
                            break;
                        }
                        
                       
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Cambiar fecha de nacimiento 
            List<Clases.User> user = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));

            if (fechanacimiento.Value != DateTime.Now)
            {
                for (int a = 0; a < user.Count; a++)
                {
                    if (user[a].NameUser == usuarioEscogido.NameUser)
                    {
                        if ((DateTime.Now.Year - 1) - fechanacimiento.Value.Year < 14)
                        {
                            MessageBox.Show("Para registrarse debe ser mayor de 15 años ");
                            break;

                        }
                        else
                        {
                            user[a].Nationality = txtnacionalidadR.SelectedItem.ToString();
                            serializar.Serialize(user, File.Open("data.bin", FileMode.Create));
                            MessageBox.Show("Fecha de nacimiento cambiada");
                            break;
                        }
                        
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor rellene los datos");
              
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            //Seleccionar para ver informacion 
            usuarios = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count; a++)
            {
                if (listBox2.SelectedItem != null)
                {
                    if (usuarios[a].NameUser == listBox2.SelectedItem.ToString())
                    {
                        usuarioEscogido2 = usuarios[a];
                        break;
                    }
                }
                
            }
            label55.Text = usuarioEscogido2.Name;
            label45.Text = usuarioEscogido2.Lastname;
            label50.Text = usuarioEscogido2.Nationality;
            label46.Text = usuarioEscogido2.Occupation;
            label51.Text = usuarioEscogido2.Mail;
            label58.Text = usuarioEscogido2.NameUser;
            label44.Text = usuarioEscogido2.Age.ToString();
            label53.Text = usuarioEscogido2.Gender;
            label49.Text = usuarioEscogido2.Plan;
            label37.Text = usuarioEscogido2.RegistrationDate.Day+" /  "+ usuarioEscogido2.RegistrationDate.Month + " / "+ usuarioEscogido2.RegistrationDate.Year;
            label57.Text = usuarioEscogido2.PaymentInfo;
            label52.Text = usuarioEscogido2.NumPhone.ToString();

            if (usuarioEscogido2.Profiles.Count>0)
            {
                for (int a = 0; a < usuarioEscogido2.Profiles.Count; a++)
                {
                    listBox3.Items.Add(usuarioEscogido2.Profiles[a].NameProfile);
                }
            }
            else
            {
                listBox3.Items.Add("No existen Perfiles");
            }
            if (usuarioEscogido2.VideosComprados.Count > 0)
            {
                for (int a = 0; a < usuarioEscogido2.VideosComprados.Count; a++)
                {
                    listBox4.Items.Add(usuarioEscogido2.VideosComprados[a].Title);
                }
            }
            else
            {
                listBox4.Items.Add("No existen películas compradas");
            }



        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel30.Visible = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel30.Visible = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //Eliminar usuario
            List < Clases.User > us = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < us.Count(); a++)
            {
                if (listBox5.SelectedItem!=null)
                {
                    if (us[a].NameUser == usuarioEscogido3.NameUser)
                    {

                        us.RemoveAt(a);

                        MessageBox.Show("Usuario eliminado");
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario");
                    break;
                }
                

            }
            serializar.Serialize(us, File.Open("data.bin", FileMode.Create));
            panel9.Visible = false;
            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;

        }
        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            List<Clases.User> u = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < u.Count(); a++)
            {
                if (listBox5.SelectedItem != null)
                {
                    if (u[a].NameUser == listBox5.SelectedItem.ToString())
                    {
                        usuarioEscogido3 = u[a];
                        break;
                    }
                }

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            label52.Text = "-";
            label55.Text = "-";
            label45.Text = "-";
            label50.Text = "-";
            label46.Text = "-";
            label51.Text = "-";
            label58.Text = "-";
            label44.Text = "-";
            label53.Text = "-";
            label49.Text = "-";
            label37.Text = "-";
            label57.Text = "-";
            txtNumeroTarjeta.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            txtCodigoSeguridadTarjeta.Text = "";
            txtNombreR.Text = "";
            txtANombreUsuarioR.Text = "";
            txtConfirmacionContraseñaR.Text = "";
            txtContraseñaR.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtEmailR.Text = "";
            comboBox2.SelectedItem = null;
            txtNombreR.Text = "";
            textBox2.Text = "";
            TxtApellidoR.Text = "";
            textBox1.Text = "";

            txtnumerocelularr.Text = "";
            txtnacionalidadR.Text = "";
            txtgeneroR.Text = "";
            txtnombreUsuarioR.Text = "";
            txtocupacionR.Text = "";
            txtpsswd.Text = "";
            txtemail.Text = "";
            txtapellido.Text = "";
            txtnombre.Text = "";
            usuarios = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count(); a++)
            {
                listBox5.Items.Add(usuarios[a].NameUser);
            }
            if (panel9.Visible == true)
            {
                panel9.Visible = false;
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;


            }
            else
            {
                panel3.Visible = true;
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                panel9.Visible = true;
            }

        }
    }
}
