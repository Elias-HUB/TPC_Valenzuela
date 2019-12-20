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

    <div class="container" style="height: 22px;">
        <div class="row ">
            <a href="Comisiones.aspx">Comisiones </a>
            <p>> </p>
            <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>">Instancias Evaluativas</a>
        </div>
    </div>
    <hr style="margin-top: 0px; margin-bottom: 4px;" />


    <div class="form-row align-content-center" style="margin-left: 25px; margin-right: 25px; justify-content: center;">
        <h3>
            <asp:Label Text="" ID="LblTitABM" runat="server" Style="margin-left: 20px;" />
        </h3>
    </div>


    <%-- FILTRO --%>
    <div class="form-row align-content-center" style="justify-content: center;">
        <div class="col-3">
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



    <%-- Agregar Instancia --%>
    <div class="form-row align-content-center align-items-center" style="justify-content: center; margin-top:10px;">
        <asp:Label Text="Nueva Instancia" runat="server" />       
        <div class="col-3">
            <asp:TextBox runat="server" ID="TboxNombreNuevo" placeholder="Instancia" CssClass="form-control" Style="height: 48px;" />
        </div>
        <div style="margin-left: 10px;">
            <asp:DropDownList runat="server" ID="DpTipoNuevo" Class="custom-select custom-select-lg" Style="height: 48px;"></asp:DropDownList>
        </div>
        <div>
            <asp:Button Text="Agregar" runat="server" ID="BtnAgregar" OnClick="BtnAgregar_Click" class="btn btn-info" Style="height: 48px;" />
        </div>
    </div>
    <%-- Fin Agregar Instancia --%>


    <div class="container-fluid" style="margin-top: 10px;">

        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />

        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />

        <%--* Inicio GRID Instancia*--%>

        <asp:GridView ID="DGVInstancia" runat="server" ShowFooterWhenEmpty="True" Class="customers" AutoGenerateColumns="false" ShowFooter="False" DataKeyNames="Id"
            OnRowCommand="dgvIntancia_RowCommand" OnRowEditing="dgvIntancia_RowEditing" OnRowCancelingEdit="dgvIntancia_RowCancelingEdit"
            OnRowUpdating="dgvIntancia_RowUpdating" OnRowDeleting="dgvIntancia_RowDeleting"
            OnRowDataBound="dgvIntancia_RowDataBound" OnRowCreated="DGVInstancia_RowCreated" ShowHeaderWhenEmpty="True" OnPageIndexChanging="DGVInstancia_PageIndexChanging"
            AllowPaging="True" PagerStyle-HorizontalAlign="Center" PagerSettings-PageButtonCount="4" PagerSettings-Mode="NumericFirstLast" PageSize="4">
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
