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
    public partial class ABM_Comision : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargaDList();
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        public void CargaDList()
        {
            MateriaServices materiaServices = new MateriaServices();
            CuatrimestreServices cuatrimestreServices = new CuatrimestreServices();
            TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
            TurnoServices turnoServices = new TurnoServices();
            DlistMateria.DataValueField = "Id";
            DlistMateria.DataTextField = "Nombre";
            DlistMateria.DataSource = materiaServices.Listar();
            DlistMateria.DataBind();
            DlistCuatrimestre.DataValueField = "Id";
            DlistCuatrimestre.DataTextField = "Nombre";
            DlistCuatrimestre.DataSource = cuatrimestreServices.Listar();
            DlistCuatrimestre.DataBind();
            DlistTurno.DataValueField = "Id";
            DlistTurno.DataTextField = "Nombre";
            DlistTurno.DataSource = turnoServices.Listar();
            DlistTurno.DataBind();
        }

        protected void BtnInstancias_click(object sender, EventArgs e)
        {
            ComisionServices comisionServices = new ComisionServices();
            Comision comision = new Comision();
            comision.Materia = new Materia();
            comision.Materia.Id = Convert.ToInt64(DlistMateria.SelectedValue);
            Session["ABMComisionNuevo-Materia" + Session.SessionID] = comision.Materia;
            Session["DatosComisionNuevo-Materia" + Session.SessionID] = DlistMateria.SelectedItem.Text;

            comision.Turno = new Turno();
            comision.Turno.Id = Convert.ToInt64(DlistTurno.SelectedValue);
            Session["ABMComisionNuevo-Turno" + Session.SessionID] = comision.Turno;
            Session["DatosComisionNuevo-Turno" + Session.SessionID] = DlistTurno.SelectedItem.Text;

            comision.Cuatrimestre = new Cuatrimestre();
            comision.Cuatrimestre.Id = Convert.ToInt64(DlistCuatrimestre.SelectedValue);
            Session["ABMComisionNuevo-Cuatrimestre" + Session.SessionID] = comision.Cuatrimestre;
            Session["DatosComisionNuevo-Cuatrimestre" + Session.SessionID] = DlistTurno.SelectedItem.Text;


            //VERIFICAR DOCENTE 
            comision.docente = new Docente();
            comision.docente.Legajo = Convert.ToInt64(Session["DocenteLegajo" + Session.SessionID]);

            comision.Anio = Convert.ToInt32(TboxAnio.Text);
            Session["ABMComisionNuevo-Anio" + Session.SessionID] = Convert.ToInt32(TboxAnio.Text);
            Session["DatosComisionNuevo-Anio" + Session.SessionID] = TboxAnio.Text;

            Comision Aux = new Comision();
            Aux = comisionServices.Busqueda(Convert.ToInt64(Session["DocenteLegajo" + Session.SessionID]), comision);
            if (Aux == null)
            {
                InstanciaServices instanciaServices = new InstanciaServices();
                List<Instancia> instancias = instanciaServices.ListarXComision(Convert.ToInt64(22041997));
                Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] = instancias;

                AlumnoServices alumnoServices = new AlumnoServices();
                List<Alumno> alumnos = alumnoServices.ListarAlumnosComision(Convert.ToInt64(22041997));
                Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = alumnos;
                Response.Redirect("List-Instancia.aspx?valor=" + 22041997);
            }
            LblIntancia.Text = "Ya posee una instancia igual, cargue una nueva!";
            Session["ABMComisionNuevo-Materia" + Session.SessionID] = "";
            Session["ABMComisionNuevo-Turno" + Session.SessionID] = "";
            Session["ABMComisionNuevo-Cuatrimestre" + Session.SessionID] = "";
            Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] = "";
            Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] = "";
            Session["ABMComisionNuevo-Anio" + Session.SessionID] = "";
        }
    }
}