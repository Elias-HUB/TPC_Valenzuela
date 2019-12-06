using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASA.Models;
using AccesoDatos;

namespace Services
{
    public class UsuarioServices
    {
        public bool VerificarMail (long Legajo, string Clave)
        {            
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT LegajoDocente, Clave FROM [Valenzuela_DB].[dbo].[Usuario] where LegajoDocente = @LegajoDocente and Clave = @Clave");
                Datos.Clear();
                Datos.agregarParametro("@LegajoDocente", Legajo);
                Datos.agregarParametro("@Clave", Clave);
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
