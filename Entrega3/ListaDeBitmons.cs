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
    public partial class ListaDeBitmons : Form
    {
        public List<string> listaBitmons = new List<string>();
        public List<string> listaAuxiliar = new List<string>();
        int bitActual = 1;
        int cantidadDeBitmons;
        int dimensiones;
        int tiempoDeSimulacion;
     
        public ListaDeBitmons(int cantidadDeBitmons,int dimensiones,int tiempoDeSimulacion)
        {
            InitializeComponent();
            this.cantidadDeBitmons = cantidadDeBitmons;
            this.dimensiones = dimensiones;
            this.tiempoDeSimulacion = tiempoDeSimulacion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaBitmons.Add(comboBox1.Text);
            bitActual += 1;
            label1.Text = "Bitmon " + bitActual;
            if (bitActual == cantidadDeBitmons+1)
            {
                foreach (string bitmon in listaBitmons)
                {
                    if (bitmon == "Dorvalo")
                    {
                        listaAuxiliar.Add("🦅");
                    }
                    else if (bitmon == "Doti")
                    {
                        listaAuxiliar.Add("🦄");
                    }
                    else if (bitmon== "Ent")
                    {
                        listaAuxiliar.Add("🌵");
                    }
                    else if (bitmon=="Gofue")
                    {
                        listaAuxiliar.Add("🐉");
                    }
                    else if (bitmon=="Wetar")
                    {
                        listaAuxiliar.Add("🐳");
                    }
                    else
                    {
                        listaAuxiliar.Add("🐍");
                    }
                }
                Game game = new Game(listaAuxiliar,dimensiones,tiempoDeSimulacion);
                game.Show();
                Close();
            }else if (bitActual == cantidadDeBitmons)
            {
                button1.Text = "Guardar";

            }

            
        }
    }
}
