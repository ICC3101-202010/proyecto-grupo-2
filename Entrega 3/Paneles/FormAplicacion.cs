﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Entrega_3.Clases;
using System.Threading;

namespace Entrega_3.Paneles
{

    public partial class FormAplicacion : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); //Timer
        Profile perfilCambiar;
        Profile perfilActual;
        string algo; // para ver si era usica o video.
        //est es solo para probar busqueda
        static DateTime date = new DateTime();
        int numlikes; //PARA LOS LIKES DE LAS CANCIONES/VIDEOS
        int numreproducciones;
        int nota;
        int notaActual;
        string contraseña;
        string reproduciendo;
        SongClass cancionSonando; //PARA AGREGAR CANCOINES PLAYLISt
        Video videoSonando;
        string tipoPlaylist;
        Queue<string> cola = new Queue<string>();
        SongClass cancionElegida;
        Video videoElegida;
        string cosaElegida = "";
        List<string> cola1 = new List<string>();
        List<string> cupones= new List<string>();
        List<string> cuponesUsados = new List<string>();
        static List<string> listaPerfilesLikes = new List<string>();
        string videoClick = "";
        List<Profile> listaPerfiles = new List<Profile>();
        PlaylistSpotifai playlistElegidaCancion;
        Profile perfilesSeguidos;
        List<PlaylistSpotifai> playlistCancionesPerfil;


        static List<string> premios = new List<string>();

        static List<string> discograpich = new List<string>();
        static List<SongClass> canciones = new List<SongClass>();
        static Album album = new Album("nameAlbum", "gender", "producer", singer, date);
        static Album album2 = new Album("nameAlbum2", "gender2", "producer2", singer, date);
        static Album album3 = new Album("nameAlbum3", "gender3", "producer3", singer, date);
        static Album album4 = new Album("nameAlbum4", "gender4", "producer4", singer, date);

        static List<Album> listaAlbum = new List<Album>();
        static Singer singer = new Singer(canciones, listaAlbum, premios, "voiceType", "genders", 22, discograpich, "name", 12, "Lastname", "genero", "nationality", "ocupacion");
        static Singer singer2 = new Singer(canciones, listaAlbum, premios, "voiceType2", "genders2", 22, discograpich, "name2", 12, "Lastname2", "genero2", "nationality2", "ocupacion2");
        static Singer singer3 = new Singer(canciones, listaAlbum, premios, "voiceType3", "genders3", 22, discograpich, "name3", 12, "Lastname3", "genero3", "nationality3", "ocupacion3");
        static Singer singer4 = new Singer(canciones, listaAlbum, premios, "voiceType4", "genders4", 22, discograpich, "name4", 12, "Lastname4", "genero4", "nationality4", "ocupacion4");

        static List<Video> videos = new List<Video>();
        static Actor Mactor = new Actor("name", 22, "lName", "gender", "nationality", "Ocupacion", videos, premios, 22);
        static Actor Mactor2 = new Actor("name2", 22, "lName2", "gender2", "nationality2", "Ocupacion2", videos, premios, 22);
        static Actor Mactor3 = new Actor("name3", 22, "lName3", "gender3", "nationality3", "Ocupacion3", videos, premios, 22);
        static Actor Mactor4 = new Actor("name4", 22, "lName4", "gender4", "nationality4", "Ocupacion4", videos, premios, 22);
        static Director d = new Director("nDi", 22, "LastD", "gender", "nationality", "ocupation", videos, premios, 22);
        static Director d2 = new Director("nDi2", 222, "LastD2", "gender2", "nationality2", "ocupation2", videos, premios, 222);
        static Director d3 = new Director("nDi3", 22, "Last3", "gender3", "nationality3", "ocupatio3", videos, premios, 22);
        static Director d4 = new Director("nDi4", 222, "LastD4", "gender4", "nationality4", "ocupation4", videos, premios, 222);

        SongClass cancion = new SongClass("Cgender", "publicationYear", "title", 22, 22, "study", "keyword", "composer", singer, album, "format", 1, 2,"url",0,0, listaPerfilesLikes);
        SongClass cancion2 = new SongClass("Cgender2", "publicationYear2", "title2", 22, 22, "study2", "keyword2", "composer2", singer2, album2, "format2", 11, 22, "url", 0, 0, listaPerfilesLikes);
        SongClass cancion3 = new SongClass("Cgender3", "publicationYear3", "title3", 22, 22, "study3", "keyword3", "composer3", singer3, album3, "format3", 111, 222, "url", 0, 0, listaPerfilesLikes);
        SongClass cancion4 = new SongClass("Cgender4", "publicationYear4", "title4", 22, 22, "study4", "keyword4", "composer4", singer4, album4, "format4", 1111, 2222, "url", 0, 0, listaPerfilesLikes);

        Video video = new Video("Vgender", "publicationYear", "title", 22, 22, "study", "keyword", "description", Mactor, d, "format", 1, 2, "url", 0, 0, listaPerfilesLikes);
        Video video2 = new Video("Vgender2", "publicationYear2", "title2", 22, 22, "study2", "keyword2", "description2", Mactor2, d2, "format2", 11, 22, "url", 0, 0, listaPerfilesLikes);
        Video video3 = new Video("Vgender3", "publicationYear3", "title3", 22, 22, "study3", "keyword3", "description3", Mactor3, d3, "format3", 111, 222, "url", 0, 0, listaPerfilesLikes);
        Video video4 = new Video("Vgender4", "publicationYear4", "title4", 22, 22, "study4", "keyword4", "description4", Mactor4, d4, "format4", 1111, 2222, "url", 0, 0, listaPerfilesLikes);

       

        //hasta aqui

        //esto es lo del reproductor 
        string ArchivoMP3;
        string rutaArchivoMP3;
        bool Play = false;
        List<SongClass> canciones123 = new List<SongClass>();
        List<Video> videos123 = new List<Video>();


        //hasta aqui
        Clases.User usuario = new Clases.User();
        Clases.Serialization serializar = new Clases.Serialization();

        //Playlist del perfil.
        List<Video> playlistFavoritasVideos = new List<Video>();
        List<SongClass> playlistFavoritasCanciones = new List<SongClass>();
        List<PlaylistSpotifai> playlistCanciones = new List<PlaylistSpotifai>();
        List<PlaylistVideoEmptyClass> playlistVideos = new List<PlaylistVideoEmptyClass>();
        string cumpleaños = "";
        string cupon = "";

        string TipoCuenta;
        //Crear peliculas

        
        public FormAplicacion(Clases.User user)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerTickHandler);
            timer.Start();
            void TimerTickHandler(object sender, EventArgs e)
            {
                timer.Stop();
                ReproducirCola();
                timer.Start();
            }
            InitializeComponent();
            usuario = user;
            //mulan
            List<Video> pelisNiki = new List<Video>();
            List<String> premiosNiki = new List<string>();
            List<Video> pelisLiu = new List<Video>();
            List<String> premiosLiu = new List<string>();
            Actor actor = new Actor("Liu", 32, "Yifei", "Varios", "China", "Actriz-Cantante-Modelo", pelisLiu, premiosLiu, 18);
            Director director = new Director("Niki", 53, "Caro", "Varios", "Nueva Zelanda", "Directora-Productora-Guionista", pelisNiki, premiosNiki, 20);
            List<string> profileLikes = new List<string>();
            string ruta1 = Path.Combine(Application.StartupPath, "mulan.mp4");
            Video mulanVideo = new Video("Aventuras", "2020",
                         "mulan", 285, 4, "Walt-Disney", "mulan",
                         "hija de un veterano de guerra que desafia la tradición", actor, director, "mp4", 0,100, ruta1, 0, 0,profileLikes);
            pelisNiki.Add(mulanVideo);
            premiosNiki.Add("Member of the New Zealand Order of Merit");
            pelisLiu.Add(mulanVideo);
            premiosLiu.Add("Best Actress China Film");
            premiosLiu.Add("Best Actress Macau International");

            //Joker
            List<Video> pelisTodd = new List<Video>();
            List<String> premiosTodd = new List<string>();
            List<Video> pelisJoaquin = new List<Video>();
            List<String> premiosJoaquin = new List<string>();
            Actor actor2 = new Actor("Joaquin", 45, "Phoenix", "Varios", "Puerto Rico", "Actor-productor-guionista", pelisTodd, premiosTodd, 38);
            Director director2 = new Director("Todd", 49, "Phillips", "Varios", "Estados unidos", "Director-Productor-Guionista-Actor", pelisTodd, premiosTodd, 26);
            List<string> profileLikes2 = new List<string>();
            string ruta2 = Path.Combine(Application.StartupPath, "joker.mp4");
            Video jokerVideo = new Video("Crimen", "2019",
                         "joker", 260, 4, "Dc", "joker",
                         "Arthur sufre de un trastorno medico", actor2, director2, "mp4", 0, 100, ruta2, 0, 0, profileLikes2);
            pelisTodd.Add(jokerVideo);
            premiosTodd.Add("Globo de oro -mejor pelicula");
            pelisJoaquin.Add(jokerVideo);
            premiosJoaquin.Add("Best Actress Oscar");
            premiosJoaquin.Add("Best Actress Globos de oro");

            //Avenger
            List<Video> pelisAyR= new List<Video>();
            List<String> premiosAyR = new List<string>();
            List<Video> pelisRobert = new List<Video>();
            List<String> premiosRobert = new List<string>();
            Actor actor3 = new Actor("Robert", 55, "Downey Jr", "Varios", "Estados Unidos", "Actor-Cantante-Empresario", pelisRobert, premiosRobert, 50);
            Director director3 = new Director("Hermanos", 50, "Russo", "Varios", "Estados unidos", "Director-Productor-Guionista-Actor", pelisAyR, premiosAyR, 26);
            List<string> profileLikes3 = new List<string>();
            string ruta3 = Path.Combine(Application.StartupPath, "avengers.mp4");
            Video avengerVideo = new Video("Ciencia Ficcion", "2019",
                         "avengers", 266, 4, "Marvel", "avengers",
                         "Secuela de Infinity War", actor3, director3, "mp4", 0, 100, ruta3, 0, 0, profileLikes3);
            pelisAyR.Add(avengerVideo);
            premiosAyR.Add("Premios Emmy");
            pelisRobert.Add(avengerVideo);
            premiosRobert.Add("Best Actress BAFTA");
            premiosRobert.Add("Best Actress Globos de oro");

            List<Video> videoAux111 = new List<Video>();
           
            
            videoAux111 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
            string mulanSI = "";
            string jokerSI = "";
            string avengersSI = "";
            for (int a=0;a<videoAux111.Count;a++)
            {
                if (videoAux111[a].Title=="mulan")
                {
                    mulanSI = "si";
                }
                if (videoAux111[a].Title == "joker")
                {
                    jokerSI = "si";
                }
                if (videoAux111[a].Title == "avengers")
                {
                    avengersSI = "si";
                }
            }
            if (mulanSI=="")
            {
                videoAux111.Add(mulanVideo);
            }
            if (jokerSI == "")
            {
                videoAux111.Add(jokerVideo);
            }
            if (avengersSI == "")
            {
                videoAux111.Add(avengerVideo);
            }
            
          
            
            serializar.Serialize(videoAux111, File.Open("Videos.bin", FileMode.Create));

            if (user.Plan == "Basico")
            {
                DateTime fechaActual = DateTime.Now;
                if (user.RegistrationDate.Month==fechaActual.Month && user.RegistrationDate.Day == fechaActual.Day)
                {
                    MessageBox.Show("Feliz cumpleaños!!, Te tenemos un regalo... hoy podras disfrutar los beneficios del plan premium");
                    cumpleaños = "si";
                    TipoCuenta = "Premium";
                    if (user.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = false;
                        pic8.Visible = false;
                        crear1.Visible = true;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                    }
                    else
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;
                        pic6.Visible = false;
                        pic7.Visible = false;
                        pic8.Visible = false;
                        pic4.Visible = false;
                        pic3.Visible = false;
                        pic2.Visible = false;
                    }
                    string ruta = Path.Combine(Application.StartupPath, "cumpleaños.mp3");
                    Reproductor2.URL = ruta;

                }
                else
                {
                    TipoCuenta = "Basico";
                    btnSubirArchivos.Visible = false;
                    btnPlaylisMusica.Visible = false;
                    btnPlaylistVideo.Visible = false;
                    btnCambiarPerfil.Visible = false;
                    panel12.Visible = false;

                    if (user.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = false;
                        pic8.Visible = false;
                        crear1.Visible = true;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                    }
                    else
                    {
                        pic5.Visible = false;
                        pic6.Visible = false;
                        pic7.Visible = false;
                        pic8.Visible = false;

                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic3.Visible = false;
                        pic2.Visible = false;

                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;

                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;


                    }
                }
                
            }
            else if (user.Plan == "Premium")
            {
                int errores = 1;
                DateTime fechaActual = DateTime.Now;
                if (user.RegistrationDate.Month == fechaActual.Month && user.RegistrationDate.Day == fechaActual.Day)
                {
                    string ruta = Path.Combine(Application.StartupPath, "cumpleaños.mp3");
                    Random rnd = new Random();
                    int numR = rnd.Next(2000000);


                    cumpleaños = "si";
                    cupon = user.NameUser + "-" + numR + "H";
                    List<string> todosCupones = serializar.Deserialize<List<string>>(File.Open("cupones.bin", FileMode.Open));

                    for (int a = 0; a < todosCupones.Count(); a++)
                    {
                        string[] separado = todosCupones[a].Split('-');

                        errores--;
                        if (separado[0] == user.NameUser)
                        {
                            MessageBox.Show("Su cupon es: " + todosCupones[a]);
                            break;

                        }
                        else
                        {
                            errores++;
                        }
                    }
                    if (errores > 0)
                    {
                        todosCupones.Add(cupon);

                        Reproductor2.URL = ruta;
                        MessageBox.Show("Feliz cumpleaños!!, tiene un cupon para ver una pelicula en estreno! Su codigo es: " + cupon);

                    }


                    serializar.Serialize(todosCupones, File.Open("cupones.bin", FileMode.Create));


                }

                if (user.Profiles.Count == 0)
                {
                    pic5.Visible = true;
                    pic1.Visible = false;
                    pic4.Visible = false;
                    pic7.Visible = false;
                    pic3.Visible = false;
                    pic6.Visible = false;
                    pic2.Visible = false;
                    pic8.Visible = false;
                    crear1.Visible = true;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;
                }
                else
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    button1.Visible = true;
                    pic6.Visible = false;
                    pic7.Visible = false;
                    pic8.Visible = false;
                    pic4.Visible = false;
                    pic3.Visible = false;
                    pic2.Visible = false;
                }
            }

            else if (user.Plan == "Familiar")
            {
                int errores = 1;
                DateTime fechaActual = DateTime.Now;
                if (user.RegistrationDate.Month == fechaActual.Month && user.RegistrationDate.Day == fechaActual.Day)
                {
                    string ruta = Path.Combine(Application.StartupPath, "cumpleaños.mp3");
                    Random rnd = new Random();
                    int numR = rnd.Next(2000000);


                    cumpleaños = "si";
                    cupon = user.NameUser + "-" + numR + "H";
                    List<string> todosCupones = serializar.Deserialize<List<string>>(File.Open("cupones.bin", FileMode.Open));
                    
                    for (int a = 0; a < todosCupones.Count(); a++)
                    {
                        string[] separado = todosCupones[a].Split('-');
                      
                        errores--;
                        if (separado[0] == user.NameUser)
                        {
                            MessageBox.Show("Su cupon es: " + todosCupones[a]);
                            break;

                        }
                        else
                        {
                            errores++;
                        }
                    }
                    if (errores > 0)
                    {
                        todosCupones.Add(cupon);

                        Reproductor2.URL = ruta;
                        MessageBox.Show("Feliz cumpleaños!!, tiene un cupon para ver una pelicula en estreno! Su codigo es: " + cupon);

                    }


                    serializar.Serialize(todosCupones, File.Open("cupones.bin", FileMode.Create));


                }

                if (user.Profiles.Count == 0)
                {
                    pic5.Visible = true;
                    pic1.Visible = false;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = true;
                    pic2.Visible = false;
                    pic8.Visible = true;
                    crear1.Visible = true;
                    crear2.Visible = true;
                    crear3.Visible = true;
                    crear4.Visible = true;
                }
                else if (user.Profiles.Count == 1)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = true;
                    pic2.Visible = false;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = true;
                    crear3.Visible = true;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    button1.Visible = true;
                    label8.Visible = true;
                }
                else if (user.Profiles.Count == 2)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = true;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else if (user.Profiles.Count == 3)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = false;
                    pic3.Visible = true;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    label10.Text = usuario.Profiles[2].NameProfile;
                    label10.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                }
                else if (user.Profiles.Count == 4)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = true;
                    pic7.Visible = false;
                    pic3.Visible = true;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = false;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    label10.Text = usuario.Profiles[2].NameProfile;
                    label10.Visible = true;
                    label11.Text = usuario.Profiles[3].NameProfile;
                    label11.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void SubMenuAjustes_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            if (panelSubMenuAjustes.Visible==true)
            {
                panelSubMenuAjustes.Visible = false;
            }
            else 
                    
            { panelSubMenuAjustes.Visible = true; }
            if (SubirArchivo.Visible == true)
            {
                SubirArchivo.Visible = false;
            }
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }

        }

        private void btnPlaylistVideo_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }

            if (panelSubMenuAjustes.Visible == true)
            {
                panelSubMenuAjustes.Visible = false;
            }
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            if (SubirArchivo.Visible == true)
            {
                SubirArchivo.Visible = false;
            }
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            else
            {
                panel7.Visible = true;
            }
        }

        private void btnPlaylisMusica_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            if (panelSubMenuAjustes.Visible == true)
            {
                panelSubMenuAjustes.Visible = false;
            }
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            if (SubirArchivo.Visible == true)
            {
                SubirArchivo.Visible = false;

            }
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            else
            {
                panel14.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panelSubMenuAjustes.Visible == true)
            {
                panelSubMenuAjustes.Visible = false;
            }
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            if (SubirArchivo.Visible == true)
            {
                SubirArchivo.Visible = false;
            }
            else
            {
                SubirArchivo.Visible = true;
            }
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            if (panel32.Visible == true)
            {
                panel32.Visible = false;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            panel37.Visible = false;
            if (panel27.Visible == true)
            {
                panel27.Visible = false;
            }
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            if (panelSubMenuAjustes.Visible == true)
            {
                panelSubMenuAjustes.Visible = false;
            }
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            if (SubirArchivo.Visible == true)
            {
                SubirArchivo.Visible = false;
            }
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            if (panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            if (panel32.Visible == true)
            {
                panel32.Visible = false;
            }
        }

        private void pic12_Click(object sender, EventArgs e)
        {
           
        }

        private void pic13_Click(object sender, EventArgs e)
        {
           
        }

        private void pic14_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedorPincipal_Paint(object sender, PaintEventArgs e)
        {
            if (listCanciones.Visible == true)
            {
                listCanciones.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int a = 0; a<usuario.Profiles.Count;a++)
            {
                if (usuario.Profiles[a].NameProfile == label8.Text)
                {
                    perfilActual = usuario.Profiles[a];
                }
            }
            
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            //panel5.Visible = false;
            
            string h = ".jpg";
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;

            
            Image image1 = Image.FromFile(usuario.Profiles[0].PleasuresMusic[0] + h);
            pic12.Image = image1;
            Image image2 = Image.FromFile(usuario.Profiles[0].PleasuresMusic[1] + h);
            pic13.Image = image2;
            Image image3 = Image.FromFile(usuario.Profiles[0].PleasuresMusic[2] + h);
            pic14.Image = image3;
            
 
        }

        private void crear1_Click(object sender, EventArgs e)
        {
            panelContenedorPincipal.Visible = false;
            panelCrearUsuario.Visible = true;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;


        }

        private void crear2_Click(object sender, EventArgs e)
        {
            panelContenedorPincipal.Visible = false;
            panelCrearUsuario.Visible = true;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;

        }

        private void crear3_Click(object sender, EventArgs e)
        {
            panelContenedorPincipal.Visible = false;
            panelCrearUsuario.Visible = true;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;

        }

        private void crear4_Click(object sender, EventArgs e)
        {
            panelContenedorPincipal.Visible = false;
            panelCrearUsuario.Visible = true;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label9.Text)
                {
                    perfilActual = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
           // panel5.Visible = false;
            string h = ".jpg";
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;


            Image image1 = Image.FromFile(usuario.Profiles[1].PleasuresMusic[0] + h);
            pic12.Image = image1;
            Image image2 = Image.FromFile(usuario.Profiles[1].PleasuresMusic[1] + h);
            pic13.Image = image2;
            Image image3 = Image.FromFile(usuario.Profiles[1].PleasuresMusic[2] + h);
            pic14.Image = image3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label10.Text)
                {
                    perfilActual = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            string h = ".jpg";
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
           // panel5.Visible = false;


            Image image1 = Image.FromFile(usuario.Profiles[2].PleasuresMusic[0] + h);
            pic12.Image = image1;
            Image image2 = Image.FromFile(usuario.Profiles[2].PleasuresMusic[1] + h);
            pic13.Image = image2;
            Image image3 = Image.FromFile(usuario.Profiles[2].PleasuresMusic[2] + h);
            pic14.Image = image3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label11.Text)
                {
                    perfilActual = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            string h = ".jpg";
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            //panel5.Visible = false;


            Image image1 = Image.FromFile(usuario.Profiles[3].PleasuresMusic[0] + h);
            pic12.Image = image1;
            Image image2 = Image.FromFile(usuario.Profiles[3].PleasuresMusic[1] + h);
            pic13.Image = image2;
            Image image3 = Image.FromFile(usuario.Profiles[3].PleasuresMusic[2] + h);
            pic14.Image = image3;
        }

        private void btnCambiarPerfil_Click(object sender, EventArgs e)
        {
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;
            panelContenedorPincipal.Visible = false;
            panelCrearUsuario.Visible = false;
            panel4.Visible = false;
            Reproductor.Ctlcontrols.stop();
            panel32.Visible = false;

            
        }

        private void Crear_Click(object sender, EventArgs e)
        {
            int errores = 0;
            if (usuario.Profiles.Count > 0)
            {
                for (int a = 0; a < usuario.Profiles.Count; a++)
                {
                    if (nomPerfil.Text == usuario.Profiles[a].NameProfile)
                    {
                        MessageBox.Show("Ya existe un perfil con este nombre");
                        errores++;
                    }
                }

            }
            if (nomPerfil.Text == "" || privacidadPerfil.SelectedItem == null || gustosMusicales.CheckedItems.Count< 3 || gustosPeliculas.CheckedItems.Count<3)
            {
                MessageBox.Show("RELLENE TODOS LOS DATOS");
                if(gustosMusicales.CheckedItems.Count < 3)
                {
                    MessageBox.Show("Debe ingresar al menos 3 gustos musicales");
                }
                if (gustosPeliculas.CheckedItems.Count < 3)
                {
                    MessageBox.Show("Debe ingresar al menos 3 categorias de peliculas favoritas");
                }

            }
            else if (errores == 0)
            {
                panelCrearUsuario.Visible = false;
                List<String> gustosMusica = new List<string>();
                List<String> gustosPelis = new List<string>();
                List<Profile> seguidos=new List<Profile>(); ;
                List<Profile> seguidores = new List<Profile>();
                List<PlaylistSpotifai> playlistCancionSeguidas = new List<PlaylistSpotifai>();
                List<PlaylistVideoEmptyClass> playlistVideoSeguidas = new List<PlaylistVideoEmptyClass>();
                List<Album> albumSeguidos = new List<Album>();
                List<Actor> actoresSeguidos = new List<Actor>();
                List<Singer> cantantesSeguidos = new List<Singer>();
                List<Director> directoresSeguidos = new List<Director>();
                
                for (int i = 0; i < gustosMusicales.Items.Count; i++)
                {
                    if (gustosMusicales.GetItemChecked(i) == true)
                    {
                        gustosMusica.Add(gustosMusicales.Items[i].ToString());

                    }


                }
                for (int i = 0; i < gustosPeliculas.Items.Count; i++)
                {
                    if (gustosPeliculas.GetItemChecked(i) == true)
                    {
                        gustosPelis.Add(gustosPeliculas.Items[i].ToString());

                    }


                }
                List<Clases.User> todosUsuarios = new List<Clases.User>();
                Clases.Profile perfil = new Clases.Profile(nomPerfil.Text, privacidadPerfil.SelectedItem.ToString(), gustosMusica, gustosPelis,playlistCanciones,playlistVideos,playlistFavoritasCanciones,playlistFavoritasVideos, seguidos, seguidores, playlistCancionSeguidas, playlistVideoSeguidas, albumSeguidos, actoresSeguidos, cantantesSeguidos, directoresSeguidos);
                usuario.Profiles.Add(perfil);

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
                MessageBox.Show("Perfil Creado");
                panelContenedorPincipal.Visible = false;
                panelCrearUsuario.Visible = false;

                if (usuario.Plan == "Basico")
                {

                    DateTime fechaActual = DateTime.Now;
                    if (usuario.RegistrationDate.Month == fechaActual.Month && usuario.RegistrationDate.Day == fechaActual.Day)
                    {
                        if (usuario.Profiles.Count == 0)
                        {
                            pic5.Visible = true;
                            pic1.Visible = false;
                            pic4.Visible = false;
                            pic7.Visible = false;
                            pic3.Visible = false;
                            pic6.Visible = false;
                            pic2.Visible = false;
                            pic8.Visible = false;
                            crear1.Visible = true;
                            crear2.Visible = false;
                            crear3.Visible = false;
                            crear4.Visible = false;
                        }
                        else
                        {
                            pic5.Visible = false;
                            pic1.Visible = true;
                            crear1.Visible = false;
                            crear2.Visible = false;
                            crear3.Visible = false;
                            crear4.Visible = false;
                            label8.Text = usuario.Profiles[0].NameProfile;
                            label8.Visible = true;
                            button1.Visible = true;
                        }
                    }
                    else
                    {
                        if (usuario.Profiles.Count == 0)
                        {
                            pic5.Visible = true;
                            pic1.Visible = false;
                            pic4.Visible = false;
                            pic7.Visible = false;
                            pic3.Visible = false;
                            pic6.Visible = false;
                            pic2.Visible = false;
                            pic8.Visible = false;
                            crear1.Visible = true;
                            crear2.Visible = false;
                            crear3.Visible = false;
                            crear4.Visible = false;

                        }
                        else
                        {
                            pic5.Visible = false;
                            pic1.Visible = true;
                            crear1.Visible = false;
                            crear2.Visible = false;
                            crear3.Visible = false;
                            crear4.Visible = false;
                            label8.Text = usuario.Profiles[0].NameProfile;
                            label8.Visible = true;
                            button1.Visible = true;


                        }
                    }
                        
                }
                else if (usuario.Plan == "Premium")
                {
                    if (usuario.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = false;
                        pic8.Visible = false;
                        crear1.Visible = true;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                    }
                    else
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;
                    }
                }

                else if (usuario.Plan == "Familiar")
                {
                    if (usuario.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = true;
                        pic3.Visible = false;
                        pic6.Visible = true;
                        pic2.Visible = false;
                        pic8.Visible = true;
                        crear1.Visible = true;
                        crear2.Visible = true;
                        crear3.Visible = true;
                        crear4.Visible = true;
                    }
                    else if (usuario.Profiles.Count == 1)
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic7.Visible = true;
                        pic3.Visible = false;
                        pic6.Visible = true;
                        pic2.Visible = false;
                        pic8.Visible = true;
                        crear1.Visible = false;
                        crear2.Visible = true;
                        crear3.Visible = true;
                        crear4.Visible = true;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;
                    }
                    else if (usuario.Profiles.Count == 2)
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic7.Visible = true;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = true;
                        pic8.Visible = true;
                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = true;
                        crear4.Visible = true;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        label9.Text = usuario.Profiles[1].NameProfile;
                        label9.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                    }
                    else if (usuario.Profiles.Count == 3)
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = true;
                        pic6.Visible = false;
                        pic2.Visible = true;
                        pic8.Visible = true;
                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = true;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        label9.Text = usuario.Profiles[1].NameProfile;
                        label9.Visible = true;
                        label10.Text = usuario.Profiles[2].NameProfile;
                        label10.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                    }
                    else if (usuario.Profiles.Count == 4)
                    {
                        pic5.Visible = false;
                        pic1.Visible = true;
                        pic4.Visible = true;
                        pic7.Visible = false;
                        pic3.Visible = true;
                        pic6.Visible = false;
                        pic2.Visible = true;
                        pic8.Visible = false;
                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        label9.Text = usuario.Profiles[1].NameProfile;
                        label9.Visible = true;
                        label10.Text = usuario.Profiles[2].NameProfile;
                        label10.Visible = true;
                        label11.Text = usuario.Profiles[3].NameProfile;
                        label11.Visible = true;
                        button1.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        
                    }
                }
            }
        }

        private void pic9_Click(object sender, EventArgs e) //imagen avenger
        {
            videoClick = "avengers";
            int errores = 1;
            List<User> usuarios = new List<User>();
            usuarios = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count; a++)
            {
                if (usuarios[a].NameUser == usuario.NameUser)
                {

                    for (int b = 0; b < usuarios[a].VideosComprados.Count(); b++)
                    {
                        errores--;
                        if (usuarios[a].VideosComprados[b].Title == "avengers")
                        {

                            panel6.Visible = true;
                            List<Video> videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                            foreach (Video x in videoAux0)
                            {
                                if (x.Title == "avengers")
                                {
                                    videoSonando = x;
                                    reproduciendo = "video";//Esto sirve para agregar en las playlists.
                                    panel6.Visible = true;
                                    txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                    btnPausa.Visible = true;
                                    btnPlay.Visible = false;
                                    numlikes = x.Likes;
                                    NumLike.Text = numlikes.ToString();
                                    NumLike.Visible = true;

                                    numreproducciones = x.NReproduction;
                                    numreproducciones += 1; //REPRODUCCIONES
                                    x.NReproduction = numreproducciones;

                                    NumReproducciones.Text = numreproducciones.ToString();

                                    if (x.ProfileLikes.Count() > 0)
                                    {
                                        if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                        {
                                            manito.Visible = false;
                                        }
                                        else
                                        {
                                            manito.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }
                                    e6.Visible = true;
                                    e7.Visible = true;
                                    e8.Visible = true;
                                    e9.Visible = true;
                                    e10.Visible = true;
                                    panel27.Visible = false;
                                    panel25.Visible = false;
                                    panel23.Visible = false;
                                    
                                }
                            }
                            string ruta32 = Path.Combine(Application.StartupPath, "avengers.mp4");
                            Reproductor2.URL = ruta32;
                            serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                            break;
                            //aca poner para que se abra el panel del reproductor
                        }
                        else
                        {
                            errores++;
                        }

                    }
                    break;
                }
            }
            if (errores > 0)
            {
                if (panel34.Visible == true)
                {
                    panel34.Visible = false;
                }
                else
                {
                    panel34.Visible = true;
                    panel18.Visible = false;
                    panel15.Visible = false;
                }
            }
            
        }

        private void gustosMusicales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            label15.Text = "Cambio de Contraseña";
            l1.Text = "Constraseña actual";
            l2.Text = "Nueva constraseña";
            l3.Text = "Confirme nueva";
            l1.Visible = true;
            l2.Visible = true;
            l3.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            radioButton1.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            btnCambiarClave.Visible = true;
            btncambiarp.Visible = false;


            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void btnCambiarPlan_Click(object sender, EventArgs e)
        {
            label15.Text = "Escoja Plan";
            l1.Visible = false;
            l2.Visible = false;
            l3.Visible = true;
            l3.Text = "Contraseña";
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = true;
            btnCambiarClave.Visible = false;
            btncambiarp.Visible = true;
            radioButton1.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;

            if (panel4.Visible == true)
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
            }
        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            panel27.Visible = false;
            if (usuario.Plan == "Basico")
            {
                DateTime fechaActual = DateTime.Now;
                if (usuario.RegistrationDate.Month == fechaActual.Month && usuario.RegistrationDate.Day == fechaActual.Day)
                {
                    if (usuario.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = false;
                        pic8.Visible = false;
                        crear1.Visible = true;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                        label8.Visible = false;
                        button1.Visible = false;
                        b1.Visible = false;
                        b2.Visible = false;
                        b3.Visible = false;
                        b4.Visible = false;
                        b13.Visible = false;
                        b14.Visible = false;
                        b15.Visible = false;
                        b16.Visible = false;
                    }
                    else
                    {
                        pic5.Visible = false;
                        pic6.Visible = false;
                        pic7.Visible = false;
                        pic8.Visible = false;

                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic3.Visible = false;
                        pic2.Visible = false;

                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;

                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;


                    }
                }
                else
                {
                    if (usuario.Profiles.Count == 0)
                    {
                        pic5.Visible = true;
                        pic1.Visible = false;
                        pic4.Visible = false;
                        pic7.Visible = false;
                        pic3.Visible = false;
                        pic6.Visible = false;
                        pic2.Visible = false;
                        pic8.Visible = false;
                        crear1.Visible = true;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;
                        label8.Visible = false;
                        button1.Visible = false;
                        b1.Visible = false;
                        b2.Visible = false;
                        b3.Visible = false;
                        b4.Visible = false;
                        b13.Visible = false;
                        b14.Visible = false;
                        b15.Visible = false;
                        b16.Visible = false;
                    }
                    else
                    {
                        pic5.Visible = false;
                        pic6.Visible = false;
                        pic7.Visible = false;
                        pic8.Visible = false;

                        pic1.Visible = true;
                        pic4.Visible = false;
                        pic3.Visible = false;
                        pic2.Visible = false;

                        crear1.Visible = false;
                        crear2.Visible = false;
                        crear3.Visible = false;
                        crear4.Visible = false;

                        label8.Text = usuario.Profiles[0].NameProfile;
                        label8.Visible = true;
                        button1.Visible = true;


                    }
                }
                
            }
            else if (usuario.Plan == "Premium")
            {
                TipoCuenta = "Premiun";
                if (usuario.Profiles.Count == 0)
                {
                    pic5.Visible = true;
                    pic1.Visible = false;
                    pic4.Visible = false;
                    pic7.Visible = false;
                    pic3.Visible = false;
                    pic6.Visible = false;
                    pic2.Visible = false;
                    pic8.Visible = false;
                    crear1.Visible = true;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;
                    label8.Visible = false;
                    button1.Visible = false;
                    b1.Visible = false;
                    b2.Visible = false;
                    b3.Visible = false;
                    b4.Visible = false;
                    b13.Visible = false;
                    b14.Visible = false;
                    b15.Visible = false;
                    b16.Visible = false;
                }
                else
                {
                    pic5.Visible = false;
                    pic6.Visible = false;
                    pic7.Visible = false;
                    pic8.Visible = false;

                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic3.Visible = false;
                    pic2.Visible = false;

                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;

                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    button1.Visible = true;


                }
            }

            else if (usuario.Plan == "Familiar")
            {
                TipoCuenta = "Familiar";
                if (usuario.Profiles.Count == 0)
                {
                    pic5.Visible = true;
                    pic1.Visible = false;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = true;
                    pic2.Visible = false;
                    pic8.Visible = true;
                    crear1.Visible = true;
                    crear2.Visible = true;
                    crear3.Visible = true;
                    crear4.Visible = true;

                }
                else if (usuario.Profiles.Count == 1)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = true;
                    pic2.Visible = false;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = true;
                    crear3.Visible = true;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    button1.Visible = true;
                    label8.Visible = true;
                }
                else if (usuario.Profiles.Count == 2)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = true;
                    pic3.Visible = false;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = true;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                }
                else if (usuario.Profiles.Count == 3)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = false;
                    pic7.Visible = false;
                    pic3.Visible = true;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = true;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = true;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    label10.Text = usuario.Profiles[2].NameProfile;
                    label10.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                }
                else if (usuario.Profiles.Count == 4)
                {
                    pic5.Visible = false;
                    pic1.Visible = true;
                    pic4.Visible = true;
                    pic7.Visible = false;
                    pic3.Visible = true;
                    pic6.Visible = false;
                    pic2.Visible = true;
                    pic8.Visible = false;
                    crear1.Visible = false;
                    crear2.Visible = false;
                    crear3.Visible = false;
                    crear4.Visible = false;
                    label8.Text = usuario.Profiles[0].NameProfile;
                    label8.Visible = true;
                    label9.Text = usuario.Profiles[1].NameProfile;
                    label9.Visible = true;
                    label10.Text = usuario.Profiles[2].NameProfile;
                    label10.Visible = true;
                    label11.Text = usuario.Profiles[3].NameProfile;
                    label11.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                }


            }
            panelContenedorPincipal.Visible = false;
            panel4.Visible = false;
            panelSubMenuAjustes.Visible = false;
            panelCrearUsuario.Visible = false;
            
            if (usuario.Plan == "Basico" && usuario.Profiles.Count == 1)
            {
                b1.Visible = true;
                b13.Visible = true;

            }
            else if (usuario.Plan == "Premium" && usuario.Profiles.Count == 1)
            {
                b1.Visible = true;
                b13.Visible = true;

            }
            else if (usuario.Plan == "Familiar")
            {
                if (usuario.Profiles.Count==1)
                {
                    b1.Visible = true;
                    b13.Visible = true;
                }
                else if (usuario.Profiles.Count == 2)
                {
                    b1.Visible = true;
                    b13.Visible = true;
                    b2.Visible = true;
                    b14.Visible = true;
                }
                else if (usuario.Profiles.Count == 3)
                {
                    b1.Visible = true;
                    b13.Visible = true;
                    b2.Visible = true;
                    b14.Visible = true;
                    b3.Visible = true;
                    b15.Visible = true;

                }
                else if (usuario.Profiles.Count == 4)
                {
                    b1.Visible = true;
                    b13.Visible = true;
                    b2.Visible = true;
                    b14.Visible = true;
                    b3.Visible = true;
                    b15.Visible = true;
                    b4.Visible = true;
                    b16.Visible = true;

                }


            }


        }

        private void panelSubMenuAjustes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Disculpa ,estamos presentando dificultades por el momento , intenta en otra entrega :(");
            string a = "c";//suponemos es premiun
            string b = "b";//suponemos es familiar
            List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            if (txt1.Text == "" || txt2.Text == "" || txt3.Text == "")
            {
                MessageBox.Show("POR FAVOR RELLENE TODOS DATOS");
            }

            else if (deserializarUser.Count > 0)//aca hay que poner que se verifique el inicio de secion
            {
                int error = 1;
                int avanzar = 0;
                Clases.User us = new Clases.User();
                for (int d = 0; d < deserializarUser.Count; d++)
                {
                    error--;
                    if (deserializarUser[d].Password == txt1.Text)
                    {

                        us = deserializarUser[d];

                    }
                    else
                    {
                        error++;
                    }

                }
                if (error > 0)
                {
                    MessageBox.Show("contraseña invalida");
                }
                if (txt2.Text != txt3.Text)
                {
                    MessageBox.Show("su nueva contraseña no coincide ");

                }
                if (txt2.Text == txt3.Text)
                {
                    if (txt1.Text == txt2.Text)
                    {
                        MessageBox.Show("Su contraseña nueva no puede ser igual a la anterior");

                    }
                    else
                    {
                        avanzar += 1;
                    }
                }
                if (avanzar > 0)
                {
                    int error3 = 1;
                    for (int d = 0; d < deserializarUser.Count; d++)
                    {
                        error3--;
                        if (deserializarUser[d].Password == txt1.Text)
                        {


                            deserializarUser[d].Password = txt2.Text;
                            panel4.Visible = false;
                            

                        }
                        else
                        {
                            error3++;
                        }

                    }
                    if (error3 <= 0)
                    {
                        MessageBox.Show("Contraseña cambiada con exito");
                    }
                    serializar.Serialize(deserializarUser, File.Open("data.bin", FileMode.Create));

                    //solo falta agregar la nueva contraseña al usuario


                }


            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            for(int a=0; a<usuario.Profiles.Count;a++)
            {
                if (usuario.Profiles[a].NameProfile == label8.Text)
                {
                    perfilCambiar = usuario.Profiles[a];
                }
            }
            
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            panel6.Visible = true;
            panel23.Visible = true;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label9.Text)
                {
                    perfilCambiar = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            panel6.Visible = true;
            panel23.Visible = true;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label10.Text)
                {
                    perfilCambiar = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            panel6.Visible = true;
            panel23.Visible = true;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label11.Text)
                {
                    perfilCambiar = usuario.Profiles[a];
                }
            }
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            panel6.Visible = true;
            panel23.Visible = true;
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            try
            {
                canciones = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
                videos = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));


            }
            catch (System.Runtime.Serialization.SerializationException)
            {

            }
            
            if (listCanciones.Visible == true)
            {
                listCanciones.Visible = false;
                listCanciones.Items.Clear();
            }
            else
            {
                listCanciones.Items.Clear();
                listCanciones.Visible = true;
            }
            listCanciones.Items.Clear();


            try
            {
                int entero = 0;
                string answer = txtBusqueda.Text.ToUpper();
                string[] listaStr = answer.Split(' ');//TIENE QUE IR EN EL FORMS


                try
                {
                    entero = Int32.Parse(answer);
                }
                catch (FormatException)
                {

                }
                if (entero != 0)
                {
                    //Buscar por resolucion de video o cancion
                    var resolution = from s in canciones
                                     where s.Resolution == entero
                                     select s;
                    var resolution2 = from s in videos
                                      where s.Resolution == entero
                                      select s;
                    foreach (SongClass x in resolution)
                    {
                        listCanciones.Items.Add(x);
                    }
                    foreach (Video z in resolution2)
                    {
                        listCanciones.Items.Add(z);
                    }

                    //Buscar por nota definida.
                    var nota = from s in canciones
                               where s.Evaluation == entero
                               select s;
                    var nota2 = from s in videos
                                where s.Evaluation == entero
                                select s;
                    foreach (SongClass x in nota)
                    {
                        listCanciones.Items.Add(x);
                    }
                    foreach (Video z in nota2)
                    {
                        listCanciones.Items.Add(z);
                    }

                }
                else //STRINGS
                {
                    //UN SOLLO FILTRO.
                    //filtro por titulos de videos y canciones.
                    string answer2 = listaStr[0].ToUpper(); //Ponerlo en el FORMS
                    var title = from s in canciones //Filtro por Titutlo de la cancion. Y video.
                                where s.Title.ToUpper() == answer2.ToUpper()
                                select s;
                    var title2 = from s in videos
                                 where s.Title.ToUpper() == answer2.ToUpper()
                                 select s;
                    foreach (SongClass ojb2 in title)
                    {
                        listCanciones.Items.Add(ojb2);
                    }
                    foreach (Video ojb2 in title2)
                    {
                        listCanciones.Items.Add(ojb2);
                    }



                    var keyWord = from s in canciones //Filtro por palabra clave
                                  where s.Keyword.ToUpper() == answer.ToUpper()
                                  select s;
                    var keyword2 = from s in videos
                                   where s.Keyword.ToUpper() == answer.ToUpper()
                                   select s;
                    foreach (SongClass x in keyWord)
                    {
                        listCanciones.Items.Add(x);
                    }
                    foreach (Video z in keyword2)
                    {
                        listCanciones.Items.Add(z);
                    }

                    //Busqueda por persona. Se buscara por director/Actor, Singer/Composer. Todo sera buscado por nombres.
                    var persona = from s in canciones
                                  where s.Singer.Name.ToUpper() == answer.ToUpper() || s.Composer == answer.ToUpper()
                                  select s;
                    var persona2 = from s in videos
                                   where s.Director.Name.ToUpper() == answer.ToUpper() || s.MainActor.Name == answer.ToUpper()
                                   select s;
                    foreach (SongClass x in persona)
                    {
                        listCanciones.Items.Add(x);
                    }
                    foreach (Video z in persona2)
                    {
                        listCanciones.Items.Add(z);
                    }

                    //Busqueda por caracteristica de personas. Se buscara director en videos y singer en canciones.
                    // En Ambos se buscara por Gender o Nacionalidad.
                    var person = from s in canciones
                                 where s.Singer.Gender.ToUpper() == answer.ToUpper() || s.Singer.Nationality == answer.ToUpper()
                                 select s;
                    var person2 = from s in videos
                                  where s.Director.Gender.ToUpper() == answer.ToUpper() || s.Director.Nationality == answer.ToUpper()
                                  select s;
                    foreach (SongClass x123 in person)
                    {
                        listCanciones.Items.Add(x123);
                    }
                    foreach (Video z123 in person2)
                    {
                        listCanciones.Items.Add(z123);
                    }

                    var category = from s in canciones //Categoria = Genero de musica, en el caso de video a que tipo pertenece.
                                   where s.Gender.ToUpper() == answer.ToUpper()
                                   select s;
                    var category2 = from s in videos
                                    where s.Gender.ToUpper() == answer.ToUpper()
                                    select s;

                    foreach (SongClass y2 in category)
                    {
                        listCanciones.Items.Add(y2);
                    }
                    foreach (Video z1 in category2)
                    {
                        listCanciones.Items.Add(z1);
                    }
                }


                //Multiples filtrosss ----------------------------------------------------- Por ahora con strings
                if (listaStr.Count() >= 2)
                {
                    string and1 = "and";

                    string or1 = "or";


                    if (listaStr[1] == and1.ToUpper()) //Ejemplo, se tienen que mostrar todas las canciones y videos que contenga Gender y keyword deseada.
                    {
                        //BIEN
                        var Multi1 = from s in canciones //Genero y palabra clave
                                     where s.Gender.ToUpper() == listaStr[0].ToUpper() || s.Gender.ToUpper() == listaStr[2].ToUpper()
                                     where s.Keyword.ToUpper() == listaStr[2].ToUpper() || s.Keyword.ToUpper() == listaStr[0].ToUpper()
                                     select s;
                        var multi2 = from s in videos
                                     where s.Gender.ToUpper() == listaStr[0].ToUpper() || s.Gender.ToUpper() == listaStr[2].ToUpper()
                                     where s.Keyword.ToUpper() == listaStr[2].ToUpper() || s.Keyword.ToUpper() == listaStr[0].ToUpper()
                                     select s;
                        foreach (SongClass j in Multi1)
                        {
                            listCanciones.Items.Add(j);
                        }
                        foreach (Video j in multi2)
                        {
                            listCanciones.Items.Add(j);
                        }

                        //Palabra clave y persona //BIEN
                        var Mezcla = from s in canciones
                                     where s.Keyword.ToUpper() == listaStr[0].ToUpper() || s.Keyword.ToUpper() == listaStr[2].ToUpper()
                                     where (s.Singer.Name.ToUpper() == listaStr[2].ToUpper() || s.Composer.ToUpper() == listaStr[2].ToUpper()) || (s.Singer.Name.ToUpper() == listaStr[0].ToUpper() || s.Composer.ToUpper() == listaStr[0].ToUpper())
                                     select s;
                        var Mezcla2 = from s in videos
                                      where s.Keyword.ToUpper() == listaStr[0].ToUpper() || s.Keyword.ToUpper() == listaStr[2].ToUpper()
                                      where (s.Director.Name.ToUpper() == listaStr[2].ToUpper() || s.MainActor.Name.ToUpper() == listaStr[2].ToUpper()) || (s.Director.Name.ToUpper() == listaStr[0].ToUpper() || s.MainActor.Name.ToUpper() == listaStr[0].ToUpper())
                                      select s;
                        foreach (SongClass j in Mezcla)
                        {
                            listCanciones.Items.Add(j);
                        }

                        foreach (Video j in Mezcla2)
                        {
                            listCanciones.Items.Add(j);
                        }
                        /*
                        //Palabra clave y caracteristica de la persona.
                        var anakin = from s in canciones
                                     where s.Keyword.ToUpper() == listaStr[0].ToUpper() || s.Keyword.ToUpper() == listaStr[2].ToUpper()
                                     where s.Singer.Gender.ToUpper() == listaStr[1].ToUpper() || s.Singer.Nationality.ToUpper() == listaStr[1].ToUpper() || (s.Singer.Gender.ToUpper() == listaStr[0].ToUpper() || s.Singer.Nationality.ToUpper() == listaStr[0].ToUpper())
                                     select s;
                        var anakin2 = from s in videos
                                      where (s.Keyword.ToUpper() == listaStr[0].ToUpper() && (s.Director.Gender.ToUpper() == listaStr[1].ToUpper() || s.Director.Nationality.ToUpper() == listaStr[1].ToUpper())) || (s.Keyword.ToUpper() == listaStr[1].ToUpper() && (s.Director.Gender.ToUpper() == listaStr[0].ToUpper() || s.Director.Nationality.ToUpper() == listaStr[0].ToUpper()))
                                      select s;
                        foreach (SongClass j in anakin)
                        {
                            listCanciones.Items.Add(j);
                        }
                        foreach (Video j in anakin2)
                        {
                            listCanciones.Items.Add(j);
                        }
                        */


                        //Palabra clave y titutlo. //BIEN
                        var zelda1 = from s in canciones
                                     where s.Keyword.ToUpper() == listaStr[0].ToUpper() || s.Keyword.ToUpper() == listaStr[2].ToUpper()
                                     where s.Title.ToUpper() == listaStr[0].ToUpper() || s.Title.ToUpper() == listaStr[2].ToUpper()
                                     select s;
                        var zelda2 = from s in videos
                                     where s.Keyword.ToUpper() == listaStr[0].ToUpper() || s.Keyword.ToUpper() == listaStr[2].ToUpper()
                                     where s.Title.ToUpper() == listaStr[0].ToUpper() || s.Title.ToUpper() == listaStr[2].ToUpper()
                                     select s;
                        foreach (SongClass j in zelda1)
                        {
                            listCanciones.Items.Add(j);
                        }
                        foreach (Video j in zelda2)
                        {
                            listCanciones.Items.Add(j);
                        }


                    }
                    else if (listaStr[1] == or1.ToUpper()) //Mismo orden que en el and.
                    {
                        var Multi1d = from s in canciones //Genero y palabra clave
                                      where (s.Gender.ToUpper() == listaStr[0].ToUpper() || s.Gender.ToUpper() == listaStr[2].ToUpper()) || (s.Keyword.ToUpper() == listaStr[2].ToUpper() || s.Keyword.ToUpper() == listaStr[0].ToUpper())
                                      select s;
                        var multi2 = from s in videos
                                     where (s.Gender.ToUpper() == listaStr[0].ToUpper() || s.Gender.ToUpper() == listaStr[2].ToUpper()) || (s.Keyword.ToUpper() == listaStr[2].ToUpper() || s.Keyword.ToUpper() == listaStr[0].ToUpper())
                                     select s;
                        foreach (SongClass j in Multi1d)
                        {
                            listCanciones.Items.Add(j);
                        }
                        foreach (Video j in multi2)
                        {
                            listCanciones.Items.Add(j);
                        }

                        //Palabra clave y persona
                        var Mezcla = from s in canciones
                                     where (s.Keyword.ToUpper() == listaStr[0].ToUpper() || (s.Singer.Name.ToUpper() == listaStr[2].ToUpper() || s.Composer.ToUpper() == listaStr[2].ToUpper())) || (s.Keyword.ToUpper() == listaStr[2].ToUpper() && (s.Singer.Name.ToUpper() == listaStr[0].ToUpper() || s.Composer.ToUpper() == listaStr[0].ToUpper()))
                                     select s;
                        var Mezcla2 = from s in videos
                                      where (s.Keyword.ToUpper() == listaStr[0].ToUpper() || (s.Director.Name.ToUpper() == listaStr[2].ToUpper() || s.MainActor.Name.ToUpper() == listaStr[2].ToUpper())) || (s.Keyword.ToUpper() == listaStr[2].ToUpper() || (s.Director.Name.ToUpper() == listaStr[0].ToUpper() || s.MainActor.Name.ToUpper() == listaStr[0].ToUpper()))
                                      select s;
                        foreach (SongClass j in Mezcla)
                        {
                            listCanciones.Items.Add(j);
                        }

                        foreach (Video j in Mezcla2)
                        {
                            listCanciones.Items.Add(j);
                        }
                        //PALABRA CLAVE Y TITULO.
                        var zelda1 = from s in canciones
                                     where s.Keyword.ToUpper() == listaStr[0].ToUpper() | s.Keyword.ToUpper() == listaStr[2].ToUpper() || s.Title.ToUpper() == listaStr[0].ToUpper() | s.Title.ToUpper() == listaStr[2].ToUpper()
                                     select s;
                        var zelda2 = from s in videos
                                     where (s.Keyword.ToUpper() == listaStr[0].ToUpper() | s.Keyword.ToUpper() == listaStr[2].ToUpper()) | (s.Title.ToUpper() == listaStr[0].ToUpper() | s.Title.ToUpper() == listaStr[2].ToUpper())
                                     select s;
                        foreach (SongClass j in zelda1)
                        {
                            listCanciones.Items.Add(j);
                        }
                        foreach (Video j in zelda2)
                        {
                            listCanciones.Items.Add(j);
                        }

                    }


                }
                if (listCanciones.Items.Count == 0)// ESto es cuando no pudo encontrar nada relacionado con canciones y videos.
                {
                    MessageBox.Show("No se pudo encontrar nada relacionado. Intente de nuevo.");
                }

            }

            catch (System.Runtime.Serialization.SerializationException) //VEr despues
            {
                MessageBox.Show("Terminos no validos.");
            }

        }
            

        private void button5_Click(object sender, EventArgs e)
        {
            canciones.Add(cancion);
            canciones.Add(cancion2);
            canciones.Add(cancion3);
            canciones.Add(cancion4);
            videos.Add(video);
            videos.Add(video2);
            videos.Add(video3);
            videos.Add(video4);

            listaAlbum.Add(album);
            listaAlbum.Add(album2);
            listaAlbum.Add(album3);
            listaAlbum.Add(album4);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            listCanciones.Items.Clear();
        }

        private void listCanciones_SelectedIndexChanged(object sender, EventArgs e) //SERIALIZAR
        {
            panelContenedorPincipal.Visible = true;
            panel6.Visible = true;
            panel23.Visible = true;
            panel25.Visible = true;

            panel27.Visible = true;

            panel32.Visible = true;
            //DESERIALIZANDO
            List<SongClass> songAux0 = new List<SongClass>();
            try
            {
                songAux0 = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
            }
            catch (System.Runtime.Serialization.SerializationException)
            {

            }
            List<Video> videoAux0 = new List<Video>();
            try
            {
                videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
            }
            catch (System.Runtime.Serialization.SerializationException)
            {

            }

            //HASTA ACA
            if (listCanciones.SelectedItem != null)
            {
                string answer = listCanciones.SelectedItem.ToString();
                string[] listaStr = answer.Split(' ');
                foreach(SongClass x in songAux0)
                {
                    if (x.Title == listaStr[0])
                    {
                        lblTitle.Text = x.Title;
                        lblStudy.Text = x.Study;
                        lblPublicationYear.Text = x.PublicationYear;
                        lblKeyword.Text = x.Keyword;
                        lblGender.Text = x.Gender;
                        lblDuration.Text = x.Duration.ToString();
                        cancionElegida = x;
                        cosaElegida = "cancion";
                    }
                }
                foreach (Video x in videoAux0)
                {
                    if (x.Title == listaStr[0])
                    {
                        lblTitle.Text = x.Title;
                        lblStudy.Text = x.Study;
                        lblPublicationYear.Text = x.PublicationYear;
                        lblKeyword.Text = x.Keyword;
                        lblGender.Text = x.Gender;
                        lblDuration.Text = x.Duration.ToString();
                        videoElegida = x;
                        cosaElegida = "video";
                    }
                }
            }
        }

        private void Adjuntar_Click(object sender, EventArgs e)
        {

            OpenFileDialog CajaBusquedaDeARchivos = new OpenFileDialog();
            // SOLO Puedo elegir un archivo
            if (CajaBusquedaDeARchivos.ShowDialog() == DialogResult.OK) //Filtrando solo los archivos MP3
            {

                ArchivoMP3 = CajaBusquedaDeARchivos.SafeFileName; // aqui se van almacenar todos los archivos
                rutaArchivoMP3 = CajaBusquedaDeARchivos.FileName;



                // NECESITO FILTRO QUE SOLO SEA MP3 o MP4
                int startIndex = ArchivoMP3.Length - 4;
                int final = 4;
                String substring = ArchivoMP3.Substring(startIndex, final);
                try
                {
                    //VER QUE SEAN MINUSCULAS Y MAYUSCULAS
                    if (substring == ".mp3" || substring == ".mp4" || substring == ".wav")
                    {
                        listBox1.Items.Add(ArchivoMP3);
                        btnAgregarInfo.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Solo formato .mp3 o .mp4");
                }
                //Vamos a agarrar el ultio elemtno que adjuntamos en nuestra app y lo vamos a reproducir
                Reproductor.URL = rutaArchivoMP3;
                listBox1.SelectedIndex = 0;
            }
        }

        private void btnAgregarInfo_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            // NECESITO FILTRO QUE SOLO SEA MP3
            int startIndex = ArchivoMP3.Length - 4;
            int final = 4;
            String substring = ArchivoMP3.Substring(startIndex, final);
            try
            {
                //VER QUE SEAN MINUSCULAS Y MAYUSCULAS
                if (substring == ".mp3" || substring == ".wav")
                {
                    label20.Text = "Cantante";
                    label19.Text = "Compositor";
                    label18.Text = "Album";
                }
                else if (substring == ".mp4")
                {
                    label20.Text = "Director";
                    label19.Text = "Actor";
                    label18.Text = "Descripcion";

                }
            }
            catch
            {
                MessageBox.Show("Solo formato .mp3 o .mp4o.wav");
            }
        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }




        private void Subir_Click(object sender, EventArgs e) //Btn Agregar
        {
            //if (txt=="");malo
            //subir los try de los int 
            //else{

            List<SongClass> songAux123 = new List<SongClass>();
            List<Video> videoAux123 = new List<Video>();

            int startIndex = ArchivoMP3.Length - 4;
            int final = 4;
            String substring = ArchivoMP3.Substring(startIndex, final);
            if (txtTitle.Text == "" || txtSinger.Text == "" || txtComposer.Text == "" || txtAlbum.Text == "" || txtGender.Text == "" || txtPublicationYear.Text == "" || txtStudy.Text == "" || txtKeyword.Text == "" || txtAlbum.Text == "")
            {
                MessageBox.Show("Rellene todos los datos");
            }
            else
            {
                try
                {
                    //VER QUE SEAN MINUSCULAS Y MAYUSCULAS
                    if (substring == ".mp3")
                    {
                        string title = "";
                        string singer12 = "";
                        string composer = "";
                        string album12 = "";
                        string gender = "";
                        string publicationYear = ""; //Tiene que ser en el formato de data time
                        string study = "";
                        string keyWord = "";

                        title = txtTitle.Text;
                        singer12 = txtSinger.Text;
                        composer = txtComposer.Text;
                        album12 = txtAlbum.Text;
                        gender = txtGender.Text;
                        publicationYear = txtPublicationYear.Text;
                        study = txtStudy.Text;
                        keyWord = txtKeyword.Text;

                        Singer singer123 = new Singer(canciones, listaAlbum, premios, "voiceType", "genders", 22, discograpich, singer12, 12, "Lastname", "genero", "nationality", "ocupacion");
                        Album album123 = new Album(album12, "gender", "producer", singer, date);

                        //Preguntarle al pefil si quiere rellenar los datos de Singer y Album
                        double duration123 = Reproductor.Ctlcontrols.currentItem.duration;
                        SongClass ob = new SongClass(gender, publicationYear, title, duration123, 123, study, keyWord, composer, singer123, album123, ArchivoMP3, 123, 123, rutaArchivoMP3, 0, 0, listaPerfilesLikes);
                        //Deserializando

                        List<SongClass> songAux = new List<SongClass>();

                        try
                        {
                            songAux = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
                        }
                        catch (System.Runtime.Serialization.SerializationException)
                        {

                        }
                        foreach (SongClass x in songAux)
                        {
                            songAux123.Add(x);
                        }
                        songAux123.Add(ob);
                        serializar.Serialize(songAux123, File.Open("Canciones.bin", FileMode.Create));
                    }


                    else if (substring == ".mp4")
                    {

                        string title = "";
                        string actor = "";
                        string composer = "";
                        string director = "";
                        string gender = "";
                        string publicationYear = ""; //Tiene que ser en el formato de data time
                        string study = "";
                        string keyWord = "";
                        string description = "";



                        title = txtTitle.Text;
                        director = txtSinger.Text;
                        composer = txtComposer.Text;
                        actor = txtAlbum.Text;
                        gender = txtGender.Text;
                        publicationYear = txtPublicationYear.Text;
                        study = txtStudy.Text;
                        keyWord = txtKeyword.Text;
                        description = txtAlbum.Text;

                        Actor Mactor123 = new Actor("name4", 22, actor, "gender4", "nationality4", "Ocupacion4", videos, premios, 22);
                        Director d123 = new Director(director, 22, "LastD", "gender", "nationality", "ocupation", videos, premios, 22);
                        double duration123 = Reproductor.Ctlcontrols.currentItem.duration; //SOn segundos

                        Video ob2 = new Video(gender, publicationYear, title, duration123, 123, study, keyWord, description, Mactor123, d123, ArchivoMP3, 123, 123, rutaArchivoMP3, 0, 0, listaPerfilesLikes);

                        //videos123.Add(ob2);
                        List<Video> videoAux = new List<Video>();
                        try
                        {
                            videoAux = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                        }
                        catch (System.Runtime.Serialization.SerializationException)
                        {

                        }
                        foreach (Video x in videoAux)
                        {
                            videoAux123.Add(x);
                        }
                        videoAux123.Add(ob2);
                        serializar.Serialize(videoAux123, File.Open("Videos.bin", FileMode.Create));
                        // Lo hicimos xq para que no se repitieran las canciones
                    }
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }

                MessageBox.Show("Su archivo ha sido guardado.");
                panel5.Visible = false;
                btnAgregarInfo.Visible = false;
                //Limpiando los txt.

                txtTitle.Clear();
                txtSinger.Clear();
                txtComposer.Clear();
                txtAlbum.Clear();
                txtGender.Clear();
                txtPublicationYear.Clear();
                txtStudy.Clear();
                txtKeyword.Clear();
                txtAlbum.Clear();

                listBox1.Items.Clear();
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            Reproductor2.Ctlcontrols.pause();
            btnPausa.Visible = false;
            btnPlay.Visible = true;
            btnDetener.Visible = true;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            btnDetener.Visible = false;
            btnPausa.Visible = false;
            btnPlay.Visible = true;
            Reproductor2.Ctlcontrols.stop();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            btnPlay.Visible = false;
            btnPausa.Visible = true;
            Reproductor2.Ctlcontrols.play();
            

            
        }
        
        private void pictureBox2_Click(object sender, EventArgs e) // BOTON DE LIKE
        {
            List<SongClass> songAux123 = new List<SongClass>();
            List<Video> videoAux123 = new List<Video>();

            numlikes += 1;
            NumLike.Text = numlikes.ToString();
            if ( reproduciendo == "musica")
            {
                List<SongClass> songAux = new List<SongClass>();

                try
                {
                    songAux = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
                }
                catch (System.Runtime.Serialization.SerializationException)
                {

                }
                foreach (SongClass x in songAux)
                {
                    songAux123.Add(x);
                }
                foreach (SongClass x in songAux123)
                {
                    if (x.Title == cancionSonando.Title)
                    {
                        x.Likes++;
                        x.ProfileLikes.Add(perfilActual.NameProfile);
                        if (x.ProfileLikes.Count() > 0)
                        {
                            if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                            {
                                manito.Visible = false;
                            }
                            else
                            {
                                manito.Visible = true;
                            }
                        }

                    }
                }
                serializar.Serialize(songAux123, File.Open("Canciones.bin", FileMode.Create));
            }

            else
            {
                if (videoSonando.ProfileLikes.Count() > 0)
                {
                    if (true == videoSonando.ProfileLikes.Contains(perfilActual.NameProfile))
                    {
                        manito.Visible = false;
                    }
                    else
                    {
                        manito.Visible = true;
                    }
                }
                else
                {
                    manito.Visible = true;
                }
                List<Video> videoAux = new List<Video>();
                try
                {
                    videoAux = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                }
                catch (System.Runtime.Serialization.SerializationException)
                {

                }
                foreach (Video x in videoAux)
                {
                    videoAux123.Add(x);
                }
                foreach (Video x in videoAux123)
                {
                    if (x.Title == videoSonando.Title)
                    {
                        x.Likes++;
                        x.ProfileLikes.Add(perfilActual.NameProfile);
                        if (x.ProfileLikes.Count() > 0)
                        {
                            if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                            {
                                manito.Visible = false;
                            }
                            else
                            {
                                manito.Visible = true;
                            }
                        }
                    }
                }
                serializar.Serialize(videoAux123, File.Open("Videos.bin", FileMode.Create));
            }


        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel27.Visible = false;
            panel25.Visible = false;
            panel23.Visible = false;
        }

        private void NumLike_Click(object sender, EventArgs e)
        {

        }
    
        private void e6_Click_1(object sender, EventArgs e)
        {
            e6.Visible = false;
            e1.Visible = true;
        }

        private void e7_Click_1(object sender, EventArgs e)
        {
            e6.Visible = false;
            e7.Visible = false;
            e1.Visible = true;
            e2.Visible = true;
        }

        private void e8_Click_1(object sender, EventArgs e)
        {
            e6.Visible = false;
            e7.Visible = false;
            e8.Visible = false;
            e1.Visible = true;
            e2.Visible = true;
            e3.Visible = true;

        }

        private void e9_Click_1(object sender, EventArgs e)
        {
            e6.Visible = false;
            e7.Visible = false;
            e8.Visible = false;
            e9.Visible = false;
            e1.Visible = true;
            e2.Visible = true;
            e3.Visible = true;
            e4.Visible = true;
        }

        private void e10_Click_1(object sender, EventArgs e)
        {
            e6.Visible = false;
            e7.Visible = false;
            e8.Visible = false;
            e9.Visible = false;
            e10.Visible = false;

            e1.Visible = true;
            e2.Visible = true;
            e3.Visible = true;
            e4.Visible = true;
            e5.Visible = true;
        }

        private void b13_Click(object sender, EventArgs e)
        {
            for (int a = 0; a<usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label8.Text)
                {
                    usuario.Profiles.RemoveAt(a);
                }
            }
            MessageBox.Show("Perfil eliminado");
            List<Clases.User> todosUsuarios = new List<Clases.User>();
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
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;

            label8.Visible = false;
            button1.Visible = false;
            label9.Visible = false;
            button2.Visible = false;
            label10.Visible = false;
            button3.Visible = false;
            label11.Visible = false;
            button4.Visible = false;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;
        }

        private void b14_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label9.Text)
                {
                    usuario.Profiles.RemoveAt(a);
                }
            }
            MessageBox.Show("Perfil eliminado");
            List<Clases.User> todosUsuarios = new List<Clases.User>();

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
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            label8.Visible = false;
            button1.Visible = false;
            label9.Visible = false;
            button2.Visible = false;
            label10.Visible = false;
            button3.Visible = false;
            label11.Visible = false;
            button4.Visible = false;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;
        }

        private void b15_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label10.Text)
                {
                    usuario.Profiles.RemoveAt(a);
                }
            }
            MessageBox.Show("Perfil eliminado");
            List<Clases.User> todosUsuarios = new List<Clases.User>();

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
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            label8.Visible = false;
            button1.Visible = false;
            label9.Visible = false;
            button2.Visible = false;
            label10.Visible = false;
            button3.Visible = false;
            label11.Visible = false;
            button4.Visible = false;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;
        }

        private void b16_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count; a++)
            {
                if (usuario.Profiles[a].NameProfile == label11.Text)
                {
                    usuario.Profiles.RemoveAt(a);
                }
            }
            MessageBox.Show("Perfil eliminado");
            List<Clases.User> todosUsuarios = new List<Clases.User>();

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
            panelCrearUsuario.Visible = true;
            panelContenedorPincipal.Visible = true;
            label8.Visible = false;
            button1.Visible = false;
            label9.Visible = false;
            button2.Visible = false;
            label10.Visible = false;
            button3.Visible = false;
            label11.Visible = false;
            button4.Visible = false;
            b1.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b13.Visible = false;
            b14.Visible = false;
            b15.Visible = false;
            b16.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel23.Visible = false;
            panel6.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.SelectedItem == null && checkedListBox1.CheckedItems.Count == 0 && checkedListBox2.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe cambiar por lo menos un dato");
            }
            else
            {
                int error = 0;
                if (textBox1.Text != "")
                {
                    for (int a = 0; a < usuario.Profiles.Count; a++)
                    {
                        if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                        {
                            usuario.Profiles[a].NameProfile = textBox1.Text;
                        }
                    }

                }
                if (comboBox1.SelectedItem != null)
                {
                    for (int a = 0; a < usuario.Profiles.Count; a++)
                    {
                        if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                        {
                            usuario.Profiles[a].ProfileType = comboBox1.SelectedItem.ToString();
                        }
                    }
                }
                if (checkedListBox1.CheckedItems.Count > 0)
                {
                    if (checkedListBox1.CheckedItems.Count >= 3)
                    {
                        List<string> nuevalista = new List<string>();
                        // Eliminar todo de las listas
                        
                        for (int a = 0; a < usuario.Profiles.Count; a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                            {
                                usuario.Profiles[a].PleasuresMusic = nuevalista;
                            }
                        }
                        
                        // Agregar a la lista
                        

                        for (int a = 0; a < usuario.Profiles.Count; a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                            {
                                for (int g = 0; g < checkedListBox1.Items.Count; g++)
                                {
                                    if (checkedListBox1.GetItemChecked(g) == true)
                                    {
                                        usuario.Profiles[a].PleasuresMusic.Add(checkedListBox1.Items[g].ToString());

                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar por lo menos 3 gustos musicales");
                        error++;
                    }
                
                }
                if (checkedListBox2.CheckedItems.Count > 0)
                {
                    if (checkedListBox2.CheckedItems.Count >= 3)
                    {
                        List<string> nuevalista2 = new List<string>();
                        // Eliminar todo de las listas
                        for (int a = 0; a < usuario.Profiles.Count; a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                            {
                                usuario.Profiles[a].PleasuresMovies = nuevalista2;

                            }
                        }
                        // Agregar a la lista
                        for (int a = 0; a < usuario.Profiles.Count; a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilCambiar.NameProfile)
                            {
                                for (int g = 0; g < checkedListBox2.Items.Count; g++)
                                {
                                    if (checkedListBox2.GetItemChecked(g) == true)
                                    {
                                        usuario.Profiles[a].PleasuresMovies.Add(checkedListBox2.Items[g].ToString());

                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar por lo menos 3 categorias favoritas de peliculas");
                        error++;
                    }
                }
                if (error == 0)
                {
                    MessageBox.Show("Perfil cambiado");
                    //serializar
                    List<Clases.User> todosUsuarios = new List<Clases.User>();

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
                    if (usuario.Profiles.Count == 1)
                    {
                        label8.Text = usuario.Profiles[0].NameProfile;
                    }
                    else if (usuario.Profiles.Count == 2)
                    {
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label9.Text = usuario.Profiles[1].NameProfile;
                    }
                    else if (usuario.Profiles.Count == 3)
                    {
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label9.Text = usuario.Profiles[1].NameProfile;
                        label10.Text = usuario.Profiles[2].NameProfile;
                    }
                    else if (usuario.Profiles.Count == 4)
                    {
                        label8.Text = usuario.Profiles[0].NameProfile;
                        label9.Text = usuario.Profiles[1].NameProfile;
                        label10.Text = usuario.Profiles[2].NameProfile;
                        label11.Text = usuario.Profiles[3].NameProfile;
                    }
                    panel23.Visible = false;
                    panel6.Visible = false;
                }
                else
                {
                    MessageBox.Show("Datos invalidos");
                }


                
            }
                
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label26.Visible = true;
            textBox1.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label27.Visible = true;
            comboBox1.Visible = true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            checkedListBox2.Visible = true;
        }

        private void verPerfil_Click_1(object sender, EventArgs e)
        {
            panel27.Visible = false;
            mostrarGustos.Clear();
            mostrarCategorias.Clear();
            panel6.Visible = true; 
            panel23.Visible = true;
            panel25.Visible = true;
            mostrarNombre.Text = perfilActual.NameProfile;
            mostrarPrivacidad.Text = perfilActual.ProfileType;
            string Sumastring = "";
            int contador = 1;
            for (int a=0; a<perfilActual.PleasuresMusic.Count;a++)
            {
                Sumastring+= contador+") "+perfilActual.PleasuresMusic[a]+ Environment.NewLine;
                contador++;
            }
            mostrarGustos.Text = Sumastring;

            string Sumastring2 = "";
            int contador2 = 1;
            for (int a = 0; a < perfilActual.PleasuresMovies.Count; a++)
            {
                Sumastring2 += contador2 + ") " + perfilActual.PleasuresMovies[a] + Environment.NewLine;
                contador2++;
            }
            mostrarCategorias.Text = Sumastring2;


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel23.Visible = false;
            panel25.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel26.Visible = true;
                button22.Visible = false;
                button21.Visible = true;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tipoPlaylist = "playlistCancion";
            listBox3.Items.Clear();
            algo = "musica";
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel23.Visible = true;
                panel25.Visible = true;
                panel27.Visible = true;
                
                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {

                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile) 
                    {
                        if (usuario.Profiles[a].PlaylistCanciones.Count()>0) 
                        { 
                             for (int b = 0; b < usuario.Profiles[a].PlaylistCanciones.Count();b++)
                                 {
                                      listBox3.Items.Add(usuario.Profiles[a].PlaylistCanciones[b].Nombre);
                                 }
                        }
                        else
                        {
                            MessageBox.Show("La playlist no contiene canciones");
                        }

                    }

                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //PlaylistVideo
        {
            tipoPlaylist = "playlistVideo";
            algo = "video";
            listBox3.Items.Clear();
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel23.Visible = true;
                panel25.Visible = true;
                panel27.Visible = true;

                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {

                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                    {
                        if (usuario.Profiles[a].PlaylistVideos.Count() > 0)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistVideos.Count(); b++)
                            {
                                listBox3.Items.Add(usuario.Profiles[a].PlaylistVideos[b].Name);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La playlist no contiene canciones");
                        }

                    }
                }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel26.Visible = true;
                button21.Visible = false;
                button22.Visible = true;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }
        //CREAR MUSICA PLAYLIST ----------------------------------------
        private void button21_Click(object sender, EventArgs e) 
        {
            int error = 0;
            string privacidad;
            string nombre = txtNombrePlaylist.Text;
            PlaylistSpotifai listaPlaylistCanciones = new PlaylistSpotifai();
            listaPlaylistCanciones.Nombre = nombre;
            List<SongClass> cancionesPlaylist = new List<SongClass>();
            listaPlaylistCanciones.CancionesPlaylist = cancionesPlaylist;
            for (int a = 0; a < usuario.Profiles.Count(); a++) //Sirve para relacionar el usuairo con el perfil actual.
            {
                if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                {
                    if (txtNombrePlaylist.Text != "" && comboPrivacidad.SelectedItem != null)
                    {
                        if (usuario.Profiles[a].ProfileType == "Privado")
                        {
                            if (comboPrivacidad.SelectedItem.ToString() == "Privado") 
                            { 
                                privacidad = comboPrivacidad.SelectedItem.ToString();
                                listaPlaylistCanciones.Privacidad = privacidad;
                                usuario.Profiles[a].PlaylistCanciones.Add(listaPlaylistCanciones);
                                MessageBox.Show("Playlist creada");
                       
                                txtNombrePlaylist.Text = "";
                                List<Clases.User> todosUsuarios = new List<Clases.User>();

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
                            }
                            else
                            {
                                MessageBox.Show("Su perfil es privado, solo puede tener listas privadas.");
                                error++;
                            }


                        }
                        else
                        {
                            privacidad = comboPrivacidad.SelectedItem.ToString();
                            listaPlaylistCanciones.Privacidad = privacidad;
                            usuario.Profiles[a].PlaylistCanciones.Add(listaPlaylistCanciones);
                            MessageBox.Show("Playlist creada");

                            txtNombrePlaylist.Text = "";
                            List<Clases.User> todosUsuarios = new List<Clases.User>();

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
                        }
                        


                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los datos");
                    }
                }                
            }
        }
            
        //CREAR PLAYLIST VIDEOS:.-----------------------------

        private void button22_Click(object sender, EventArgs e) //CREAR PLAYLIST VIDEO
        {
            int error = 0;
            string privacidad;
            string nombre = txtNombrePlaylist.Text;
            PlaylistVideoEmptyClass listaPlaylistvideos = new PlaylistVideoEmptyClass();
            listaPlaylistvideos.Name = nombre;
            List<Video> videosPlaylist = new List<Video>();
            listaPlaylistvideos.VideosPlaylist = videosPlaylist;
            for (int a = 0; a < usuario.Profiles.Count(); a++) //Sirve para relacionar el usuairo con el perfil actual.
            {
                if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                {
                    if (txtNombrePlaylist.Text != "" && comboPrivacidad.SelectedItem != null)
                    {
                        if (usuario.Profiles[a].ProfileType == "Privado")
                        {

                            if (comboPrivacidad.SelectedItem.ToString() == "Privado")
                            {


                                privacidad = comboPrivacidad.SelectedItem.ToString();
                                listaPlaylistvideos.Privacidad = privacidad;
                                usuario.Profiles[a].PlaylistVideos.Add(listaPlaylistvideos);
                                MessageBox.Show("Playlist creada");

                                txtNombrePlaylist.Text = "";
                                List<Clases.User> todosUsuarios = new List<Clases.User>();

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
                            }

                            else

                            {
                                MessageBox.Show("Su perfil es privado, solo puede tener listas privadas.");
                                error++;
                            }
                        }
                        else
                        {
                            privacidad = comboPrivacidad.SelectedItem.ToString();
                            listaPlaylistvideos.Privacidad = privacidad;
                            usuario.Profiles[a].PlaylistVideos.Add(listaPlaylistvideos);
                            MessageBox.Show("Playlist creada");

                            txtNombrePlaylist.Text = "";
                            List<Clases.User> todosUsuarios = new List<Clases.User>();

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
                        }

                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los datos");
                       
                    }
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox4.Items.Clear();
                //Mostrar la informacion d ela playlist
                if (algo == "musica")
                {
                    int error = 1;
                    if (listBox3.SelectedItem != null)
                    {
                        for (int a = 0; a < usuario.Profiles.Count(); a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistCanciones.Count(); b++)
                                {
                                    error--;
                                    if (listBox3.SelectedItem.ToString() == usuario.Profiles[a].PlaylistCanciones[b].Nombre && usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist.Count() > 0)
                                    {

                                        for (int c = 0; c < usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist.Count(); c++)
                                        {
                                            listBox4.Items.Add(usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist[c]);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                    }
                                }

                            }
                        }
                    }
                    if (error > 0)
                    {
                        listBox4.Items.Add("NO HAY CANCIONES");
                    }
                }
                else if (algo == "video")
                {
                    int error = 1;
                    if (listBox3.SelectedItem != null)
                    {
                        for (int a = 0; a < usuario.Profiles.Count(); a++)
                        {
                            if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistVideos.Count(); b++)
                                {
                                    error--;
                                    if (listBox3.SelectedItem.ToString() == usuario.Profiles[a].PlaylistVideos[b].Name && usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist.Count() > 0)
                                    {

                                        for (int c = 0; c < usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist.Count(); c++)
                                        {
                                            listBox4.Items.Add(usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist[c]);
                                        }
                                    }
                                    else
                                    {
                                        error++;
                                    }
                                }

                            }
                        }
                    }
                    if (error > 0)
                    {
                        listBox4.Items.Add("NO HAY VIDEOS");
                    }
                }

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un item.");
            }

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {

            listBox2.Visible =true;
            if (reproduciendo == "musica")
            {
                listBox2.Items.Clear();

                if (panel26.Visible == true)
                {
                    panel26.Visible = false;
                }
                else
                {

                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {

                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            if (usuario.Profiles[a].PlaylistCanciones.Count() > 0)
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistCanciones.Count(); b++)
                                {
                                    listBox2.Items.Add(usuario.Profiles[a].PlaylistCanciones[b].Nombre);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La playlist no contiene canciones");
                            }

                        }

                    }

                }
            }
            else if (reproduciendo == "video")
            {

                listBox2.Items.Clear();
                if (panel26.Visible == true)
                {
                    panel26.Visible = false;
                }
                else
                {

                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {

                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            if (usuario.Profiles[a].PlaylistVideos.Count() > 0)
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistVideos.Count(); b++)
                                {
                                    listBox2.Items.Add(usuario.Profiles[a].PlaylistVideos[b].Name);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La playlist no contiene canciones");
                            }

                        }
                    }
                }
            }
        }

        private void label38_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e) // AQUI SE SELECCIONA PARA AGREGAR LA CANCIONES A LA PLYALIST
        {//este el panel
            try
            {
                if (reproduciendo == "musica")
                {
                    int error1 = 1;
                    
                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {
                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistCanciones.Count(); b++)
                            {
                                error1--;
                                if (listBox2.SelectedItem != null)
                                {
                                    if (usuario.Profiles[a].PlaylistCanciones[b].Nombre == listBox2.SelectedItem.ToString())
                                    {
                                        usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist.Add(cancionSonando);
                                        List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                                        MessageBox.Show("Cancion Guardada");
                                    }
                                }
                                else
                                {
                                    error1++;
                                }
                            }
                        }
                    }
                    if (error1 > 0)
                    {
                        MessageBox.Show("Debe seleccionar un item");
                    }
                }
                else if (reproduciendo == "video")
                {
                    int error1 = 1;
                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {

                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistVideos.Count(); b++)
                            {
                                error1--;
                                if(listBox2.SelectedItem != null)
                                {
                                    if (usuario.Profiles[a].PlaylistVideos[b].Name == listBox2.SelectedItem.ToString())
                                    {
                                        usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist.Add(videoSonando);
                                        List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                                        MessageBox.Show("Video Guardada");
                                        //Serilizar
                                    }
                                }
                                else
                                {
                                    error1++;
                                }
                                
                            }
                        }
                    }
                    if (error1 > 0)
                    {
                        MessageBox.Show("Debe seleccionar un item");
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un item.");
            }

        }
        private void listBox2_MouseMove(object sender, MouseEventArgs e)
        {
            listBox2.Visible = true;
        }

        private void listBox2_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void listBox2_MouseLeave(object sender, EventArgs e)
        {
            listBox2.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e) //BOTON PARA AGREGAR MUSICA
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (algo == "musica")
                {
                    int error = 1;
                    int error2 = 1;
                    int error4 = 1;
                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {

                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            if(tipoPlaylist == "playlistCancion")
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistCanciones.Count(); b++)
                                {
                                    error2--;
                                    if (listBox3.SelectedItem != null)
                                    {
                                        if (usuario.Profiles[a].PlaylistCanciones[b].Nombre == listBox3.SelectedItem.ToString())
                                        {
                                            for (int c = 0; c < usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist.Count(); c++)
                                            {
                                                error--;
                                                try
                                                {
                                                    if (listBox4.SelectedItem != null)
                                                    {
                                                        string nombre = listBox4.SelectedItem.ToString();
                                                        string[] listaStr = nombre.Split(' '); //BUSCAMOS EL NOMBRE QUE ES UNNICO

                                                        if (usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist[c].Title == listaStr[0])
                                                        {
                                                            Reproductor2.URL = usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist[c].Url;
                                                            txtBarraMusica.Text = usuario.Profiles[a].PlaylistCanciones[b].CancionesPlaylist[c].Title;
                                                        }
                                                    }
                                                    else
                                                    {

                                                        error++;
                                                    }
                                                }
                                                catch (System.NullReferenceException)
                                                {
                                                    MessageBox.Show("Debe seleccionar un item.");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        error2++;
                                    }
                                }
                                if (error > 0 || error2 > 0)
                                {
                                    MessageBox.Show("Debe seleccionar un item.");

                                }
                            }

                            
                            else if ( tipoPlaylist == "playlistCancionFavoritas")
                            {
                                
                         
                                for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasCanciones.Count(); b++)
                                {
                                    error4--;
                                    try
                                    {
                                        if (listBox4.SelectedItem != null)
                                        {

                                            string nombre = listBox4.SelectedItem.ToString();
                                            string[] listaStr = nombre.Split(' '); //BUSCAOS EL NOMBER QUE ES UNNICO

                                            if (usuario.Profiles[a].PlaylistFavoritasCanciones[b].Title == listaStr[0])
                                            {
                                                Reproductor2.URL = usuario.Profiles[a].PlaylistFavoritasCanciones[b].Url;
                                                txtBarraMusica.Text = usuario.Profiles[a].PlaylistFavoritasCanciones[b].Title;
                                            }
                                        }
                                        else
                                        {
                                            error4++;
                                        }
                                    }
                                    catch (System.NullReferenceException)
                                    {
                                        MessageBox.Show("Debe seleccionar un item.");
                                    }
                                }
                                if (error4 > 0)
                                {
                                    MessageBox.Show("Debe seleccionar un item.");
                                }
                            }
                        }
                    }

                }
                else if (algo == "video")
                {
                    int error = 1;
                    int error2 = 1;
                    int error4 = 1;
                    for (int a = 0; a < usuario.Profiles.Count(); a++)
                    {

                        if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                        {
                            if (tipoPlaylist == "playlistVideo")
                            {
                                for (int b = 0; b < usuario.Profiles[a].PlaylistVideos.Count(); b++)
                                {
                                    error2--;
                                    if (listBox3.SelectedItem != null)
                                    {
                                        if (usuario.Profiles[a].PlaylistVideos[b].Name == listBox3.SelectedItem.ToString())
                                        {
                                            for (int c = 0; c < usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist.Count(); c++)
                                            {
                                                error--;
                                                try
                                                {
                                                    if (listBox4.SelectedItem != null)
                                                    {
                                                        string nombre = listBox4.SelectedItem.ToString();
                                                        string[] listaStr = nombre.Split(' '); //BUSCAMOS EL NOMBRE QUE ES UNNICO

                                                        if (usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist[c].Title == listaStr[0])
                                                        {
                                                            Reproductor2.URL = usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist[c].Url;
                                                            txtBarraMusica.Text = usuario.Profiles[a].PlaylistVideos[b].VideosPlaylist[c].Title;
                                                        }
                                                    }
                                                    else
                                                    {

                                                        error++;
                                                    }
                                                }
                                                catch (System.NullReferenceException)
                                                {
                                                    MessageBox.Show("Debe seleccionar un item.");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        error2++;
                                    }
                                }
                                if (error > 0 || error2 > 0)
                                {
                                    MessageBox.Show("Debe seleccionar un item.");
                                }
                            }


                            else if (tipoPlaylist == "playlistVideoFavoritas")
                            {


                                for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasVideos.Count(); b++)
                                {
                                    error4--;
                                    try
                                    {
                                        if (listBox4.SelectedItem != null)
                                        {

                                            string nombre = listBox4.SelectedItem.ToString();
                                            string[] listaStr = nombre.Split(' '); //BUSCAOS EL NOMBER QUE ES UNNICO

                                            if (usuario.Profiles[a].PlaylistFavoritasVideos[b].Title == listaStr[0])
                                            {
                                                Reproductor2.URL = usuario.Profiles[a].PlaylistFavoritasVideos[b].Url;
                                                txtBarraMusica.Text = usuario.Profiles[a].PlaylistFavoritasVideos[b].Title;
                                            }
                                        }
                                        else
                                        {
                                            error4++;
                                        }
                                    }
                                    catch (System.NullReferenceException)
                                    {
                                        MessageBox.Show("Debe seleccionar un item.");
                                    }
                                }
                                if (error4 > 0)
                                {
                                    MessageBox.Show("Debe seleccionar un item.");
                                }
                            }
                        }
                    }
                }

            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un item.");
            }
        }

        private void btncambiarp_Click(object sender, EventArgs e)
        {
            contraseña = txt3.Text;

            //MessageBox.Show("Disculpa ,estamos presentando dificultades por el momento , intenta en otra entrega :(");
            //MessageBox.Show("Disculpa ,estamos presentando dificultades por el momento , intenta en otra entrega :(");

            List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            if (txt3.Text == "")
            {
                MessageBox.Show("POR FAVOR INGRESE LA CONTRAEÑA");
            }

            else if (deserializarUser.Count > 0)//aca hay que poner que se verifique el inicio de secion
            {
                int error = 1;
                int avanzar = 0;
                int error2 = 1;
                Clases.User us = new Clases.User();
                for (int d = 0; d < deserializarUser.Count; d++)
                {
                    error--;
                    if (deserializarUser[d].Password == txt3.Text)
                    {

                        us = deserializarUser[d];//guardo la informacion del usuario en US
                        avanzar += 1;
                    }
                    else
                    {
                        error++;
                    }

                }
                if (error > 0)
                {
                    MessageBox.Show("contraseña invalida");
                }
                if (radioButton1.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
                {
                    MessageBox.Show("Por favor seleccione alguna de las alternativas");
                }
                if (us.Plan == "Basico" && radioButton1.Checked == true)
                {
                    MessageBox.Show("No puede cambiarse a un plan en el cual se encuentra actualmente");
                    error2 += 1;


                }
                if (us.Plan == "Premium" && radioButton4.Checked == true)
                {
                    MessageBox.Show("No puede cambiarse a un plan en el cual se encuentra actualmente");
                    error2 += 1;

                }
                if (us.Plan == "Familiar" && radioButton5.Checked == true)
                {
                    MessageBox.Show("No puede cambiarse a un plan en el cual se encuentra actualmente");
                    error2 += 1;

                }



                if (avanzar > 0)
                {
                    int error3 = 1;

                    for (int d = 0; d < deserializarUser.Count; d++)
                    {
                        error3--;
                        if (deserializarUser[d].Password == txt3.Text)
                        {

                            if (radioButton1.Checked == true)
                            {
                                deserializarUser[d].Plan = "Basico";
                               
                                
                               
                            }
                            if (radioButton4.Checked == true)
                            {
                                deserializarUser[d].Plan = "Premium";
                               
                                
                            }



                            if (radioButton5.Checked == true)
                            {
                                deserializarUser[d].Plan = "Familiar";
                                
                                
                            }

                        }
                        else
                        {
                            error3++;

                        }

                    }
                    if (error3 <=1)
                    {
                        if (radioButton1.Checked == true)
                        {
                            panel31.Visible = false;
                            MessageBox.Show("Plan cambiado con exito ");
                            this.Hide();
                            FormAplicacion formAplicacion = new FormAplicacion(us);
                            formAplicacion.Show();
                        }
                        else
                        {
                            panel31.Visible = true;
                        }
                       
                       
                    }
                    serializar.Serialize(deserializarUser, File.Open("data.bin", FileMode.Create));

                    //solo falta agregar la nueva contraseña al usuario


                }


            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Reproductor2.Ctlcontrols.fastReverse();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Reproductor2.Ctlcontrols.stop();
            this.Hide();
            Form1 form = new Form1();
            form.Show();

            //FormAplicacion formAplicacion = new FormAplicacion(us);
            //formAplicacion.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel30.Visible = true;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            panel30.Visible = false;
        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVolverTarjeta_Click(object sender, EventArgs e)
        {
            panel31.Visible = false;
        }

        private void btnContinuarTarjeta_Click(object sender, EventArgs e)
        {
            List<Clases.User> deserializarUser = serializar.Deserialize<List<Clases.User>>(File.Open("data.bin", FileMode.Open));
            if (txt3.Text == "")
            {
                MessageBox.Show("POR FAVOR INGRESE LA CONTRAEÑA");
            }

            else if (deserializarUser.Count > 0)//aca hay que poner que se verifique el inicio de secion
            {
                int error = 1;
                int avanzar = 0;
                int error2 = 1;
                Clases.User us = new Clases.User();
                for (int d = 0; d < deserializarUser.Count; d++)
                {
                    error--;
                    if (deserializarUser[d].Password == contraseña)
                    {

                        us = deserializarUser[d];//guardo la informacion del usuario en US
                        avanzar += 1;
                    }
                    else
                    {
                        error++;
                    }

                }
           
                if (txtNumeroTarjeta.Text !="" && comboBox2.SelectedItem!=null && comboBox3 != null && txtCodigoSeguridadTarjeta.Text!="")
            {
                MessageBox.Show("Plan cambiado con exito");
                this.Hide();
                FormAplicacion formAplicacion = new FormAplicacion(us);
                formAplicacion.Show();
            }
            else
            {
                MessageBox.Show("Por favor rellene todos los datos");
            }
        }
    }

        private void button6_Click(object sender, EventArgs e) //PlaylistFavoritosVideos
        {
            tipoPlaylist = "playlistVideoFavoritas";
            algo = "video";
            listBox3.Items.Clear();
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel23.Visible = true;
                panel25.Visible = true;
                panel27.Visible = true;

                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {

                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                    {
                        if (usuario.Profiles[a].PlaylistFavoritasVideos.Count() > 0)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasVideos.Count(); b++)
                            {
                                foreach (Video x in usuario.Profiles[a].PlaylistFavoritasVideos)
                                {
                                    listBox4.Items.Add(x);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La playlist no contiene canciones");
                        }

                    }

                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e) //PlaylistFavoritaCancion
        {
            tipoPlaylist = "playlistCancionFavoritas";
            listBox3.Items.Clear();
            algo = "musica";
            if (panel26.Visible == true)
            {
                panel26.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel23.Visible = true;
                panel25.Visible = true;
                panel27.Visible = true;

                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {

                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                    {
                        if (usuario.Profiles[a].PlaylistFavoritasCanciones.Count() > 0)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasCanciones.Count(); b++)
                            {
                                foreach(SongClass x in usuario.Profiles[a].PlaylistFavoritasCanciones)
                                {
                                    listBox4.Items.Add(x);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La playlist no contiene canciones");
                        }

                    }

                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e) //Playlist favoritos.BOTON CORAZON
        {
            if (reproduciendo == "musica")
            {
                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {
                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                    {
                        if(usuario.Profiles[a].PlaylistFavoritasCanciones.Count() > 0)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasCanciones.Count(); b++)
                            {
                                if (usuario.Profiles[a].PlaylistFavoritasCanciones[b].Title == cancionSonando.Title)
                                {
                                    MessageBox.Show("La cancion ya ha sido agregada previamente.");
                                }
                                else
                                {
                                    usuario.Profiles[a].PlaylistFavoritasCanciones.Add(cancionSonando);
                                    List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                                    MessageBox.Show("Cancion Guardada");
                                }
                            }
                        }
                        else
                        {
                            usuario.Profiles[a].PlaylistFavoritasCanciones.Add(cancionSonando);
                            List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                            MessageBox.Show("Cancion Guardada");
                        }
                    }
                }
            }
            else if (reproduciendo == "video")
            {
                for (int a = 0; a < usuario.Profiles.Count(); a++)
                {
                    if (usuario.Profiles[a].NameProfile == perfilActual.NameProfile)
                    {
                        if (usuario.Profiles[a].PlaylistFavoritasVideos.Count() > 0)
                        {
                            for (int b = 0; b < usuario.Profiles[a].PlaylistFavoritasVideos.Count(); b++)
                            {
                                if (usuario.Profiles[a].PlaylistFavoritasVideos[b].Title == videoSonando.Title)
                                {
                                    MessageBox.Show("El video ya ha sido agregado previamente.");
                                }
                                else
                                {
                                    usuario.Profiles[a].PlaylistFavoritasVideos.Add(videoSonando);
                                    List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                                    MessageBox.Show("Video Guardado");
                                }
                            }
                        }
                        else
                        {
                            usuario.Profiles[a].PlaylistFavoritasVideos.Add(videoSonando);
                            List<Clases.User> todosUsuarios = new List<Clases.User>();
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
                            MessageBox.Show("Video Guardado");
                        }
                    }
                }
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e) //Agregar a cola. Boton.
        {

            //Debemos agregar las canciones.
            if(reproduciendo == "musica")
            {
                cola.Enqueue(cancionSonando.Url);
            }
            else if( reproduciendo == "video")
            {
                cola.Enqueue(videoSonando.Url);
            }
        }

        private void VerCola_Click(object sender, EventArgs e) //Ver las canciones en la cola.
        {
            if (cola1.Count()>0)
            {
                for (int a = 0; a < cola1.Count(); a++)
                {
                    listBox7.Items.Add(cola1[a]);
                }
            }
            else
            {
                listBox7.Items.Add("no hay elementos");
            }
            listBox7.Visible = true;
           
            
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            List<SongClass> songAux0 = new List<SongClass>();
            try
            {
                songAux0 = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
            }
            catch (System.Runtime.Serialization.SerializationException)
            {

            }
            List<Video> videoAux0 = new List<Video>();
            try
            {
                videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
            }
            catch (System.Runtime.Serialization.SerializationException)
            {

            }

            try
            {
                if (listCanciones.SelectedItem != null)
                {
                    string answer = listCanciones.SelectedItem.ToString();
                    string[] listaStr = answer.Split(' ');
                    foreach (SongClass x in songAux0)
                    {
                        if (x.Title == listaStr[0])
                        {
                            cancionSonando = x;
                            reproduciendo = "musica";
                            Reproductor2.URL = x.Url;
                            txtBarraMusica.Text = x.Title + " autor;" + x.Singer.Name;
                            btnPausa.Visible = true;
                            btnPlay.Visible = false;
                            panel6.Visible = true;
                            numlikes = x.Likes;
                            NumLike.Text = numlikes.ToString();
                            NumLike.Visible = true;

                            numreproducciones = x.NReproduction;
                            numreproducciones += 1; //REPRODUCCIONES
                            x.NReproduction = numreproducciones;

                            NumReproducciones.Text = numreproducciones.ToString();
                            if (x.ProfileLikes.Count() > 0)
                            {
                                if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                {
                                    manito.Visible = false;
                                }
                                else
                                {
                                    manito.Visible = true;
                                }
                            }
                            else
                            {
                                manito.Visible = true;
                            }

                            e6.Visible = true;
                            e7.Visible = true;
                            e8.Visible = true;
                            e9.Visible = true;
                            e10.Visible = true;
                            panel27.Visible = false;
                            panel25.Visible = false;
                            panel23.Visible = false;
                        }
                    }
                    serializar.Serialize(songAux0, File.Open("Canciones.bin", FileMode.Create));
                    foreach (Video x in videoAux0)
                    {
                        if (x.Title == listaStr[0])
                        {
                            string comprado = "";
                            if (x.Title=="mulan" || x.Title == "joker" || x.Title == "avengers")
                            {
                                List<User> deserializarUser = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
                                for (int h=0;h<deserializarUser.Count;h++)
                                {
                                    if (deserializarUser[h].NameUser==usuario.NameUser)
                                    {
                                        for (int t = 0; t < deserializarUser[h].VideosComprados.Count; t++)
                                        {
                                            if (deserializarUser[h].VideosComprados[t].Title== x.Title)
                                            {
                                                comprado = "si";
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (comprado=="si")
                                {
                                    videoSonando = x;
                                    reproduciendo = "video";//Esto sirve para agregar en las playlists.
                                    Reproductor2.URL = x.Url;
                                    panel6.Visible = true;
                                    txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                    btnPausa.Visible = true;
                                    btnPlay.Visible = false;
                                    numlikes = x.Likes;
                                    NumLike.Text = numlikes.ToString();
                                    NumLike.Visible = true;

                                    numreproducciones = x.NReproduction;
                                    numreproducciones += 1; //REPRODUCCIONES
                                    x.NReproduction = numreproducciones;

                                    NumReproducciones.Text = numreproducciones.ToString();

                                    if (x.ProfileLikes.Count() > 0)
                                    {
                                        if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                        {
                                            manito.Visible = false;
                                        }
                                        else
                                        {
                                            manito.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }


                                    e6.Visible = true;
                                    e7.Visible = true;
                                    e8.Visible = true;
                                    e9.Visible = true;
                                    e10.Visible = true;
                                    panel27.Visible = false;
                                    panel25.Visible = false;
                                    panel23.Visible = false;
                                    break;
                                    //MATI AQUI TIENE SE TIENE QUE ABRIR UN PANEL jajja buena
                                }
                                else
                                {
                                    MessageBox.Show("Debe comprar la pelicula para poder verla");
                                    break;
                                }
                            }
                            else
                            {
                                videoSonando = x;
                                reproduciendo = "video";//Esto sirve para agregar en las playlists.
                                Reproductor2.URL = x.Url;
                                panel6.Visible = true;
                                txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                btnPausa.Visible = true;
                                btnPlay.Visible = false;
                                numlikes = x.Likes;
                                NumLike.Text = numlikes.ToString();
                                NumLike.Visible = true;

                                numreproducciones = x.NReproduction;
                                numreproducciones += 1; //REPRODUCCIONES
                                x.NReproduction = numreproducciones;

                                NumReproducciones.Text = numreproducciones.ToString();

                                if (x.ProfileLikes.Count() > 0)
                                {
                                    if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                    {
                                        manito.Visible = false;
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }
                                }
                                else
                                {
                                    manito.Visible = true;
                                }


                                e6.Visible = true;
                                e7.Visible = true;
                                e8.Visible = true;
                                e9.Visible = true;
                                e10.Visible = true;
                                panel27.Visible = false;
                                panel25.Visible = false;
                                panel23.Visible = false;
                                break;
                                //MATI AQUI TIENE SE TIENE QUE ABRIR UN PANEL jajja buena
                            }
                        }
                    }
                    serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un item ");
                }

            }

            catch (System.NullReferenceException)
            {
                MessageBox.Show("Debe seleccionar un item.");
            }
        }

        private void btnAgregarCola_Click(object sender, EventArgs e)
        {
            if (cosaElegida == "video")
            {
                string comprado = "";
                if (videoElegida.Title == "mulan" || videoElegida.Title == "joker" || videoElegida.Title == "avengers")
                {
                    List<User> deserializarUser = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
                    for (int h = 0; h < deserializarUser.Count; h++)
                    {
                        if (deserializarUser[h].NameUser == usuario.NameUser)
                        {
                            for (int t = 0; t < deserializarUser[h].VideosComprados.Count; t++)
                            {
                                if (deserializarUser[h].VideosComprados[t].Title == videoElegida.Title)
                                {
                                    comprado = "si";
                                    break;
                                }
                            }
                        }
                    }
                    if (comprado == "si")
                    {
                        cola1.Add(videoElegida.Url);
                        MessageBox.Show("Video agreado a la cola");

                    }
                    else
                    {
                        MessageBox.Show("Para agregar a la cola, debe comprar el video");

                    }
                }
                else
                {
                    cola1.Add(videoElegida.Url);
                    MessageBox.Show("Video agreado a la cola");
                }
            }
            else
            {
                cola1.Add(cancionElegida.Url);
                MessageBox.Show("Cancion agreada a la cola");
            }
            ReproducirCola();

        }

        private void pic11_Click(object sender, EventArgs e)//imagen mulan
        {
            videoClick = "mulan";
            //nose pq pusiste esto aca jajaa saludos xdxd
            //ver videos del usuario 
            int errores = 1;
            List<User> usuarios = new List<User>();
            usuarios = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            for(int a=0; a < usuarios.Count; a++)
            {
                if (usuarios[a].NameUser == usuario.NameUser)
                {
                   
                    for (int b = 0; b< usuarios[a].VideosComprados.Count(); b++)
                    {
                        errores--;
                        if (usuarios[a].VideosComprados[b].Title== "mulan")
                        {
                            //aca poner para que se abra el panel del reproductor
                            panel6.Visible = true;
                            List<Video> videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                            foreach (Video x in videoAux0)
                            {
                                if (x.Title == "mulan")
                                {
                                    videoSonando = x;
                                    reproduciendo = "video";//Esto sirve para agregar en las playlists.

                                    panel6.Visible = true;
                                    txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                    btnPausa.Visible = true;
                                    btnPlay.Visible = false;
                                    numlikes = x.Likes;
                                    NumLike.Text = numlikes.ToString();
                                    NumLike.Visible = true;

                                    numreproducciones = x.NReproduction;
                                    numreproducciones += 1; //REPRODUCCIONES
                                    x.NReproduction = numreproducciones;

                                    NumReproducciones.Text = numreproducciones.ToString();

                                    if (x.ProfileLikes.Count() > 0)
                                    {
                                        if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                        {
                                            manito.Visible = false;
                                        }
                                        else
                                        {
                                            manito.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }


                                    e6.Visible = true;
                                    e7.Visible = true;
                                    e8.Visible = true;
                                    e9.Visible = true;
                                    e10.Visible = true;
                                    panel27.Visible = false;
                                    panel25.Visible = false;
                                    panel23.Visible = false;
                                    //MATI AQUI TIENE SE TIENE QUE ABRIR UN PANEL jajja buena
                                }
                            }
                            string ruta = Path.Combine(Application.StartupPath, "mulan.mp4");
                            Reproductor2.URL = ruta;
                            serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                            break;
                            
                        }
                        else
                        {
                            errores++;
                        }

                    }
                    break;
                }
            }
            if (errores > 0)
            {
                if (panel18.Visible == true)
                {
                    panel34.Visible = false;
                    panel15.Visible = false;
                    panel18.Visible = false;//boton cupones
                }
                else
                {
                    panel18.Visible = true;
                    panel34.Visible = false;
                    panel15.Visible = false;
                }
            }
        }
        private void pic10_Click(object sender, EventArgs e)//imagen joker
        {
            videoClick = "joker";
            int errores = 1;
            List<User> usuarios = new List<User>();
            usuarios = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count; a++)
            {
                if (usuarios[a].NameUser == usuario.NameUser)
                {

                    for (int b = 0; b < usuarios[a].VideosComprados.Count(); b++)
                    {
                        errores--;
                        if (usuarios[a].VideosComprados[b].Title == "joker")
                        {
                            panel6.Visible = true;
                            List<Video> videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                            foreach (Video x in videoAux0)
                            {
                                if (x.Title == "joker")
                                {
                                    videoSonando = x;
                                    reproduciendo = "video";//Esto sirve para agregar en las playlists.
                                    panel6.Visible = true;
                                    txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                    btnPausa.Visible = true;
                                    btnPlay.Visible = false;
                                    numlikes = x.Likes;
                                    NumLike.Text = numlikes.ToString();
                                    NumLike.Visible = true;

                                    numreproducciones = x.NReproduction;
                                    numreproducciones += 1; //REPRODUCCIONES
                                    x.NReproduction = numreproducciones;

                                    NumReproducciones.Text = numreproducciones.ToString();

                                    if (x.ProfileLikes.Count() > 0)
                                    {
                                        if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                        {
                                            manito.Visible = false;
                                        }
                                        else
                                        {
                                            manito.Visible = true;
                                        }
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }


                                    e6.Visible = true;
                                    e7.Visible = true;
                                    e8.Visible = true;
                                    e9.Visible = true;
                                    e10.Visible = true;
                                    panel27.Visible = false;
                                    panel25.Visible = false;
                                    panel23.Visible = false;
                                    //MATI AQUI TIENE SE TIENE QUE ABRIR UN PANEL jajja buena
                                }
                            }
                            string ruta23 = Path.Combine(Application.StartupPath, "joker.mp4");
                            Reproductor2.URL = ruta23;
                            serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                            break;
                            //aca poner para que se abra el panel del reproductor
                        }
                        else
                        {
                            errores++;
                        }
                    }
                    break;
                }
            }
            if (errores > 0)
            {
                if (panel15.Visible == true)
                {
                    panel34.Visible = false;
                    panel15.Visible = false;
                    panel18.Visible = false;

                }
                else
                {
                    panel15.Visible = true;
                    panel18.Visible = false;
                    panel34.Visible = false;
                }
            }
            
        }

        private void btncupon1_Click(object sender, EventArgs e)
        {
            panel38.Visible = false;
            panel37.Visible = true;
        }


        //btncupon2 no se cambio nombre
        
        //btncupon2 no se cambio nombre
        //btncupon2 no se cambio nombre
        private void button12_Click(object sender, EventArgs e)

        //btncupon2 no se cambio nombre
        {
            panel38.Visible = false;
            panel37.Visible = true;
        }

        private void btncomprar1_Click(object sender, EventArgs e)
        {

            panel37.Visible = true;
            panel38.Visible = true;
        }

        private void btncupon3_Click(object sender, EventArgs e)//cupones mulan
        {
            panel38.Visible = false;
            panel37.Visible = true;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panel37.Visible = true;
            panel38.Visible = true;
            //btncomprar2 no se cambio nombre
        }

        private void btncomprar3_Click(object sender, EventArgs e)
        {
            panel37.Visible = true;
            panel38.Visible = true;
            //comprar
        }

        private void button9_Click(object sender, EventArgs e)//Confirmar cupon
        {
            
            List<string> todosCupones = serializar.Deserialize<List<string>>(File.Open("cupones.bin", FileMode.Open));
            List<User> deserializarUser = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            List<Video> deserializarVideo = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
            Video videoComprado = new Video();
            List<string> todosCuponesUsados = new List<string>();


            todosCuponesUsados =serializar.Deserialize<List<string>>(File.Open("cuponesUsados.bin", FileMode.Open));
   
            for (int t = 0; t < deserializarVideo.Count(); t++)
            {
                if (deserializarVideo[t].Title == videoClick)
                {
                    videoComprado = deserializarVideo[t];
                }

            }
            int errores = 1;
            if (textBox2.Text!="")
            {
                for (int a = 0; a < todosCupones.Count(); a++)
                {
                    errores--;
                    if (todosCupones[a] == textBox2.Text && todosCuponesUsados.Contains(todosCupones[a])==false)
                    {
                        MessageBox.Show("Su cupon ha sido utilizado con exito");
                        
                        todosCuponesUsados.Add(todosCupones[a]);
                        for (int c = 0; c < deserializarUser.Count(); c++)
                        {
                            if (deserializarUser[c].NameUser == usuario.NameUser)
                            {
                                deserializarUser[c].VideosComprados.Add(videoComprado);
                                serializar.Serialize(deserializarUser, File.Open("data.bin", FileMode.Create));
                            }

                        }
                        
                        serializar.Serialize(todosCuponesUsados, File.Open("cuponesUsados.bin", FileMode.Create));
                        panel34.Visible = false;
                        panel18.Visible = false;
                        panel15.Visible = false;
                        break;
                    }
                    else if (todosCupones[a] == textBox2.Text && todosCuponesUsados.Contains(todosCupones[a]) == true)
                    {
                        MessageBox.Show("Ups! su cupón ya ha sido utlizado antes");
                        break;
                    }
                    else if (todosCupones[a] != textBox2.Text)
                    {
                        errores++;
                    }
                }
                if (errores>0)
                {
                    MessageBox.Show("Ups! este cupón no existe");
                }
            }
            else
            {
                MessageBox.Show("Porfavor ingrese un codigo");
            }
            textBox2.Clear();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //continuar tarjta comprar estreno
            panel37.Visible = false;
            
            List<User> deserializarUser = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            List<Video> deserializarVideo = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
            Video videoComprado = new Video();
            for (int t = 0; t < deserializarVideo.Count(); t++)
            {
                if (deserializarVideo[t].Title == videoClick)
                {
                    videoComprado = deserializarVideo[t];
                }

            }
            int error2 = 0;
            if (textBox3.Text == "" || textBox4.Text == "" || comboBox5.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Rellene todos los datos");
            }
            else
            { 
                int cvv = 0;
                
                List<int> numeros = new List<int>();
                for (int a = 0; a < 10; a++)
                {
                    numeros.Add(a);
                }

                if (textBox4.Text != "")
                {
                    for (int b = 0; b < textBox4.Text.Length; b++)
                    {
                        if (numeros.Contains((int)Char.GetNumericValue(textBox4.Text[b])) == true)
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

                    cvv += Int32.Parse(textBox3.Text);
                }
                catch (FormatException)
                {

                    error2 ++;
                }
                if (error2 == 0)
                {
                    for (int c = 0; c < deserializarUser.Count(); c++)
                    {
                        if (deserializarUser[c].NameUser == usuario.NameUser)
                        {
                            MessageBox.Show("Su estreno ha sido comprado!");
                            deserializarUser[c].VideosComprados.Add(videoComprado);
                            serializar.Serialize(deserializarUser, File.Open("data.bin", FileMode.Create));
                            panel34.Visible = false;
                            panel18.Visible = false;
                            panel15.Visible = false;
                            break;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Error, ingrese nuevamente su forma de pago");
                }

            }
            textBox3.Clear(); 
            textBox4.Clear();
            comboBox4.SelectedItem = null; 
            comboBox5.SelectedItem = null;


        }

        private void label43_Click(object sender, EventArgs e)
        {

        }
        //BOTONES DE BUSQUEDA
        private void btnSeeAll_Click(object sender, EventArgs e)
        {
            
            listCanciones.Visible = true;
            listCanciones.Items.Clear();
            foreach (SongClass x in canciones)
            {
                listCanciones.Items.Add(x);
            }
            foreach (Video x in videos)
            {
                listCanciones.Items.Add(x);
            }
        }

        private void btnKeyword_Click(object sender, EventArgs e)
        {
            listCanciones.Visible = true;
            listCanciones.Items.Clear();
            foreach (SongClass x in canciones)
            {
                listCanciones.Items.Add("Keyword, titulo: " + x.Keyword + ", " + x.Title);
            }
            foreach (Video x in videos)
            {
                listCanciones.Items.Add("Keyword, titulo: " + x.Keyword + ", " + x.Title);
            }
        }

        private void btnGender_Click(object sender, EventArgs e)
        {
            
            listCanciones.Visible = true;
            listCanciones.Items.Clear();
            foreach (SongClass x in canciones)
            {
                listCanciones.Items.Add("Categoria, titulo: " + x.Gender + ", " + x.Title);
            }
            foreach (Video x in videos)
            {
                listCanciones.Items.Add("Categoria, titulo: " + x.Gender + ", " + x.Title);
            }
        }
        //HASTA ACA.

        private void ReproducirCola()
        {

            if (Reproductor2.Ctlcontrols.currentPosition == 0)
            {
                if (cola1.Count > 0)
                {

                    Reproductor2.URL = cola1[0];


                    List<SongClass> songAux0 = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
                    if (cola1.Count() > 0)
                    {
                        foreach (SongClass x in songAux0)
                        {
                            if (x.Url == cola1[0])
                            {
      
                                cancionSonando = x;
                                reproduciendo = "musica";
                                txtBarraMusica.Text = x.Title + " autor;" + x.Singer.Name;
                                btnPausa.Visible = true;
                                btnPlay.Visible = false;
                                panel6.Visible = true;
                                numlikes = x.Likes;
                                NumLike.Text = numlikes.ToString();
                                NumLike.Visible = true;

                                numreproducciones = x.NReproduction;
                                numreproducciones += 1; //REPRODUCCIONES
                                x.NReproduction = numreproducciones;

                                NumReproducciones.Text = numreproducciones.ToString();
                                if (x.ProfileLikes.Count() > 0)
                                {
                                    if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                    {
                                        manito.Visible = false;
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }
                                }
                                else
                                {
                                    manito.Visible = true;
                                }

                                e6.Visible = true;
                                e7.Visible = true;
                                e8.Visible = true;
                                e9.Visible = true;
                                e10.Visible = true;
                                panel27.Visible = false;
                                panel25.Visible = false;
                                panel23.Visible = false;
                            }
                        }
                        serializar.Serialize(songAux0, File.Open("Canciones.bin", FileMode.Create));
                        List<Video> videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                        foreach (Video x in videoAux0)
                        {

                            if (x.Url == cola1[0])
                            {

                                videoSonando = x;
                                reproduciendo = "video";//Esto sirve para agregar en las playlists.

                                panel6.Visible = true;
                                txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                                btnPausa.Visible = true;
                                btnPlay.Visible = false;
                                numlikes = x.Likes;
                                NumLike.Text = numlikes.ToString();
                                NumLike.Visible = true;

                                numreproducciones = x.NReproduction;
                                numreproducciones += 1; //REPRODUCCIONES
                                x.NReproduction = numreproducciones;

                                NumReproducciones.Text = numreproducciones.ToString();

                                if (x.ProfileLikes.Count() > 0)
                                {
                                    if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                    {
                                        manito.Visible = false;
                                    }
                                    else
                                    {
                                        manito.Visible = true;
                                    }
                                }
                                else
                                {
                                    manito.Visible = true;
                                }
                                e6.Visible = true;
                                e7.Visible = true;
                                e8.Visible = true;
                                e9.Visible = true;
                                e10.Visible = true;
                                panel27.Visible = false;
                                panel25.Visible = false;
                                panel23.Visible = false;
                                break;
                                //MATI AQUI TIENE SE TIENE QUE ABRIR UN PANEL jajja buena
                            }
                        }
                        serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                    }
                    cola1.RemoveAt(0);
                }
            }
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                string nueva = cola1[0];
                Reproductor2.URL = nueva;
                List<SongClass> songAux0 = serializar.Deserialize<List<SongClass>>(File.Open("Canciones.bin", FileMode.Open));
                if (cola1.Count() > 0)
                {
                    foreach (SongClass x in songAux0)
                    {
                        if (x.Url == cola1[0])
                        {
                            cancionSonando = x;
                            reproduciendo = "musica";
                            txtBarraMusica.Text = x.Title + " autor;" + x.Singer.Name;
                            btnPausa.Visible = true;
                            btnPlay.Visible = false;
                            panel6.Visible = true;
                            numlikes = x.Likes;
                            NumLike.Text = numlikes.ToString();
                            NumLike.Visible = true;

                            numreproducciones = x.NReproduction;
                            numreproducciones += 1; //REPRODUCCIONES
                            x.NReproduction = numreproducciones;

                            NumReproducciones.Text = numreproducciones.ToString();
                            if (x.ProfileLikes.Count() > 0)
                            {
                                if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                {
                                    manito.Visible = false;
                                }
                                else
                                {
                                    manito.Visible = true;
                                }
                            }
                            else
                            {
                                manito.Visible = true;
                            }
                            e6.Visible = true;
                            e7.Visible = true;
                            e8.Visible = true;
                            e9.Visible = true;
                            e10.Visible = true;
                            panel27.Visible = false;
                            panel25.Visible = false;
                            panel23.Visible = false;
                        }
                    }
                    serializar.Serialize(songAux0, File.Open("Canciones.bin", FileMode.Create));
                    List<Video> videoAux0 = serializar.Deserialize<List<Video>>(File.Open("Videos.bin", FileMode.Open));
                    foreach (Video x in videoAux0)
                    {

                        if (x.Url == cola1[0])
                        {

                            videoSonando = x;
                            reproduciendo = "video";//Esto sirve para agregar en las playlists.

                            panel6.Visible = true;
                            txtBarraMusica.Text = x.Title + " Director;" + x.Director.Name;
                            btnPausa.Visible = true;
                            btnPlay.Visible = false;
                            numlikes = x.Likes;
                            NumLike.Text = numlikes.ToString();
                            NumLike.Visible = true;

                            numreproducciones = x.NReproduction;
                            numreproducciones += 1; //REPRODUCCIONES
                            x.NReproduction = numreproducciones;

                            NumReproducciones.Text = numreproducciones.ToString();

                            if (x.ProfileLikes.Count() > 0)
                            {
                                if (true == x.ProfileLikes.Contains(perfilActual.NameProfile))
                                {
                                    manito.Visible = false;
                                }
                                else
                                {
                                    manito.Visible = true;
                                }
                            }
                            else
                            {
                                manito.Visible = true;
                            }
                            e6.Visible = true;
                            e7.Visible = true;
                            e8.Visible = true;
                            e9.Visible = true;
                            e10.Visible = true;
                            panel27.Visible = false;
                            panel25.Visible = false;
                            panel23.Visible = false;
                            break;

                        }
                    }
                    serializar.Serialize(videoAux0, File.Open("Videos.bin", FileMode.Create));
                }
                cola1.RemoveAt(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Cola vacia");
            }
        }
        //Seguiento de perfiles, albumes etc.
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string answer = txtBuscarSeguir.Text;
            var perfilesasd = from s in listaPerfiles
                              where s.NameProfile.ToUpper() == answer.ToUpper()
                              select s;

            foreach (Profile j in perfilesasd)
            {
                listBox5.Items.Add(j);
            }
        }

        private void txtBuscarSeguir_TextChanged(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
           
            List<User> usuarios = new List<User>();
            usuarios = serializar.Deserialize<List<User>>(File.Open("data.bin", FileMode.Open));
            for (int a = 0; a < usuarios.Count; a++)
            {


                for (int b = 0; b < usuarios[a].Profiles.Count(); b++)
                {
                    listaPerfiles.Add(usuarios[a].Profiles[b]);
                }
            }
            foreach (Profile j in listaPerfiles)
            {
                listBox5.Items.Add(j);
            }
        }

        private void listBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            playlistCancionesPerfil = new List<PlaylistSpotifai>();
            listBox6.Items.Clear();
            int error = 1;
            //Perfiles, Playlist.
            //Hacer if para que se diferencie 
            foreach (Profile x in listaPerfiles)
            {
                string algo = listBox5.SelectedItem.ToString();
                string[] listaString1 = algo.Split(' ');
                if (listaString1[0] == x.NameProfile)
                {
                    error--;
                    if (x.PlaylistCanciones.Count > 0)
                    {
                        for (int a = 0; a < x.PlaylistCanciones.Count(); a++)
                        {
                            listBox6.Items.Add(x.PlaylistCanciones[a]);
                            playlistCancionesPerfil.Add(x.PlaylistCanciones[a]);
                        }
                    }
                    else
                    {
                        error++;
                    }
                }
            }
            if (error > 0)
            {
                listBox6.Items.Add("Este perfil no contiene playlist de canciones");
            }
        }

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < usuario.Profiles.Count(); a++)
            {
                if (perfilActual == usuario.Profiles[a])
                {
                    usuario.Profiles[a].PlaylistCancionSeguidas.Add(playlistElegidaCancion);
                }
            }
            for (int a = 0; a < usuario.Profiles.Count(); a++)
            {
                if (perfilActual == usuario.Profiles[a])
                {
                    usuario.Profiles[a].Seguidos.Add(perfilesSeguidos);
                    MessageBox.Show("Has empezado a seguir esta playlist junto con el perfil");
                }
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e) //unavez que seleccione la playlist la empizo a seguir
        {
            for (int a = 0; a < playlistCancionesPerfil.Count(); a++)
            {
                string[] algo = listBox6.SelectedItem.ToString().Split(' ');
                if (playlistCancionesPerfil[a].Nombre == algo[0])
                {
                    playlistElegidaCancion = playlistCancionesPerfil[a];
                    
                }
            }
        }

        private void btnSeeAll_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}