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

    <div class="Container">
        <div>
            <p>Comision>Alumno>Instancia</p>
        </div>
        <div class="form-group row">
            <div class="col-3"></div>
            <div class=" col-6">
                <asp:Label Text="Comentario:" runat="server" />
                <%--<asp:TextBox runat="server" class="form-control HV" />--%>
                <%--<label for="comment">Comentario:</label>--%>
                <%--<textarea runat="server" class="form-control HV" rows="7" id="TboxComentario"></textarea>--%>
                <asp:TextBox ID="textarea" class="form-control HV"  height="200px" runat="server" TextMode="MultiLine" />

                <div class="HV">
                    <asp:Button Text="Enviar Comentario por mail" runat="server" class="btn btn-info btn-lg btn-block" />
                    <%-- <button class="btn btn-info btn-lg btn-block">
                        Enviar Comentario por mail
                    </button>--%>
                </div>
            </div>
        </div>
        <div class="row Margen">
            <div class="form-group col-4">
                <label for="comment">Comentario Fecha Alta: </label>
                <textarea class="form-control HV" rows="5" id="comment"></textarea>
                <div class="HV">
                    <button class="btn btn-info btn-lg btn-block">Enviar Comentario por mail</button>
                </div>
            </div>
            <div class="form-group col-4">
                <label for="comment">Comentario Fecha Alta: </label>
                <textarea class="form-control HV" rows="5" id="comment"></textarea>
                <div class="HV">
                    <button class="btn btn-info btn-lg btn-block">
                        Enviar Comentario por mail
                    </button>
                </div>
            </div>
            <div class="form-group col-4">
                <label for="comment">Comentario Fecha Alta: </label>
                <textarea
                    class="form-control HV"
                    rows="5"
                    id="comment"></textarea>
                <div class="HV">
                    <button class="btn btn-info btn-lg btn-block">
                        Enviar Comentario por mail
                    </button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
