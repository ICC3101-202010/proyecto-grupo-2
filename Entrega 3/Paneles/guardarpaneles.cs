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
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;

            }
            else
            {
                panel3.Visible = true;
            }
            if (panel5.Visible == true)
            {
                panel5.Visible = false;

            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
        }

        private void btncrearusuario_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;

            }
            if (panel5.Visible == true)
            {
                panel5.Visible = false;

            }
            else
            {
                panel5.Visible = true;
            }
            if (panel8.Visible == true)
            {
                panel8.Visible = false;
            }
        }

        private void btnverusuarios_Click(object sender, EventArgs e)
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
            else
            {
                panel8.Visible = false;
            }
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
        }

        private void btnVolverTarjeta_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void btnContinuarTarjeta_Click(object sender, EventArgs e)
        {

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
            radioButton5.Visible = false;
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
                        if (deserializarUser.Count > 0)
                        {
                            for (int c = 0; c < deserializarUser.Count; c++)
                            {
                                todosUsuarios.Add(deserializarUser[c]);
                            }
                        }
                        todosUsuarios.Add(usuario);
                        serializar.Serialize(todosUsuarios, File.Open("data.bin", FileMode.Create));

                        MessageBox.Show("Registro Existoso");
                        this.Hide();
                        forms1.Show();

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
                        this.Hide();
                        forms1.Show();

                    }
                    else
                    {
                        MessageBox.Show("Error, ingrese nuevamente su forma de pago");
                    }



                }

            }
        }
    }
}
