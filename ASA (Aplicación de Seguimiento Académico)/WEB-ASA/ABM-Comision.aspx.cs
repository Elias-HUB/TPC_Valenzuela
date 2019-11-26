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
            //DlistTipo.DataValueField = "Id";
            //DlistTipo.DataTextField = "Nombre";
            //DlistTipo.DataSource = tipoInstanciaServices.Listar();
            //DlistTipo.DataBind();
            DlistTurno.DataValueField = "Id";
            DlistTurno.DataTextField = "Nombre";
            DlistTurno.DataSource = turnoServices.Listar();
            DlistTurno.DataBind();
        }

        public void CargaDGVInstancia()
        {
            InstanciaServices instanciaServices = new InstanciaServices();
            TipoInstanciaServices tipoInstanciaServices = new TipoInstanciaServices();
            List<Instancia> instancias = instanciaServices.Listar();
            DGVInstancia.DataSourceID = null;
            DGVInstancia.DataSource = instancias;
            DGVInstancia.DataBind();
            ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataValueField = "Id";
            ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataTextField = "Nombre";
            ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataSource = tipoInstanciaServices.Listar();
            ((DropDownList)DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter")).DataBind();
        }

        protected void dgvIntancia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    InstanciaServices instanciaServices = new InstanciaServices();
                    Instancia instancia = new Instancia();
                    instancia.Nombre = (DGVInstancia.FooterRow.FindControl("txbNombreFooter") as TextBox).Text;
                    instancia.FechaInicio = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaInicioFooter") as TextBox).Text);
                    instancia.FechaFin = Convert.ToDateTime((DGVInstancia.FooterRow.FindControl("TboxFechaFinFooter") as TextBox).Text);

                    instancia.TipoInstancia = new TipoInstancia();
                    instancia.TipoInstancia.Nombre = (DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedItem.ToString();
                    instancia.TipoInstancia.Id = Convert.ToInt64((DGVInstancia.FooterRow.FindControl("DGBDlistTipoFooter") as DropDownList).SelectedValue);

                    instanciaServices.Nuevo(instancia);
                    lblCorrecto.Text = "Se a agregado la instancia de manera correctamente.";
                    lblIncorrecto.Text = "";
                    CargaDGVInstancia();
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
                instancia.Id = Convert.ToInt64((DGVInstancia.Rows[e.RowIndex].FindControl("LBLId") as Label).Text);
                instancia.Nombre = (DGVInstancia.Rows[e.RowIndex].FindControl("TboxNombre") as TextBox).Text;
                instancia.FechaInicio = Convert.ToDateTime((DGVInstancia.Rows[e.RowIndex].FindControl("TboxFechaInicio") as TextBox).Text);
                instancia.FechaFin = Convert.ToDateTime((DGVInstancia.Rows[e.RowIndex].FindControl("TboxFechaFin") as TextBox).Text);

                instancia.TipoInstancia = new TipoInstancia();
                instancia.TipoInstancia.Nombre = (DGVInstancia.Rows[e.RowIndex].FindControl("DGBDlistTipo") as DropDownList).SelectedItem.ToString();
                instancia.TipoInstancia.Id = Convert.ToInt64((DGVInstancia.Rows[e.RowIndex].FindControl("DGBDlistTipo") as DropDownList).SelectedValue);
                instanciaServices.Modificar(instancia);
                lblCorrecto.Text = "Se Modifico la Instancia de manera correctamente.";
                lblIncorrecto.Text = "";
                DGVInstancia.ShowFooter = true;
                Response.Redirect("ABM-Comision.aspx");
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
                instanciaServices.Eliminar(instancia.Id);
                lblCorrecto.Visible = true;
                lblCorrecto.Text = "Se elimino la instancia de manera correcta";
                lblIncorrecto.Text = "";
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
            e.Row.Cells[0].Visible = false;
            //e.Row.Cells[2].Visible = false;
        }
    }
}