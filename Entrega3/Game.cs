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
       
        int CELDAS;
        List<Bitmon> bithalla = new List<Bitmon>();
        bool[,] terreno;
        bool[,] hayBitmon;
        Terreno terreno1 = new Terreno();
        AgregarBitmons addBitmon = new AgregarBitmons();
        List<Bitmon> listaTipoBitmons = new List<Bitmon>();
        List<Bitmon> BitmonsNacidos = new List<Bitmon>();

        int wetar1 = 0;
        int dorvalo1 = 0;
        int doti1 = 0;
        int ent1 = 0;
        int gofue1 = 0;
        int taplan1 = 0;


        int tiempoVidaBitmons;
        int CantBitmons;
        int tiempoVidaWetar, tiempoVidaDoti, tiempoVidaDorvalo, tiempoVidaGofue, tiempoVidaTaplan, tiempoVidaEnt;


        int time = 0;
        int anio = 0;

       
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
        
            // 1 año
            if (time % 12 == 0)
            {   
                foreach (Bitmon bitmon in listaTipoBitmons)
                {
                    if (bitmon.Especie() == "🐳")
                    {
                        wetar1 += 1;

                    }
                    else if (bitmon.Especie() == "🐍")
                    {
                        taplan1 += 1;

                    }
                    else if (bitmon.Especie() == "🐉")
                    {
                        gofue1 += 1;

                    }
                    else if (bitmon.Especie() == "🌵")
                    {
                        ent1 += 1;

                    }
                    else if (bitmon.Especie() == "🦄")
                    {
                        doti1 += 1;

                    }
                    else
                    {
                        dorvalo1 += 1;

                    }
                }
                anio++;


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
                                MessageBox.Show(bit.Especie() + " v/s " + bits.Especie());
                                aux[a].ReducirPuntosDeVida(bits.Daño(bit));
                                aux[b].ReducirPuntosDeVida(bit.Daño(bits));
                                
                                if (bit.Muere())
                                {
                                    bithalla.Add(bit);
                                    MessageBox.Show("Ha muerto un " + bit.Especie());
                                    bits.SumarPuntosDeVida(bit.Daño(bits));
                                }
                                else if (bits.Muere())
                                {
                                    bithalla.Add(bits);
                                    MessageBox.Show("Ha muerto un " + bits.Especie());
                                    bit.SumarPuntosDeVida(bits.Daño(bit));
                                }

                            }
                            foreach(Bitmon bitmon in listaTipoBitmons)
                            {
                                bitmon.CambioTerreno(matrizBotones);
                                if (bitmon.AfinidadTerreno(matrizBotones))
                                {
                                    bitmon.ReducirTiempoDeVida(2);

                                }
                                else
                                {
                                    bitmon.ReducirTiempoDeVida(1);
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


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bitmons muertos: " + bithalla.Count);
            int wetar = 0,  wetarD = 0, wetarN = 0;
            int dorvalo = 0, dorvaloD = 0, dorvaloN = 0;
            int doti = 0,  dotiD = 0, dotiN = 0;
            int ent = 0,  entD = 0, entN = 0;
            int gofue = 0,  gofueD = 0, gofueN = 0;
            int taplan = 0,  taplanD = 0, taplanN = 0;
            string wetarM = "", dorvaloM = "", dotiM = "", entM = "", gofueM = "", taplanM = "";

            foreach (Bitmon bit in listaTipoBitmons)
            {
                if (bit.Especie() == "🐳")
                {
                    wetar += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaWetar += bit.TiempoDeVida();
                    CantBitmons += 1;

                }
                else if (bit.Especie() == "🐍")
                {
                    taplan += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaTaplan += bit.TiempoDeVida();
                    CantBitmons += 1;
                }
                else if (bit.Especie() == "🐉")
                {
                    gofue += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaGofue += bit.TiempoDeVida();
                    CantBitmons += 1;


                }
                else if (bit.Especie() == "🌵")
                {
                    ent += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaEnt += bit.TiempoDeVida();
                    CantBitmons += 1;

                }
                else if (bit.Especie() == "🦄")
                {
                    doti += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaDoti += bit.TiempoDeVida();
                    CantBitmons += 1;

                }
                else
                {
                    dorvalo += 1;
                    tiempoVidaBitmons += bit.TiempoDeVida();
                    tiempoVidaDorvalo += bit.TiempoDeVida();
                    CantBitmons += 1;
                }

            }
          
            foreach (Bitmon bitmonM in listaTipoBitmons)
            {

                if (bitmonM.Especie() == "🐳")
                {
                    wetarM = "hay";

                }
                else if (bitmonM.Especie() == "🐍")
                {
                    taplanM = "hay";

                }
                else if (bitmonM.Especie() == "🐉")
                {
                    gofueM = "hay";

                }
                else if (bitmonM.Especie() == "🌵")
                {
                    entM = "hay";

                }
                else if (bitmonM.Especie() == "🦄")
                {
                    dotiM = "hay";

                }
                else
                {
                    dorvaloM = "hay";

                }

            }

            foreach (Bitmon bitmonDie in bithalla)
            {
                if (bitmonDie.Especie() == "🐳")
                {
                    wetarD += 1;

                }
                else if (bitmonDie.Especie() == "🐍")
                {
                    taplanD += 1;

                }
                else if (bitmonDie.Especie() == "🐉")
                {
                    gofueD += 1;

                }
                else if (bitmonDie.Especie() == "🌵")
                {
                    entD += 1;

                }
                else if (bitmonDie.Especie() == "🦄")
                {
                    dotiD += 1;


                }
                else
                {
                    dorvaloD += 1;

                }

            }

            foreach (Bitmon bitmonNacido in BitmonsNacidos)
            {
                if (bitmonNacido.Especie() == "🐳")
                {
                    wetarN += 1;

                }
                else if (bitmonNacido.Especie() == "🐍")
                {
                    taplanN += 1;

                }
                else if (bitmonNacido.Especie() == "🐉")
                {
                    gofueN += 1;

                }
                else if (bitmonNacido.Especie() == "🌵")
                {
                    entN += 1;

                }
                else if (bitmonNacido.Especie() == "🦄")
                {
                    dotiN += 1;

                }
                else
                {
                    dorvaloN += 1;

                }
            }


            if (CantBitmons != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Bitmon: " + tiempoVidaBitmons / CantBitmons);
            }


            if (wetar != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Wetar: " + tiempoVidaWetar / wetar);
                MessageBox.Show("Cantidad de hijos promedio: " + wetarN / wetar);
                MessageBox.Show("Tasa bruta de Natalidad de Wetar: " + (wetar1 / wetar) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Wetar: " + (wetarD / wetar) * 100);
            }



            if (dorvalo != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Dorvalo: " + tiempoVidaDorvalo / dorvalo);
                MessageBox.Show("Cantidad de hijos promedio:" + dorvaloN / dorvalo);
                MessageBox.Show("Tasa bruta de Natalidad de Dorvalo: " + (dorvalo1 / dorvalo) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Dorvalo: " + (dorvaloD / dorvalo) * 100);
            }

            if (taplan != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Taplan: " + tiempoVidaTaplan / taplan);
                MessageBox.Show("Cantidad de hijos promedio: " + taplanN / taplan);
                MessageBox.Show("Tasa bruta de Natalidad de Taplan: " + (taplan1 / taplan) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Taplan: " + (taplanD / taplan) * 100);
            }
            if (gofue != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Gofue: " + tiempoVidaGofue / gofue);
                MessageBox.Show("Cantidad de hijos promedio: " + gofueN / gofue);
                MessageBox.Show("Tasa bruta de Natalidad de Gofue: " + (gofue1 / gofue) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Gofue: " + (gofueD / gofue) * 100);
            }

            if (ent != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Ent: " + tiempoVidaEnt / ent);
                MessageBox.Show("Cantidad de hijos promedio: " + entN / ent);
                MessageBox.Show("Tasa bruta de Natalidad de Ent: " + (ent1 / ent) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Ent: " + (entD / ent) * 100);
            }

            if (doti != 0)
            {
                MessageBox.Show("Tiempo de vida promedio de Doti: " + tiempoVidaDoti / doti);
                MessageBox.Show("Cantidad de hijos promedio: " + dotiN / doti);
                MessageBox.Show("Tasa bruta de Natalidad de Doti: " + (doti1 / doti) * 1000);
                MessageBox.Show("Tasa bruta de Mortalidad de Doti: " + (dotiD / doti) * 100);
            }
            if (bithalla.Count() != 0)
            {
                MessageBox.Show("Descripcion de la poblacion de Bithalla: " +
                "\n Wetar: " + wetarD + "es el  " + wetarD / bithalla.Count() * 100 + "% del Bithalla" +
                "\n Taplan: " + taplanD + "es el  " + taplanD / bithalla.Count() * 100 + "% del Bithalla" +
                "\n Gofue: " + gofueD + "es el  " + gofueD / bithalla.Count() * 100 + "% del Bithalla" +
                "\n Ent: " + entD + "es el  " + entD / bithalla.Count() * 100 + "% del Bithalla" +
                "\n Doti: " + dotiD + "es el  " + dotiD / bithalla.Count() * 100 + "% del Bithalla" +
                "\n Dorvalo: " + dorvaloD + "es el  " + dorvaloD / bithalla.Count() * 100 + "% del Bithalla");
            }

            if (wetarM == "")
            {
                MessageBox.Show("Wetar extinto");
            }
            if (taplanM == "")
            {
                MessageBox.Show("Taplan extinto");
            }
            if (gofueM == "")
            {
                MessageBox.Show("Gofue extinto");
            }
            if (entM == "")
            {
                MessageBox.Show("Ent extinto");
            }
            if (dotiM == "")
            {
                MessageBox.Show("Doti extinto");
            }
            if (dorvaloM == "")
            {
                MessageBox.Show("Dorvalo extinto");
            }
        }
    }
}
