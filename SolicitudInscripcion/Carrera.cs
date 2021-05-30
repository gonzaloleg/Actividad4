using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolicitudInscripcion
{
    internal class Carrera
    {
        public int CodigoCarrera { get; }
        public string NombreCarrera { get; }
        
        const string maestroCarreras = "maestroCarreras.txt";

        public static List<Carrera> carreras = new List<Carrera>();

        public Carrera (string linea)
        {
            var datos = linea.Split('|');
            CodigoCarrera = int.Parse(datos[0]);
            NombreCarrera = datos[1];
        }
        public Carrera()
        {

        }

        public void LeerMaestroCarreras()
        {
            if (File.Exists(maestroCarreras))
            {
                using (var reader = new StreamReader(maestroCarreras))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unaCarrera = new Carrera(linea);
                        carreras.Add(unaCarrera);
                    }
                }
            }
        }
        public int VerCarrera()
        {
            foreach (Carrera carrera in carreras)
            {
                Console.WriteLine($"{carrera.CodigoCarrera}-{carrera.NombreCarrera}");
            }

            Console.WriteLine();
            int opcion = Validaciones.ValidarOpcion("¿En qué carrera desea anotarse?", 1, 6);

            return opcion;
        }
    }
}