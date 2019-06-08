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

        List<Bitmon> bithalla = new List<Bitmon>();
        List<Button> listaBotones;
        Button[,] matrizBotones;
        bool[,] terreno;
        bool[,] hayBitmon;
        Terreno terreno1 = new Terreno();
        AgregarBitmons addBitmon = new AgregarBitmons();
        List<Bitmon> listaBitmons = new List<Bitmon>();


        int time = 0;

        public Form1()
        {
            InitializeComponent();

            matrizBotones = new Button[FILAS, COLUMNAS];
            terreno = new bool[FILAS, COLUMNAS];
            hayBitmon = new bool[FILAS, COLUMNAS];
            label2.Text = "Cantidad de bitmons";
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
            foreach (Bitmon bit in listaBitmons)
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
            label4.Text = "Mes " + time;
            label2.Text ="Cantidad de bitmons: " + listaBitmons.Count;
            Random random = new Random();
            int fila = random.Next(FILAS);
            int columna = random.Next(COLUMNAS);
            bool existeUnBitmon = hayBitmon[fila, columna];
            int tipoBitmon = random.Next(1, 7);
            int tiempoDeVida = random.Next(1, 6);
            int puntosDeVida = random.Next(10, 250);
            int puntosDeAtaque = random.Next(30, 101);
            int cantidadDeHijos = 0;
            foreach (Bitmon bit in listaBitmons)
            {
                bit.Desplazamiento(matrizBotones);

            }
            ModificarMapa();
            if (time % 3 == 0)
            {
                while (true) {
                    if (matrizBotones[fila, columna].Text == "")
                    {
                        Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = ent.Especie();
                        listaBitmons.Add(ent);
                        break;
                    }
                    else
                    {
                        fila = random.Next(FILAS);
                        columna = random.Next(COLUMNAS);
                    }
                }
            }
            List<Bitmon> aux = new List<Bitmon>();
            aux = listaBitmons;
            List<Bitmon> aux2 = new List<Bitmon>();
            int a = 0;
            int b = 0;
            bool crearBitmon = true;
            foreach (Bitmon bit in listaBitmons)
            {
                foreach (Bitmon bits in listaBitmons)
                {
                    if( a!=b)
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
                                    aux2.Add(dorvalo);
                                    MessageBox.Show("Ha nacido un dorvalo");
                                }
                                else if (tipoBitmon == 2)
                                {
                                    Doti doti = new Doti(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = doti.Especie();
                                    aux2.Add(doti);
                                    MessageBox.Show("Ha nacido un doti");

                                }
                                else if (tipoBitmon == 3 && (matrizBotones[fila, columna].BackColor != Color.Red && matrizBotones[fila, columna].BackColor != Color.Brown))
                                {
                                    Ent ent2 = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = ent2.Especie();
                                    aux2.Add(ent2);
                                    MessageBox.Show("Ha nacido un ent");
                                }
                                else if (tipoBitmon == 4)
                                {
                                    Gofue gofue = new Gofue(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = gofue.Especie();
                                    aux2.Add(gofue);
                                    MessageBox.Show("Ha nacido un gofue");
                                }
                                else if (tipoBitmon == 5 && matrizBotones[fila, columna].BackColor == Color.Aqua)
                                {
                                    Wetar wetar = new Wetar(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = wetar.Especie();
                                    aux2.Add(wetar);
                                    MessageBox.Show("Ha nacido un dorvalo");
                                }
                                else
                                {
                                    Taplan taplan = new Taplan(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                                    hayBitmon[fila, columna] = true;
                                    matrizBotones[fila, columna].Text = taplan.Especie();
                                    aux2.Add(taplan);
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
                                } else if (bits.Muere())
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
            foreach(Bitmon bit in aux2)
            {
                aux.Add(bit);
            }
            foreach(Bitmon bit in bithalla)
            {
                aux.Remove(bit);
            }
            listaBitmons = aux;
        }

                

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bitmons muertos: " + bithalla.Count);
            int wetar = 0;
            int dorvalo = 0;
            int doti = 0;
            int ent = 0;
            int gofue = 0;
            int taplan = 0;

            foreach(Bitmon bit in listaBitmons)
            {
                if(bit.Especie()== "🐳")
                {
                    wetar += 1;
                }
                else if (bit.Especie() == "🐍")
                {
                    taplan += 1;
                }else if (bit.Especie()== "🐉")
                {
                    gofue += 1;

                }else if (bit.Especie()== "🌵")
                {
                    ent += 1;

                }else if (bit.Especie()== "🦄")
                {
                    doti += 1;

                }
                else
                {
                    dorvalo += 1;
                }
            }
            MessageBox.Show(" Cantidad de wetar: " + wetar + "\n Cantidad de doti: " + doti + "\n Cantidad de dorvalo: " + dorvalo + "\n Cantidad de ent: " + ent + "\n Cantidad de taplan: " + taplan);
            

        }

        //button 2, mes siguiente
    }
}