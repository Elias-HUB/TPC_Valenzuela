<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="List-Instancia.aspx.cs" Inherits="WEB_ASA.List_Instancia" %>

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
        <div class="row ">
            <div style="margin-left: 20px;">
                <a href="Comisiones.aspx">Comisiones</a>
            </div>
        </div>
    </div>
    <hr style="margin-top: 0px; margin-bottom: 4px;" />

    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <h3>
            <asp:Label Text="" ID="LblTitulo" runat="server" Style="margin-left: 20px;" />
        </h3>
    </div>

    <%-- FILTRO --%>
    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <div style="margin-left: 10px;">
            <asp:TextBox runat="server" ID="TboxNombreIns" placeholder="Instancia" CssClass="form-control" Style="height: 48px;" />
        </div>
        <div style="margin-left: 10px;">
            <asp:DropDownList ID="DpTipo" runat="server" Class="custom-select custom-select-lg" Style="height: 48px;" AppendDataBoundItems="True">
                <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button Text="Buscar" runat="server" ID="BtnBuscar" OnClick="BtnBuscar_Click" class="btn btn-info" Style="height: 48px;" />
        </div>
    </div>
    <%-- Fin Filtro --%>


    <div class="container-fluid" style="margin-top: 10px;">
        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />
        <a href="ABM-Instancia.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info btn-block">Agregar o Modificar Instancias</a>

        <% if (Request.QueryString["valor"] == "22041997" && lblIncorrecto.Text == "")
            { %>
        <a href="List-Alumnos.aspx?valor=22041997" class="btn btn-info btn-info btn-block">Agregar Alumnos</a>
        <%} %>


        <%--Inicio GridView Instancias--%>

        <asp:GridView ID="DGVInstancia" runat="server" Class="customers" AutoGenerateColumns="false" DataKeyNames="Id"
            OnRowCreated="DGVInstancia_RowCreated" AllowPaging="True"
            PagerSettings-Mode="NumericFirstLast" PageSize="4" OnPageIndexChanging="DGVInstancia_PageIndexChanging"
            PagerSettings-Position="Bottom">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="LBLId" Text='<%# Eval("Id")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Nombre--%>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nombre")%>' runat="server" />
                    </ItemTemplate>

                </asp:TemplateField>

                <%--Tipo Instancia Nombre--%>
                <asp:TemplateField HeaderText="Tipo de la Instancia">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("TipoInstancia.Nombre")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>


                <%--Alumnos--%>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <a href="List-Alumnos.aspx?valor=<%# Eval("Id")%>" class="btn btn-info btn-info btn-block">Alumnos</a>
                        <%--<asp:Button Text="Alumnos" runat="server" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast"></PagerSettings>
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>

        <%--Fin GridView Instancias--%>
    </div>
</asp:Content>
