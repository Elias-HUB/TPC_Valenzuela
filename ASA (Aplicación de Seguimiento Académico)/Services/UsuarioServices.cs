using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASA.Models;
using AccesoDatos;

namespace ASA.Services
{
    public class UsuarioServices
    {
        public bool BuscarDocenteUsuario(long Legajo, string Clave)
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

        public void NuevoUsuario(long Legajo, string Clave)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            //AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("insert into Usuario (LegajoDocente,Clave) values (@LegajoDocente,@Clave)");
                datos.agregarParametro("@LegajoDocente", Legajo);
                datos.agregarParametro("@Clave", Clave);
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
        public bool BuscarDocenteUsuarioSC(long Legajo)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT LegajoDocente, Clave FROM [Valenzuela_DB].[dbo].[Usuario] where LegajoDocente = @LegajoDocente");
                Datos.Clear();
                Datos.agregarParametro("@LegajoDocente", Legajo);
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

        public Usuario BuscarDocente(long Legajo)
        {
            AccesoDatos.AccesoDatos Datos = new AccesoDatos.AccesoDatos();
            Usuario aux = new Usuario();
            aux = null;
            try
            {
                Datos.SetearQuery("SELECT * FROM [Valenzuela_DB].[dbo].[Usuario] inner join Docente on Docente.Legajo =LegajoDocente where LegajoDocente =  '" + Legajo + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    aux = new Usuario();
                    aux.Docente = new Docente();
                    aux.Docente.Legajo = (long)Datos.Lector["Legajo"];
                    aux.Docente.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Docente.Apellido = (string)Datos.Lector["Apellido"];
                    aux.Docente.Telefono = (int)Datos.Lector["Telefono"];
                    aux.Docente.Email = (string)Datos.Lector["Email"];

                    aux.Docente.Dirreccion = new Dirreccion();
                    aux.Docente.Dirreccion.Direccion = (string)Datos.Lector["Direccion"];
                    aux.Docente.Dirreccion.Ciudad = (string)Datos.Lector["Ciudad"];
                    aux.Docente.Dirreccion.CodPostal = (int)Datos.Lector["CodigoPostal"];

                    aux.Clave = (string)Datos.Lector["Clave"];
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
