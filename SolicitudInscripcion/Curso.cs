using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolicitudInscripcion
{
    internal class Curso
    {
        public int CodigoMateria { get; }
        public int CodigoCurso { get; }
        public string NombreMateria { get; }
        public string Docente { get; }
        public string Dias { get; }
        public string Horario { get; }
        public string Sede { get; }
        
        const string maestroCursos = "maestroCursos.txt";

        public List<Curso> cursos = new List<Curso>();

        public List<Curso> cursosElegidos = new List<Curso>();
        public Curso(string linea)
        {
            var datos = linea.Split('|');
            CodigoMateria = int.Parse(datos[0]);
            CodigoCurso = int.Parse(datos[1]);
            NombreMateria = datos[2];
            Docente = datos[3];
            Dias = datos[4];
            Horario = datos[5];
            Sede = datos[6];
        }

        public Curso()
        {

        }

        public void VerCursoPorMateria(int codigoMateria)
        {
            List<int> listaAuxiliar2 = new List<int>();
            for (int i = 0; i < cursos.Count ; i++)
            {
                if (codigoMateria == cursos[i].CodigoMateria)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;                    
                    Console.WriteLine("Codigo \tNombre Materia\t\t\tDocente\t\tDia\tHorario\tSede");
                    Console.WriteLine($"{cursos[i].CodigoCurso}\t{cursos[i].NombreMateria}\t{cursos[i].Docente}\t{cursos[i].Dias}\t{cursos[i].Horario}\t{cursos[i].Sede}");
                    Console.ResetColor();
                    listaAuxiliar2.Add(cursos[i].CodigoCurso);
                }
            }            

            int opcionCurso = Validaciones.ValidarOpcion("\nIngrese código del curso en el cual desea anotarse:", listaAuxiliar2.Min(), listaAuxiliar2.Max());
            
            for (int i = 0; i < cursos.Count; i++)
            {
                if (opcionCurso == cursos[i].CodigoCurso)
                {
                    cursosElegidos.Add(cursos[i]);
                }
            }
        }

        public List<Curso> CargarCursoElegido()
        {
            List<Curso> listaAuxiliar = new List<Curso>();
            foreach (Curso curso in cursosElegidos)
            {
                listaAuxiliar.Add(curso);
            }

            return listaAuxiliar;
        }

        public void ListarCursosElegidos()
        {
            foreach (Curso curso in cursosElegidos)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nEl curso seleccionado es el siguiente:");
                Console.WriteLine($"{curso.CodigoCurso}\t{curso.NombreMateria}\t\t{curso.Docente}\t{curso.Dias}\t{curso.Horario}\t{curso.Sede}");
                Console.ResetColor();
            }
        }

        public void LeerMaestroAlumnos()
        {
            if (File.Exists(maestroCursos))
            {
                using (var reader = new StreamReader(maestroCursos))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unCurso = new Curso(linea);
                        cursos.Add(unCurso);
                    }
                }
            }

        }
    }
}