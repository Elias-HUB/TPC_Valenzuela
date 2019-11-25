using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}