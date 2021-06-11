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
                
                if (!int.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("\nPor favor ingrese un número válido.");
                    res = -1;
                }
                if (res < min || res > max)
                {
                    Console.WriteLine($"\nNo puede ingresar un valor menor a: {min} \nNo puede ingresar un valor mayor a: {max}");
                }

            } while (res < min || res > max);

            return res;
        }

        internal static int ValidarOpcion2(string mensaje, int min, int max, int prohibido)
        {
            int res;

            do
            {

                Console.WriteLine(mensaje);
                //Console.WriteLine($"\nNo puede ingresar un valor menor a: {min} \nNo puede ingresar un valor mayor a: {max}");

                if (!int.TryParse(Console.ReadLine(), out res))
                {
                    Console.WriteLine("\nPor favor ingrese un número válido.");
                    res = -1;
                }
                if (res == prohibido)
                {
                    Console.WriteLine("\nNo puede seleccionar el curso original como opción alternativa.");
                    res = -1;
                }

            } while (res < min || res > max || res == prohibido);            

            return res;
        }

    }
}