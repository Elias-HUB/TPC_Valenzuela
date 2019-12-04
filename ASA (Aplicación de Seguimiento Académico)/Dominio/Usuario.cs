using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASA.Models;

namespace Dominio
{
    public class Usuario
    {
        public string Clave { get; set; }
        public Docente Docente { get; set; }
    }
}
