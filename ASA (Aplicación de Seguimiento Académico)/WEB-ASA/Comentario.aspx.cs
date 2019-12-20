using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;
using System.Net.Mail;

namespace WEB_ASA
{
    public partial class Comentario : System.Web.UI.Page
    {
        public List<ASA.Models.Comentario> comentarios = new List<ASA.Models.Comentario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["IdComision-Alumno" + Session.SessionID] = Request.QueryString["valor"];
                    ASA.Models.Alumno alumnoAUX = new Alumno();
                    AlumnoServices alumnoServices = new AlumnoServices();
                    alumnoAUX=alumnoServices.BuscarAlumno(Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]));
                    LblTitulo.Text = Session["DatosComision" + Session.SessionID] + " - " + Session["DatosInstancia" + Session.SessionID] + " - " + alumnoAUX.Apellido + " " + alumnoAUX.Nombre;
                }
                long Comision = Convert.ToInt64(Session["IdComision" + Session.SessionID]);
                long Instancia = Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]);
                long Alumno = Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]);
                ComentarioServices comentarioServices = new ComentarioServices();
                comentarios = comentarioServices.ComentariosCIA(Comision, Instancia, Alumno);
                
            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }
        }

        protected void Btnmodificar_Click(object sender, EventArgs e)
        {
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            ComentarioServices comentarioServices = new ComentarioServices();
            //comentario.Id = Convert.ToInt64(LblId.ID.ToString());
            comentario.Id = Convert.ToInt64((Label)FindControl("LblDescr"));
            comentarioServices.Comentario(comentario.Id);
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ComentarioServices comentarioServices = new ComentarioServices();
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            comentario.Descripcion = TboxDescripcion.Text;
            comentario.Nota = DlistNota.SelectedItem.Text;
            comentarioServices.Agregar(comentario, Convert.ToInt64(Session["IdComision" + Session.SessionID]), Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]), Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]));
            Response.Redirect("List-Alumnos.aspx?valor=" + Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]));
        }

        protected void SendMail(Alumno alumno, string comentario)
        {
            MailMessage Mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            Mail.From = new MailAddress("eliasvalenzuela953@gmail.com");
            Mail.To.Add(alumno.Email);
            Mail.Subject = "ASA Notificaciones";
            Mail.Body = (comentario);
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Memorex.FRGP@gmail.com", "CameraMouse");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(Mail);
        }

        protected void BtnGuardarEnviarMail_Click(object sender, EventArgs e)
        {
            ComentarioServices comentarioServices = new ComentarioServices();
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            comentario.Descripcion = TboxDescripcion.Text;
            comentarioServices.Agregar(comentario, Convert.ToInt64(Session["IdComision" + Session.SessionID]), Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]), Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]));

            AlumnoServices alumnoServices = new AlumnoServices();
            ASA.Models.Alumno alumno = new Alumno();
            alumno = alumnoServices.BuscarAlumno(Convert.ToInt64((Session["IdComision-Alumno" + Session.SessionID])));

            SendMail(alumno, comentario.Descripcion);
            Response.Redirect("List-Alumnos.aspx?valor=" + (Session["IdComision-Instancia" + Session.SessionID]));
        }
    }

}