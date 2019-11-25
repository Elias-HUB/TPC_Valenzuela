using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class CuatrimestreServices
    {
        public List<Models.Cuatrimestre> Listar()
        {
            List<Models.Cuatrimestre> Listado = new List<Models.Cuatrimestre>();
            Models.Cuatrimestre Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT[Id],[Nombre] FROM [Valenzuela_DB].[dbo].[Cuatrimestre]");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Cuatrimestre();
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