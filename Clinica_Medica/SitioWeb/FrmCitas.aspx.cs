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
    public partial class FrmCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recibeCitas();
        }
        public void recibeCitas()
        {

            string nombre = (string)(Session["Nombre"]);
            txtNombre.Text = nombre;
            int id_paciente = Convert.ToInt32(Session["id_del_paciente"]);
            txtId.Text = txtId.ToString();
            string apellido = (string)(Session["Apellido"]);
            txtApellido.Text = apellido;
            int id_medico = Convert.ToInt32(Session["id_del_medico"]);
            txtId.Text = txtId.ToString();
        }


        private EntidadCitas GenerarEntidadCitas()
        {
            EntidadCitas pagos = new EntidadCitas();

            DateTime fecha = Convert.ToDateTime(txtFecha.Text);

            pagos.Id_paciente = Convert.ToInt32(txtId.Text); // llave foranea
            pagos.Id_medico = Convert.ToInt32(txtId.Text); // llave foranea
            pagos.Fecha = Convert.ToDateTime(txtFecha.Text);
            pagos.Hora = Convert.ToDateTime(txtHora.Text);
            pagos.Especialidad = txtEspecialidad.Text;

            return pagos;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadCitas citas;
            BLCitas logica = new BLCitas(clsConfiguracion.getConnectionString);
            int resultado;
            try
            {
                citas = GenerarEntidadCitas();

                resultado = logica.Insertar(citas);

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmPaciente.aspx");
        }
    }
}