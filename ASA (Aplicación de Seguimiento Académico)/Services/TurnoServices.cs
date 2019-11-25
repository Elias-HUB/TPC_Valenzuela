using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class TurnoServices
    {
        public List<Models.Turno> Listar()
        {
            List<Models.Turno> Listado = new List<Models.Turno>();
            Models.Turno Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT[Id],[Nombre] FROM [Valenzuela_DB].[dbo].[Turno]");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Turno();
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