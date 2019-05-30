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
       
        public void AddBitmon(Button[,] matrizBotones, bool[,] hayBitmon,  int COLUMNAS, int FILAS, int BITMONS)
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
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text ="Dr" ;
                    }
                    else if (tipoBitmon == 2)
                    {
                        Doti doti = new Doti(tiempoDeVida,puntosDeVida,puntosDeAtaque,cantidadDeHijos,fila,columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = doti.Especie();
                    }
                    else if (tipoBitmon== 3)
                    {
                        Ent ent = new Ent(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = ent.Especie() ;
                    }
                    else if (tipoBitmon == 4)
                    {
                        Gofue gofue = new Gofue(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = gofue.Especie() ;
                    }
                    else if (tipoBitmon == 5)
                    {
                        Taplan taplan = new Taplan(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = taplan.Especie();
                    }
                    else if (tipoBitmon == 6)
                    {
                        Wetar wetar = new Wetar(tiempoDeVida, puntosDeVida, puntosDeAtaque, cantidadDeHijos, fila, columna);
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = wetar.Especie();
                    }

                    cantidadB++;

                }
            }

            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    matrizBotones[fila, columna].Enabled = true;

                }
        }

       /* public bool ExisteBitmon(int fila, int columna)
        {
            //return hayBitmon[fila, columna];
        }*/
    }
}