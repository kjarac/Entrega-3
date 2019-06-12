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
    public partial class Game : Form
    {
        private int FILAS;
        private int COLUMNAS;
        List<string> listaBitmons = new List<string>();
        List<Button> listaBotones;
        Button[,] matrizBotones;
        TableLayoutPanel mapa;
        int dimensiones;
        int tiempoDeSimulacion;
        // int DIMENSIONES;
        int CELDAS;
        List<Bitmon> bithalla = new List<Bitmon>();
        bool[,] terreno;
        bool[,] hayBitmon;
        Terreno terreno1 = new Terreno();
        AgregarBitmons addBitmon = new AgregarBitmons();
        List<Bitmon> listaTipoBitmons = new List<Bitmon>();

        int time = 0;

        public Game(List<string> listaBitmons, int dimensiones, int tiempoDeSimulacion)
        {
            this.listaBitmons = listaBitmons;
            this.dimensiones = dimensiones;
            this.tiempoDeSimulacion = tiempoDeSimulacion;
            InitializeComponent();
            FILAS = dimensiones;
            COLUMNAS = dimensiones;
            matrizBotones = new Button[FILAS, COLUMNAS];
            terreno = new bool[FILAS, COLUMNAS];
            hayBitmon = new bool[FILAS, COLUMNAS];
            configurarTableLayout();

        }




        private void button4_Click(object sender, EventArgs e)
        {
            FILAS = dimensiones;
            COLUMNAS = dimensiones;
            CELDAS = dimensiones * dimensiones;
            matrizBotones = new Button[FILAS, COLUMNAS];
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

                    button.BackColor = Color.LightGray;
                    button.FlatAppearance.BorderSize = 0;
                    mapa.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);
                }
            }
            terreno1.ConfiguracionTerreno(matrizBotones, terreno, CELDAS, COLUMNAS, FILAS);
            listaTipoBitmons = addBitmon.AddListaBitmon(listaBitmons, matrizBotones, COLUMNAS, FILAS, hayBitmon);

        }

        private void configurarTableLayout()
        {
            mapa = new TableLayoutPanel();
            int DIMENSIONES = dimensiones;

   
            mapa.RowCount = DIMENSIONES;
            mapa.ColumnCount = DIMENSIONES;

            FILAS = DIMENSIONES;
            COLUMNAS = DIMENSIONES;

            int tamanoBoton = (int)Math.Round(300.0 / DIMENSIONES);
            int tamanoTabla = tamanoBoton * DIMENSIONES;

            for (var i = 0; i < COLUMNAS; i++)
                mapa.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tamanoBoton));

            for (var i = 0; i < FILAS; i++)
                mapa.RowStyles.Add(new RowStyle(SizeType.Absolute, tamanoBoton));

            mapa.Size = new Size(tamanoTabla, tamanoTabla);

            //centra el mapa
            mapa.Anchor = AnchorStyles.None;

            tableLayoutPanel1.Controls.Add(mapa, 0, 1);
        }

        private void indicadorListaBitmon_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form config = new ConfiguracionInicial();
            Hide();
            config.Show();
        }


    }
}
