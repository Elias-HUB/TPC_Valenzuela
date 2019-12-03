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
            comision.Turno = new Turno();
            comision.Turno.Id = Convert.ToInt64(DlistTurno.SelectedValue);
            comision.Cuatrimestre = new Cuatrimestre();
            comision.Cuatrimestre.Id = Convert.ToInt64(DlistCuatrimestre.SelectedValue);
            //VERIFICAR DOCENTE 
            comision.docente = new Docente();
            comision.docente.Legajo = Convert.ToInt64(2);
            comision.Anio = Convert.ToInt32(TboxAnio.Text);
            comisionServices.Nuevo(comision);
            Int64 IdCom = comisionServices.UltimoRegistro();

            Response.Redirect("ABM-Instancia.aspx?IdComision=" + IdCom);
        }
    }
}