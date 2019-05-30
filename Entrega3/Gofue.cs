using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Gofue : Bitmon
    {
        bool afin;
        public override void CambioTerreno(Button[,] matrizBotones)
        {
            if (afin)
            {
                if ((matrizBotones[posicionX, posicionY].BackColor == Color.LightGreen))
                {
                    matrizBotones[posicionX, posicionY].BackColor = Color.Brown;
                }
                if ((matrizBotones[posicionX, posicionY].BackColor == Color.White))
                {
                    matrizBotones[posicionX, posicionY].BackColor = Color.Aqua;
                }
            }
        }
        public Gofue(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Gofue";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }

        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.Especie() == "Taplan" || bitmon.Especie() == "Ent")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }
       /* public override void Desplazamiento(Terreno mapa)
        {
            Random random = new Random();
            while (true)
            {
                int rnd = random.Next(3);
                if (rnd == 0 && posicionX != mapa.Ancho()) // con 0 se mueve hacia la derecha
                {
                    posicionX += 1;
                    break;
                }
                else if (rnd == 1 && posicionX != 0) // con 1 se mueve hacia la izquierda
                {
                    posicionX -= 1;
                    break;
                }
                else if (rnd == 2 && posicionY != 0) //con 2 se mueve hacia arriba
                {
                    posicionY -= 1;
                    break;
                }
                else if (rnd == 3 && posicionY != mapa.Largo())// con 3 se mueve hacia abajo            
                {
                    posicionY += 1;
                    break;
                }
                else
                {
                    continue;
                }

            }
        //}*/
        public override void AfinidadTerreno(Button[,] matrizBotones)
        {
            if (matrizBotones[posicionX,posicionY].BackColor==Color.Red || matrizBotones[posicionX, posicionY].BackColor == Color.Brown)
            {
                afin = true;
            }
            else
            {
                afin = false;
            }
        }


    }
}
