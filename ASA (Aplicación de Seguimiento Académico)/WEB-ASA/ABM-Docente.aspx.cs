using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;

namespace WEB_ASA
{
    public partial class ABM_Docente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["Legajo"] != "Vacio")
                    {
                        Docente docente = new Docente();
                        DocenteServices docenteServices = new DocenteServices();
                        docente = docenteServices.BuscarDocente(Convert.ToInt64(Request.QueryString["Legajo"]));
                        TboxLegajo.Text = docente.Legajo.ToString();
                        TboxNombre.Text = docente.Nombre;
                        TboxApellido.Text = docente.Apellido;
                        TboxEmail.Text = docente.Email;
                        TboxTelefono.Text = docente.Telefono.ToString();
                        TboxDirreccion.Text = docente.Dirreccion.Direccion;
                        TboxCiudad.Text = docente.Dirreccion.Ciudad;
                        TboxCP.Text = docente.Dirreccion.CodPostal.ToString();
                        TboxLegajo.Enabled = false;
                        BtnBuscar.Visible = false;
                        BtnAgregar.Text = "Modificar";
                    }
                    else
                    {
                        BtnBuscar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            DocenteServices docenteServices = new DocenteServices();
            UsuarioServices usuarioServices = new UsuarioServices();
            Usuario usuario = new Usuario();
            usuario.Docente = new Docente();
            usuario.Docente = null;
            usuario = usuarioServices.BuscarDocente(Convert.ToInt64(TboxLegajo.Text));

            if (usuario.Docente != null)
            {
                TboxLegajo.Text = usuario.Docente.Legajo.ToString();
                TboxNombre.Text = usuario.Docente.Nombre;
                TboxClave.Text = usuario.Clave;
                TboxApellido.Text = usuario.Docente.Apellido;
                TboxEmail.Text = usuario.Docente.Email;
                TboxTelefono.Text = usuario.Docente.Telefono.ToString();
                TboxDirreccion.Text = usuario.Docente.Dirreccion.Direccion;
                TboxCiudad.Text = usuario.Docente.Dirreccion.Ciudad;
                TboxCP.Text = usuario.Docente.Dirreccion.CodPostal.ToString();
                TboxError.Text = "";
            }
            else
            {
                TboxNombre.Text = "";
                TboxApellido.Text = "";
                TboxEmail.Text = "";
                TboxTelefono.Text = "";
                TboxDirreccion.Text = "";
                TboxCiudad.Text = "";
                TboxCP.Text = "";
                TboxError.Text = "";
            }

        }

        public void AltaDocente(Usuario usuario)
        {

            usuario.Docente.Legajo = Convert.ToInt64(TboxLegajo.Text);
            usuario.Docente.Nombre = Convert.ToString(TboxNombre.Text);
            usuario.Docente.Apellido = Convert.ToString(TboxApellido.Text);
            usuario.Docente.Email = Convert.ToString(TboxEmail.Text);
            usuario.Docente.Telefono = Convert.ToInt32(TboxTelefono.Text);
            usuario.Docente.Dirreccion = new Dirreccion();
            usuario.Docente.Dirreccion.Direccion = Convert.ToString(TboxDirreccion.Text);
            usuario.Docente.Dirreccion.Ciudad = Convert.ToString(TboxCiudad.Text);
            usuario.Docente.Dirreccion.CodPostal = Convert.ToInt32(TboxCP.Text);
            usuario.Clave = TboxClave.Text;
        }

        public bool Busqueda(List<Alumno> alumnos, Alumno Aux)
        {
            if (alumnos != null)
            {
                foreach (Alumno alumnoAux in alumnos)
                {
                    if (alumnoAux.Legajo == Aux.Legajo)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int Indice(List<Alumno> alumnos, long Aux)
        {
            int cont = -1;
            foreach (Alumno alumnoAux in alumnos)
            {
                cont++;
                if (alumnoAux.Legajo == Aux)
                {
                    return cont;
                }
            }
            return -1;
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Docente docente = new Docente();
                DocenteServices docenteServices = new DocenteServices();
                Usuario usuario = new Usuario();
                usuario.Docente = new Docente();
                UsuarioServices usuarioServices = new UsuarioServices();
                //Aca es para modificar
                if (Request.QueryString["Legajo"] != "Vacio")
                {
                    AltaDocente(usuario);
                    if (Request.QueryString["IdComision"] != "22041997")
                    {
                        docenteServices.Modificar(usuario);



                  //modificar clkave
                        Response.Redirect("Comisiones.aspx");
                    }
                }

                //Aca para uno nuevo 
                else
                {
                    AltaDocente(usuario);
                    Docente Aux = new Docente();
                    Aux = usuario.Docente;
                    if (usuarioServices.BuscarDocenteUsuarioSC(Convert.ToInt64(Aux.Legajo)) == false)
                    {

                        Aux = null;
                        Aux = docenteServices.BuscarDocente(usuario.Docente.Legajo);
                        if (Aux == null)
                        {

                            docenteServices.Nuevo(usuario.Docente);
                            usuarioServices.NuevoUsuario(Convert.ToInt64(TboxLegajo.Text), TboxClave.Text);
                            Response.Redirect("Login.aspx");

                        }
                        else
                        {
                            //if (Request.QueryString["IdComision"] != "22041997")
                            //{
                            //    alumnoServices.Modificar(alumno);
                            //    alumnoServices.NuevoComAlu(Convert.ToInt64((Session["IdComision" + Session.SessionID])), Convert.ToInt64(TboxLegajo.Text));
                            //    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                            //}
                            //else
                            //{
                            //    int Cont = -1;
                            //    List<Alumno> alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                            //    foreach (Alumno alumnoAux in alumnos)
                            //    {
                            //        Cont++;
                            //        if (alumnoAux.Legajo == alumno.Legajo)
                            //        {
                            //            AltaAlumno(alumnos[Cont]);
                            //        }
                            //    }
                            //    alumnos.Add(alumno);
                            //    Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = alumnos;
                            //    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                            //}
                            TboxError.Text = "Ya existe un Docente con este legajo, si desea modificarlo tiene que inresar al sistema.";
                            TboxNombre.Text = "";
                            TboxApellido.Text = "";
                            TboxEmail.Text = "";
                            TboxTelefono.Text = "";
                            TboxDirreccion.Text = "";
                            TboxCiudad.Text = "";
                            TboxCP.Text = "";
                            TboxClave.Text = "";

                        }
                    }
                    else
                    {
                        TboxError.Text = "Ya existe un Docente con este legajo, si desea modificarlo tiene que inresar al sistema.";
                        TboxNombre.Text = "";
                        TboxApellido.Text = "";
                        TboxEmail.Text = "";
                        TboxTelefono.Text = "";
                        TboxDirreccion.Text = "";
                        TboxCiudad.Text = "";
                        TboxCP.Text = "";
                        TboxClave.Text = "";
                    }

                }
            }
            catch (System.FormatException)
            {
                TboxError.Text = "Complete los Datos antes de agregar";
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }
    }
}