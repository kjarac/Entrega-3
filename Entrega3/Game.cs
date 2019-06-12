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
        int anio = 1;
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
        List<Bitmon> BitmonsNacidos = new List<Bitmon>();

        int time = 0;
        public void ModificarMapa()
        {
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    matrizBotones[fila, columna].Text = "";
                }
            }
            foreach (Bitmon bit in listaTipoBitmons)
            {
                matrizBotones[bit.PosicionX(), bit.PosicionY()].Text += bit.Especie();
            }
        }
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

            if (listaTipoBitmons==null || listaBitmons == null)
            {
                button1.Hide();
                button2.Hide();
                button4.Hide();
            }
            else
            {

                button4.Show();
            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            time++;
            if(time== tiempoDeSimulacion)
            {
                MessageBox.Show("Tiempo de simulación terminada");
                //Aqui agregale la ventana de mostrar estadisticas
                //Close();

            }
            label2.Text = "Mes :" + time;
            label1.Text = "Cantidad de Bitmons: " + listaTipoBitmons.Count;
            /*label3.Text = "Mes " + time;
            label2.Text = "Cantidad de bitmons: " + listaBitmons.Count;
            label5.Text = "año" + anio;*/
            Random random = new Random();
            int fila = random.Next(FILAS);
            int columna = random.Next(COLUMNAS);
            bool existeUnBitmon = hayBitmon[fila, columna];
            int tipoBitmon = random.Next(1, 7);
            int tiempoDeVida = random.Next(1, 6);
            int puntosDeVida = random.Next(10, 250);
            int puntosDeAtaque = random.Next(30, 101);
            int cantidadDeHijos = 0;
            foreach (Bitmon bit in listaTipoBitmons)
            {
                bit.Desplazamiento(matrizBotones);

            }
            ModificarMapa();
            if (time % 3 == 0)
            {
                while (true)
                {
                    if (matrizBotones[fila, columna].Text == "")
                    {
                        Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = ent.Especie();
                        listaTipoBitmons.Add(ent);
                        break;
                    }
                    else
                    {
                        fila = random.Next(FILAS);
                        columna = random.Next(COLUMNAS);
                    }
                }


            }
            if (time % 12 == 0)
            {
                anio += 1;
                listaBitmons.Count();

            }
            List<Bitmon> aux = new List<Bitmon>();
            aux = listaTipoBitmons;

            int a = 0;
            int b = 0;

            foreach (Bitmon bit in listaTipoBitmons)
            {
                foreach (Bitmon bits in listaTipoBitmons)
                {
                    if (a != b)
                    {
                        if (bit.PosicionX() == bits.PosicionX() && bit.PosicionY() == bits.PosicionY())
                        {
                            if (bit.AfinidadBitmons(bits))
                            {
                                aux[a].Reproducirse();
                                aux[b].Reproducirse();
                                fila = random.Next(FILAS);
                                columna = random.Next(COLUMNAS);
                                existeUnBitmon = hayBitmon[fila, columna];
                                tipoBitmon = random.Next(1, 7);
                                tiempoDeVida = random.Next(1, 6);
                                puntosDeVida = random.Next(10, 250);
                                puntosDeAtaque = random.Next(30, 101);
                                cantidadDeHijos = 0;
                                if (tipoBitmon == 1)
                                {
                                    Dorvalo dorvalo = new Dorvalo(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = dorvalo.Especie();
                                    BitmonsNacidos.Add(dorvalo);
                                    MessageBox.Show("Ha nacido un dorvalo");
                                }
                                else if (tipoBitmon == 2)
                                {
                                    Doti doti = new Doti(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = doti.Especie();
                                    BitmonsNacidos.Add(doti);
                                    MessageBox.Show("Ha nacido un doti");

                                }
                                else if (tipoBitmon == 3 || (matrizBotones[fila, columna].BackColor != Color.Red && matrizBotones[fila, columna].BackColor != Color.Brown))
                                {
                                    Ent ent2 = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = ent2.Especie();
                                    BitmonsNacidos.Add(ent2);
                                    MessageBox.Show("Ha nacido un ent");
                                }
                                else if (tipoBitmon == 4)
                                {
                                    Gofue gofue = new Gofue(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = gofue.Especie();
                                    BitmonsNacidos.Add(gofue);
                                    MessageBox.Show("Ha nacido un gofue");
                                }
                                else if (tipoBitmon == 5 && matrizBotones[fila, columna].BackColor == Color.Aqua)
                                {
                                    Wetar wetar = new Wetar(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = wetar.Especie();
                                    BitmonsNacidos.Add(wetar);
                                    MessageBox.Show("Ha nacido un dorvalo");
                                }
                                else
                                {
                                    Taplan taplan = new Taplan(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = taplan.Especie();
                                    BitmonsNacidos.Add(taplan);
                                    MessageBox.Show("Ha nacido un taplan");
                                }

                            }
                            else
                            {
                                aux[a].ReducirPuntosDeVida(bits.Daño(bit));
                                aux[b].ReducirPuntosDeVida(bit.Daño(bits));
                                MessageBox.Show(bit.Especie() + " v/s " + bits.Especie());
                                if (bit.Muere())
                                {
                                    bithalla.Add(bit);
                                    MessageBox.Show("Ha muerto un " + bit.Especie());
                                }
                                else if (bits.Muere())
                                {
                                    bithalla.Add(bits);
                                    MessageBox.Show("Ha muerto un " + bits.Especie());
                                }

                            }
                        }
                    }
                    b++;
                }
                a++;
                break;
            }
            foreach (Bitmon bit in BitmonsNacidos)
            {
                aux.Add(bit);
            }
            foreach (Bitmon bit in bithalla)
            {
                aux.Remove(bit);
            }
            listaTipoBitmons = aux;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
