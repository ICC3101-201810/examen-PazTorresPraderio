using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Examen_PazTorresPraderio
{
    public partial class Form2 : Form
    {
        Form1 parent;
        string nombre;
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        int speed = 5;
        int fantasma1 = 10;
        int fantasma2 = 8;
        int puntaje = 0;
        public Form2(Form1 parent, string nombre)
        {
            InitializeComponent();
            this.parent = parent;
            this.nombre = nombre;
            gameover.Hide();
            derrota.Hide();
            datosfinales.Hide();
            Controls.Remove(cherry);
            Controls.Remove(pera);
            timer3.Interval = 10000;
            timer3.Tick += new EventHandler(timer3_Tick);
            timer2.Interval = 30000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

        }
        protected override void OnClosed(EventArgs e)
        {
            parent.Show();
            base.OnClosed(e);
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.pacman_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                pacman.Image = Properties.Resources.pacman_right;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                pacman.Image = Properties.Resources.pacman_up;

            }
            if ( e.KeyCode == Keys.Down)
            {
                godown = true;
                pacman.Image = Properties.Resources.pacman_down;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
 

            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;

            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
              
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score.Text = "Tu Puntaje es :" + Convert.ToString(puntaje);
            nombreUsser.Text = "Hola" + " " +  nombre;

            if (goleft)
            {
                pacman.Left -= speed;
                FantasmaRojo.Left -= fantasma1;
                FantasmaRosa.Left -= fantasma2;
                
            }
            if (goright)
            {
                pacman.Left += speed;
                FantasmaRojo.Left += fantasma1;
                FantasmaRosa.Left += fantasma2;
            }
            if (goup)
            {
                pacman.Top -= speed;
                FantasmaRojo.Top -= fantasma1;
                FantasmaRosa.Top -= fantasma2;          
            }
            if (godown)
            {
                pacman.Top += speed;
                FantasmaRojo.Top += fantasma1;
                FantasmaRosa.Top += fantasma2;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Name == "wall1" || x.Name == "wall2" || x.Name == "wall3" || x.Name == "paredIzq" || x.Name == "paredDer" || x.Name == "ParedDown" || x.Name == "paredUp")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(FantasmaRojo.Bounds))
                    {
                        fantasma1 = -fantasma1;
                    }
                }
            }
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && x.Name == "wall1" || x.Name == "wall2" || x.Name == "wall3" || x.Name == "paredIzq" || x.Name == "paredDer" || x.Name == "ParedDown" || x.Name == "paredUp")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(FantasmaRosa.Bounds))
                    {
                        fantasma2 = -fantasma2;
                    }
                }
            }
            
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && x.Name == "wall1" || x.Name =="wall2" || x.Name == "wall3" || x.Name == "paredIzq" || x.Name == "paredDer" ||  x.Name == "ParedDown" || x.Name == "paredUp" || x.Name =="FantasmaRojo" || x.Name =="FantasmaRosa")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        pacman.Left = 156;
                        pacman.Top = 226;
                        gameover.Show();
                        derrota.Show();
                        datosfinales.Text = "Tu puntaje" + " " + nombre + " " + "es :" + " " + puntaje.ToString();
                        datosfinales.Show();
                        Jugador jugador = new Jugador(nombre, puntaje);
                        BBDD.AddJugador(jugador);
                        timer.Interval = 5000;
                        timer.Tick += new EventHandler(timer_Tick);
                        timer.Start();
                        timer1.Stop();
                        
                    }

                }
                if (x is PictureBox && x.Name == "coin"  || x.Name =="coin1" || x.Name == "coin2" || x.Name == "coin3" || x.Name == "coin4" || x.Name == "coin5" || x.Name == "coin6" || x.Name == "coin7" || x.Name == "coin8" || x.Name == "coin9" || x.Name == "coin10")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        puntaje++;
                    }
                }
                if (x is PictureBox && x.Name == "cherry")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        timer2.Start();
                        timer3.Stop();
                        puntaje += 10;
                    }
                }
                if (x is PictureBox && x.Name == "pera")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x);
                        timer2.Start();
                        timer3.Stop();
                        puntaje += 15;
                    }
                }


            }
            
        }
        void timer_Tick(object sender, EventArgs e)
        {

            this.Hide();
            Form3 f3 = new Form3(this);
            f3.Show();
            timer.Stop();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Controls.Add(cherry);
            Controls.Add(pera);
            timer2.Stop();
            timer3.Start();
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Controls.Remove(cherry);
            Controls.Remove(pera);
            timer3.Stop();
            timer2.Start();

        }
    }
    
}
