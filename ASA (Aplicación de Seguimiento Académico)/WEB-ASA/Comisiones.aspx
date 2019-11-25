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
        <div class="card-columns Margen">

            <%--Boton--%>
        <div class="card text-white bg-dark">
            <asp:Image ImageUrl="imageurl" runat="server" class="card-img-top"/>
          <%--<img class="card-img-top" alt="..." src="" />--%>
          <div class="card-body">
            <%--<h5 class="card-title">Titulo</h5>--%>
              <asp:Label Text="DESCRIPCION" runat="server" class="card-text"/>
              
            <%--<p class="card-text">DESCRIPCION</p>--%>
          </div>
            <a href="#" class="btn btn-secondary btn-lg btn-block"><h6>Quiero este</h6></a>
       <%--   <Link to="/Alumnos" class="btn btn-secondary btn-lg btn-block">
            <h6>Quiero este</h6>
          </Link>--%>
        </div>
        </div>

</asp:Content>
