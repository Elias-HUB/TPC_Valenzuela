<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="WEB_ASA.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card:hover {
            box-shadow: 1px 8px 20px rgb(49, 100, 129);
            -webkit-transition: box-shadow 0.12s ease-in;
        }
    </style>

    <div class="col-md-6 row">
        <h3>Comiciones</h3>
        <button type="button" class="btn mt-50 btn-lg btn-primary">
            Agregar Comisión
        </button>
    </div>
    <div class="card-columns Margen" style="margin-left: 25px; margin-right: 25px;">

        <% foreach (var item in Comisions)
            { %>
        <div class="card text-center border-info">
            <div class="card-header bg-white">
                <% =item.Materia.Carrera.Universidad.Nombre %>
            </div>
            <div class="card-body ">
                <h5 class="card-title"><% =item.Materia.Nombre %></h5>
                <p class="card-text"><% =item.Materia.Carrera.Nombre %></p>
                <a href="#" class="btn btn-primary btn-info">Instancias Evaluativas</a>
            </div>
            <div class="card-footer bg-transparent">
                <% =item.Cuatrimestre.Nombre + " " + item.Anio  %>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
