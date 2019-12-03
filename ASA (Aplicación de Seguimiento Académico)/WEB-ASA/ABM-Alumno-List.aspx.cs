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
    public partial class ABM_Alumno_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargaDGVInstancia();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CargaDGVInstancia()
        {
            try
            {
                AlumnoServices alumnoServices = new AlumnoServices();
                List<Alumno> alumnos = alumnoServices.ListarAlumnosComision(Convert.ToInt64(Request.QueryString["IdComision"]));
                DGVAlumnos.DataSourceID = null;
                DGVAlumnos.DataSource = alumnos;
                if (alumnos.Count == 0)
                {
                    List<Alumno> Listado = new List<Alumno>();
                    Alumno Aux = new Alumno();
                    Aux.Legajo = 0;
                    Aux.Nombre = "";
                    Aux.Apellido = "";
                    Aux.Telefono = 0;
                    Aux.Email = "";

                    Aux.Dirreccion = new Dirreccion();
                    Aux.Dirreccion.Direccion = "";
                    Aux.Dirreccion.Ciudad = "";
                    Aux.Dirreccion.CodPostal = 0;

                    Listado.Add(Aux);
                    DGVAlumnos.DataSource = Listado;
                    DGVAlumnos.DataBind();
                    DGVAlumnos.Rows[0].Visible = false;
                }
                else
                {
                    DGVAlumnos.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void dgvIntancia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    Response.Redirect("ABM-Alumno.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]) + "&Legajo=Vacio");
                }
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

        protected void dgvIntancia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void dgvIntancia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

        protected void dgvIntancia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //DGVInstancia.EditIndex = -1;
            //DGVInstancia.ShowFooter = true;
            //CargaDGVInstancia();
        }

        protected void dgvIntancia_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvIntancia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                AlumnoServices alumnoServices = new  AlumnoServices();
                Alumno alumno = new Alumno();
                alumno.Legajo = Convert.ToInt64((DGVAlumnos.DataKeys[e.RowIndex].Value));
                alumnoServices.Eliminar(alumno.Legajo, Convert.ToInt64(Session["IdComision" + Session.SessionID]));
                CargaDGVInstancia();
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

        protected void DGVInstancia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[0].Visible = false;
            //e.Row.Cells[2].Visible = false;
        }

        protected void DGVAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Alumno alumno = new Alumno();            
            alumno.Legajo = Convert.ToInt64(DGVAlumnos.SelectedDataKey.Value);
            Response.Redirect("ABM-Alumno.aspx?IdComision=" + (Session["IdComision" + Session.SessionID]) + "&Legajo=" + alumno.Legajo);
        }
    }
}
