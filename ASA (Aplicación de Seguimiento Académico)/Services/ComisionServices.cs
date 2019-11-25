using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class ComisionServices
    {
        public List<Models.Alumno> Listar(long Id)
        {
            List<Models.Alumno> Listado = new List<Models.Alumno>();
            Models.Alumno Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM [Valenzuela_DB].[dbo].[Materia] inner join [Valenzuela_DB].[dbo].[Carrera] on Carrera.Id = Materia.IdCarrera inner join [Valenzuela_DB].[dbo].[Universidad] on Universidad.Id = Carrera.IdUniversidad");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Alumno();
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
