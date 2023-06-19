using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_LogicaNegocio;

namespace Capa_Presentación
{
    public partial class FrmBuscarPaciente : Form
    {
        public event EventHandler Aceptar;
        int vgn_id_paciente;

        public FrmBuscarPaciente()
        {
            InitializeComponent();
        }

        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
            DataSet DSPacientes;
            try
            {
                DSPacientes = logica.ListarPacientes(condicion, orden);
                grdListaPacientes.DataSource = DSPacientes;
                grdListaPacientes.DataMember = DSPacientes.Tables["Pacientes"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBuscarPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                cargarListaDataSet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string condicion = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    condicion = string.Format("Nombre like'%{0}%'", txtNombre.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Debe escribir parte del nombre a buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                }

                cargarListaDataSet(condicion);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar()
        {
            if (grdListaPacientes.SelectedRows.Count > 0)
            {
                vgn_id_paciente = (int)grdListaPacientes.SelectedRows[0].Cells[0].Value;
                // le manda id al evento Aceptar que esta en FrmClientes
                Aceptar(vgn_id_paciente, null);
                Close();
            }
        }// fin seleccionar

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void grdListaPacientes_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aceptar(-1, null);
            Close();
        }
    }
}
