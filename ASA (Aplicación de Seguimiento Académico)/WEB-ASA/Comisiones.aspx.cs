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
    public partial class Comisiones : System.Web.UI.Page
    {
        public List<Comision> Comisions = new List<Comision>();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
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
                    CARGAR();
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        public void CARGAR()
        {

            Comisions = (new ComisionServices().Listar(Convert.ToInt32(Session["DocenteLegajo" + Session.SessionID]), DlistMateria.SelectedItem.Text, DlistTurno.SelectedItem.Text, DlistCuatrimestre.SelectedItem.Text, TboxAnio.Text));
        }

        protected void BtnComision_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABM-Comision.aspx");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CARGAR();
        }
    }
}