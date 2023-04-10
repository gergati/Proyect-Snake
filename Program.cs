// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

namespace ProyectoSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Tablero tablero = new Tablero(20, 20);

            Serpiente serpiente = new Serpiente(10, 10);
            Caramelo caramelo = new Caramelo(0, 0);
            bool haComido = false;

            do
            {
                Console.Clear();
                tablero.DibujarTablero();

                
                serpiente.ComprobarMorir(tablero);
                if (serpiente.EstaViva)
                {
                    serpiente.Moverse(haComido);
                    //Comprobamos si se comio el caramelo
                    haComido = serpiente.ComerCaramelo(caramelo, tablero);
                    //Dibujamos serpiente
                    serpiente.DibujarSerpiente();
                    if (!tablero.ContieneCaramelo)
                    {
                        caramelo = Caramelo.CrearCaramelo(serpiente, tablero);

                    }
                    //Dibujamos caramelo
                    caramelo.DibujarCaramelo();

                
                    //Leemos informacion
                    var sw = Stopwatch.StartNew();
                    while(sw.ElapsedMilliseconds <= 250)
                    {
                        serpiente.Direccion = leerMovimiento(serpiente.Direccion);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Util.DibujarPosicion(tablero.Anchura/2, tablero.Altura/2, "Game Over");
                    Util.DibujarPosicion(tablero.Anchura / 2, (tablero.Altura / 2) + 1, $"Puntuacion: {serpiente.Puntos}");
                    Console.ResetColor();
                }
            } while (serpiente.EstaViva);

            Console.ReadKey();
        }
        static Direccion leerMovimiento(Direccion movimientoActual)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if(key == ConsoleKey.UpArrow && movimientoActual != Direccion.Abajo)
                {
                    return Direccion.Arriba;
                }
                else if(key == ConsoleKey.DownArrow && movimientoActual != Direccion.Arriba)
                {
                    return Direccion.Abajo;
                }
                else if (key == ConsoleKey.LeftArrow && movimientoActual != Direccion.Derecha)
                {
                    return Direccion.Izquierda;
                }
                else if(key == ConsoleKey.RightArrow && movimientoActual != Direccion.Izquierda)
                {
                    return Direccion.Derecha;
                }
            }
            return movimientoActual;
        }
    }
}
