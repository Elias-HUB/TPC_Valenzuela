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

    <div>
        <div class="container  row">
            <div class="col-4">
                <p>COMISION > INSTANCIA </p>
            </div>
            <div class="col-4">
                <a href="ABM-Instancia.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info">Agregar Instancias</a>
            </div>
            <div class="col-4">
                <button type="button" class="btn btn-info">
                    Info
                </button>
            </div>
        </div>
        

        <%--Inicio GridView Instancias--%>
        <div class="container">
            <asp:GridView ID="DGVInstancia" runat="server" Class="customers" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCreated="DGVInstancia_RowCreated">
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
                    <asp:TemplateField HeaderText="Fecha Inicio">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FechaInicio")%>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--Fecha Fin--%>
                    <asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FechaFin")%>' runat="server" />
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
            </asp:GridView>
            
            <%--Fin GridView Instancias--%>
        </div>

    </div>

</asp:Content>
