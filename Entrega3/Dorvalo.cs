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

      
       
        public Dorvalo(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "🦅";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }


        public override void CambioTerreno(Button[,] matrizBotones) // no cambia el terreno, solo lo habita
        {
        }
        public override void Desplazamiento(Button[,] matrizBotones)
        {

            int direccion = random.Next(4);
            if (direccion == 1 && posicionX<=5)//derecha
            {
                posicionX += 2;
                direccionMov = direccion;
            }
            else if (direccion == 2 && posicionX >= 2)//izquierda
            {
                posicionX -= 2;
                direccionMov = direccion;
            }
            else if (direccion == 0 && posicionY>= 2)//arriba
            {
                posicionY -= 2;
                direccionMov = direccion;
            }
            else if( direccion==3 && posicionY <= 5) //abajo
            {
                posicionY += 2;
                direccionMov = direccion;
            }
        }
        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.Especie() == "🌵" || bitmon.Especie() == "🐳")
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

        public override bool AfinidadBitmons(Bitmon bitmon)
        {
            if(bitmon.Especie() == "🌵" || bitmon.Especie() == "🐳" || bitmon.Especie() == "🌵")
            {
                afin = false;
                return afin;
            }
            else
            {
                afin = true;
                return afin;
            }
        }
    }
}
