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
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = ex;
                Response.Redirect("Error.aspx");
            }

        }

        public void CargaDGVInstancia()
        {
            try
            {
                AlumnoServices alumnoServices = new AlumnoServices();
                List<Alumno> alumnos = new List<Alumno>();
                if (Request.QueryString["valor"] != "22041997")
                {
                    alumnos = alumnoServices.Listar(Convert.ToInt64(Session["IdComision" + Session.SessionID]));
                }
                else
                {
                    alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
                }
                DGVAlumnos.DataSourceID = null;
                DGVAlumnos.DataSource = alumnos;

                if (alumnos.Count == 0)
                {
                    List<Alumno> Listado = new List<Alumno>();
                    Alumno Aux = new Alumno();
                    Aux.Legajo = 0;
                    Aux.Nombre = "";
                    Aux.Apellido = "";
                    Aux.Email = "";
                    Aux.Telefono = 0;

                    Aux.Dirreccion = new Dirreccion();
                    Aux.Dirreccion.Ciudad = "";
                    Aux.Dirreccion.CodPostal = 0;
                    Aux.Dirreccion.Direccion = "";
                    Listado.Add(Aux);
                    DGVAlumnos.DataSource = Listado;
                    DGVAlumnos.DataBind();
                    DGVAlumnos.Rows[0].Visible = false;
                    lblIncorrecto.Text = "No hay Alumnos, por favor agrege Alumnos a la comision";
                }
                else
                {
                    DGVAlumnos.DataBind();
                }
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

        protected void DGVAlumnos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (Request.QueryString["valor"] == "22041997")
            {
                e.Row.Cells[3].Visible = false;
            }
        }

        protected void BtnGuardarComision_Click(object sender, EventArgs e)
        {
            Comision comision = new Comision();

            comision.Materia = new Materia();
            comision.Materia = Session["ABMComisionNuevo-Materia" + Session.SessionID] as Materia;

            comision.Turno = new Turno();
            comision.Turno = Session["ABMComisionNuevo-Turno" + Session.SessionID] as Turno;

            comision.Cuatrimestre = new Cuatrimestre();
            comision.Cuatrimestre = Session["ABMComisionNuevo-Cuatrimestre" + Session.SessionID] as Cuatrimestre;

            comision.docente = new Docente();
            comision.docente.Legajo = Convert.ToInt64(Session["DocenteLegajo" + Session.SessionID]);

            comision.Anio = Convert.ToInt32(Session["ABMComisionNuevo-Anio" + Session.SessionID]);

            ComisionServices comisionServices = new ComisionServices();
            Session["IdComision" + Session.SessionID] = comisionServices.Nuevo(comision);
            int a = Convert.ToInt32(Session["IdComision" + Session.SessionID]);
            InstanciaServices instanciaServices = new InstanciaServices();


            List<Instancia> instancias = Session["ABMComisionNuevo-ListInstancias" + Session.SessionID] as List<Instancia>;
            Instancia instancia = new Instancia();
            int Indice = 0;
            foreach (Instancia Ins in instancias)
            {
                instancias[Indice].Id = instanciaServices.Nuevo(instancias[Indice]);
                instanciaServices.NuevoComIns((Convert.ToInt64(Session["IdComision" + Session.SessionID])), instancias[Indice].Id);
                Indice++;
            }


            Indice = 0;
            List<Alumno> alumnos = Session["ABMComisionNuevo-ListAlumnos" + Session.SessionID] as List<Alumno>;
            Alumno alumno = new Alumno();
            AlumnoServices alumnoServices = new AlumnoServices();
            foreach (Alumno Alu in alumnos)
            {
                if ((alumnoServices.BuscarAlumno(alumnos[Indice].Legajo)) == null)
                {
                    alumnoServices.Nuevo(alumnos[Indice]);
                    alumnoServices.NuevoComAlu(Convert.ToInt64((Session["IdComision" + Session.SessionID])), alumnos[Indice].Legajo);
                    Indice++;
                }
                else
                {
                    alumnoServices.Modificar(alumnos[Indice]);
                    alumnoServices.NuevoComAlu(Convert.ToInt64((Session["IdComision" + Session.SessionID])), alumnos[Indice].Legajo);
                    Indice++;
                }
            }

            Response.Redirect("Comisiones.aspx");

        }
    }
}