using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudInscripcion
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno unAlumno = new Alumno();
            unAlumno.LeerMaestroAlumnos();
            unAlumno.Inicializar();
            Console.ReadKey();

            /*            
            Carrera.VerCarrera();
            Materia.VerMateriaPorCarrera();
            Curso.VerCursoPorMateria();
            Inscripcion.ImprimirComprobante();
            Console.WriteLine();*/

        }
    }
}
