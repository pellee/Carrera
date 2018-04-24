using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    class Carrera
    {
        List<Equipo> equipos = new List<Equipo>();
        List<Corredor> corredores = new List<Corredor>();
        Etapa[] etapas = new Etapa[10];


        public void CrearEquipo()
        {
            var equipo = new Equipo();

            Console.WriteLine("Ingrese el nombre del equipo; ");
            equipo.NombreEqui = Console.ReadLine();

            equipo.Id = equipos.Count + 1;

            equipos.Add(equipo);
        }

        private Equipo BuscarEquipo(string nombreEqui)
        {
            foreach (var e in equipos) {
                if (nombreEqui == e.NombreEqui)
                    return e;
            }

            return null;
        }

        public void CrearCorredor()
        {
            var corredor = new Corredor();
            var aux = new Equipo();
            string nombreEqui = "";

            Console.WriteLine("Ingrese nombre del corredor: ");
            corredor.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido de corredor: ");
            corredor.Apellido = Console.ReadLine();

            corredor.Id = corredores.Count + 1;

            do {
                Console.WriteLine("Ingrese nombre del equipo");
                nombreEqui = Console.ReadLine();

                aux = BuscarEquipo(nombreEqui);

                if (aux != null)
                    corredor.RefEquipo = aux;
            } while (aux == null);

            corredores.Add(corredor);
        }

        private int BuscarLugarEtapa()
        {
            for (int i = 0; i < etapas.Length; i++) {
                if (etapas[i] == null)
                    return i;
            }

            return -1;
        }

        public void CrearEtapa()
        {
            var etapa = new Etapa();
            int i = 0;

            Console.WriteLine("Ingrese fecha de la etapa: ");
            etapa.FechaEtapa = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese kilometros de la etapa: ");
            etapa.KilometroEtapa = int.Parse(Console.ReadLine());

            i = BuscarLugarEtapa();

            if (i != -1)
                etapas[i] = etapa;
            else
                Console.WriteLine("Ya estan todas las etapas");
        }

        private Corredor BuscarGanador()
        {
            var aux = new Corredor();

            for (int i = 0; i < corredores.Count; i++)
            {

                if (i == 0)
                    aux = corredores[i];

                if (aux.Tiempo > corredores[i].Tiempo)
                    aux = corredores[i];
            }

            return aux;
        }

        public void InicioCarrera()
        {
            foreach (var e in etapas) {
                var aux = new Corredor();

                Console.WriteLine(e.FechaEtapa + "  " + e.KilometroEtapa);

                foreach (var c in corredores) {
                    Console.WriteLine("Ingrese el tiempo del corredor " + c.Nombre + " " + c.Apellido);
                    c.Tiempo = double.Parse(Console.ReadLine());
                }

                aux = BuscarGanador();

                Console.WriteLine("El ganador es: " + aux.Nombre + " del equipo " + aux.RefEquipo.NombreEqui);

                foreach (var eq in equipos) {
                    eq.PromEquipo(corredores);

                    Console.WriteLine("El promedio de carrera del equipo " + eq.NombreEqui + "  fue de: " + eq.PromEqui);
                }
            }
        }

    }
}
