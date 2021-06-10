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
        public List<int> MateriasAprobadas { get; }

        const string maestroAlumnos = "maestroAlumnos.txt";

        public static List<Alumno> alumnos = new List<Alumno>();

        public Alumno()
        {

        }

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

            List<int> materiasAprobadas = new List<int>();

            if (tabs > 6)
            { 
                for (int i = 7; i < tabs + 1; i++)
                {
                     materiasAprobadas.Add(int.Parse(datos[i]));
                }

                MateriasAprobadas = materiasAprobadas;
            }            

        }

        

        public void LeerMaestroAlumnos(string opcion)
        {
            if (File.Exists(maestroAlumnos))
            {
                using (var reader = new StreamReader(maestroAlumnos))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        if (String.IsNullOrEmpty(linea)) continue;
                        if (linea.IndexOf(opcion, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            var unAlumno = new Alumno(linea);
                            alumnos.Add(unAlumno);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Registro no encontrado en la base de datos. Programa terminado.");
                            Console.ReadKey();
                            System.Environment.Exit(0);
                        }
                        
                        
                    }
                }
            }
            
        }
        
        public List<int> Inicializar()
        {          

            foreach(Alumno a in alumnos)
            {
                return a.MateriasAprobadas;
            }
            return null;

        }

        public bool GetUltimas4()
        {
            foreach (Alumno alumno in alumnos)
            {
                if (alumno.Ultimas4 == true)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public List<Alumno> GetDatosAlumno()
        {
            List<Alumno> listaAuxiliar = new List<Alumno>();
            foreach (Alumno alumno in alumnos)
            {
                listaAuxiliar.Add(alumno);
            }

            return listaAuxiliar;
        }
       
    }
}