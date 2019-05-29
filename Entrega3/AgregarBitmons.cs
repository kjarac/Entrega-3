using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class AgregarBitmons
    {
        public void AddBitmon(Button[,] matrizBotones, bool[,] hayBitmon, int CELDAS, int COLUMNAS, int FILAS, int cantidadB)
        {

            // Terreno

            for (int fila = 0; fila < FILAS; fila++)
                for (int columna = 0; columna < COLUMNAS; columna++)
                    hayBitmon[fila, columna] = false;

            // Se crea el terreno para cada celda, al azar
            Random random = new Random();
            int celda = 0;

            while (cantidadB < CELDAS)
            {
                int fila = random.Next(FILAS);
                int columna = random.Next(COLUMNAS);
                bool existeUnBitmon = hayBitmon[fila, columna];
                int tipoTerreno = random.Next(1, 7);
                if (!existeUnBitmon)
                {
                    if (tipoTerreno == 1)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Dr";
                    }
                    else if (tipoTerreno == 2)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Do";
                    }
                    else if (tipoTerreno == 3)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "E";
                    }
                    else if (tipoTerreno == 4)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "G";
                    }
                    else if (tipoTerreno == 5)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "T";
                    }
                    else if (tipoTerreno == 6)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "W";
                    }

                    celda++;

                }
            }

        }
    }
}