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
        private const int CELDAS = 64;

        List<Button> listaBotones;
        Button[,] matrizBotones;
        bool[,] terreno;
        int time;

        public Form1()
        {
            InitializeComponent();

            matrizBotones = new Button[FILAS, COLUMNAS];
            terreno = new bool[FILAS, COLUMNAS];
            listaBotones = new List<Button>();
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.Click += cell_Click;
                    button.BackColor = Color.LightGray;
                    button.FlatAppearance.BorderSize = 0;
                    tableLayoutPanel1.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);
                }

            }
            configurarCeldas();
        }

        private void configurarCeldas()
        {
            // Terreno
            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                    terreno[fila, columna] = false;

            // Se crea el terreno para cada celda, al azar
            Random random = new Random();
            int celda = 0;

            while (celda < CELDAS)
            {
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                bool existeUnBombmon = terreno[fila, columna];
                int tipoTerreno = random.Next(1, 6);
                if (!existeUnBombmon)
                {
                    if (tipoTerreno == 1)
                    {
                        terreno[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "V";
                    }
                    else if (tipoTerreno == 2)
                    {
                        terreno[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "A";
                    }
                    else if (tipoTerreno == 3)
                    {
                        terreno[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "D";
                    }
                    else if (tipoTerreno == 4)
                    {
                        terreno[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "N";
                    }
                    else if (tipoTerreno == 5)
                    {
                        terreno[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Vn";
                    }

                    celda++;

                }
            }

            // Aqui se le cambia el color
            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    if (matrizBotones[fila, columna].Text == "V")
                    {
                        matrizBotones[fila, columna].BackColor = Color.LightGreen;
                    }
                    if (matrizBotones[fila, columna].Text == "A")
                    {
                        matrizBotones[fila, columna].BackColor = Color.Aqua;
                    }
                    if (matrizBotones[fila, columna].Text == "D")
                    {
                        matrizBotones[fila, columna].BackColor = Color.Brown;
                    }
                    if (matrizBotones[fila, columna].Text == "N")
                    {
                        matrizBotones[fila, columna].BackColor = Color.White;
                    }
                    if (matrizBotones[fila, columna].Text == "Vn")
                    {
                        matrizBotones[fila, columna].BackColor = Color.Red;
                    }

                    matrizBotones[fila, columna].Enabled = true;
                    matrizBotones[fila, columna].Text = "";
                }



        }


        private void cell_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            int filaBoton = 0;
            int columnaBoton = 0;

            // Para la posición del botón
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    if (boton == matrizBotones[fila, columna])
                    {
                        filaBoton = fila;
                        columnaBoton = columna;
                        break;
                    }
                }
            }


        }
    }

}