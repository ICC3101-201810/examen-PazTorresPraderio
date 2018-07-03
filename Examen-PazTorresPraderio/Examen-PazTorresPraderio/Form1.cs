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
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void Enter_Name(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Enter_Name1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (usserName.Text != null)
                {
                    Form2 form2 = new Form2(this, usserName.Text);
                    this.Hide();
                    form2.Show();
                    usserName.Text = "";
                }
                else
                {
                    MessageBox.Show("Debes Ingresar un nombre");
                }
               
            }
        }
    }
}
