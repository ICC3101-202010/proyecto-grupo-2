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
    public partial class FormsRegistro : Form
    {
        public FormsRegistro()
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)      
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
                Int32.Parse(txtNumerocelularR.Text);
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
                    if ( true == txtANombreUsuarioR.Text.Contains(deserializarUser[b].Mail))
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
            else if (txtEmailR.ToString().Contains("@")==false )
            {
                MessageBox.Show("El correo es invalido");
              
            }
            else if (fechaNacimiento.Value>DateTime.Now)
            {
                MessageBox.Show("Fecha de nacimiento invalida ");
             
            }
            else if ((DateTime.Now.Year - 1)-fechaNacimiento.Value.Year < 14)
            {
                MessageBox.Show("Para registrarse debe ser mayor de 15 años ");
              
            }
            else if (txtEmailR.ToString().Contains(".com") == false && txtEmailR.ToString().Contains(".cl") == false) 
            {
                MessageBox.Show("El correo es invalido");
               
            }
            
            else if (txtANombreUsuarioR.Text == "" || txtConfirmacionContraseñaR.Text == "" ||txtContraseñaR.Text=="" || fechaNacimiento.Value==DateTime.Now ||txtEmailR.Text=="" ||
                     txtGeneroR.SelectedItem == null|| txtNombreR.Text == " " || txtNumerocelularR.Text == "" || TxtApellidoR.Text == "" || txtOcupacionR.Text == "" || txtNacionalidadR.SelectedItem == null)
            {
                MessageBox.Show("RELLENE TODOS LOS DATOS");
            }
            
            else if(errores==0)
            {
                label11.Visible = false;
                panel1.Visible = true;      //aca agregar verificar si no se equivoca en la confirmacion de contraseña, que el nombre de usuario no exista ....
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnContinuar2_Click(object sender, EventArgs e)
        {
            Form1 forms1 = new Form1();
            radioButton5.Visible = false;
            string usr = txtANombreUsuarioR.Text;
            int number = Int32.Parse(txtNumerocelularR.Text);
            
            string psswd = txtContraseñaR.Text;
            string name = txtNombreR.Text;
            string lastname = TxtApellidoR.Text;
            string gender = txtGeneroR.SelectedItem.ToString();
            string nationality = txtNacionalidadR.SelectedItem.ToString();
            string ocuppation = txtOcupacionR.Text;
            string email = txtEmailR.Text;
            DateTime birthDate = fechaNacimiento.Value;
        
            DateTime dateRegister = DateTime.Now;
            int edad;
            if (birthDate.Month < dateRegister.Month)
            {
               
                edad = (dateRegister.Year - 1) - birthDate.Year;
            }
            else if(birthDate.Month == dateRegister.Month)
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
                edad= dateRegister.Year - birthDate.Year; 
            }
            
           
           
            if (radioButton1.Checked == true)//plan basico
            {
                MessageBox.Show("Registro con Existo! Plan basico seleccionado, no se realizaran cargos en su tarjeta");


                string planSeleccionado = "Basico";
                string infopago = "";

                Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, dateRegister,perfiles);
                List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
                if (deserializarUser.Count>0)
                {
                    for (int c = 0; c < deserializarUser.Count; c++){
                        todosUsuarios.Add(deserializarUser[c]);
                    }
                }
                todosUsuarios.Add(usuario);
                serializar.Serialize(todosUsuarios, File.Open("data.bin", FileMode.Create));

                forms1.Show();
                this.Close();
                    
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
                panel2.Visible = true;
            }
            else if(radioButton5.Checked == true)
            {
                panel2.Visible = true;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opcion");
            }
            
            
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelDatosTarjeta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnVolverTarjeta_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            radioButton5.Visible = true;
        }

        private void btnContinuarTarjeta_Click(object sender, EventArgs e)
        {
            if (txtNumeroTarjeta.Text == ""  || comboBox1.SelectedItem==null || comboBox2.SelectedItem == null || txtCodigoSeguridadTarjeta.Text=="")
            {
                MessageBox.Show("PARA CONTINUAR RELLENE TODOS LOS DATOS");
            }

            else
            {
                Form1 forms1 = new Form1();
                string usr = txtANombreUsuarioR.Text;
                int number = Int32.Parse(txtNumerocelularR.Text);

                string psswd = txtContraseñaR.Text;
                string name = txtNombreR.Text;
                
                string lastname = TxtApellidoR.Text;
                string gender = txtGeneroR.SelectedItem.ToString();
                string nationality = txtNacionalidadR.SelectedItem.ToString();
                string ocuppation = txtOcupacionR.Text;
                string email = txtEmailR.Text;
                DateTime birthDate = fechaNacimiento.Value;

                DateTime dateRegister = DateTime.Now;
                int edad;
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
                        Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, dateRegister,perfiles);
                        
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
                    List <int> numeros= new List<int>();  
                    for(int a = 0; a<10;a++)
                    {
                        numeros.Add(a);
                    }
                    
                    string planSeleccionado = "Familiar";
                    if (txtNumeroTarjeta.Text != "")
                    {
                        for (int b=0;b<txtNumeroTarjeta.Text.Length;b++)
                        {
                            if (numeros.Contains((int)Char.GetNumericValue(txtNumeroTarjeta.Text[b]))==true)
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
                        Clases.User usuario = new Clases.User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, dateRegister,perfiles);
                        try
                        {
                            deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
                            MessageBox.Show("Usuario Registrado con exito");
                        }
                        catch(System.Runtime.Serialization.SerializationException)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VOlVERAS A LA PANTALLA DE INICIO");
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFechaCaducacionTarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void btnVolverNormalidad_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnVolverNormalidad.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
