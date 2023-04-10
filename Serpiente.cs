using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSnake
{
    public class Serpiente
    {
        List<Posicion> Cola { get; set; }
        public Direccion Direccion { get; set; }
        public int Puntos { get; set; }
        public bool EstaViva { get; set; }
        public Serpiente(int x, int y)
        {
            Posicion posicionInicial = new Posicion(x, y);
            Cola = new List<Posicion>() { posicionInicial };
            Direccion = Direccion.Abajo;
            Puntos = 0;
            EstaViva = true;
        }
        public void DibujarSerpiente()
        {
            foreach(Posicion posicion in Cola)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Util.DibujarPosicion(posicion.X, posicion.Y, "x");
                Console.ResetColor();
            }
        }
        public void ComprobarMorir(Tablero tablero)
        {
            //Si nos chocamos contra nosotros
            Posicion primeraPosicion = Cola.First();
            EstaViva = !((Cola.Count(a => a.X == primeraPosicion.X && a.Y == primeraPosicion.Y) > 1) 
                || CabezaEstaEnPared(tablero, Cola.First()));
        }

        //Si la primera posicion esta en cualquiera de los muros, morimos
        private bool CabezaEstaEnPared(Tablero tablero, Posicion primeraPosicion) 
        {
            return primeraPosicion.Y == 0 || primeraPosicion.Y == tablero.Altura 
                || primeraPosicion.X == 0 || primeraPosicion.X == tablero.Anchura;
        }
        public void Moverse(bool haComido)
        {
            List<Posicion> nuevaCola = new List<Posicion>();
            nuevaCola.Add(ObtenerNuevaPrimeraPosicion());
            nuevaCola.AddRange(Cola);
            if (!haComido)
            {
                nuevaCola.Remove(nuevaCola.Last());
            }
            Cola = nuevaCola;
        }
        private Posicion ObtenerNuevaPrimeraPosicion()
        {
            int x = Cola.First().X;
            int y = Cola.First().Y;
            switch (Direccion)
            {
                case Direccion.Abajo:
                    y += 1;
                    break;
                case Direccion.Arriba:
                    y -= 1;
                    break;
                case Direccion.Derecha:
                    x += 1;
                    break;
                case Direccion.Izquierda:
                    x -= 1;
                    break;
            }
            return new Posicion(x, y);
        }
        public bool PosicionEnCola(int x, int y)
        {
            return Cola.Any(a => a.X == x && a.Y == y);
        }
        public bool ComerCaramelo(Caramelo caramelo, Tablero tablero)
        {
            if(PosicionEnCola(caramelo.Posicion.X, caramelo.Posicion.Y))
            {
                Puntos += 10;
                //quitar caramelo o generar uno nuevo
                tablero.ContieneCaramelo = false;
                return true;
               
            }
            return false;  
            
        }
    }

}
