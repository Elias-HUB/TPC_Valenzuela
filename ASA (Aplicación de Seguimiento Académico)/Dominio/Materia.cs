using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Materia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Carrera Carrera { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}