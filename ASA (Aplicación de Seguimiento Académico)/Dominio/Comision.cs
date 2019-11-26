using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Models
{
    public class Comision
    {
        public long Id { get; set; }
        public Materia Materia { get; set; }
        public Turno Turno { get; set; }
        public Cuatrimestre Cuatrimestre { get; set; }
        public List<Alumno> ListAlumnos { get; set; }
        public List<Instancia> ListInstancia { get; set; }
        public Docente docente { get; set; }
        public int Anio { get; set; }
        //public Boolean Estado { get; set; }

        public override string ToString()
        {
            return Anio.ToString();
        }
    }
}