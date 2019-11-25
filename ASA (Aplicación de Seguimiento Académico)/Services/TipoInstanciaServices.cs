using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class TipoInstanciaServices
    {
        public List<Models.TipoInstancia> Listar()
        {
            List<Models.TipoInstancia> Listado = new List<Models.TipoInstancia>();
            Models.TipoInstancia Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM [Valenzuela_DB].[dbo].[TipoInstancia]");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.TipoInstancia();
                    Aux.Id = (long)Datos.Lector["id"];
                    Aux.Nombre = Datos.Lector.GetString(1);
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