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
    public partial class List_Alumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["IdComision-Instancia" + Session.SessionID] = Request.QueryString["valor"];
                    CargaDGVInstancia();
                    Session["IdComentario" + Session.SessionID] = Request.QueryString["Mail"];
                    Session["LegajoAlumnoComentario" + Session.SessionID] = Request.QueryString["LegajoAlumno"];
                    var Mail = Convert.ToInt64(Session["IdComentario" + Session.SessionID]);
                    var Alumno = Convert.ToInt64(Session["LegajoAlumnoComentario" + Session.SessionID]);
                    if (Mail != 0)
                    {
                        EnvioMail(Convert.ToInt64(Mail), Convert.ToInt64(Alumno));
                        Response.Redirect("List-Alumnos.aspx?valor=" + (Session["IdComision-Instancia" + Session.SessionID]));
                    }


                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void CargaDGVInstancia()
        {
            try
            {
                AlumnoServices alumnoServices = new AlumnoServices();
                List<Alumno> alumnos = alumnoServices.Listar(Convert.ToInt64(Session["IdComision" + Session.SessionID]));
                DGVAlumnos.DataSourceID = null;
                DGVAlumnos.DataSource = alumnos;
                DGVAlumnos.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void SendMail(Alumno alumno, ASA.Models.Comentario comentario)
        {
            MailMessage Mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            Mail.From = new MailAddress("eliasvalenzuela953@gmail.com");
            Mail.To.Add(alumno.Email);
            Mail.Subject = "ASA Notificaciones";
            Mail.Body = (comentario.Descripcion);
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("Memorex.FRGP@gmail.com", "CameraMouse");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(Mail);
        }

        void EnvioMail(long IDcomentario, long Legajo)
        {
            ComentarioServices comentarioServices = new ComentarioServices();
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            comentario = comentarioServices.Comentario(IDcomentario);

            AlumnoServices alumnoServices = new AlumnoServices();
            ASA.Models.Alumno alumno = new Alumno();
            alumno = alumnoServices.BuscarAlumno(Legajo);
            SendMail(alumno, comentario);
        }
    }
}