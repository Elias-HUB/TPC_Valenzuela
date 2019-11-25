using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class MateriaServices
    {
        public List<Models.Materia> Listar()
        {
            List<Models.Materia> Listado = new List<Models.Materia>();
            Models.Materia Aux;
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM [Valenzuela_DB].[dbo].[Materia] inner join [Valenzuela_DB].[dbo].[Carrera] on Carrera.Id = Materia.IdCarrera inner join [Valenzuela_DB].[dbo].[Universidad] on Universidad.Id = Carrera.IdUniversidad");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Models.Materia();
                    Aux.Id = Datos.Lector.GetInt64(0);
                    Aux.Nombre = Datos.Lector.GetString(1);
                    Aux.Carrera = new Models.Carrera();
                    Aux.Carrera.Id = Datos.Lector.GetInt64(3);
                    Aux.Carrera.Nombre = Datos.Lector.GetString(4);
                    Aux.Carrera.Universidad = new Models.Universidad();
                    Aux.Carrera.Universidad.Id = Datos.Lector.GetInt64(6);
                    Aux.Carrera.Universidad.Nombre = Datos.Lector.GetString(7);
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