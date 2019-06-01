using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Ent : Bitmon
    {
        
        public Ent(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Ent";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }
        public override bool AfinidadTerreno(Button[,] matrizBotones)
        {

            if (matrizBotones[posicionX, posicionY].BackColor == Color.White || matrizBotones[posicionX, posicionY].BackColor == Color.Brown  || matrizBotones[posicionX, posicionY].BackColor == Color.LightGreen)
            {
                afin = true;
                return afin;
            }
            else
            {
                afin = false;
                return afin;
            }
        }

        public override void CambioTerreno(Button[,] matrizBotones)
        {
            throw new NotImplementedException();
        }

        public override int Daño(Bitmon bitmon)
        {
            throw new NotImplementedException();
        }

        public override void Desplazamiento(Button[,] matrizBotones)
        {
        }
    }
}
