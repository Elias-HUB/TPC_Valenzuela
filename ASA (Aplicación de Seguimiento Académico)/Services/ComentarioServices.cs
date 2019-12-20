using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASA.Models;

namespace ASA.Services
{
    public class ComentarioServices
    {
        public List<Models.Comentario> ComentariosCIA(long ComId, long InsId, long Legajo)
        {
            List<Models.Comentario> Listado = new List<Models.Comentario>();
            Models.Comentario Aux = null;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT [Id],[Descripcion],[FechaAlta],[FechaModificacion],Nota FROM [Valenzuela_DB].[dbo].[Comentario] where IdInstancia = @InsId and idComision = @ComId and IdAlumno = @Legajo order by FechaAlta desc");
                Datos.Clear();
                Datos.agregarParametro("@ComId", ComId);
                Datos.agregarParametro("@Legajo", Legajo);
                Datos.agregarParametro("@InsId", InsId);

                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Comentario();
                    Aux.Id = Datos.Lector.GetInt64(0);
                    Aux.Descripcion = Datos.Lector.GetString(1);
                    Aux.FechaAlta = Datos.Lector.GetDateTime(2);
                    Aux.FechaModificacion = Datos.Lector.GetDateTime(3);
                    Aux.Nota = Datos.Lector.GetString(4);
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

        public Models.Comentario Comentario (long Id)
        {
            List<Models.Comentario> Listado = new List<Models.Comentario>();
            Models.Comentario Aux = null;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT [Id],[Descripcion],[FechaAlta],[FechaModificacion] FROM [Valenzuela_DB].[dbo].[Comentario] where Id = @Id");
                Datos.Clear();
                Datos.agregarParametro("@Id", Id);

                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Comentario();
                    Aux.Id = Datos.Lector.GetInt64(0);
                    Aux.Descripcion = Datos.Lector.GetString(1);
                    Aux.FechaAlta = Datos.Lector.GetDateTime(2);
                    Aux.FechaModificacion = Datos.Lector.GetDateTime(3);
                    Listado.Add(Aux);
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

        public void Agregar(ASA.Models.Comentario Aux, long idComision, long IdInstancia, long IdAlumno)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //Aux = new Comentario();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Comentario values (@idComision, @IdInstancia, @IdAlumno, @Descripcion, @FechaAlta, @FechaModificacion, @Nota)");
                datos.agregarParametro("@idComision",idComision);
                datos.agregarParametro("@IdInstancia",IdInstancia);
                datos.agregarParametro("@IdAlumno",IdAlumno);
                datos.agregarParametro("@Descripcion", Aux.Descripcion);
                datos.agregarParametro("@FechaAlta", DateTime.Now);
                datos.agregarParametro("@FechaModificacion", DateTime.Now);
                datos.agregarParametro("@Nota", Aux.Nota);
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

        public void Modificar(ASA.Models.Comentario Aux)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //Aux = new Comentario();
            try
            {
                datos.SetearQuery("update Comentario set Descripcion = @Desc , FechaModificacion = @FMod where Id = @Id");
                datos.agregarParametro("@Desc", Aux.Descripcion);
                datos.agregarParametro("@FMod", DateTime.Now);
                datos.agregarParametro("@Id", Aux.Id);
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

    }
}