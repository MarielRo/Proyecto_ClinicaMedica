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
    public partial class FrmNuevo_Paciente : System.Web.UI.Page
    {

        string mensajeScript = "";
        public void Limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            EntidadPaciente cliente;
            BLPaciente logica = new BLPaciente(clsConfiguracion.getConnectionString);
            int identificacion;
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["id_del_paciente"] != null)
                    {
                        identificacion = int.Parse(Session["id_del_paciente"].ToString());
                        cliente = logica.ObtenerPaciente(identificacion);
                        if (cliente.Existe)
                        {
                            txtId.Text = cliente.Id_paciente.ToString();
                            txtNombre.Text = cliente.Nombre;
                            txtApellido.Text = cliente.Apellido;
                            txtTelefono.Text = cliente.Telefono;
                            txtDireccion.Text = cliente.Direccion;
                            txtEmail.Text = cliente.Email;

                            txtId.Visible = true;
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

        private EntidadPaciente GenerarEntidadPaciente()
        {
            EntidadPaciente paciente = new EntidadPaciente();

            if (Session["id_del_paciente"] != null)
            {
                paciente.Id_paciente = int.Parse(Session["id_del_paciente"].ToString());
                paciente.Existe = true;
            }
            else
            {
                paciente.Id_paciente = -1;
                paciente.Existe = false;
            }

            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellido.Text;
            paciente.Telefono = txtTelefono.Text;
            paciente.Direccion = txtDireccion.Text;
            paciente.Email = txtEmail.Text;

            return paciente;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadPaciente paciente;
            BLPaciente logica = new BLPaciente(clsConfiguracion.getConnectionString);
            int resultado;
            try
            {
                paciente = GenerarEntidadPaciente();
                if (paciente.Existe)
                {
                    resultado = logica.Modificar(paciente); //Si existe se modifica
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtNombre.Text)) //si no existe se agrega
                    {
                        resultado = logica.Insertar(paciente);
                    }
                    else
                    {
                        mensajeScript = string.Format("javascript:mostrarMensaje('Debe agregar almenos el nombre del Paciente')");
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
            Response.Redirect("FrmPaciente.aspx");
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Session["Nombre"] = txtNombre.Text;
            Session["Apellido"] = txtApellido.Text;
            Response.Redirect("FrmHistorial_Medico.aspx");
        }

        protected void btnPagos_Click(object sender, EventArgs e)
        {
            Session["Nombre"] = txtNombre.Text;
            Session["Apellido"] = txtApellido.Text;
            Response.Redirect("FrmPagos.aspx");
        }

        protected void btnCitas_Click(object sender, EventArgs e)
        {
            Session["Nombre"] = txtNombre.Text;
            Session["Apellido"] = txtApellido.Text;
            Response.Redirect("FrmCitas.aspx");
        }

        //btnNuevaCitaaa
        //
        //
        //
        //



    }
}