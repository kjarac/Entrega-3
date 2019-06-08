using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    public partial class ConfiguracionInicial : Form
    {
        public int cantidadDeBitmons;
        public int tiempoDeSimulacion;
        public int FILAS;
        public int COLUMNAS;

        public ConfiguracionInicial()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            cantidadDeBitmons = Convert.ToInt32(textBox1.Text);
            tiempoDeSimulacion = Convert.ToInt32(textBox2.Text);
            FILAS = Convert.ToInt32(textBox3.Text);
            COLUMNAS = Convert.ToInt32(textBox4.Text);
            ListaDeBitmons listaDeBitmons = new ListaDeBitmons(cantidadDeBitmons,FILAS,COLUMNAS);
            listaDeBitmons.Show();


        }
    }
}
