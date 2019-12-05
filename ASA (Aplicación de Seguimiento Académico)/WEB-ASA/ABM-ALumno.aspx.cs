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
    public partial class ABM_ALumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Legajo"] != "Vacio")
                {
                    Alumno alumno = new Alumno();
                    AlumnoServices alumnoServices = new AlumnoServices();
                    if (Request.QueryString["IdComision"] != "22041997")
                    {
                        alumno = alumnoServices.BuscarAlumno(Convert.ToInt64(Request.QueryString["Legajo"]));
                    }
                    else
                    {
                        List<Alumno> alumnos = (Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>);
                        int Index = Indice(alumnos, (Convert.ToInt64(Request.QueryString["Legajo"])));
                        alumno = alumnos[Index];
                    }
                    TboxLegajo.Text = alumno.Legajo.ToString();
                    TboxNombre.Text = alumno.Nombre;
                    TboxApellido.Text = alumno.Apellido;
                    TboxEmail.Text = alumno.Email;
                    TboxTelefono.Text = alumno.Telefono.ToString();
                    TboxDirreccion.Text = alumno.Dirreccion.Direccion;
                    TboxCiudad.Text = alumno.Dirreccion.Ciudad;
                    TboxCP.Text = alumno.Dirreccion.CodPostal.ToString();
                    TboxLegajo.Enabled = false;
                    BtnBuscar.Visible = false;
                    BtnAgregar.Text = "Modificar";
                }
                else
                {

                }
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno = null;
            AlumnoServices alumnoServices = new AlumnoServices();
            alumno = alumnoServices.BuscarAlumno(Convert.ToInt64(TboxLegajo.Text));
            if (alumno != null)
            {
                TboxLegajo.Text = alumno.Legajo.ToString();
                TboxNombre.Text = alumno.Nombre;
                TboxApellido.Text = alumno.Apellido;
                TboxEmail.Text = alumno.Email;
                TboxTelefono.Text = alumno.Telefono.ToString();
                TboxDirreccion.Text = alumno.Dirreccion.Direccion;
                TboxCiudad.Text = alumno.Dirreccion.Ciudad;
                TboxCP.Text = alumno.Dirreccion.CodPostal.ToString();
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

        public void AltaAlumno(Alumno alumno)
        {
            alumno.Legajo = Convert.ToInt64(TboxLegajo.Text);
            alumno.Nombre = Convert.ToString(TboxNombre.Text);
            alumno.Apellido = Convert.ToString(TboxApellido.Text);
            alumno.Email = Convert.ToString(TboxEmail.Text);
            alumno.Telefono = Convert.ToInt32(TboxTelefono.Text);
            alumno.Dirreccion = new Dirreccion();
            alumno.Dirreccion.Direccion = Convert.ToString(TboxDirreccion.Text);
            alumno.Dirreccion.Ciudad = Convert.ToString(TboxCiudad.Text);
            alumno.Dirreccion.CodPostal = Convert.ToInt32(TboxCP.Text);
        }

        public bool Busqueda(List<Alumno> alumnos, Alumno Aux)
        {
            foreach (Alumno alumnoAux in alumnos)
            {
                if (alumnoAux.Legajo == Aux.Legajo)
                {
                    return true;
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
                Alumno alumno = new Alumno();
                AlumnoServices alumnoServices = new AlumnoServices();
                //Aca es para modificar
                if (Request.QueryString["Legajo"] != "Vacio")
                {
                    AltaAlumno(alumno);
                    if (Request.QueryString["IdComision"] != "22041997")
                    {
                        alumnoServices.Modificar(alumno);
                        Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                    }
                    else
                    {
                        int Cont = -1;
                        List<Alumno> alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                        foreach (Alumno alumnoAux in alumnos)
                        {
                            Cont++;
                            if (alumnoAux.Legajo == alumno.Legajo)
                            {
                                AltaAlumno(alumnos[Cont]);
                            }
                        }
                        Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = alumnos;
                        Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                    }
                }

                //Aca para uno nuevo 
                else
                {
                    AltaAlumno(alumno);
                    Alumno Aux = new Alumno();
                    Aux = alumno;
                    if ((alumnoServices.BuscarAlumnosComision(Convert.ToInt64(Session["IdComision" + Session.SessionID]), Aux.Legajo)) == false)
                    {
                        //List<Alumno> pru = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                        if ((Busqueda(Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>, alumno)) == false)
                        {
                            Aux = null;
                            Aux = alumnoServices.BuscarAlumno(alumno.Legajo);
                            if (Aux == null)
                            {
                                if (Request.QueryString["IdComision"] != "22041997")
                                {
                                    alumnoServices.Nuevo(alumno);
                                    alumnoServices.NuevoComAlu(Convert.ToInt64((Session["IdComision" + Session.SessionID])), Convert.ToInt64(TboxLegajo.Text));
                                    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                                }
                                else
                                {
                                    List<Alumno> alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                                    alumnos.Add(alumno);
                                    Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = alumnos;
                                    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                                }
                            }
                            else
                            {
                                if (Request.QueryString["IdComision"] != "22041997")
                                {
                                    alumnoServices.Modificar(alumno);
                                    alumnoServices.NuevoComAlu(Convert.ToInt64((Session["IdComision" + Session.SessionID])), Convert.ToInt64(TboxLegajo.Text));
                                    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                                }
                                else
                                {
                                    int Cont = -1;
                                    List<Alumno> alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                                    foreach (Alumno alumnoAux in alumnos)
                                    {
                                        Cont++;
                                        if (alumnoAux.Legajo == alumno.Legajo)
                                        {
                                            AltaAlumno(alumnos[Cont]);
                                        }
                                    }
                                    alumnos.Add(alumno);
                                    Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = alumnos;
                                    Response.Redirect("ABM-Alumno-List.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]));
                                }
                            }
                        }
                        else
                        {
                            TboxError.Text = "El legajo ya existe en la comision, por favor ingrese un nuevo Alumno";
                            TboxNombre.Text = "";
                            TboxApellido.Text = "";
                            TboxEmail.Text = "";
                            TboxTelefono.Text = "";
                            TboxDirreccion.Text = "";
                            TboxCiudad.Text = "";
                            TboxCP.Text = "";
                        }
                    }
                    else
                    {
                        TboxError.Text = "El legajo ya existe en la comision, por favor ingrese un nuevo Alumno";
                        TboxNombre.Text = "";
                        TboxApellido.Text = "";
                        TboxEmail.Text = "";
                        TboxTelefono.Text = "";
                        TboxDirreccion.Text = "";
                        TboxCiudad.Text = "";
                        TboxCP.Text = "";
                    }

                }
            }
            catch (System.FormatException)
            {
                TboxError.Text = "Complete los Datos antes de agregar";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}