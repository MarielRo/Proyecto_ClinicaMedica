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
    public partial class FrmBuscarHistorial : Form
    {
        public FrmBuscarHistorial()
        {
            InitializeComponent();
        }

        public event EventHandler Aceptar;
        int vgn_id_historial;

        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLHistorial logica = new BLHistorial(Configuracion.getConnectionString);
            DataSet DSHistorial;
            try
            {
                DSHistorial = logica.ListarHistorial(condicion, orden);
                grdListaHistorial.DataSource = DSHistorial;
                grdListaHistorial.DataMember = DSHistorial.Tables["Historial"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmBuscarHistorial_Load(object sender, EventArgs e)
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
            if (grdListaHistorial.SelectedRows.Count > 0)
            {
                vgn_id_historial = (int)grdListaHistorial.SelectedRows[0].Cells[0].Value;
                // le manda id al evento Aceptar que esta en FrmClientes
                Aceptar(vgn_id_historial, null);
                Close();
            }
        }// fin seleccionar

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void grdListaHistorial_DoubleClick(object sender, EventArgs e)
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
