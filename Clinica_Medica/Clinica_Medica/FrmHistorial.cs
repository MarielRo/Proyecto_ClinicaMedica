using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Capa_LogicaNegocio;
using Capa_Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Capa_Presentación
{
    public partial class FrmHistorial : Form
    {
        public FrmHistorial()
        {
            InitializeComponent();
        }

        FrmBuscarPaciente formularioBuscar; //variable de tipo objeto FrmBuscarPaciente de forma global
        

        public EntidadHistorial GenerarEntidadHistorial()
        {

            EntidadHistorial historial = new EntidadHistorial() ;

            if (!string.IsNullOrEmpty(txtPaciente.Text))
            {
                historial.Id_paciente = Convert.ToInt32(txtPaciente.Text);
                historial.Diagnosticos = (txtDiagnostico.Text);
            }
            else
            {
                MessageBox.Show("Debe seleccioanr un paciente para guardar su diagnosticos", "Aviso",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            historial.Diagnosticos = txtDiagnostico.Text;

            return historial;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarPaciente();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadHistorial historial; //= new EntidadCliente();
            BLHistorial logica = new BLHistorial(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (!string.IsNullOrEmpty(txtPaciente.Text))
                {
                    historial = GenerarEntidadHistorial();
                    resultado = logica.InsertarHistorial(historial);
                    MessageBox.Show("Operación realizada con exito", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Operación NO REALIZADA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Limpiar()
        {
            txtCodigoHistorial.Text = string.Empty;
            txtPaciente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDiagnostico.Text = string.Empty;
            txtCodigoHistorial.Focus();
        }

        private void cargarListaDataSet(string condicion = "")
        {
            BLHistorial logica = new BLHistorial(Configuracion.getConnectionString);
            DataSet DSHistorial;
            try
            {
                DSHistorial = logica.ListarHistorial(condicion);
                grdHistorial.DataSource = DSHistorial;
                grdHistorial.DataMember = DSHistorial.Tables["Historial"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
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

        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idPaciente = (int)id;
                if (idPaciente != -1)
                {
                    CargarPaciente(idPaciente);
                }
                else
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }// fin de aceptar

        private void CargarPaciente(int id)
        {
            EntidadPaciente paciente = new EntidadPaciente();
            BLPaciente traerpaciente = new BLPaciente(Configuracion.getConnectionString);
            try
            {
                paciente = traerpaciente.ObtenerPaciente(id);

                if (paciente != null)
                {
                    

                    txtPaciente.Text = paciente.Id_paciente.ToString();
                    txtNombre.Text = txtNombre.Text = paciente.Nombre;


                }
                else
                {
                    MessageBox.Show("El paciente no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cargarListaDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdHistorial_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                // se recupero el ID
                id = (int)grdHistorial.SelectedRows[0].Cells[0].Value;
                // ya con el id recuperado se puede llamar a la funcion que carga el cliente
                // desde la base de datos del form
                CargarPaciente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void verificarGuardar()
        {
            if (string.IsNullOrEmpty(txtPaciente.Text))
            {
                btnGuardar.Enabled = false;
            }
            else
                btnGuardar.Enabled = true;
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            verificarGuardar();
            string condicion;
            if (!string.IsNullOrEmpty(txtPaciente.Text))
            {
                condicion = string.Format("ID_PACIENTE = {0}", txtPaciente.Text);
            }
            else
            {
                condicion = string.Format("ID_PACIENTE = {0}", "-1");
            }
            cargarListaDataSet(condicion);
        }
    }
}
