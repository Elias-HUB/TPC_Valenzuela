using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASA.Models;

namespace ASA.Services
{
    public class AlumnoServices
    {
        public List<Models.Alumno> Listar(long Id)
        {
            List<Models.Alumno> Listado = new List<Models.Alumno>();
            Models.Alumno Aux = null;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Alumno.* FROM[Valenzuela_DB].[dbo].[DetComisionAlumnos] inner join Comision on Comision.Id = DetComisionAlumnos.idComision inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno where Comision.Id = '" + Id + "'");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Alumno();
                    Aux.Legajo = Datos.Lector.GetInt64(1);
                    Aux.Nombre = Datos.Lector.GetString(2);
                    Aux.Apellido = Datos.Lector.GetString(3);
                    Aux.Telefono = Datos.Lector.GetInt32(4);
                    Aux.Email = Datos.Lector.GetString(5);

                    Aux.Dirreccion = new Dirreccion();
                    Aux.Dirreccion.Direccion = Datos.Lector.GetString(6);
                    Aux.Dirreccion.Ciudad = Datos.Lector.GetString(7);
                    Aux.Dirreccion.CodPostal = Datos.Lector.GetInt32(8);
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

        public Models.Alumno BuscarAlumno(long Legajo)
        {

            Models.Alumno Aux = null;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT *  FROM [Valenzuela_DB].[dbo].[Alumno] where Legajo =" + Legajo);
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Alumno();
                    Aux.Legajo = Datos.Lector.GetInt64(0);
                    Aux.Nombre = Datos.Lector.GetString(1);
                    Aux.Apellido = Datos.Lector.GetString(2);
                    Aux.Telefono = Datos.Lector.GetInt32(3);
                    Aux.Email = Datos.Lector.GetString(4);

                    Aux.Dirreccion = new Dirreccion();
                    Aux.Dirreccion.Direccion = Datos.Lector.GetString(5);
                    Aux.Dirreccion.Ciudad = Datos.Lector.GetString(6);
                    Aux.Dirreccion.CodPostal = Datos.Lector.GetInt32(7);
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

        public List<Alumno> ListarAlumnosComision(long comision)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            Alumno Alumno;
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Alumno.* FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] inner join Comision on Comision.Id = DetComisionAlumnos.idComision inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno where Comision.Id = '" + comision + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
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

                    alumnos.Add(Alumno);
                }
                return alumnos;
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

        public bool BuscarAlumnosComision(long comision, long IdAlumno)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT Comision.Id, Alumno.* FROM [Valenzuela_DB].[dbo].[DetComisionAlumnos] inner join Comision on Comision.Id = DetComisionAlumnos.idComision inner join Alumno on Alumno.Legajo = DetComisionAlumnos.IdAlumno where Comision.Id =" + comision + " and Alumno.Legajo = " + IdAlumno + " and DetComisionAlumnos.IdAlumno is not null");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    return true;
                }
                return false;
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

        public void Eliminar(long IdAlumno, long IdComision)
        {
            AccesoDatos.AccesoDatos accesoDatos = new AccesoDatos.AccesoDatos();
            try
            {
                accesoDatos.SetearQuery("delete [DetComisionAlumnos] where IdAlumno = @Id and idComision = @IdCom");
                accesoDatos.Clear();
                accesoDatos.agregarParametro("@Id", IdAlumno);
                accesoDatos.agregarParametro("@IdCom", IdComision);
                accesoDatos.EjecutarAccion();
                //accesoDatos.SetearQuery("delete [Comentario] where IdAlumno = @Id and idComision = @IdCom");
                //accesoDatos.Clear();
                //accesoDatos.agregarParametro("@Id", IdAlumno);
                //accesoDatos.agregarParametro("@IdCom", IdComision);
                //accesoDatos.EjecutarAccion();
                //accesoDatos.SetearQuery("delete [Instancia] where Id = @Id");
                //accesoDatos.Clear();
                //accesoDatos.agregarParametro("@Id", IdAlumno);
                //accesoDatos.agregarParametro("@IdCom", IdComision);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }

        public void Nuevo(Alumno Aux)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Alumno (Legajo,Nombre,Apellido,Telefono,Email,Direccion,Ciudad,CodigoPostal) values (@Legajo,@Nombre,@Apellido,@Telefono,@Email,@Direccion,@Ciudad,@CodigoPostal)");
                datos.agregarParametro("@Legajo", Aux.Legajo);
                datos.agregarParametro("@Nombre", Aux.Nombre);
                datos.agregarParametro("@Apellido", Aux.Apellido);
                datos.agregarParametro("@Telefono", Aux.Telefono);
                datos.agregarParametro("@Email", Aux.Email);
                datos.agregarParametro("@Direccion", Aux.Dirreccion.Direccion);
                datos.agregarParametro("@Ciudad", Aux.Dirreccion.Ciudad);
                datos.agregarParametro("@CodigoPostal", Aux.Dirreccion.CodPostal);
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

        public void NuevoComAlu(long IdCom, long IdAlu)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into DetComisionAlumnos (idComision,IdAlumno) values( @IdComision,@IdAlumno)");
                datos.agregarParametro("@IdComision", IdCom);
                datos.agregarParametro("@IdAlumno", IdAlu);
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

        public void Modificar(Alumno alumno)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.SetearQuery("Update Alumno set Legajo = @Legajo,Nombre = @Nombre,Apellido = @Apellido,Telefono = @Telefono,Email = @Email,Direccion = @Direccion,Ciudad = @Ciudad,CodigoPostal = @CodigoPostal where Legajo = @Legajo");
                datos.Clear();
                datos.agregarParametro("@Legajo", alumno.Legajo);
                datos.agregarParametro("@Nombre", alumno.Nombre);
                datos.agregarParametro("@Apellido", alumno.Apellido);
                datos.agregarParametro("@Telefono", alumno.Telefono);
                datos.agregarParametro("@Email", alumno.Email);
                datos.agregarParametro("@Direccion", alumno.Dirreccion.Direccion);
                datos.agregarParametro("@CodigoPostal", alumno.Dirreccion.CodPostal);
                datos.agregarParametro("@Ciudad", alumno.Dirreccion.Ciudad);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ProtecEliminar(long id)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM[Valenzuela_DB].[dbo].[Alumno]  inner join Comentario on Comentario.IdAlumno = Alumno.Legajo where Alumno.Legajo =" + id);
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    return true;
                }
                return false;
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
