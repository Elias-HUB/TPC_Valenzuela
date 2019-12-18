<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ABM-ALumno.aspx.cs" Inherits="WEB_ASA.ABM_ALumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>    
        $(document).keyup(
            function txtLlenos() {
                var objeto = [document.getElementById("TboxLegajo"),
                document.getElementById("TboxNombre"),
                document.getElementById("TboxApellido"),
                document.getElementById("TboxEmail"),
                document.getElementById("TboxTelefono"),
                document.getElementById("TboxDirreccion"),
                document.getElementById("TboxCiudad"),
                document.getElementById("TboxCP")]
                success = true;
                for (var i = 0; i < 8; i++) {
                    if (!objeto[i].classList.contains("border-success")) {
                        success = false;
                    }
                }
                if (success) {
                    document.getElementById("BtnAgregar").disabled = false;
                }
                else {
                    document.getElementById("BtnAgregar").disabled = true;
                }
            });

        $(document).keyup(
            function VaciarLblError() {
                document.getElementById("TboxError").value = "";
            });

        $(document).ready(function () {
            var objeto = [document.getElementById("TboxLegajo"),
            document.getElementById("TboxNombre"),
            document.getElementById("TboxApellido"),
            document.getElementById("TboxEmail"),
            document.getElementById("TboxTelefono"),
            document.getElementById("TboxDirreccion"),
            document.getElementById("TboxCiudad"),
            document.getElementById("TboxCP")]
            success = false;
            for (var i = 0; i < 8; i++) {
                if (objeto[i].value != "" && objeto[i].value.length >= 1) {
                    objeto[i].className += " border border-success";
                    success = true;
                }
            }
            if (!objeto[0].classList.contains("border-success")) {
                document.getElementById("BtnAgregar").disabled = true;
                document.getElementById("BtnBuscar").disabled = true;
            }
            else if (success) {
                document.getElementById("BtnAgregar").disabled = false;
            }
        });



        function validarVacio(text) {
            objeto = document.getElementById(text);
            valueForm = objeto.value;
            if (valueForm != "" && valueForm.length >= 3) {
                objeto.className = "form-control border border-success";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
            }
            else {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
            }
        }

        function validarLegajo() {
            objeto = document.getElementById("TboxLegajo");
            btnValidar = document.getElementById("BtnBuscar");
            valueForm = objeto.value;
            if (valueForm.length < 2) {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
                btnValidar.disabled = true;
            }
            else {
                objeto.className = "form-control border border-success";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
                btnValidar.disabled = false;
            }
        }

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

        function validarEmail() {
            objeto = document.getElementById("TboxEmail");
            valueForm = objeto.value;
            var patron = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/;
            if (valueForm.search(patron) == 0) {
                objeto.className = "form-control border border-success";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
            } else {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
            }
        }

        function soloNumeros(e) {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }

        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = "8-37-39-46";
            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }
            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }
    </script>


    <style>
        .Error {
            border: solid 2px #ff0000;
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
        <p>> </p>
        <div>
            <a href="ABM-Alumno-List.aspx?IdComision=<% =Session["IdComision" + Session.SessionID] %>">Ventana Anterior</a>
        </div>
    </div>
    <hr style="margin-top: 0rem;    margin-bottom: 0,3rem;"/>

    <div class="container">
        <div class="form-row">

            <%--LEGAJO--%>
            <div class="form-group col-md-3">
                <asp:Label Text="Legajo" ID="LblLegajo" ClientIDMode="Static" runat="server" CssClass="control-label" />
                <asp:TextBox ID="TboxLegajo" runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarLegajo(this.id)" onfocus="Seleccionar(this.id)" MaxLength="8" ClientIDMode="Static" Style="margin-top: 10px;" placeholder="22012" CssClass="form-control" />
                <p id="MensajeErrorLegajo"></p>
            </div>

            <div class="form-group col-md-3">
                <asp:Button Text="Buscar Legajo &raquo;" ID="BtnBuscar" ClientIDMode="Static" class="btn btn-dark" autoposback="false" Style="margin-top: 33px; margin-left: 10px;" runat="server" OnClick="BtnBuscar_Click" />
                <asp:Button Text="Agregar &raquo;" ID="BtnAgregar" ClientIDMode="Static" class="btn btn-dark" autoposback="false" Style="margin-top: 33px; margin-left: 10px;" runat="server" disabled="true" OnClick="BtnAgregar_Click" />
            </div>
            <asp:TextBox runat="server" ClientIDMode="Static" autoposback="false" ID="TboxError" ReadOnly="True" BorderColor="White" BackColor="White" BorderStyle="None" Width="516px" />
        </div>

        <div class="form-row " style="margin-top: 10px;">

            <%--Nombre--%>
            <div class="form-group col-md-3">
                <asp:Label Text="Nombre" ID="LblNombre" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox ID="TboxNombre" runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" placeholder="Agustin" CssClass="form-control" />
                <p id="MensajeErrorNombre"></p>
            </div>

            <%--Apellido--%>
            <div class="form-group col-md-3">
                <asp:Label Text="Apellido" ID="LblApellido" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox ID="TboxApellido" runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" placeholder="Argento" CssClass="form-control" />
                <p id="MensajeErrorApellido"></p>
            </div>
        </div>

        <div class="form-row " style="margin-top: 10px;">

            <%--Email--%>
            <div class="form-group col-md-4">
                <asp:Label Text="Email" ID="LblEmail" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                        <div class="input-group-text">@</div>
                    </div>
                    <asp:TextBox ID="TboxEmail" runat="server" onkeyup="validarEmail()" onfocus="Seleccionar(this.id)" MaxLength="33" ClientIDMode="Static" placeholder="Example@gmail.com" CssClass="form-control " />
                    <p id="MensajeErrorEmail"></p>
                </div>
            </div>

            <%--Telefono--%>
            <div class="form-group col-md-4">
                <asp:Label Text="Telefono" ID="LblTelefono" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <asp:TextBox ID="TboxTelefono" runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="15" ClientIDMode="Static" placeholder="1157412365" CssClass="form-control " />
                    <p id="MensajeErrorTelefono"></p>
                </div>
            </div>
        </div>

        <div class="form-row" style="margin-top: 10px;">

            <%--Dirrecion--%>
            <div class="form-group col-md-5">
                <asp:Label Text="Dirección" ID="LblDireccion" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox ID="TboxDirreccion" runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="40" Style="margin-top: 10px;" ClientIDMode="Static" placeholder="Avenida Siempreviva 742" CssClass="form-control " />
                <p id="MensajeErrorDireccion"></p>
            </div>

            <%--Ciudad--%>
            <div class="form-group col-md-">
                <asp:Label Text="Ciudad" ID="LblCiudad" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox ID="TboxCiudad" runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" placeholder="Mi Ciudad" CssClass="form-control" />
                <p id="MensajeErrorCiudad"></p>
            </div>

            <%--Cod Postal--%>
            <div class="form-group col-md-3">
                <asp:Label Text="CP" ID="LblCP" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox ID="TboxCP" runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="8" Style="margin-top: 10px;" ClientIDMode="Static" placeholder="XXXX" CssClass="form-control" />
                <p id="MensajeErrorCP"></p>
            </div>
        </div>


        <%--        <div style="margin-top: 10px; padding-right: 0px;">
            <asp:CheckBox Text="Acepto los términos y condiciones" ClientIDMode="Static" onclick="check()" ID="CboxTerminos" runat="server" Enabled="False" />
            <p id="MensajeErrorCBOX"></p>
        </div>--%>


        <%--<div>
                <%--<asp:Button Text="Agregar Alumno" Style="margin-top: 20px;" class="btn btn-dark" ClientIDMode="Static" ID="BtnAgregar" runat="server" disabled="true" />--%>
        <%--OnClick="BtnParticipar_click" --%>
        <%--</div>--%>
    </div>
</asp:Content>
