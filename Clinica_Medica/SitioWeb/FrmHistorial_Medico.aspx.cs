using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_LogicaNegocio;
using Capa_Entidades;

namespace SitioWeb
{
    public partial class FrmHistorial_Medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recibeClientesHistorial();
        }

        

        private EntidadHistorial GenerarEntidadHistorial()
        {
            EntidadHistorial historial = new EntidadHistorial();

            historial.Id_paciente = Convert.ToInt32(txtId.Text); // llave foranea
            historial.Diagnosticos = lblHistorial.Text;

            return historial;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadHistorial historial;
            BLHistorial logica = new BLHistorial(clsConfiguracion.getConnectionString);
            int resultado;
            
                historial = GenerarEntidadHistorial();
                resultado = logica.InsertarHistorial(historial);
        }
        public void recibeClientesHistorial()
        {

            string nombre = (string)(Session["Nombre"]);
            txtNombre.Text = nombre;
            int id_paciente = Convert.ToInt32(Session["id_del_paciente"]);
            txtId.Text = txtId.ToString();
            string apellido = (string)(Session["Apellido"]);
            txtApellido.Text = apellido;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmPaciente.aspx");
        }
    }
}