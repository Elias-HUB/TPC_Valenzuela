<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-Comision.aspx.cs" Inherits="WEB_ASA.ABM_Comision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-4">
                <h4>Ingresá los datos de la Comision</h4>
            </div>
        </div>

        <%--* 1ª Fila *--%>

        <div class="form-group row ">
            <label class="col-1 col-form-label">Materia</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistMateria" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>

            <label class="col-1 col-form-label">Turno</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistTurno" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>
        </div>


        <%--* 2º Fila *--%>
        <div class="form-group row">
            <label class="col-1 col-form-label">Cuatrimestre</label>
            <div class="col-3">
                <asp:DropDownList ID="DlistCuatrimestre" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
            </div>

            <div class="col-1 col-form-label">
                <asp:Label Text="Año" runat="server" class="col-sm-2 col-form-label" />
            </div>
            <div class="col-sm-2">
                <asp:TextBox ID="TboxAnio" runat="server" class="form-control custom-control" placeholder="2019" TextMode="Number" />
            </div>
        </div>



        <%--* Inicio Instancia fila 1 *--%>


        <%--<div>
                    <label>Instancia</label>
                </div>
    <%--              <div class="form-group row">
                    <div class="col-5">
                        <asp:TextBox runat="server" type="text" class="form-control" placeholder="Nombre" />
                    </div>


                    <div class="col-3">
                        <asp:DropDownList ID="DlistTipo" runat="server" Class="custom-select custom-select-lg mb-3"></asp:DropDownList>
                    </div>
                </div>--%>


        <%--* Inicio Instancia fila 2 *--%>
        <%--<div class="form-group row">
                    <div class="col-3 form-group">
                        <asp:Label Text="Fecha Inicio" runat="server" />
                        <asp:TextBox runat="server" class="form-control" TextMode="Date" />
                    </div>
                    <div class="col-3 form-group">
                        <asp:Label Text="Fecha Fin" runat="server" />
                        <asp:TextBox runat="server" class="form-control" TextMode="Date" />
                    </div>
                    <div>
                        <button class="btn btn-dark">Agregar</button>
                    </div>
                </div>--%>

        <asp:Label ID="lblCorrecto" Text="" runat="server" ForeColor="Green" />
        <br />
        <asp:Label ID="lblIncorrecto" Text="" runat="server" ForeColor="Red" />

        <%--* Inicio GRID Instancia*--%>
        <%--<div style="border-left: 10PX; border-right: 10px">--%>
        <asp:GridView ID="DGVInstancia" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Id"
            OnRowCommand="dgvIntancia_RowCommand" OnRowEditing="dgvIntancia_RowEditing"
            OnRowCancelingEdit="dgvIntancia_RowCancelingEdit" OnRowUpdating="dgvIntancia_RowUpdating"
            OnRowDeleting="dgvIntancia_RowDeleting" OnRowDataBound="dgvIntancia_RowDataBound" OnRowCreated="DGVInstancia_RowCreated">
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
                        <asp:TextBox runat="server" ID="TboxNombre" Text='<%# Eval("Nombre")%>' class="form-control col-12" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="txbNombreFooter" />
                    </FooterTemplate>
                </asp:TemplateField>

                <%--Tipo Instancia ID--%>
              <%--  <asp:TemplateField HeaderText="Tipo de la Instancia">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("TipoInstancia.Id")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DGBDlistTipoid" runat="server" Class="custom-select custom-select-lg" DataTextField="Nombre" DataValueField="Id">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="DGBDlistTipoFooterid" runat="server" Class="custom-select custom-select-lg" DataTextField="Nombre" DataValueField="Id">
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>--%>

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
                <asp:TemplateField HeaderText="Fecha Inicio">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FechaInicio")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaInicio" Text='<%# Eval("FechaInicio")%>' class="form-control" TextMode="DateTime" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaInicioFooter" class="form-control" TextMode="DateTimeLocal" />
                    </FooterTemplate>
                </asp:TemplateField>

                <%--Fecha Fin--%>
                <asp:TemplateField HeaderText="Fecha Fin">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("FechaFin")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaFin" Text='<%# Eval("FechaFin")%>' class="form-control" TextMode="DateTime" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox runat="server" ID="TboxFechaFinFooter" class="form-control" TextMode="DateTimeLocal" />
                    </FooterTemplate>
                </asp:TemplateField>


                <%--<ACCIONES >--%>
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Editar.svg" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Imagenes/Eliminar.svg" runat="server" CommandName="Delete" ToolTip="Eliminar" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Guardar.svg" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Imagenes/Atras.svg" runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Imagenes/Nuevo.png" runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--</div>--%>
        <%--* Fin GRID Instancia*--%>
    </div>
    <%--* Fin GRID Alumno*--%>
</asp:Content>
