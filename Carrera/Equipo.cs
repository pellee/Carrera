﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrera
{
    class Equipo
    {
        public int Id { get; set; }
        public string NombreEqui { get; set; }
        public double PromEqui { get; set; } = 0;


        public void PromEquipo(List<Corredor> corredores)
        {
            int i = 0;

            foreach (var c in corredores)
            {
                if (Id == c.RefEquipo.Id) {
                    PromEqui += c.Tiempo;
                    i++;
                }
            }

            PromEqui = PromEqui / i;
        }


    }
}
