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

    <div>
        <div class="container  row">
            <div>
                <a href="Comisiones.aspx">Comisiones </a>
            </div>
            <p>> </p>
            <div>
                <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>">Instancias Evaluativas</a>
            </div>
        </div>


        <div class="container">
            <a href="ABM-Alumno-List.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info btn-block">Agregar o Modificar Alumnos</a>
            <%--Inicio GridView Alumnos--%>


            <asp:GridView ID="DGVAlumnos" Style="margin-top: 10px" runat="server" Class="customers" AutoGenerateColumns="false" OnRowCreated="DGVAlumnos_RowCreated">
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
            </asp:GridView>
            <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
            <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />
            <%--Fin GridView Alumnos--%>

                        <% if (Request.QueryString["valor"] == "22041997" && lblIncorrecto.Text =="" )
                { %>
            <asp:Button ID="BtnGuardarComision" Text="Guardar Comision" class="btn btn-info btn-info btn-block" runat="server" OnClick="BtnGuardarComision_Click" />
            <%} %>
        </div>
    </div>
</asp:Content>
