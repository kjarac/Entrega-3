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
                if (!existeUnBitmon)
                {
                    if (tipoBitmon == 1)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Dr";
                    }
                    else if (tipoBitmon == 2)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Do";
                    }
                    else if (tipoBitmon== 3)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "E";
                    }
                    else if (tipoBitmon == 4)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "G";
                    }
                    else if (tipoBitmon == 5)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "T";
                    }
                    else if (tipoBitmon == 6)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "W";
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
    }
}