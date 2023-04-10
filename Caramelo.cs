using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSnake
{
    public class Caramelo
    {
        public Posicion Posicion { get; set; }
        public Caramelo(int x, int y)
        {
            Posicion = new Posicion(x, y);
            
        }
        public void DibujarCaramelo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Util.DibujarPosicion(Posicion.X, Posicion.Y, "o");
            Console.ResetColor();
        }

        public static Caramelo CrearCaramelo(Serpiente serpiente, Tablero tablero)
        {
            bool carameloValido = false;
            int x = 0;
            int y = 0;

            do
            {
                Random random = new Random();
                x = random.Next(1, tablero.Anchura -1 );
                y = random.Next(1, tablero.Altura - 1);
                carameloValido = serpiente.PosicionEnCola(x, y);
            } while (carameloValido);

            tablero.ContieneCaramelo = true;
            return new Caramelo(x, y);
        }
    }
}
