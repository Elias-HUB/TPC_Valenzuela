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
                    TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
                    Session["IdComision" + Session.SessionID] = Request.QueryString["valor"];
                    ComisionServices comisionServices = new ComisionServices();
                    Comision comision = new Comision();
                    comision.Materia = new Materia();
                    comision.Turno = new Turno();
                    comision = comisionServices.BusquedaID(Convert.ToInt32(Session["DocenteLegajo" + Session.SessionID]), Convert.ToInt64(Session["IdComision" + Session.SessionID]));
                    if (comision != null)
                    {
                        LblTitulo.Text = comision.Materia.Nombre.ToString() + " - Turno " + comision.Turno.Nombre.ToString() + " - " + comision.Anio.ToString() + " ";
                        Session["DatosComision" + Session.SessionID] = LblTitulo.Text;
                    }
                    else
                    {
                        //Guardar en session cada uno 
                        LblTitulo.Text = Session["DatosComisionNuevo-Materia" + Session.SessionID].ToString() + " - Turno " + Session["DatosComisionNuevo-Turno" + Session.SessionID].ToString() + " - " + Session["DatosComisionNuevo-Anio" + Session.SessionID] + " ";
                        Session["DatosComision" + Session.SessionID] = LblTitulo.Text;
                    }
                    CargaDGVInstancia();
                    DpTipo.DataValueField = "Id";
                    DpTipo.DataTextField = "Nombre";
                    DpTipo.DataSource = tipoInstanciaServices.Listar();
                    DpTipo.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        public void CargaDGVInstancia()
        {
            try
            {
                lblIncorrecto.Text = "";
                InstanciaServices instanciaServices = new InstanciaServices();
                TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
                var ValorComision = Request.QueryString["valor"];
                List<Instancia> instancias = new List<Instancia>();
                if (Request.QueryString["valor"] != "22041997")
                {
                    instancias = instanciaServices.ListarXComision(Convert.ToInt64(ValorComision), TboxNombreIns.Text, DpTipo.SelectedItem.Text);
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
                    Aux.TipoInstancia = new TipoInstancia();
                    Aux.TipoInstancia.Id = 0;
                    Aux.TipoInstancia.Nombre = "";
                    Listado.Add(Aux);
                    DGVInstancia.DataSource = Listado;
                    var algo =DGVInstancia.Rows.Count.ToString();
                    DGVInstancia.DataBind();
                    DGVInstancia.Rows[0].Visible = false;
                    lblIncorrecto.Text = "No se encontraron datos";
                }
                else
                {
                    DGVInstancia.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        protected void DGVInstancia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            DGVInstancia.Columns[0].Visible = false;
            if (Request.QueryString["valor"] == "22041997")
            {
                DGVInstancia.Columns[3].Visible = false;
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargaDGVInstancia();
        }

        protected void DGVInstancia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVInstancia.PageIndex = e.NewPageIndex;
            CargaDGVInstancia();
        }
    }
}