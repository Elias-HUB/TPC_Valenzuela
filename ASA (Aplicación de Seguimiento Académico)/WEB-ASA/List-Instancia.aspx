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


    <div class="container  row">
        <div>
            <a href="Comisiones.aspx">Comisiones</a>
        </div>
    </div>
    <hr style="margin-top: 0rem;    margin-bottom: 0,3rem;"/>




    <%--Inicio GridView Instancias--%>
    <div class="container">

        <p> </p>

        <div class="container-fluid">
            <a href="ABM-Instancia.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info btn-block">Agregar o Modificar Instancias</a>
            <asp:GridView ID="DGVInstancia" Style="margin-top: 20px" runat="server" Class="customers" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCreated="DGVInstancia_RowCreated" EmptyDataText="No tiene nada">
                <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
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

                    <%--Fecha inicio--%>
                 <%--   <asp:TemplateField HeaderText="Fecha Inicio">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FechaInicio","{0:d}")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <%--Fecha Fin--%>
                    <%--<asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FechaFin","{0:d}")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>


                    <%--Alumnos--%>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <a href="List-Alumnos.aspx?valor=<%# Eval("Id")%>" class="btn btn-info btn-info btn-block">Alumnos</a>
                            <%--<asp:Button Text="Alumnos" runat="server" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>
            <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
            <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />
            <%--Fin GridView Instancias--%>
            <% if (Request.QueryString["valor"] == "22041997" && lblIncorrecto.Text == "")
                { %>
            <a href="List-Alumnos.aspx?valor=22041997" class="btn btn-info btn-info btn-block">Agregar Alumnos</a>
            <%} %>
        </div>
    </div>
</asp:Content>
