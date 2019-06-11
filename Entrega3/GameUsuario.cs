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
    public partial class GameUsuario : Form
    {

        private int FILAS;
        private int COLUMNAS;

        List<Button> listaBotones;
        Button[,] matrizBotones;
        TableLayoutPanel mapa;

        public GameUsuario()
        {
            InitializeComponent();
            configurarTableLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrizBotones = new Button[FILAS, COLUMNAS];
            listaBotones = new List<Button>();

            // Agregaremos los botones con código, para no hacerlo 1 a 1...
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
        }

        private void configurarTableLayout()
        {
            mapa = new TableLayoutPanel();

            //int DIMENSIONES = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            //int DIMENSIONES = Convert.ToInt32(Math.Round(numericUpDown1.Value,0));
            int DIMENSIONES = 15;

            // Modificamos las filas y columnas del tableLayout
            mapa.RowCount = DIMENSIONES;
            mapa.ColumnCount = DIMENSIONES;

            // Estas constantes es para que sea más fácil de leer el código solamente
            FILAS = DIMENSIONES;
            COLUMNAS = DIMENSIONES;

            // Quiero que sea de más o menos 300x300
            // Hago esto para que el tamaño de todos los botones sea el mismo.
            // WindowsForms hace algo raro con la última columna y última fila
            // cuando estos valores no calzan bien...
            int tamanoBoton = (int)Math.Round(300.0 / DIMENSIONES);
            int tamanoTabla = tamanoBoton * DIMENSIONES;

            for (var i = 0; i < COLUMNAS; i++)
                mapa.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tamanoBoton));

            for (var i = 0; i < FILAS; i++)
                mapa.RowStyles.Add(new RowStyle(SizeType.Absolute, tamanoBoton));

            mapa.Size = new Size(tamanoTabla, tamanoTabla);

            // Lo siguiente centra la tabla
            mapa.Anchor = AnchorStyles.None;

            tableLayoutPanel1.Controls.Add(mapa, 0, 1);
        }
    }
}
