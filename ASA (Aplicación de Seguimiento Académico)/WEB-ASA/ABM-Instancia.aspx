<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-Instancia.aspx.cs" Inherits="WEB_ASA.ABM_Instancia" %>

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

    <div class=" container row">
        <a href="Comisiones.aspx">Comisiones </a>
        <p>> </p>
        <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>">Instancias Evaluativas</a>
    </div>

    <hr style="margin-top: 0rem;" />


    <div class="container-fluid">
        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />

        <%--* Inicio GRID Instancia*--%>

        <asp:GridView ID="DGVInstancia" runat="server" ShowFooterWhenEmpty="True" Class="customers" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Id"
            OnRowCommand="dgvIntancia_RowCommand" OnRowEditing="dgvIntancia_RowEditing" OnRowCancelingEdit="dgvIntancia_RowCancelingEdit"
            OnRowUpdating="dgvIntancia_RowUpdating" OnRowDeleting="dgvIntancia_RowDeleting"
            OnRowDataBound="dgvIntancia_RowDataBound" OnRowCreated="DGVInstancia_RowCreated" ShowHeaderWhenEmpty="True">
            <Columns>
                <%--ID--%>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="LBLId" Text='<%# Eval("Id")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label runat="server" ID="LBLId" Text='<%# Eval("Id")%>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txbIdFooter" />
                    </FooterTemplate>
                </asp:TemplateField>
                <%--Nombre--%>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxNombre" Text='<%# Eval("Nombre")%>' />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txbNombreFooter" />
                    </FooterTemplate>
                </asp:TemplateField>


                <%--Tipo Instancia Nombre--%>
                <asp:TemplateField HeaderText="Tipo de la Instancia">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("TipoInstancia.Nombre")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DGBDlistTipo" runat="server" Class="custom-select custom-select-lg" DataTextField="Nombre" DataValueField="Id">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DGBDlistTipoFooter" runat="server" Class="custom-select custom-select-lg" DataTextField="Nombre" DataValueField="Id">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

                <%--Fecha inicio--%>
            <%--    <asp:TemplateField HeaderText="Fecha Inicio">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FechaInicio","{0:d}")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaInicio" Text='<%# Eval("FechaInicio")%>' class="form-control" TextMode="Date" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaInicioFooter" class="form-control" TextMode="Date" />
                    </FooterTemplate>
                </asp:TemplateField>--%>

                <%--Fecha Fin--%>
               <%-- <asp:TemplateField HeaderText="Fecha Fin">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FechaFin","{0:d}")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaFin" Text='<%# Eval("FechaFin")%>' class="form-control" TextMode="Date" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaFinFooter" class="form-control" TextMode="Date" />
                    </FooterTemplate>
                </asp:TemplateField>--%>

                <%--<ACCIONES >--%>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Editar.svg" runat="server" CommandName="Edit" ToolTip="Editar" Width="30px" Height="30px" />
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

        <%--* Fin GRID Instancia*--%>
    </div>
</asp:Content>
