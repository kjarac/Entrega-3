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
        private const int BITMONS = 5;
        
        
        List<Button> listaBotones;
        Button[,] matrizBotones;
        bool[,] terreno;
        bool[,] hayBitmon;
        Terreno terreno1 = new Terreno();
        AgregarBitmons addBitmon = new AgregarBitmons();
        List<Bitmon> listaBitmons = new List<Bitmon>();


        int time=9;

        public Form1()
        {
            InitializeComponent();

            matrizBotones = new Button[FILAS, COLUMNAS];
            terreno = new bool[FILAS, COLUMNAS];
            hayBitmon = new bool[FILAS, COLUMNAS];

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

            terreno1.ConfiguracionTerreno(matrizBotones, terreno, CELDAS, COLUMNAS, FILAS);
            addBitmon.AddBitmon(matrizBotones, COLUMNAS, FILAS, BITMONS, hayBitmon);
            listaBitmons = addBitmon.GetBitmons();



        }
        public void ModificarMapa()
        {
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    matrizBotones[fila, columna].Text = "";
                }
            }
            foreach(Bitmon bit in listaBitmons)
            {
                matrizBotones[bit.PosicionX(), bit.PosicionY()].Text += bit.Especie();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form config = new ConfiguracionInicial();
            config.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time++;
            foreach(Bitmon bit in listaBitmons)
            {
                bit.Desplazamiento(matrizBotones);
                
            }
            ModificarMapa();
            if (time % 3 == 0)
            {
                Random random = new Random();
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                bool existeUnBitmon = hayBitmon[fila, columna];
                int tipoBitmon = random.Next(1, 7);
                int tiempoDeVida = random.Next(1, 6);
                int puntosDeVida = random.Next(10, 250);
                int puntosDeAtaque = random.Next(30, 101);
                int cantidadDeHijos = 0;

                Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                hayBitmon[fila, columna] = true;
                matrizBotones[fila, columna].Text = ent.Especie();
                listaBitmons.Add(ent);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //button 2, mes siguiente
    }

}