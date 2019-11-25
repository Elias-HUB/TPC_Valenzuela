using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Comentario
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public Instancia Instancia { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}