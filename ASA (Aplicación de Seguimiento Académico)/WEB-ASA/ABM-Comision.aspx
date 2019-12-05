<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-Comision.aspx.cs" Inherits="WEB_ASA.ABM_Comision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).keyup(
            function txtLlenos() {
                var objeto = [document.getElementById("TboxAnio")]
                success = true;
                for (var i = 0; i < 1; i++) {
                    if (!objeto[i].classList.contains("border-success")) {
                        success = false;
                    }
                }
                if (success) {
                    document.getElementById("BtnIntancia").disabled = false;
                }
                else {
                    document.getElementById("BtnIntancia").disabled = true;
                }
            });

        $(document).keyup(
            function VaciarLblError() {
                document.getElementById("LblIntancia").innerHTML = "";
            });

        $(document).ready(function () {
            var objeto = [document.getElementById("TboxAnio")]
            success = false;
            for (var i = 0; i < 1; i++) {
                if (objeto[i].value != "" && objeto[i].value.length >= 1) {
                    objeto[i].className += " border border-success";
                    success = true;
                }
            }
            if (!objeto[0].classList.contains("border-success")) {
                document.getElementById("BtnIntancia").disabled = true;

            }
            else if (success) {
                document.getElementById("BtnIntancia").disabled = false;
            }
        });

        function Seleccionar(text) {
            objeto = document.getElementById(text);
            if (objeto.classList.contains("border-success")) {
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
                btnValidar.disabled = false;
            } else {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
            }
        }

        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function validarVacio(text) {
            objeto = document.getElementById(text);
            valueForm = objeto.value;
            if (valueForm != "" && valueForm.length == 4) {
                objeto.className = "form-control border border-success";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
            }
            else {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
            }
        }
    </script>

        <div class="container  row">
        <div>
            <a href="Comisiones.aspx">Comisiones</a>
        </div>
    </div>


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
                <asp:TextBox ID="TboxAnio" ClientIDMode="Static" runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" class="form-control custom-control" placeholder="2019" MaxLength="4" />
            </div>
        </div>
        <div class="row">
            <asp:Button Text="Instancias" ID="BtnIntancia" ClientIDMode="Static" autoposback="false" runat="server" class="btn btn-lg btn-info" OnClick="BtnInstancias_click" disabled="true" />
            <asp:Label Text="" ID="LblIntancia" runat="server" ClientIDMode="Static"  />
        </div>
    </div>

</asp:Content>
