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
      


        public Form1()
        {
            InitializeComponent();

          
         

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var disenioPredeterminado = new GamePredeterminado();
            disenioPredeterminado.ShowDialog();
        }
            

        
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            var disenioPersonalizado = new Game(0, 0);
            disenioPersonalizado.ShowDialog();
        }
    }
}