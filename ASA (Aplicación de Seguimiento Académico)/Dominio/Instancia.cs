using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Instancia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public TipoInstancia TipoInstancia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        //public Boolean Estado { get; set; }
    }
}