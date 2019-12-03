using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASA.Models;
using AccesoDatos;

namespace ASA.Services
{
    public class InstanciaServices
    {
        public List<Models.Instancia> Listar(int id = 0)
        {
            List<Models.Instancia> Listado = new List<Models.Instancia>();
            Models.Instancia Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                string consulta = "SELECT Ins.Id, Ins.Nombre, Ins.FechaInicio, Ins.FechaFin, TI.Id, TI.Nombre  FROM [Valenzuela_DB].[dbo].[Instancia] as Ins inner join TipoInstancia as TI on IdTipoinstancia = TI.Id ";
                if (id != 0)
                {
                    consulta = consulta + "where Ins.id=" + id.ToString();
                }
                Datos.SetearQuery(consulta);
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Instancia();
                    Aux.Id = Datos.Lector.GetInt64(0);
                    Aux.Nombre = Datos.Lector.GetString(1);
                    Aux.FechaInicio = Datos.Lector.GetDateTime(2);
                    Aux.FechaFin = Datos.Lector.GetDateTime(3);
                    Aux.TipoInstancia = new Models.TipoInstancia();
                    Aux.TipoInstancia.Id = Datos.Lector.GetInt64(4);
                    Aux.TipoInstancia.Nombre = Datos.Lector.GetString(5);
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

        public List<Models.Instancia> ListarXComision(long Id)
        {
            List<Models.Instancia> Listado = new List<Models.Instancia>();
            Models.Instancia Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {                
                Datos.SetearQuery("SELECT Ins.Id, Ins.Nombre, Ins.FechaInicio, Ins.FechaFin, TI.Id, TI.Nombre  FROM Instancia as Ins inner join TipoInstancia as TI on IdTipoinstancia = TI.Id inner join DetComisionInstancia on DetComisionInstancia.IdInstancia = Ins.Id where DetComisionInstancia.idComision = @Id");
                Datos.Clear();
                Datos.agregarParametro("@Id", Id);
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Instancia();
                    Aux.Id = Datos.Lector.GetInt64(0);
                    Aux.Nombre = Datos.Lector.GetString(1);
                    Aux.FechaInicio = Datos.Lector.GetDateTime(2);
                    Aux.FechaFin = Datos.Lector.GetDateTime(3);
                    Aux.TipoInstancia = new Models.TipoInstancia();
                    Aux.TipoInstancia.Id = Datos.Lector.GetInt64(4);
                    Aux.TipoInstancia.Nombre = Datos.Lector.GetString(5);
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

        public void Modificar(Instancia Aux)
        {
            AccesoDatos.AccesoDatos accesoDatos = new AccesoDatos.AccesoDatos();
            try
            {
                accesoDatos.SetearQuery("update Instancia set Nombre = @Nombre, FechaInicio = @FechaInicio, FechaFin = @FechaFin, IdTipoinstancia = @TIins  where id = @Id");
                accesoDatos.Clear();
                accesoDatos.agregarParametro("@Nombre",Aux.Nombre);
                accesoDatos.agregarParametro("@FechaInicio",Aux.FechaInicio);
                accesoDatos.agregarParametro("@FechaFin",Aux.FechaFin);
                accesoDatos.agregarParametro("@TIins",Aux.TipoInstancia.Id);
                accesoDatos.agregarParametro("@Id",Aux.Id);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Nuevo (Instancia Aux)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Instancia (Nombre,FechaInicio,FechaFin,IdTipoinstancia) values ( @Nombre,@FechaInicio,@FechaFin,@IdTipoinstancia )");
                datos.agregarParametro("@Nombre", Aux.Nombre);
                datos.agregarParametro("@FechaInicio", Aux.FechaInicio);
                datos.agregarParametro("@FechaFin", Aux.FechaFin);
                datos.agregarParametro("@IdTipoinstancia", Aux.TipoInstancia.Id);
                //datos.agregarParametro("@estado", 1);
                datos.EjecutarAccion();
                datos.SetearQuery("insert into DetComisionInstancia (idComision,IdInstancia) values( @IdComision,@IdInstancia)");
                datos.agregarParametro("@Nombre", Aux.Nombre);
                datos.agregarParametro("@FechaInicio", Aux.FechaInicio);
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
            try
            {
                Datos.SetearQuery("SELECT TOP 1 [Id] FROM [Valenzuela_DB].[dbo].[Instancia] order by Id desc");
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

        public void NuevoComIns(long IdCom , long IdIns)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into DetComisionInstancia (idComision,IdInstancia) values( @IdComision,@IdInstancia)");
                datos.agregarParametro("@IdComision", IdCom);
                datos.agregarParametro("@IdInstancia", IdIns);
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

        public void Eliminar (long Id)
        {
            AccesoDatos.AccesoDatos accesoDatos = new AccesoDatos.AccesoDatos();
            try
            {
                accesoDatos.SetearQuery("delete [DetComisionInstancia] where IdInstancia = @Id");
                accesoDatos.Clear();
                accesoDatos.agregarParametro("@Id", Id);
                accesoDatos.EjecutarAccion();
                //accesoDatos.SetearQuery("delete [Comentario] where IdInstancia = @Id");
                //accesoDatos.Clear();
                //accesoDatos.agregarParametro("@Id", Id);
                //accesoDatos.EjecutarAccion();
                //accesoDatos.SetearQuery("delete [Instancia] where Id = @Id");
                //accesoDatos.Clear();
                //accesoDatos.agregarParametro("@Id", Id);
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
    }


}