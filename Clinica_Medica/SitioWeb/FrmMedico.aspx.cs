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
    public partial class FrmMedico : System.Web.UI.Page
    {
        string mensajeScript = "";

        private void CargarListaDataSet(string condicion = "", string orden = "")
        {
            //carga el datagridview con el dataset
            BLMedico logica = new BLMedico(clsConfiguracion.getConnectionString);
            DataSet DSPacientes;

            try
            {
                DSPacientes = logica.ListarMedicos(condicion, orden);
                grdMedico.DataSource = DSPacientes;
                grdMedico.DataMember = DSPacientes.Tables[0].TableName;
                grdMedico.DataBind();
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
            Session.Remove("id_del_medico");
            Response.Redirect("FrmNuevo_Medico.aspx");
        }

        protected void lnkEliminar_Command(object sender, CommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString());
            BLMedico logica = new BLMedico(clsConfiguracion.getConnectionString);
            EntidadMedico medico;

            try
            {
                medico = logica.ObtenerMedico(id);
                if (medico.Existe)
                {
                    if (logica.EliminarMedico(medico) > 0)
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Médico eliminado con exito')");
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
            Session["id_del_medico"] = e.CommandArgument.ToString();
            //redireccionar al formulario de frmClientes
            Response.Redirect("FrmNuevo_Medico.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void grdPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            CargarListaDataSet();
        }
    }
}