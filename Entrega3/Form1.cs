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
    public partial class Form1 : Form
    {
        List<string> listaBitmons;
        int dimensiones;
        int tiempoDeSimulacion;


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            GamePredeterminado disenioPredeterminado = new GamePredeterminado();
            disenioPredeterminado.ShowDialog();
            Hide();
        }
            

        
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Game disenioPersonalizado = new Game(listaBitmons, dimensiones, tiempoDeSimulacion);
            disenioPersonalizado.ShowDialog();
            
        }
    }
}