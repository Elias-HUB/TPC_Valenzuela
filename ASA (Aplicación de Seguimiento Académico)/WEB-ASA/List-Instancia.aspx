<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="List-Instancia.aspx.cs" Inherits="WEB_ASA.List_Instancia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="container  row">
            <div class="col-4">
                <p>COMICION > ALUMNO </p>
            </div>
            <div class="col-4">
                <button type="button" class="btn btn-info">
                    Agregar
                </button>
            </div>
            <div class="col-4">
                <button type="button" class="btn btn-info">
                    Info
                </button>
            </div>
        </div>
        <div class="container">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Nombre</th>
                        <th scope="col">Tipo</th>
                        <th scope="col">Fecha Inicio</th>
                        <th scope="col">Fecha Fin</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">TP1</th>
                        <td>Trabajo Practico</td>
                        <td>15/09</td>
                        <td>29/09</td>
                    </tr>
                    <tr>
                        <th scope="row">TPC</th>
                        <td>Trabajo Practico</td>
                        <td>01/10</td>
                        <td>30/11</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
