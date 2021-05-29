using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolicitudInscripcion
{
    internal class Alumno
    {
        public int NumeroRegistro { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public int DNI { get; }
        public string Email { get; }
        public int CodigoCarrera { get; }
        public bool Ultimas4 { get; }  
        public string MateriasAprobadas { get; }

        const string maestroAlumnos = "maestroAlumnos.txt";

        List<Alumno> alumnos = new List<Alumno>();

        public Alumno(string linea)
        {
            var datos = linea.Split('|');
            NumeroRegistro = int.Parse(datos[0]);
            Nombre = datos[1];
            Apellido = datos[2];
            DNI = int.Parse(datos[3]);
            Email = datos[4];
            CodigoCarrera = int.Parse(datos[5]);
            Ultimas4 = bool.Parse(datos[6]);
            var tabs = linea.Count(c => c == '|');

            for (int i = 6; i == tabs; i++)
            {
                MateriasAprobadas = datos[i] + "-" ;
            }

        }



        internal static void Inicializar()
        {
            throw new NotImplementedException();
        }
    }
}