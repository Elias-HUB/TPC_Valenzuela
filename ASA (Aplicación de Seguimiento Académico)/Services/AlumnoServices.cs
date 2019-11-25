using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASA.Services
{
    public class AlumnoServices
    {
        public List<Models.Alumno> Listar()
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
                    //Aux = new Models.Alumno();
                    //Aux.Legajo = Datos.Lector.GetInt64(0);
                    //Aux.Nombre = Datos.Lector.GetString(1);
                    //Aux.Apellido = new Models.Carrera();
                    //Aux.Telefono = Datos.Lector.GetInt64(3);
                    //Aux.Email = Datos.Lector.GetString(4);
                    //Aux.Dirreccion.Direccion = new Models.Universidad();
                    //Aux.Dirreccion.Ciudad= Datos.Lector.GetInt64(6);
                    //Aux.Dirreccion.CodPostal.Universidad.Nombre = Datos.Lector.GetString(7);
                    //Listado.Add(Aux);
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
