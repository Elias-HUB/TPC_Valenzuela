using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASA.Models;
using ASA.Services;

namespace WEB_ASA
{
    public partial class Comisiones : System.Web.UI.Page
    {
        public List<Comision> Comisions = new List<Comision>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Comisions = (new ComisionServices().Listar(2));
        }
    }
}