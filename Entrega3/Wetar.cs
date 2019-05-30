using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Wetar : Bitmon
    {
        bool afin;
        public Wetar(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Wetar";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }


        public override void CambioTerreno(Button[,] matrizBotones)
        {
        }
        public override int Daño(Bitmon bitmon) //Daño, recibe el otro bitmon en la misma celda
        {
            if (bitmon.Especie() == "Gofue" || bitmon.Especie() == "Taplan")
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
        }*/
        public override void AfinidadTerreno( Button[,] matrizBotones) 
        {
            if (matrizBotones[posicionX, posicionY].BackColor == Color.Aqua)
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
