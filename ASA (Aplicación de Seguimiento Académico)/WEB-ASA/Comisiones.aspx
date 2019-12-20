﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="WEB_ASA.Comisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card:hover {
            box-shadow: 1px 8px 20px rgb(49, 100, 129);
            -webkit-transition: box-shadow 0.35s ease-in;
        }
    </style>

    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <div >
            <h3>Comisiones</h3>                        
        </div>
    </div>
    <asp:Button Text="Agregar Comisión" runat="server" class="btn btn-lg btn-info" Style="margin-left: 100px;" OnClick="BtnComision_Click" />
    <div class="row" style="margin-left: 25px; margin-right: 25px; margin-top: 10px;">

        <% foreach (var item in Comisions)
            { %>
        <div class="col-sm-4" style="margin-top: 25px;">
            <div class="card">
                <div class="card text-center border-info">
                    <div class="card-header bg-white">
                        <% =item.Materia.Carrera.Universidad.Nombre %>
                    </div>
                    <div class="card-body ">
                        <h5 class="card-title"><% =item.Materia.Nombre %></h5>
                        <p class="card-text"><% =item.Materia.Carrera.Nombre %></p>
                        <%--<asp:Button ID="<% =item.Id %>" runat="server" Text="Instancias Evaluativas" class="btn btn-primary btn-info" OnClick="BtnClick"/>--%>
                        <a href="List-Instancia.aspx?valor=<% =item.Id %>" class="btn btn-lg btn-info">Instancias Evaluativas</a>
                    </div>
                    <div class="card-footer bg-transparent">
                        <% =item.Cuatrimestre.Nombre + ", Turno " + item.Turno.Nombre + ", Año " + item.Anio %>
                    </div>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
