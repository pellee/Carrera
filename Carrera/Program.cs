using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    class Program
    {
        static void Main(string[] args)
        {
            var carrera = new Carrera();
            char opc = ' ';

            do {
                Console.WriteLine("PARA SALIR PRESIONE N");

                Console.WriteLine("1>Crear Equipo\n2>Crear correrdor\n3>Crear etapa");

                opc = char.Parse(Console.ReadLine());
                opc = char.ToUpper(opc);

                switch (opc)
                {
                    case '1':
                        carrera.CrearEquipo();
                        break;
                    case '2':
                        carrera.CrearCorredor();
                        break;
                    case '3':
                        carrera.CrearEtapa();
                        break;
                }
            } while (opc != 'N');

            carrera.InicioCarrera();
        }
    }
}
