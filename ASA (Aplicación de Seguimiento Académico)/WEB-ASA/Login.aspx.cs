using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;
using Services;
using Dominio;

namespace WEB_ASA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioServices usuarioServices = new UsuarioServices();
            Usuario usuario = new Usuario();
            usuario.Docente = new Docente();
            String ALGO = TboxUsuario.Text;
            if(ALGO != "")
            {
                usuario.Docente.Legajo = Convert.ToInt64(TboxUsuario.Text);
                usuario.Clave = TboxContrasenia.Text;
                if (usuarioServices.VerificarMail(usuario.Docente.Legajo, usuario.Clave) == true)
                {
                    Session["DocenteLegajo" + Session.SessionID] = Convert.ToInt64(TboxUsuario.Text);
                    Response.Redirect("Comisiones.aspx");
                }
                else
                {
                    LblIncorrecto.Visible = true;
                }
            }
            else
            {
                LblIncorrecto.Visible = true;
            }
        }
    }
}