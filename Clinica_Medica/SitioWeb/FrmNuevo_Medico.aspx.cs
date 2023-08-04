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
    public partial class FrmNuevo_Medico : System.Web.UI.Page
    {

        string mensajeScript = "";
        public void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtEspecialidad.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadMedico medico;
            BLMedico logica = new BLMedico(clsConfiguracion.getConnectionString);
            int identificacion;
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["id_del_medico"] != null)
                    {
                        identificacion = int.Parse(Session["id_del_medico"].ToString());
                        medico = logica.ObtenerMedico(identificacion);
                        if (medico.Existe)
                        {
                            txtId.Text = medico.Id_medico.ToString();
                            txtNombre.Text = medico.Nombre;
                            txtApellido.Text = medico.Apellido;
                            txtTelefono.Text = medico.Telefono;
                            txtEmail.Text = medico.Email;
                            txtEspecialidad.Text = medico.Especialidad;


                            txtId.Visible = true;
                            txtEspecialidad.Visible = true;
                        }
                        else
                        {
                            mensajeScript = string.Format("javascript:mostrarMensaje('Paciente no encontrado')");
                            ScriptManager.RegisterStartupScript(this, typeof(string), " MensajeRetorno", mensajeScript, true);
                        }
                    }
                    else
                    {
                        Limpiar();
                        txtId.Text = "-1";
                        txtId.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), " MensajeRetorno", mensajeScript, true);
                Response.Redirect("Default.aspx");
            }
        }


        private EntidadMedico GenerarEntidadMedico()
        {
            EntidadMedico medico = new EntidadMedico();

            if (Session["id_del_medico"] != null)
            {
                medico.Id_medico = int.Parse(Session["id_del_medico"].ToString());
                medico.Existe = true;
            }
            else
            {
                medico.Id_medico = -1;
                medico.Existe = false;
            }

            medico.Nombre = txtNombre.Text;
            medico.Apellido = txtApellido.Text;
            medico.Telefono = txtTelefono.Text;
            medico.Especialidad = txtEspecialidad.Text;
            medico.Email = txtEmail.Text;

            return medico;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadMedico medico;
            BLMedico logica = new BLMedico(clsConfiguracion.getConnectionString);
            int resultado;
            try
            {
                medico = GenerarEntidadMedico();
                if (medico.Existe)
                {
                    resultado = logica.Modificar(medico); //Si existe se modifica
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtNombre.Text)) //si no existe se agrega
                    {
                        resultado = logica.Insertar(medico);
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar almenos el nombre del Médico')");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                        resultado = -1;
                    }

                }
                if (resultado > 0)
                {

                    mensajeScript = string.Format("javascript:mostrarMensaje('Operacion realizada con exito')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    mensajeScript = string.Format("javascript:mostrarMensaje('No se pudo realizar operacion')");
                    ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
                }
            }
            catch (Exception ex)
            {
                mensajeScript = string.Format("javascript:mostrarMensaje('{0}')", ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(string), "MensajeRetorno", mensajeScript, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMedico.aspx");
        }
    }
}