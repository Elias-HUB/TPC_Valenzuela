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
        public Docente BuscarDocente(long Legajo)
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


        public void Modificar(Usuario usuario)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.SetearQuery("Update Alumno set Legajo = @Legajo,Nombre = @Nombre,Apellido = @Apellido,Telefono = @Telefono,Email = @Email,Direccion = @Direccion,Ciudad = @Ciudad,CodigoPostal = @CodigoPostal where Legajo = @Legajo");
                datos.Clear();
                datos.agregarParametro("@Legajo", usuario.Docente.Legajo);
                datos.agregarParametro("@Nombre", usuario.Docente.Nombre);
                datos.agregarParametro("@Apellido", usuario.Docente.Apellido);
                datos.agregarParametro("@Telefono", usuario.Docente.Telefono);
                datos.agregarParametro("@Email", usuario.Docente.Email);
                datos.agregarParametro("@Direccion", usuario.Docente.Dirreccion.Direccion);
                datos.agregarParametro("@CodigoPostal", usuario.Docente.Dirreccion.CodPostal);
                datos.agregarParametro("@Ciudad", usuario.Docente.Dirreccion.Ciudad);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Nuevo(Docente Aux)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Docente (Legajo,Nombre,Apellido,Telefono,Email,Direccion,Ciudad,CodigoPostal) values (@Legajo,@Nombre,@Apellido,@Telefono,@Email,@Direccion,@Ciudad,@CodigoPostal)");
                datos.agregarParametro("@Legajo", Aux.Legajo);
                datos.agregarParametro("@Nombre", Aux.Nombre);
                datos.agregarParametro("@Apellido", Aux.Apellido);
                datos.agregarParametro("@Telefono", Aux.Telefono);
                datos.agregarParametro("@Email", Aux.Email);
                datos.agregarParametro("@Direccion", Aux.Dirreccion.Direccion);
                datos.agregarParametro("@Ciudad", Aux.Dirreccion.Ciudad);
                datos.agregarParametro("@CodigoPostal", Aux.Dirreccion.CodPostal);
                //datos.agregarParametro("@estado", 1);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


    }

}