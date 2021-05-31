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
            string maestroElegido="";
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
            //Prueba para visualizar materias aprobadas de alumno elegido
            //unAlumno.Inicializar();
            var listaAprobadas = unAlumno.Inicializar();
            
            Materia.VerMateriaPorCarrera();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("¿En qué materia desea inscribirse?");

                int codigoMateria = Validaciones.ValidarOpcion("Ingrese código de materia", 1, 2000);
                if (!unaMateria.BuscarCodigo(codigoMateria))
                {
                    Console.WriteLine("Codigo de materia inválido.");
                } 
                if (listaAprobadas.Contains(codigoMateria))
                {
                    Console.WriteLine("No puede anotarse en una materia previamente aprobada. Seleccione nuevamente.");
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
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        Console.WriteLine("No cuenta con las materias correlativas requeridas aprobadas para anotarse. Seleccione otra materia.");
                        continue;
                    }
                }
                

                Curso unCurso = new Curso();
                unCurso.LeerMaestroAlumnos();                
                unCurso.VerCursoPorMateria(codigoMateria);
                unCurso.ListarCursosElegidos();

                /*
                int contador2 = 1;
                Console.WriteLine("¿Desea anotarse en otra materia?");
                int otra = Validaciones.ValidarOpcion("1 - SI       2 - NO", 1, 2); 
                
                if (otra == 1 && contador2 <= 3)
                {
                    continue;
                }*/


            }

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
