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
    public partial class FrmPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            recibePagos();
        }

        private EntidadPagos GenerarEntidadPagos()
        {
            EntidadPagos pagos = new EntidadPagos();

            DateTime fecha = Convert.ToDateTime(txtFecha.Text);

            pagos.Id_paciente = Convert.ToInt32(txtId.Text); // llave foranea
            pagos.Fecha = Convert.ToDateTime(txtFecha.Text);
            pagos.Monto = Convert.ToInt32(txtMonto.Text);
            pagos.Detalle = txtDetalle.Text;

            return pagos;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadPagos pagos;
            BLPagos logica = new BLPagos(clsConfiguracion.getConnectionString);
            int resultado;
            try
            {
                pagos = GenerarEntidadPagos();

                resultado = logica.Insertar(pagos);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void recibePagos()
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