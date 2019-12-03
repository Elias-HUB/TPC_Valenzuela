<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-Comision.aspx.cs" Inherits="WEB_ASA.ABM_Comision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-4">
                <h4>Ingresá los datos de la Comision</h4>
            </div>
        </div>

        <%--* 1ª Fila *--%>

        <div class="form-group row ">
            <label class="col-1 col-form-label">Materia</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistMateria" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>

            <label class="col-1 col-form-label">Turno</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistTurno" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>
        </div>


        <%--* 2º Fila *--%>
        <div class="form-group row">
            <label class="col-1 col-form-label">Cuatrimestre</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistCuatrimestre" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>

            <div class="col-1 col-form-label">
                <asp:Label Text="Año" runat="server" class="col-sm-2 col-form-label" />
            </div>
            <div class="col-sm-2">
                <asp:TextBox ID="TboxAnio" runat="server" class="form-control custom-control" placeholder="2019" TextMode="Number" />
            </div>
        </div>
        <asp:Button Text="Instancias" runat="server" OnClick="BtnInstancias_click" />
    </div>

</asp:Content>
