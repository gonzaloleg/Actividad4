using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudInscripcion
{
    internal class Inscripcion
    {
        public List<Curso> cursosSolicitados = new List<Curso>();
        public int NumeroRegistro { get;}
        public string Nombre { get; }
        public string Apellido { get; }
        public int CodigoInscripcion { get; }

        public Inscripcion(int nroRegistro, string nombre, string apellido, int codigoInscripcion)
        {
            NumeroRegistro = nroRegistro;
            Nombre = nombre;
            Apellido = apellido;
            CodigoInscripcion = codigoInscripcion;
        }
      
        public void ImprimirComprobante(Inscripcion unaInscripcion, List<Curso> cursos)
        {
            Console.Clear();
            Console.WriteLine("COMPROBANTE DE INSCRIPCION");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Nro Registro: {unaInscripcion.NumeroRegistro}");
            Console.WriteLine($"{unaInscripcion.Nombre} {unaInscripcion.Apellido}");
            Console.WriteLine($"Codigo Inscripcion #{unaInscripcion.CodigoInscripcion}");

            Console.WriteLine("Cursos:");
            Console.WriteLine("Codigo \tNombre Materia\t\t\tDocente\t\tDia\tHorario\tSede");
            foreach (Curso curso in cursos)
            {
                Console.WriteLine($"\n{curso.CodigoCurso}-{curso.NombreMateria}-{curso.Docente}-{curso.Dias}-{curso.Horario}-{curso.Sede}");
            }        
        }
    }
}
