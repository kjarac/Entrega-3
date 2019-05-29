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
            List<string> bitmonsiniciales = new List<string>();

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
                        bitmonsiniciales.Add("Dr");
                        string celda = matrizBotones[fila, columna].Text;
                    }
                    else if (tipoTerreno == 2)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "Do";
                        bitmonsiniciales.Add("Do");
                        string celda = matrizBotones[fila, columna].Text;
                    }
                    else if (tipoTerreno == 3)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "E";
                        bitmonsiniciales.Add("E");
                        string celda = matrizBotones[fila, columna].Text;
                    }
                    else if (tipoTerreno == 4)
                    {
                        hayBitmon[fila, columna] = true;
                        
                        matrizBotones[fila, columna].Text = "G";
                        bitmonsiniciales.Add("G");
                        string celda = matrizBotones[fila, columna].Text;
                    }
                    else if (tipoTerreno == 5)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "T";
                        bitmonsiniciales.Add("T");
                        string celda = matrizBotones[fila, columna].Text;
                    }
                    else if (tipoTerreno == 6)
                    {
                        hayBitmon[fila, columna] = true;
                        matrizBotones[fila, columna].Text = "W";
                        bitmonsiniciales.Add("W");
                        string celda = matrizBotones[fila, columna].Text;
                    }

                    celda++;

                }
            }

        }
        
        private void Reproduccion(string celda)
        {

        }
    }
}
