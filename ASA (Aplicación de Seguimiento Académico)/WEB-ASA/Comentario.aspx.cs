﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;

namespace WEB_ASA
{
    public partial class Comentario : System.Web.UI.Page
    {
        public List<ASA.Models.Comentario> comentarios = new List<ASA.Models.Comentario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    Session["IdComision-Alumno" + Session.SessionID] = Request.QueryString["valor"];
                }
                long Comision = Convert.ToInt64(Session["IdComision" + Session.SessionID]);
                long Instancia = Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]);
                long Alumno = Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]);
                ComentarioServices comentarioServices = new ComentarioServices();
                comentarios = comentarioServices.ComentariosCIA(Comision, Instancia, Alumno);                
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Btnmodificar_Click(object sender, EventArgs e)
        {
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            ComentarioServices comentarioServices = new ComentarioServices();
            //comentario.Id = Convert.ToInt64(LblId.ID.ToString());
            comentario.Id =Convert.ToInt64((Label)FindControl("LblDescr"));
            
            comentarioServices.Comentario(comentario.Id);
        }


        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            ComentarioServices comentarioServices = new ComentarioServices();
            ASA.Models.Comentario comentario = new ASA.Models.Comentario();
            comentario.Descripcion = TboxDescripcion.Text;
            comentarioServices.Agregar(comentario, Convert.ToInt64(Session["IdComision" + Session.SessionID]), Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]),Convert.ToInt64(Session["IdComision-Alumno" + Session.SessionID]));
            Response.Redirect("List-Alumnos.aspx?valor=" + Convert.ToInt64(Session["IdComision-Instancia" + Session.SessionID]));
        }
    }

}