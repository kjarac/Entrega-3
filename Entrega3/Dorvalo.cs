using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    class Dorvalo : Bitmon
    {

        bool afin;
       
        public Dorvalo(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Dorvalo";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }


        public override void CambioTerreno(Button[,] matrizBotones)
        {
        }
        public override void Desplazamiento()
        {
            Random random = new Random();

            int direccion = random.Next(4);
            if (direccion == 0&& posicionX<=6)//derecha
            {
                posicionX += 2;
                direccionMov = direccion;
            }
            else if (direccion == 1 && posicionX >= 2)//izquierda
            {
                posicionX -= 2;
                direccionMov = direccion;
            }
            else if (direccion == 2 && posicionY>= 2)//arriba
            {
                posicionY -= 2;
                direccionMov = direccion;
            }
            else if( direccion==3 && posicionY <= 6) //abajo
            {
                posicionY += 2;
                direccionMov = direccion;
            }
        }
        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.Especie() == "Ent" || bitmon.Especie() == "Wetar")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }
      
       
        public override bool AfinidadTerreno(Button[,] matrizBotones)
        {
            afin = true;
            return afin;
        }
    }
}
