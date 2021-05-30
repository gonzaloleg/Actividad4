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
        const string maestroSistemas = "maestroSistemas.txt";
        const string maestroContador = "maestroContador.txt";
        const string maestroAdministracion = "maestroAdministracion.txt";
        const string maestroActuario = "maestroActuario.txt";
        const string maestroActuario2 = "maestroActuario2.txt";
        const string maestroEconomia = "maestroEconomia.txt";


        internal static void ElegirMaestro (int opcion)
        {
            string maestroElegido;

            if (opcion == 1)
            {
                maestroElegido = maestroSistemas;
            }
            if (opcion == 2)
            {
                maestroElegido = maestroContador;
            }
            if (opcion == 3)
            {
                maestroElegido = maestroAdministracion;
            }
            if (opcion == 4)
            {
                maestroElegido = maestroActuario;
            }
            if (opcion == 5)
            {
                maestroElegido = maestroActuario2;
            }
            if (opcion == 6)
            {
                maestroElegido = maestroEconomia;
            }
        }



        internal static void VerMateriaPorCarrera()
        {
            throw new NotImplementedException();
        }
    }
}