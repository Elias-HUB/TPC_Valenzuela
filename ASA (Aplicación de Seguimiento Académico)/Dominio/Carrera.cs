using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Carrera
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Universidad Universidad { get; set; }
        public Boolean Estado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}