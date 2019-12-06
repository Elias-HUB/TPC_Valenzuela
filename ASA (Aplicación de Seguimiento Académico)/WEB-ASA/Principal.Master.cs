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
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DocenteServices docenteServices = new DocenteServices();
                Docente docente = new Docente();
                if(Session["DocenteLegajo" + Session.SessionID] != null)
                {
                    docente = docenteServices.BuscarDocente(Convert.ToInt64(Session["DocenteLegajo" + Session.SessionID]));
                    LblSession.Text = "Bienvenido " + docente.Nombre + " ";
                }

            }

        }

        protected void BtnSession_Click(object sender, EventArgs e)
        {
            Session["DocenteLegajo" + Session.SessionID] = null;
            Response.Redirect("Login.aspx");
        }
    }
}