using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Docente : Persona
    {
        public long Legajo { get; set; }        
        //public Boolean Estado { get; set; }
        //public TipoPerfil TipoPerfil { get; set; }
    }
}