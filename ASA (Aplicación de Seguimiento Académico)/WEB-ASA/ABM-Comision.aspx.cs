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
                    CargaDGVInstancia();
                }
            }
            catch (Exception)
            {

                throw;
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
            DlistTipo.DataValueField = "Id";
            DlistTipo.DataTextField = "Nombre";
            DlistTipo.DataSource = tipoInstanciaServices.Listar();
            DlistTipo.DataBind();
            DlistTurno.DataValueField = "Id";
            DlistTurno.DataTextField = "Nombre";
            DlistTurno.DataSource = turnoServices.Listar();
            DlistTurno.DataBind();
        }

        public void CargaDGVInstancia()
        {
            InstanciaServices instanciaServices = new InstanciaServices();
            List<Instancia> instancias = instanciaServices.Listar();
            DGVInstancia.DataSourceID = null;
            DGVInstancia.DataSource = instancias;
            DGVInstancia.DataBind();
        }

        protected void dgvIntancia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvIntancia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                DGVInstancia.EditIndex = e.NewEditIndex;
                CargaDGVInstancia();
                InstanciaServices instanciaServices = new InstanciaServices();
                TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
                ((DropDownList)DGVInstancia.Rows[e.NewEditIndex].FindControl("DGBDlistTipo")).DataValueField = "Id";
                ((DropDownList)DGVInstancia.Rows[e.NewEditIndex].FindControl("DGBDlistTipo")).DataTextField = "Nombre";
                ((DropDownList)DGVInstancia.Rows[e.NewEditIndex].FindControl("DGBDlistTipo")).DataSource = tipoInstanciaServices.Listar(); ;
                ((DropDownList)DGVInstancia.Rows[e.NewEditIndex].FindControl("DGBDlistTipo")).DataBind();
                Instancia instancia = (instanciaServices.Listar(e.NewEditIndex + 1))[0];
                ((DropDownList)DGVInstancia.Rows[e.NewEditIndex].FindControl("DGBDlistTipo")).Items.FindByValue(instancia.TipoInstancia.Id.ToString()).Selected = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void dgvIntancia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DGVInstancia.EditIndex = -1;
            CargaDGVInstancia();
        }

        protected void dgvIntancia_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvIntancia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvIntancia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}