using System;

namespace SolicitudInscripcion
{
    internal class Validaciones
    {
        internal static int ValidarOpcion(string mensaje, int min, int max)
        {
            int res;

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine($"\nNo puede ingresar un valor menor a: {min} \nNo puede ingresar un valor mayor a: {max}");

                if (!int.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("\nPor favor ingrese un número válido.");
                    res = -1;
                }

            } while (res < min || res > max);

            return res;
        }
        
    }
}