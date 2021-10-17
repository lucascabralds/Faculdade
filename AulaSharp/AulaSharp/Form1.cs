using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           this.txtHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hora x = new Hora("17","30");
            //txtHora.Text = x.hora +"h" + x.minuto;
            //txtDespertador.Text = x.hora + "h" + x.minuto;

            this.txtHora.Text = DateTime.Now.ToString("HH:mm");


        }

        
    }
}
