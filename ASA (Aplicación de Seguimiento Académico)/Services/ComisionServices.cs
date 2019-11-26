using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesoDatos;
using ASA.Models;

namespace ASA.Services
{
    public class ComisionServices
    {
        public List<Models.Comision> Listar(int IdDocente)
        {
            List<Models.Comision> Listado = new List<Models.Comision>();
            Models.Comision Aux;
            DocenteServices docenteServices = new DocenteServices();
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Materia.Id, Materia.Nombre, Carrera.Id, Carrera.Nombre, Universidad.Id, Universidad.Nombre, Turno.Id, Turno.Nombre, Cuatrimestre.Id, Cuatrimestre.Nombre, Comision.Anio FROM  Comision inner join Materia on IdMateria = Materia.Id inner join Carrera on Carrera.Id = Materia.IdCarrera inner join Universidad on Universidad.Id = Carrera.IdUniversidad inner join Turno on  Turno.id = IdTurno inner join Cuatrimestre on IdCuatrimestre = Cuatrimestre.Id inner join Docente on IdDocente = Docente.Legajo where IdDocente = @IdDocente");
                Datos.agregarParametro("@IdDocente", IdDocente);
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Comision();
                    Aux.Id = Datos.Lector.GetInt64(0);

                    Aux.Materia = new Materia();
                    Aux.Materia.Id = Datos.Lector.GetInt64(1);
                    Aux.Materia.Nombre = Datos.Lector.GetString(2);

                    Aux.Materia.Carrera = new Carrera();
                    Aux.Materia.Carrera.Id = Datos.Lector.GetInt64(3);
                    Aux.Materia.Carrera.Nombre = Datos.Lector.GetString(4);

                    Aux.Materia.Carrera.Universidad = new Universidad();
                    Aux.Materia.Carrera.Universidad.Id = Datos.Lector.GetInt64(5);
                    Aux.Materia.Carrera.Universidad.Nombre = Datos.Lector.GetString(6);

                    Aux.Turno = new Turno();
                    Aux.Turno.Id = Datos.Lector.GetInt64(7);
                    Aux.Turno.Nombre = Datos.Lector.GetString(8);

                    Aux.Cuatrimestre = new Cuatrimestre();
                    Aux.Cuatrimestre.Id = Datos.Lector.GetInt64(9);
                    Aux.Cuatrimestre.Nombre = Datos.Lector.GetString(10);

                    Aux.Anio= Datos.Lector.GetInt32(11);

                    Aux.docente = new Docente();
                    Aux.docente = docenteServices.BuscarDocente(IdDocente);

                    ListarAlumnosComision(Aux);

                    Listado.Add(Aux);
                }
                return Listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void ListarAlumnosComision (Comision comision)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            Alumno Alumno;
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Alumno.* FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] inner join Comision on Comision.Id = DetComisionAlumnos.idComision inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno where Comision.Id = '" + comision.Id + "'");
                Datos.EjecutarLector();
                while(Datos.Lector.Read())
                {
                    Alumno = new Alumno();
                    Alumno.Legajo = Datos.Lector.GetInt64(1);
                    Alumno.Nombre = Datos.Lector.GetString(2);
                    Alumno.Apellido = Datos.Lector.GetString(3);
                    Alumno.Telefono = Datos.Lector.GetInt32(4);
                    Alumno.Email = Datos.Lector.GetString(5);

                    Alumno.Dirreccion = new Dirreccion();
                    Alumno.Dirreccion.Direccion = Datos.Lector.GetString(6);
                    Alumno.Dirreccion.Ciudad = Datos.Lector.GetString(7);
                    Alumno.Dirreccion.CodPostal = Datos.Lector.GetInt32(8);

                    comision.ListAlumnos = new List<Alumno>();
                    comision.ListAlumnos.Add(Alumno);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
