<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WEB_ASA.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron">
        <div class="alert alert-danger" role="alert" style="margin-top: 10px">
            <p>
                <% = Session["Error" + Session.SessionID] %>  ALTO ERROR WACHO
            </p>
        </div>        
    </div>

    <div>
        <h3>
            <a class="h6" href="https://cdn.memegenerator.es/imagenes/memes/full/3/88/3887280.jpg">Soporte técnico</a>
        </h3>
    </div>

</asp:Content>
