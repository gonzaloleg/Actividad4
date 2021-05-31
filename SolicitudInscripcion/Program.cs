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
            List<Curso> cursosElegidos = new List<Curso>();

            Console.WriteLine("¿Con qué alumno desea ingresar?");
            int opcion = Validaciones.ValidarOpcion("1 - 881861-Leguizamon Gonzalo\n2 - 890043-Rojas Maria\n3 - 894561-Forrester Mateo", 1, 3);
            string maestroElegido= "";
            if (opcion == 1)
            {
                maestroElegido = "maestroAlumno1.txt";
            }
            if (opcion == 2)
            {
                maestroElegido = "maestroAlumno2.txt";
            }
            if (opcion == 3)
            {
                maestroElegido = "maestroAlumno3.txt";

            }

            Alumno unAlumno = new Alumno();
            unAlumno.LeerMaestroAlumnos(maestroElegido);            
            
            Console.ReadKey();

            Carrera unaCarrera = new Carrera();
            unaCarrera.LeerMaestroCarreras();
            int opcion2 = unaCarrera.VerCarrera();
            Materia unaMateria = new Materia();
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

                //bool encontrado = true;

                if (!unaMateria.BuscarCodigo(codigoMateria))
                {
                    Console.WriteLine("Materia no encontrada");
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
                        Console.WriteLine("\nNo se aplican correlativas por encontrarse en las ultimas 4 materias. Elija curso:");
                    }
                }
                

                Curso unCurso = new Curso();
                unCurso.LeerMaestroAlumnos();                
                unCurso.VerCursoPorMateria(codigoMateria);
                unCurso.ListarCursosElegidos();

                

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

            



            Console.ReadKey();            

        }
    }
}
