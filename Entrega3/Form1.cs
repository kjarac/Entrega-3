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
      

        

        public Form1()
        {
            InitializeComponent();

          
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            var disenioPredeterminado = new GamePredeterminado();
            disenioPredeterminado.ShowDialog();
            
=======
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

>>>>>>> c1f905bbcc2afdb4bd84d3a2db0e3ae283e7bfaa
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var disenioPersonalizado = new Game(0,0);
            disenioPersonalizado.ShowDialog();
        }
    }
}