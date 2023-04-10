using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSnake
{
    public class Tablero
    {
        public readonly int Altura;
        public readonly int Anchura;
        public bool ContieneCaramelo;
        public Tablero(int altura, int anchura)
        {
            Altura = altura;
            Anchura = anchura;
            ContieneCaramelo = false;
        }
        public void DibujarTablero()
        {
            for (int i = 0; i <= Altura; i++) 
            {
                //Linea derecha
                Util.DibujarPosicion(Anchura, i, "x");
                Util.DibujarPosicion(0, i, "x");
            }
            for (int i = 0; i <= Anchura; i++)
            {
                Util.DibujarPosicion(i, 0, "x");
                Util.DibujarPosicion(i, Altura,"x");
            }
        }
    }
}
