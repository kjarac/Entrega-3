using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Doti : Bitmon
    {
        bool afin;
        public Doti(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Doti";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }

        public override void AfinidadTerreno( Button[,] matrizBotones)
        {
            afin = true; 
        }

        public override void CambioTerreno(Button[,] matrizBotones)
        {
            if (afin) {
                if ((matrizBotones[posicionX, posicionY].BackColor == Color.Aqua))
               {
                    matrizBotones[posicionX, posicionY].BackColor = Color.Red;
               }
                    
                
            }
        }


        public override int Daño(Bitmon bitmon)
        {
            return puntosDeAtaque;
        }

      /*  public override void Desplazamiento(Terreno mapa)
        {
            throw new NotImplementedException();
        }*/
    }
}
