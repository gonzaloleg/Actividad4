using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SolicitudInscripcion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Curso> cursosElegidos = new List<Curso>();
            List<Curso> cursosAlternativosElegidos = new List<Curso>();

            Console.WriteLine("¿Con qué alumno desea ingresar?");
            int opcion = Validaciones.ValidarOpcion("Ingrese número de registro:", 100000, 999999);
            
            string registroElegido = opcion.ToString();

            Alumno unAlumno = new Alumno();
            unAlumno.LeerMaestroAlumnos(registroElegido);

            string archivo = opcion + ".txt";

            if (File.Exists(archivo))
            {
                Console.WriteLine("El alumno ya realizó la inscripción para este período. Terminando programa.");
                Console.ReadKey();
                System.Environment.Exit(0);
            }            

                Console.ReadKey();

            Carrera unaCarrera = new Carrera();
            unaCarrera.LeerMaestroCarreras();
            Console.WriteLine("\nLISTADO DE CARRERAS");
            Console.WriteLine("-------------------");
            int opcion2 = unaCarrera.VerCarrera();
            Materia unaMateria = new Materia();
            Console.WriteLine("\nLISTADO DE MATERIAS");
            Console.WriteLine("-------------------");
            unaMateria.ElegirMaestro(opcion2);            
            var listaAprobadas = unAlumno.Inicializar();
            
            Materia.VerMateriaPorCarrera();
            bool salir = false;
            int cantidad = 1;

            while (!salir && cantidad <= 4)
            {
                Console.WriteLine("\n¿En qué materia desea inscribirse?");

                int codigoMateria = Validaciones.ValidarOpcion("\nIngrese código de materia", 1, 2000);
                if (!unaMateria.BuscarCodigo(codigoMateria))
                {
                    Console.WriteLine("\nCodigo de materia inválido.");
                } 
                if (listaAprobadas.Contains(codigoMateria))
                {
                    Console.WriteLine("\nNo puede anotarse en una materia previamente aprobada. Seleccione nuevamente.");
                    continue;
                }


                if (!unaMateria.BuscarCodigo(codigoMateria))
                {
                    Console.WriteLine("\nMateria no encontrada");
                    continue;
                }
                var listaCorrelativas = unaMateria.VerificarCorrelativas(codigoMateria);
                int contador = 0;

                if (listaCorrelativas != null)
                {                
                    for (int i = 0; i < listaCorrelativas.Count; i++)
                    {
                        for (int q = 0; q < listaAprobadas.Count; q++)
                        {
                            if (listaCorrelativas[i] == listaAprobadas[q])
                            {
                                contador++;
                            }
                        }
                    }
                    if (contador == listaCorrelativas.Count)
                    {
                        Console.WriteLine("\nCursos disponibles para eleccion:");
                    }
                    if (contador != listaCorrelativas.Count && !unAlumno.GetUltimas4())
                    {
                        Console.WriteLine("\nNo cuenta con las materias correlativas requeridas aprobadas para anotarse. Seleccione otra materia.");
                        continue;
                    }
                    if (contador != listaCorrelativas.Count && unAlumno.GetUltimas4())
                    {
                        Console.WriteLine("\nNota:");
                        Console.WriteLine("----");
                        Console.WriteLine("No se aplican correlativas por encontrarse en las ultimas 4 materias. Elija curso:");
                    }
                }
                

                Curso unCurso = new Curso();
                unCurso.LeerMaestroAlumnos();
                Console.WriteLine("\nCursos disponibles:");
                unCurso.VerCursoPorMateria(codigoMateria);
                unCurso.ListarCursosElegidos();
                cursosElegidos.AddRange(unCurso.CargarCursoElegido());
                cursosAlternativosElegidos.AddRange(unCurso.CargarCursoAlternativoElegido());



                Console.WriteLine("\n¿Desea anotarse en otra materia?");
                int otra = Validaciones.ValidarOpcion("1 - SI       2 - NO", 1, 2);

                if (otra == 1 && cantidad <= 2)
                {
                   
                    cantidad++;
                    _ = otra == 1 && otra > 4;

                    Console.WriteLine("\n Recordatorio: No puede inscribirse a más de 3 materias, salvo que se encuentre en las ultimas 4.");
                    continue;                    
                }
                if (otra == 1 && cantidad == 3 && !unAlumno.GetUltimas4())
                {
                    Console.WriteLine("No puede anotarse a mas de 3 materias.");
                    salir = true;
                }
                if(otra == 1 && cantidad == 3 && unAlumno.GetUltimas4())
                {
                    Console.WriteLine("Alumno se encuentra en las ultimas 4. Se le permite anotarse a un curso extra.");
                    cantidad++;
                    continue;
                }
                if (otra == 1 && cantidad >= 4)
                {
                    Console.WriteLine("No puede anotarse a mas cursos.");                    
                    salir = true;
                }
                if (otra == 2)
                {
                    salir = true;
                }
            }

            Console.WriteLine("\nSe solicitará inscripción a los siguientes cursos:");
            Console.WriteLine("Cursos originales:");
            foreach (Curso curso in cursosElegidos)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n{curso.CodigoCurso}-{curso.NombreMateria}-{curso.Docente}-{curso.Dias}-{curso.Horario}-{curso.Sede}");
                Console.ResetColor();
            }
            Console.WriteLine("\nCursos alternativos:");
            foreach (Curso curso in cursosAlternativosElegidos)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n{curso.CodigoCurso}-{curso.NombreMateria}-{curso.Docente}-{curso.Dias}-{curso.Horario}-{curso.Sede}");
                Console.ResetColor();
            }

            Console.WriteLine("\nSolicitud de inscripción finalizada, presione cualquier tecla para imprimir el comprobante y terminar.");
            Console.ReadKey();
            var datosAlumno = unAlumno.GetDatosAlumno();

            foreach (Alumno alumno in datosAlumno)
            {
                var random = new Random();
                int numRandom = random.Next(10000);
                Inscripcion unaInscripcion = new Inscripcion(alumno.NumeroRegistro, alumno.Nombre, alumno.Apellido, numRandom);
                Console.ReadKey();
                unaInscripcion.ImprimirComprobante(unaInscripcion, cursosElegidos, cursosAlternativosElegidos);

            }           


        }
    }
}
