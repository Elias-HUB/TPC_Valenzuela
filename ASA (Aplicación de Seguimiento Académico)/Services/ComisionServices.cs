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
                Datos.SetearQuery("SELECT Comision.Id, Materia.Id, Materia.Nombre, Carrera.Id, Carrera.Nombre, Universidad.Id, Universidad.Nombre, Turno.Id, Turno.Nombre, Cuatrimestre.Id, Cuatrimestre.Nombre, Comision.Anio FROM  Comision inner join Materia on IdMateria = Materia.Id inner join Carrera on Carrera.Id = Materia.IdCarrera inner join Universidad on Universidad.Id = Carrera.IdUniversidad inner join Turno on  Turno.id = IdTurno inner join Cuatrimestre on IdCuatrimestre = Cuatrimestre.Id inner join Docente on IdDocente = Docente.Legajo where IdDocente = @IdDocente order by Anio desc,Cuatrimestre.Nombre desc");
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

                    ListarInstanciaComision(Aux);

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

        public Models.Comision Busqueda(long IdDocente, Comision comision)
        {
            Models.Comision Aux = null;
            DocenteServices docenteServices = new DocenteServices();
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Materia.Id, Materia.Nombre, Carrera.Id, Carrera.Nombre, Universidad.Id, Universidad.Nombre, Turno.Id, Turno.Nombre, Cuatrimestre.Id, Cuatrimestre.Nombre, Comision.Anio FROM  Comision inner join Materia on IdMateria = Materia.Id inner join Carrera on Carrera.Id = Materia.IdCarrera inner join Universidad on Universidad.Id = Carrera.IdUniversidad inner join Turno on  Turno.id = IdTurno inner join Cuatrimestre on IdCuatrimestre = Cuatrimestre.Id inner join Docente on IdDocente = Docente.Legajo where IdDocente = @IdDocente and Materia.Id = @Materia and Turno.Id = @Turno and Cuatrimestre.Id = @Cuatrimestre and Comision.Anio = @ComisionAnio order by Anio desc,Cuatrimestre.Nombre desc");
                Datos.agregarParametro("@IdDocente", IdDocente);
                Datos.agregarParametro("@Materia", comision.Materia.Id);
                Datos.agregarParametro("@Turno", comision.Turno.Id);
                Datos.agregarParametro("@Cuatrimestre", comision.Cuatrimestre.Id);
                Datos.agregarParametro("@ComisionAnio", comision.Anio);
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

                    Aux.Anio = Datos.Lector.GetInt32(11);

                    Aux.docente = new Docente();
                    Aux.docente = docenteServices.BuscarDocente(IdDocente);
                    
                }
                return Aux;
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

        public void Nuevo(Comision Aux)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Comision (IdMateria,IdTurno,IdCuatrimestre,IdDocente,Anio) values (@IdMateria,@IdTurno,@IdCuatrimestre,@IdDocente,@Anio)");
                datos.agregarParametro("@IdMateria", Aux.Materia.Id);
                datos.agregarParametro("@IdTurno", Aux.Turno.Id);
                datos.agregarParametro("@IdCuatrimestre", Aux.Cuatrimestre.Id);
                datos.agregarParametro("@IdDocente", Aux.docente.Legajo);
                datos.agregarParametro("@Anio", Aux.Anio);
                //datos.agregarParametro("@estado", 1);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public long UltimoRegistro()
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            long Registro = 0;
            List<Instancia> alumnos = new List<Instancia>();
            try
            {
                Datos.SetearQuery("SELECT TOP 1 [Id] FROM [Valenzuela_DB].[dbo].[Comision] order by Id desc");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    Registro = Datos.Lector.GetInt64(0);
                }
                return Registro;
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

        public void ListarInstanciaComision(Comision comision)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            Instancia Instancia;
            List<Instancia> alumnos = new List<Instancia>();
            try
            {
                Datos.SetearQuery("SELECT Ins.Id, Ins.Nombre, Ins.FechaInicio, Ins.FechaFin, TI.Id, TI.Nombre  FROM Instancia as Ins inner join TipoInstancia as TI on IdTipoinstancia = TI.Id inner join DetComisionInstancia on DetComisionInstancia.IdInstancia = Ins.Id where DetComisionInstancia.idComision =  '" + comision.Id + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    Instancia = new Instancia();
                    Instancia.Id = Datos.Lector.GetInt64(0);
                    Instancia.Nombre = Datos.Lector.GetString(1);
                    Instancia.FechaInicio = Datos.Lector.GetDateTime(2);
                    Instancia.FechaFin = Datos.Lector.GetDateTime(3);
                    Instancia.TipoInstancia = new Models.TipoInstancia();
                    Instancia.TipoInstancia.Id = Datos.Lector.GetInt64(4);
                    Instancia.TipoInstancia.Nombre = Datos.Lector.GetString(5);

                    comision.ListInstancia = new List<Instancia>();
                    comision.ListInstancia.Add(Instancia);
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
