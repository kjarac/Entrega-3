using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Terreno
    {
        public void ConfiguracionTerreno(Button [,] matrizBotones, bool[,] terreno, int CELDAS, int COLUMNAS, int FILAS)
        {
           
                // Terreno
                for (int fila = 0; fila < FILAS; fila++)
                    for (int columna = 0; columna < COLUMNAS; columna++)
                        terreno[fila, columna] = false;

                // Se crea el terreno para cada celda, al azar
                Random random = new Random();
                int celda = 0;

                while (celda < CELDAS)
                {
                    int fila = random.Next(FILAS);
                    int columna = random.Next(COLUMNAS);
                    bool existeUnTerreno = terreno[fila, columna];
                    int tipoTerreno = random.Next(1, 6);
                    if (!existeUnTerreno)
                    {
                        if (tipoTerreno == 1)
                        {
                            terreno[fila, columna] = true;
                            matrizBotones[fila, columna].Text = "V";
                        }
                        else if (tipoTerreno == 2)
                        {
                            terreno[fila, columna] = true;
                            matrizBotones[fila, columna].Text = "A";
                        }
                        else if (tipoTerreno == 3)
                        {
                            terreno[fila, columna] = true;
                            matrizBotones[fila, columna].Text = "D";
                        }
                        else if (tipoTerreno == 4)
                        {
                            terreno[fila, columna] = true;
                            matrizBotones[fila, columna].Text = "N";
                        }
                        else if (tipoTerreno == 5)
                        {
                            terreno[fila, columna] = true;
                            matrizBotones[fila, columna].Text = "Vn";
                        }

                        celda++;

                    }
                }

                // Aqui se le cambia el color
                for (int fila = 0; fila < FILAS; fila++)
                    for (int columna = 0; columna < COLUMNAS; columna++)
                    {
                        if (matrizBotones[fila, columna].Text == "V")
                        {
                            matrizBotones[fila, columna].BackColor = Color.LightGreen;
                        }
                        if (matrizBotones[fila, columna].Text == "A")
                        {
                            matrizBotones[fila, columna].BackColor = Color.Aqua;
                        }
                        if (matrizBotones[fila, columna].Text == "D")
                        {
                            matrizBotones[fila, columna].BackColor = Color.Brown;
                        }
                        if (matrizBotones[fila, columna].Text == "N")
                        {
                            matrizBotones[fila, columna].BackColor = Color.White;
                        }
                        if (matrizBotones[fila, columna].Text == "Vn")
                        {
                            matrizBotones[fila, columna].BackColor = Color.Red;
                        }

                        matrizBotones[fila, columna].Enabled = true;
                        matrizBotones[fila, columna].Text = "";
                    }
        }

    }
}
