using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmPaciente.aspx");
        }
        protected void btnDoctores_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMedico.aspx");
        }
    }
}