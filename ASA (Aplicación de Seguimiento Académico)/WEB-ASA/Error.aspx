<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WEB_ASA.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="jumbotron">
        <div class="alert alert-danger" role="alert" style="margin-top: 10px">
            <p>
                <% = Session["Error" + Session.SessionID] %>
            </p>
        </div>
        <a href="Comisiones.aspx" class="btn btn-dark" style="margin-top: 10px">Cargar otro voucher</a>
    </div>

    <div><a class="h6" href="https://cdn.memegenerator.es/imagenes/memes/full/3/88/3887280.jpg">Soporte técnico</a></div>

</asp:Content>
