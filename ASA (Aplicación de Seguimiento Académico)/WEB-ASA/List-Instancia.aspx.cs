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
    public partial class List_Instancia : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["IdComision" + Session.SessionID] = Request.QueryString["valor"];
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
            InstanciaServices instanciaServices = new InstanciaServices();
            TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
            var ValorComision = Request.QueryString["valor"];
            List<Instancia> instancias = new List<Instancia>();
            if (Request.QueryString["valor"] != "22041997")
            {
                instancias = instanciaServices.ListarXComision(Convert.ToInt64(ValorComision)); 
            }
            else
            {
                instancias = Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] as List<Instancia>;
            }
            DGVInstancia.DataSourceID = null;
            DGVInstancia.DataSource = instancias;

            if (instancias.Count == 0)
            {
                List<Instancia> Listado = new List<Instancia>();
                Instancia Aux = new Instancia();
                Aux.Id = 0;
                Aux.Nombre = "";
                Aux.FechaInicio = DateTime.Now;
                Aux.FechaFin = DateTime.Now;
                Aux.TipoInstancia = new TipoInstancia();
                Aux.TipoInstancia.Id = 0;
                Aux.TipoInstancia.Nombre = "";
                Listado.Add(Aux);
                DGVInstancia.DataSource = Listado;
                DGVInstancia.DataBind();
                DGVInstancia.Rows[0].Visible = false;
                lblIncorrecto.Text = "No hay instancias, por favor agrege instancias";
            }
            else
            {
                DGVInstancia.DataBind();
            }
        }
        
   

        protected void DGVInstancia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            if (Request.QueryString["valor"] == "22041997")
            {
                e.Row.Cells[5].Visible = false;
            }
        }

    }
}