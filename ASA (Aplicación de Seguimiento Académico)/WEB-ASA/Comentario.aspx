<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="WEB_ASA.Comentario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        <div>
            <a href="Comisiones.aspx">Comisiones </a>
        </div>
        <p> > </p>
        <div>
            <a href="List-Instancia.aspx?valor=<% =Session["IdComision" + Session.SessionID] %>"> Instancias Evaluativas</a>
        </div>
                <p> > </p>
        <div>
            <a href="List-Alumnos.aspx?valor=<% =(Session["IdComision-Instancia" + Session.SessionID]) %>"> Alumnos Insciptos</a>
        </div>
    </div>


    <div class="Container">

        <div class="form-group row">
            <div class="col-3"></div>
            <div class=" col-6">
                <asp:Label Text="Nuevo Comentario:" runat="server" />
                <asp:TextBox ID="TboxDescripcion" class="form-control HV" Height="200px" runat="server" TextMode="MultiLine" />

                <div class="form-group">
                    <asp:Button Text="Guardar" runat="server" class="btn btn-info btn-lg btn-block" OnClick="BtnGuardar_Click" />
                    <asp:Button Text="Guardar y Enviar por mail" runat="server" ID="BtnGuardarEnviarMail" class="btn btn-info btn-lg btn-block" OnClick="BtnGuardarEnviarMail_Click"/>
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
                <div class="row-group">
                    <label for="comment">Ultima Modificaion: </label>
                    <label for="comment"><% =item.FechaModificacion %></label>
                </div>
                <textarea class="form-control"  ID="LblDescr"  style="height: 100px" disabled="disabled"><% =item.Descripcion%></textarea>
                <div class=" form-group">
                    <a href="List-Alumnos.aspx?valor=<% = (Session["IdComision-Instancia" + Session.SessionID]) + "&Mail=" + item.Id + "&LegajoAlumno=" + (Session["IdComision-Alumno" + Session.SessionID]) %>" class="btn btn-info btn-lg btn-block">Enviar por mail</a>
                   
                </div>
            </div>
            <% } %>



        </div>
    </div>

</asp:Content>
