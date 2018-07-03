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
    public partial class Form3 : Form
    {
        Form2 parent;
        public Form3(Form2 parent)
        {
            this.parent = parent;
            InitializeComponent();
            foreach (Jugador jugador in BBDD.jugadores)
            {

                Datos.Items.Add("Puntaje" + " " + jugador.GetScore() + " "+ "Nombre"  +  " " + jugador.GetName());
                
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            parent.Show();
        }
    }
}
