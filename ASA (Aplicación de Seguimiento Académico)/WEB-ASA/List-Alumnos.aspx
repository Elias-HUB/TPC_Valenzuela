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
            <div class="col-4">
                <p>COMISION</p>
            </div>
            <div class="col-4">
                 <a href="ABM-Alumno-List.aspx?IdComision=<% =(Session["IdComision" + Session.SessionID]) %>" class="btn btn-info">Agregar Alumno</a>
                <%--<button type="button" class="btn btn-info">
                    Agregar Alumno
                </button>--%>
            </div>
            <div class="col-4">
                <button type="button" class="btn btn-info">
                    Info
                </button>
            </div>
        </div>
        <div class="container">

            <%--Inicio GridView Alumnos--%>

            <div class="container">
                <asp:GridView ID="DGVAlumnos" runat="server" Class="customers" AutoGenerateColumns="false">
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

                <%--Fin GridView Alumnos--%>
            </div>
        </div>
    </div>
</asp:Content>
