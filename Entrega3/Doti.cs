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
        int direccionMov;
        public Doti(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "🦄";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }

        public override bool AfinidadBitmons(Bitmon bitmon) // Se lleva bien con todos
        {
            afin = true;
            return afin;
        }

        public override bool AfinidadTerreno( Button[,] matrizBotones)
        {
            afin = true;
            return afin;
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

        public override void Desplazamiento(Button[,] matrizBotones)
        {
            int direccion = random.Next(4);
            if (AfinidadTerreno(matrizBotones))
                if (direccion == 1 && posicionX <= 6) // con 0 se mueve hacia la derecha
                {
                    posicionX += 1;
                    direccionMov = direccion;

                }
                else if (direccion == 0 && posicionX >= 1) // con 1 se mueve hacia la izquierda
                {
                    posicionX -= 1;
                    direccionMov = direccion;

                }
                else if (direccion == 2 && posicionY >= 1) //con 2 se mueve hacia arriba
                {
                    posicionY -= 1;
                    direccionMov = direccion;
                }
                else if (direccion == 3 && posicionY <= 6)// con 3 se mueve hacia abajo            
                {
                    posicionY += 1;
                    direccionMov = direccion;
                }
        }
}
    }

