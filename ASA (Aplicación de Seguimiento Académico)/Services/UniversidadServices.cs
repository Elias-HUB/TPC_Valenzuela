using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccesoDatos;

namespace ASA.Services
{
    public class UniversidadServices
    {
        public List<Models.Universidad> Listar()
        {
            List<Models.Universidad> Listado = new List<Models.Universidad>();
            Models.Universidad Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT[Id],[Nombre] FROM [Valenzuela_DB].[dbo].[Universidad]");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Universidad();
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