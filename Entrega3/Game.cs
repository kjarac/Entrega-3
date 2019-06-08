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
        TableLayoutPanel tableLayoutPanelMapa;
        int FILAS;
        int COLUMNAS;
        
        List<Button> listaBotones;
        Button[,] matrizBotones;
       public Game()
        {
            InitializeComponent();
            ConfigurarTableLayout();
            
           
            matrizBotones = new Button[FILAS, COLUMNAS];
            listaBotones = new List<Button>();

            for (int fila=0; fila<FILAS; fila++)
            {
                for(int columna = 0; columna<COLUMNAS; columna++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0, 0, 0, 0);
                    button.Padding = new Padding(0, 0, 0, 0);
                    button.FlatStyle = FlatStyle.Popup;
                    button.BackColor = Color.LightGray;
                    button.FlatAppearance.BorderSize = 0;
                    tableLayoutPanelMapa.Controls.Add(button, columna, fila);
                    matrizBotones[fila, columna] = button;
                    listaBotones.Add(button);
                   
                }
            }
            
            
        }

        private void ConfigurarTableLayout()
        {
            tableLayoutPanelMapa = new TableLayoutPanel();
            int DIMENSIONES =Convert.ToInt32(numericUpDown1.Value);
            tableLayoutPanelMapa.RowCount = DIMENSIONES;
            tableLayoutPanelMapa.ColumnCount = DIMENSIONES;

            FILAS = DIMENSIONES;
            COLUMNAS = DIMENSIONES;

            int tamanioBoton = (int)Math.Round(300.0 / DIMENSIONES);
            int tamanioTabla = tamanioBoton * COLUMNAS;


            for (var i = 0; i < COLUMNAS; i++)
                tableLayoutPanelMapa.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tamanioBoton));

            for (var i = 0; i < FILAS; i++)
                tableLayoutPanelMapa.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, tamanioBoton));

            tableLayoutPanelMapa.Size = new Size(tamanioTabla, tamanioTabla);

            tableLayoutPanelMapa.Anchor = AnchorStyles.None;
            tableLayoutPanel1.Controls.Add(tableLayoutPanelMapa, 0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form config = new ConfiguracionInicial();
            Hide();
            config.Show();
           
        }
    }
}
