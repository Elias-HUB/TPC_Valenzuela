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
            //Session["IdComision" + Session.SessionID] = ValorComision;
            List<Instancia> instancias = instanciaServices.ListarXComision(Convert.ToInt64(ValorComision));
            DGVInstancia.DataSourceID = null;
            DGVInstancia.DataSource = instancias;
            DGVInstancia.DataBind();
        }

        protected void DGVInstancia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

    }
}