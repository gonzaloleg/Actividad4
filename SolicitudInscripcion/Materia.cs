using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolicitudInscripcion
{
    internal class Materia
    {       

        public static List<Materia> materias = new List<Materia>();
        public int CodigoMateria { get;  }
        public string NombreMateria { get; }
        public List<int> Correlativas { get; }

        public Materia()
        {

        }

        public Materia(string linea)
        {
            var datos = linea.Split('|');
            CodigoMateria = int.Parse(datos[0]);
            NombreMateria = datos[1];
            List<int> correlativas = new List<int>();
            
            var tabs = linea.Count(c => c == '|');
            if (tabs > 1)
            {
                for (int i = 2; i < tabs + 1; i++)
                {
                    correlativas.Add(int.Parse(datos[i]));
                }
                Correlativas = correlativas;
            }
        }

        internal void ElegirMaestro (int opcion)
        {
            string maestroElegido="";

            if (opcion == 1)
            {
                maestroElegido = "maestroSistemas.txt";
            }
            if (opcion == 2)
            {
                maestroElegido = "maestroContador.txt";
            }
            if (opcion == 3)
            {
                maestroElegido = "maestroAdministracion.txt";
            }
            if (opcion == 4)
            {
                maestroElegido = "maestroActuario.txt";
            }
            if (opcion == 5)
            {
                maestroElegido = "maestroActuario2.txt";
            }
            if (opcion == 6)
            {
                maestroElegido = "maestroEconomia.txt";
            }

            if (File.Exists(maestroElegido))
            {
                using (var reader = new StreamReader(maestroElegido))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unaMateria = new Materia(linea);
                        materias.Add(unaMateria);
                    }
                }
            }
        }

        public bool BuscarCodigo(int codigo)
        {
            int posicion = 0;
            bool encontrado = false;
            while (posicion < materias.Count && !encontrado)
            {
                if (materias[posicion].CodigoMateria == codigo)
                {
                    encontrado = true;
                }
                else
                {
                    posicion++;
                }
            }
            return encontrado;
        }



        internal static void VerMateriaPorCarrera()
        {
            Console.WriteLine("Codigo Materia - Nombre Materia");
            foreach (Materia materia in materias)
            {
                Console.WriteLine($"{materia.CodigoMateria}\t{materia.NombreMateria}");
            }
        }


    }
}