using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASA.Models;
using AccesoDatos;

namespace ASA.Services
{
    public class DocenteServices
    {
        public Docente BuscarDocente (long Legajo)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            Docente aux = null;
            try
            {
                Datos.SetearQuery("SELECT * FROM [Valenzuela_DB].[dbo].[Docente] where Legajo =  '" + Legajo + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    aux = new Docente();
                    aux.Legajo = (long)Datos.Lector["Legajo"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Apellido = (string)Datos.Lector["Apellido"];
                    aux.Telefono = (int)Datos.Lector["Telefono"];
                    aux.Email = (string)Datos.Lector["Email"];

                    aux.Dirreccion = new Dirreccion();
                    aux.Dirreccion.Direccion = (string)Datos.Lector["Direccion"];
                    aux.Dirreccion.Ciudad = (string)Datos.Lector["Ciudad"];
                    aux.Dirreccion.CodPostal = (int)Datos.Lector["CodigoPostal"];
                }
                return aux;
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