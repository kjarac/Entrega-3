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
        private const int FILAS = 8;
        private const int COLUMNAS = 8;

        List<Button> listaBotones;
        Button[,] matrizBotones;
        bool[,] bitmon;
        bool[,] terreno;
        int time;
        public Form1()
        {
            InitializeComponent();

            matrizBotones = new Button[FILAS, COLUMNAS];
            bitmon = new bool[FILAS, COLUMNAS];
            listaBotones = new List<Button>();

            //Agregando botones al cod

            for (int fila = 0; fila < FILAS; fila++)
            {
                for(int columna = 0; columna < COLUMNAS; columna++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.Click += cell_Click;
                    button.BackColor = Color.LightGray;
                    button.FlatAppearance.BorderSize = 0;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);

                }
            }

            
        }

        private void cell_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int filaBoton = 0;
            int columnaBoton = 0;

            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna<COLUMNAS; columna++)
                {
                    if (boton == matrizBotones[fila,columna])
                    {
                        filaBoton = fila;
                        columnaBoton = columna;
                        break;
                    }
                }
            }

        }

        private void ConfigurarCeldas() // para el terreno 
        {
            
            for(int fila = 0; fila <FILAS; fila++)
            {

            }
        }

      
    }
}
