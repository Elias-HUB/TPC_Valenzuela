<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="WEB_ASA.Comentario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).ready(function () {
            var objeto = [document.getElementById("TboxDescripcion")]
            success = false;
            for (var i = 0; i < 1; i++) {
                if (objeto[i].value != "" && objeto[i].value.length >= 1) {
                    objeto[i].className += " border border-success";
                    success = true;
                }
            }
            if (!objeto[0].classList.contains("border-success")) {
                document.getElementById("BtnGuardarEnviarMail").disabled = true;
                document.getElementById("BtnGuardar").disabled = true;

            }
            else if (success) {
                document.getElementById("BtnGuardarEnviarMail").disabled = false;
                document.getElementById("BtnGuardar").disabled = false;
            }
        });

        $(document).keyup(
            function txtLlenos() {
                var objeto = [document.getElementById("TboxDescripcion")]
                success = true;
                for (var i = 0; i < 1; i++) {
                    if (!objeto[i].classList.contains("border-success")) {
                        success = false;
                    }
                }
                if (success) {
                    document.getElementById("BtnGuardarEnviarMail").disabled = false;
                    document.getElementById("BtnGuardar").disabled = false;
                }
                else {
                    document.getElementById("BtnGuardarEnviarMail").disabled = true;
                    document.getElementById("BtnGuardar").disabled = true;
                }
            });

        function validarVacio(text) {
            objeto = document.getElementById(text);
            valueForm = objeto.value;
            if (valueForm != "" && valueForm.length != 0) {
                objeto.className = "form-control border border-success";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(79, 162, 51, 0.25)";
            }
            else {
                objeto.className = "form-control border border-danger";
                objeto.style.boxShadow = "0 0 0 0.2rem rgba(255, 0, 0, 0.23)";
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
    </script>

    <style>
        .HV {
            margin-top: 10px;
        }

            .HV:hover {
                box-shadow: 1px 8px 20px rgb(46, 140, 228);
            }

        .Margen {
            margin-top: 20px;
            margin-left: 25px;
            margin-right: 25px;
        }
    </style>

    <div class="container  row">
        <div style ="margin-left: 20px">
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
    <hr style="margin-top: 0rem; margin-bottom: 0,3rem;" />

    <div class="Container">
        <div class="container">
            <p>
                <asp:Label Text="text" ID="LblTitulo" runat="server" />
            </p>
        </div>
        <div class="form-group row">
            <div class="col-3"></div>
            <div class=" col-6">
                <asp:Label Text="Nuevo Comentario:" runat="server" />
                <asp:TextBox ID="TboxDescripcion" class="form-control HV" Height="200px" runat="server" TextMode="MultiLine" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" ClientIDMode="Static" />

                <div class="form-group">
                    <asp:Button Text="Guardar" runat="server" ID="BtnGuardar" class="btn btn-info btn-lg btn-block" OnClick="BtnGuardar_Click" disabled="true" ClientIDMode="Static" />
                    <asp:Button Text="Guardar y Enviar por mail" runat="server" ID="BtnGuardarEnviarMail" class="btn btn-info btn-lg btn-block" OnClick="BtnGuardarEnviarMail_Click" disabled="true" ClientIDMode="Static" />
                </div>
            </div>
        </div>


        <div class="row Margen">

            <% foreach (var item in comentarios)
                { %>

            <div class="form-group col-4">
                <div class="row-group">
                    <label for="comment">Fecha Alta: </label>
                    <label for="comment"><% =item.FechaAlta %></label>
                </div>
                <%--  <div class="row-group">
                    <label for="comment">Ultima Modificaion: </label>
                    <label for="comment"><% =item.FechaModificacion %></label>
                </div>--%>
                <textarea class="form-control" id="LblDescr" style="height: 100px" disabled="disabled"><% =item.Descripcion%></textarea>
                <div class=" form-group">
                    <a href="List-Alumnos.aspx?valor=<% = (Session["IdComision-Instancia" + Session.SessionID]) + "&Mail=" + item.Id + "&LegajoAlumno=" + (Session["IdComision-Alumno" + Session.SessionID]) %>" class="btn btn-info btn-lg btn-block">Enviar por mail</a>

                </div>
            </div>
            <% } %>
        </div>
    </div>

</asp:Content>
