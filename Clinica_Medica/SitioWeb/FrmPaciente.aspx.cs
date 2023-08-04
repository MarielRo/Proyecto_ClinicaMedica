using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_LogicaNegocio;
using Capa_Entidades;
using System.Data;

namespace SitioWeb
{
    public partial class FrmPaciente : System.Web.UI.Page
    {
        string mensajeScript = "";

        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLPaciente logica = new BLPaciente(clsConfiguracion.getConnectionString);
            DataSet DSPacientes;

            try
            {
                DSPacientes = logica.ListarPacientes(condicion, orden);
                grdPaciente.DataSource = DSPacientes;
                grdPaciente.DataMember = DSPacientes.Tables[0].TableName;
                grdPaciente.DataBind();
                //en la tabla con nombre pacientes del dataset
            }
            catch (Exception)
            {
                throw;
            }
        }// fin CargarListaDataSet
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string condicion = string.Format("NOMBRE LIKE '%{0}%' ", txtNombre.Text);
                CargarListaDataSet(condicion);
            }

            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session.Remove("id_del_paciente");
            Response.Redirect("FrmNuevo_Paciente.aspx");
        }

        protected void grdPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPaciente.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            BLPaciente logica = new BLPaciente(clsConfiguracion.getConnectionString);
            EntidadPaciente paciente;

            try
            {
                paciente = logica.ObtenerPaciente(id);
                if (paciente.Existe)
                {
                    if (logica.EliminarPaciente(paciente) > 0)
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Paciente eliminado con exito')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        CargarListaDataSet();
                        txtNombre.Text = "";
                    }
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", logica.Mensaje);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }


        protected void lnkModificar_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            //redireccionar al formulario de frmClientes
            Response.Redirect("FrmNuevo_Paciente.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void lnkHistorial_Command(object sender, CommandEventArgs e)
        {

            Session["id_del_paciente"] = e.CommandArgument.ToString();
            Response.Redirect("FrmNuevo_Paciente.aspx");

        }

        protected void lnkCitas_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            Response.Redirect("FrmNuevo_Paciente.aspx");
        }

        protected void lnkPagos_Command(object sender, CommandEventArgs e)
        {
            Session["id_del_paciente"] = e.CommandArgument.ToString();
            Response.Redirect("FrmNuevo_Paciente.aspx");
        }
    }
}