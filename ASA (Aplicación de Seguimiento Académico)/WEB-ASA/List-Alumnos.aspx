<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="List-Alumnos.aspx.cs" Inherits="WEB_ASA.List_Alumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .customers {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            .customers td, .customers th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            /*.customers tr:nth-child(even) {
                background-color: #f2f2f2;
            }*/

            /*.customers tr:hover {
                background-color: #ddd;
            }*/

            .customers th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #5bc0de;
                color: white;
                text-align: center;
            }
    </style>


    <div class="container" style="height: 22px;">
        <div class="row">
            <div style="margin-left: 20px;">
                <a href="Comisiones.aspx">Comisiones </a>
            </div>
            <p>> </p>
            <div>
                <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>">Instancias Evaluativas</a>
            </div>
        </div>
    </div>
    <hr style="margin-top: 0px; margin-bottom: 4px;" />


    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <h3>
            <asp:Label Text="" ID="LblTitulo" runat="server" />
        </h3>
    </div>

    <%-- FILTRO --%>
    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <div style="margin-left: 10px;">
            <asp:TextBox runat="server" ID="TboxLegajo" placeholder="Legajo" CssClass="form-control" />
        </div>
        <div style="margin-left: 10px;">
            <asp:TextBox runat="server" ID="TboxNombre" placeholder="Nombre" CssClass="form-control" />
        </div>
        <div style="margin-left: 10px;">
            <asp:TextBox runat="server" ID="TboxApellido" placeholder="Apellido" CssClass="form-control" />
        </div>
        <div>
            <asp:Button Text="Buscar" runat="server" ID="BtnBuscar" OnClick="BtnBuscar_Click" class="btn btn-info" />
        </div>
    </div>
    <%-- Fin Filtro --%>



    <div class="container-fluid" style="margin-top: 10px;">
        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />
        <a href="ABM-Alumno-List.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info btn-block">Agregar o Modificar Alumnos</a>


        <% if (Request.QueryString["valor"] == "22041997" && lblIncorrecto.Text == "")
            { %>
        <asp:Button ID="BtnGuardarComision" Text="Guardar Comision" class="btn btn-info btn-info btn-block" runat="server" OnClick="BtnGuardarComision_Click" />
        <%} %>


        <%--Inicio GridView Alumnos--%>
        <asp:GridView ID="DGVAlumnos" runat="server" Class="customers" AutoGenerateColumns="false" OnRowCreated="DGVAlumnos_RowCreated" 
            AllowPaging="True" PageSize="4" OnPageIndexChanging="DGVAlumnos_PageIndexChanging"
            PagerSettings-Mode="NumericFirstLast">
            <Columns>
                <asp:TemplateField HeaderText="Legajo">
                    <ItemTemplate>
                        <asp:Label ID="LBLegajo" Text='<%# Eval("Legajo")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Nombre--%>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nombre")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Apellido--%>
                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Apellido")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>


                <%--Alumnos--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="Comentario.aspx?valor=<%# Eval("Legajo")%>" class="btn btn-info btn-block">Comentario</a>
                        <%--<asp:Button Text="Alumnos" runat="server" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>

        <%--Fin GridView Alumnos--%>
    </div>
</asp:Content>
