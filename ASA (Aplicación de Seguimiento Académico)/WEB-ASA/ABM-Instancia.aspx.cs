﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;

namespace WEB_ASA
{
    public partial class ABM_Instancia : System.Web.UI.Page
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
                InstanciaServices instanciaServices = new InstanciaServices();
                TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
                List<Instancia> instancias = new List<Instancia>();
                var IdComision = Request.QueryString["IdComision"];
                if (Request.QueryString["IdComision"] != "22041997")
                {
                    instancias = instanciaServices.ListarXComision(Convert.ToInt64(Request.QueryString["IdComision"]));
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
                }
                else
                {
                    DGVInstancia.DataBind();
                }
                ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataValueField = "Id";
                ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataTextField = "Nombre";
                ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataSource = tipoInstanciaServices.Listar();
                ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataBind();
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
                    if ((DGVInstancia.FooterRow.FindControl("txbNombreFooter") as TextBox).Text != "")
                    {
                        if (Request.QueryString["IdComision"] != "22041997")
                        {
                            InstanciaServices instanciaServices = new InstanciaServices();
                            Instancia instancia = new Instancia();
                            instancia.Nombre = (DGVInstancia.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                            instancia.FechaInicio = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaInicioFooter") as TextBox).Text);
                            instancia.FechaFin = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaFinFooter") as TextBox).Text);

                            instancia.TipoInstancia = new TipoInstancia();
                            instancia.TipoInstancia.Nombre = (DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedItem.ToString();
                            instancia.TipoInstancia.Id = Convert.ToInt64((DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedValue);

                            long id;
                            id = instanciaServices.Nuevo(instancia);

                            //VERIRICAAAAAAAAAAAAAAAR

                            instanciaServices.NuevoComIns(Convert.ToInt64(Request.QueryString["IdComision"]), id);
                            lblCorrecto.Text = "Se a agregado la instancia de manera correctamente.";
                            lblIncorrecto.Text = "";

                            //Aca recargar
                            Response.Redirect("ABM-Instancia.aspx?IdComision=" + Session["IdComision" + Session.SessionID]);

                        }
                        else
                        {
                            InstanciaServices instanciaServices = new InstanciaServices();
                            Instancia instancia = new Instancia();
                            List<Instancia> instancias = Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] as List<Instancia>;
                            instancia.Nombre = (DGVInstancia.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                            instancia.FechaInicio = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaInicioFooter") as TextBox).Text);
                            instancia.FechaFin = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaFinFooter") as TextBox).Text);

                            instancia.TipoInstancia = new TipoInstancia();
                            instancia.TipoInstancia.Nombre = (DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedItem.ToString();
                            instancia.TipoInstancia.Id = Convert.ToInt64((DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedValue);

                            instancias.Add(instancia);
                            Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] = instancias;

                            lblCorrecto.Text = "Se a agregado la instancia de manera correctamente.";
                            lblIncorrecto.Text = "";

                            //Aca recargar
                            Response.Redirect("ABM-Instancia.aspx?IdComision=" + Session["IdComision" + Session.SessionID]);
                        }
                    }
                    else
                    {
                        lblCorrecto.Text = "";
                        lblIncorrecto.Text = "El nombre no puede ir vacio, ingrese nuevamente la instancia";
                        CargaDGVInstancia();
                    }
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
                DGVInstancia.ShowFooter = false;
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

        protected void dgvIntancia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                InstanciaServices instanciaServices = new InstanciaServices();
                Instancia instancia = new Instancia();

                int index = Convert.ToInt32(DGVInstancia.EditIndex);

                instancia.Id = Convert.ToInt64((DGVInstancia.Rows[e.RowIndex].FindControl("LBLId") as Label).Text);
                instancia.Nombre = (DGVInstancia.Rows[e.RowIndex].FindControl("TboxNombre") as TextBox).Text;
                instancia.FechaInicio = Convert.ToDateTime((DGVInstancia.Rows[e.RowIndex].FindControl("TboxFechaInicio") as TextBox).Text);
                instancia.FechaFin = Convert.ToDateTime((DGVInstancia.Rows[e.RowIndex].FindControl("TboxFechaFin") as TextBox).Text);

                instancia.TipoInstancia = new TipoInstancia();
                instancia.TipoInstancia.Nombre = (DGVInstancia.Rows[e.RowIndex].FindControl("DGBDlistTipo") as DropDownList).SelectedItem.ToString();
                instancia.TipoInstancia.Id = Convert.ToInt64((DGVInstancia.Rows[e.RowIndex].FindControl("DGBDlistTipo") as DropDownList).SelectedValue);

                if (Request.QueryString["IdComision"] != "22041997")
                {
                    instanciaServices.Modificar(instancia);
                }
                else
                {
                    Instancia AUX = new Instancia();
                    List<Instancia> instancias = Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] as List<Instancia>;
                    instancias[index] = instancia;
                    Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] = instancias;
                }



                lblCorrecto.Text = "Se Modifico la Instancia de manera correctamente.";
                lblIncorrecto.Text = "";
                DGVInstancia.ShowFooter = true;
                Response.Redirect("ABM-Instancia.aspx?IdComision=" + Session["IdComision" + Session.SessionID]);
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

        protected void dgvIntancia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DGVInstancia.EditIndex = -1;
            DGVInstancia.ShowFooter = true;
            CargaDGVInstancia();
        }

        protected void dgvIntancia_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvIntancia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                InstanciaServices instanciaServices = new InstanciaServices();
                Instancia instancia = new Instancia();
                instancia.Id = Convert.ToInt64((DGVInstancia.Rows[e.RowIndex].FindControl("LBLId") as Label).Text);
                int index = Convert.ToInt32(DGVInstancia.DataKeys[e.RowIndex].Value.ToString());

                if (Request.QueryString["IdComision"] != "22041997")
                {
                    if (instanciaServices.ProtecEliminar(instancia.Id) == false)
                    {
                        instanciaServices.Eliminar(instancia.Id);
                        lblCorrecto.Visible = true;
                        lblCorrecto.Text = "Se elimino la instancia de manera correcta";
                        lblIncorrecto.Text = "";
                        CargaDGVInstancia();
                    }
                    else
                    {
                        lblIncorrecto.Visible = true;
                        lblIncorrecto.Text = "En esta instancia los Alumnos tienen comentarios, no puede ser eliminada.";
                        lblCorrecto.Text = "";
                        CargaDGVInstancia();
                    }

                }
                else
                {
                    List<Instancia> instancias = Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] as List<Instancia>;
                    instancias.RemoveAt(index);
                    Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] = instancias;
                }
            }
            catch (Exception ex)
            {
                lblCorrecto.Text = "";
                lblIncorrecto.Text = ex.Message;
            }
        }

        protected void DGVInstancia_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            //e.Row.Cells[2].Visible = false;
        }
    }
}