using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class AgregarBitmons
    {
        Random random = new Random();
        List<Bitmon> bitmons = new List<Bitmon>();
        public List<Bitmon> GetBitmons()
        {
            return bitmons;
        }
        public List<Bitmon> AddListaBitmon(List<string> listaBitmon,Button[,] matrizBotones, int COLUMNAS, int FILAS, bool[,] hayBitmon)
        {
            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                    hayBitmon[fila, columna] = false;

            // Se crea el terreno para cada celda, al azar
                List<Bitmon> bitmons = new List<Bitmon>();

                int cantidadDeHijos = 0;
                foreach (string bit in listaBitmon)
                {
                    int fila = random.Next(FILAS);
                    int columna = random.Next(COLUMNAS);
                    bool existeUnBitmon = hayBitmon[fila, columna];
                    int tiempoDeVida = random.Next(1, 6);
                    int puntosDeVida = random.Next(10, 250);
                    int puntosDeAtaque = random.Next(30, 101);
                    if (!existeUnBitmon)
                    {
                        if (bit == "🦅")
                        {
                            Dorvalo dorvalo = new Dorvalo(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = dorvalo.Especie();
                            dorvalo.CambioTerreno(matrizBotones);
                            bitmons.Add(dorvalo);

                        }
                        else if (bit== "🦄")
                        {
                            Doti doti = new Doti(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = doti.Especie();
                            doti.CambioTerreno(matrizBotones);
                            bitmons.Add(doti);

                        }
                        else if (bit== "🌵" || (matrizBotones[fila, columna].BackColor != Color.Red && matrizBotones[fila, columna].BackColor != Color.Brown))
                        {
                            Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = ent.Especie();
                        ent.CambioTerreno(matrizBotones);
                            bitmons.Add(ent);
                        }
                        else if (bit== "🐉")
                        {
                            Gofue gofue = new Gofue(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = gofue.Especie();
                             gofue.CambioTerreno(matrizBotones);
                            bitmons.Add(gofue);
                        }

                        else if (bit=="🐳" && matrizBotones[fila, columna].BackColor == Color.Aqua)
                        {
                            Wetar wetar = new Wetar(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = wetar.Especie();
                        wetar.CambioTerreno(matrizBotones);
                            bitmons.Add(wetar);
                        }
                        else
                        {
                            Taplan taplan = new Taplan(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                            hayBitmon[fila, columna] = true;
                            matrizBotones[fila, columna].Text = taplan.Especie();
                        taplan.CambioTerreno(matrizBotones);
                            bitmons.Add(taplan);
                        }


                    
                }


            }

            return bitmons;
        }
        public List<Bitmon>  AddBitmon(Button[,] matrizBotones,  int COLUMNAS, int FILAS, int BITMONS, bool [,] hayBitmon)
        {

            // Terreno
         
            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                    hayBitmon[fila, columna] = false;

            // Se crea el terreno para cada celda, al azar
            Random random = new Random();
            int cantidadB = 0;
            while (cantidadB < BITMONS)
            {
                
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                bool existeUnBitmon = hayBitmon[fila, columna];
                int tipoBitmon = random.Next(1, 7);
                int tiempoDeVida = random.Next(1,6);
                int puntosDeVida = random.Next(10, 250);
                int puntosDeAtaque = random.Next(30, 101);
                int cantidadDeHijos = 0;


                if (!existeUnBitmon)
                {
                    if (tipoBitmon == 1)
                    {
                        Dorvalo dorvalo = new Dorvalo(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = dorvalo.Especie();
                        dorvalo.CambioTerreno(matrizBotones);
                        bitmons.Add(dorvalo);

                    }
                    else if (tipoBitmon == 2)
                    {
                        Doti doti = new Doti(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text =doti.Especie();
                        doti.CambioTerreno(matrizBotones);
                        bitmons.Add(doti);

                    }
                    else if (tipoBitmon == 3 || (matrizBotones[fila,columna].BackColor!=Color.Red && matrizBotones[fila, columna].BackColor != Color.Brown))
                    {
                        Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = ent.Especie();
                        ent.CambioTerreno(matrizBotones);
                        bitmons.Add(ent);
                    }
                    else if (tipoBitmon == 4)
                    {
                        Gofue gofue = new Gofue(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = gofue.Especie();
                        gofue.CambioTerreno(matrizBotones);
                        bitmons.Add(gofue);
                    }
                   
                    else if (tipoBitmon == 5 && matrizBotones[fila, columna].BackColor==Color.Aqua)
                    {
                        Wetar wetar = new Wetar(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = wetar.Especie();
                        wetar.CambioTerreno(matrizBotones);
                        bitmons.Add(wetar);
                    }
                    else 
                    {
                        Taplan taplan = new Taplan(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = taplan.Especie();
                        taplan.CambioTerreno(matrizBotones);
                        bitmons.Add(taplan);
                    }

                    cantidadB++;

                }
                
            }

            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    matrizBotones[fila, columna].Enabled = true;

                }
            return bitmons;
        }


       
    }
}