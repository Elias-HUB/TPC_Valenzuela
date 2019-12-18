<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-Alumno-List.aspx.cs" Inherits="WEB_ASA.ABM_Alumno_List" %>

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
            <a href="Comisiones.aspx">Comisiones </a>
        </div>
        <p>> </p>
        <div>
            <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>">Instancias Evaluativas</a>
        </div>
        <p>> </p>
        <div>
            <a href="List-Alumnos.aspx?valor=<% =(Session["IdComision-Instancia" + Session.SessionID]) %>">Alumnos Insciptos</a>
        </div>
    </div>
    <hr style="margin-top: 0rem;    margin-bottom: 0,3rem;"/>

    <%--<a href="List-Alumnos.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>" class="btn btn-lg btn-info">Alumnos</a>--%>
    <div class="container-fluid">
        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />

        <%--* Inicio GRID Alumnos*--%>

        <asp:GridView ID="DGVAlumnos" runat="server" ShowFooterWhenEmpty="True" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Legajo"
            OnRowCommand="dgvIntancia_RowCommand" OnRowEditing="dgvIntancia_RowEditing" OnRowCancelingEdit="dgvIntancia_RowCancelingEdit"
            OnRowUpdating="dgvIntancia_RowUpdating" OnRowDeleting="dgvIntancia_RowDeleting" OnSelectedIndexChanged="DGVAlumnos_SelectedIndexChanged"
            OnRowDataBound="dgvIntancia_RowDataBound" OnRowCreated="DGVInstancia_RowCreated" ShowHeaderWhenEmpty="True" Class="customers">
            <Columns>
                <%--Legajo--%>
                <asp:TemplateField HeaderText="Legajo">
                    <ItemTemplate>
                        <asp:Label ID="LBLegajo" Text='<%# Eval("Legajo")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TboxLegajo" Text='<%# Eval("Legajo")%>' runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Nombre--%>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxNombre" Text='<%# Eval("Nombre")%>' class="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Apellido--%>
                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Apellido")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxApellido" Text='<%# Eval("Apellido")%>' class="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Email--%>
                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Email")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxEmail" Text='<%# Eval("Email")%>' class="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--<ACCIONES >--%>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Editar.svg" runat="server" CommandName="Select" ToolTip="Editar" Width="30px" Height="30px" />
                        <asp:ImageButton ImageUrl="~/Imagenes/Eliminar.svg" runat="server" CommandName="Delete" ToolTip="Eliminar" Width="30px" Height="30px" Style="margin-left: 5px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Guardar.svg" runat="server" CommandName="Update" ToolTip="Guardar" Width="30px" Height="30px" />
                        <asp:ImageButton ImageUrl="~/Imagenes/Atras.svg" runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="30px" Height="30px" Style="margin-left: 10px" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Nuevo.png" runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="35px" Height="35px" Style="margin-left: 20px" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--* Fin GRID Alumnos*--%>
    </div>

</asp:Content>
