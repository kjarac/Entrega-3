using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entrega3
{
    abstract class Bitmon
    {
        protected int tiempoDeVida;
        protected int puntosDeVida;
        protected int puntosDeAtaque;
        protected string especie;
        protected int cantidadDeHijos;
        protected int posicionX;
        protected int posicionY;
        protected int direccionMov;
        protected bool afin;

        public abstract void CambioTerreno(Button[,] matrizBotones);

        public abstract bool AfinidadTerreno(Button[,] matrizBotones);

        public abstract int Daño(Bitmon bitmon);

        public abstract void Desplazamiento(Button[,] matrizBotones);

        public int PosicionX()
        {
            return posicionX;
        }
        public int PosicionY()
        {
            return posicionY;
        }
        public string Especie()
        {
            return especie;
        }
        public bool Muere()
        {
            if (tiempoDeVida == 0 || puntosDeVida == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Reproducirse()
        {
            cantidadDeHijos += 1;
        }
        public void ReducirTiempoDeVida(int a)
        {
            tiempoDeVida = tiempoDeVida - a;
        }
        public void ReducirPuntosDeVida(int ataque)
        {
            puntosDeVida -= ataque;
        }

        public int ObtenerAtaque()
        {
            return puntosDeAtaque;
        }
       




    }
}
