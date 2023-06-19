using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_LogicaNegocio;
using Capa_Entidades;

namespace Capa_Presentación
{
    public partial class FrmPacientes : Form
    {

        FrmBuscarPaciente formularioBuscar; //variable de tipo objeto FrmBuscarPaciente de forma global
        EntidadPaciente pacienteRegistrado;
        public FrmPacientes()
        {
            InitializeComponent();
        }

        public EntidadPaciente GenerarEntidadPaciente()
        {

            EntidadPaciente paciente;
            if (!string.IsNullOrEmpty(txtPaciente.Text))
            {
                paciente = pacienteRegistrado; // si el cliente existe , utiliza la entidad clienteregistrado
                                               //y le asigna los valores a la entidad cliente
            }
            else
            {
                paciente = new EntidadPaciente();
            }
            paciente.Nombre = txtNombre.Text;
            paciente.Apellido = txtApellidos.Text;
            paciente.Telefono = txtTelefono.Text;
            paciente.Email = txtEmail.Text;
            paciente.Fecha_nac = dtpFechaNacimiento.Value;
            paciente.Direccion = txtDireccion.Text;

            return paciente;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            EntidadPaciente paciente; //= new EntidadCliente();
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text)
                  && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtDireccion.Text))
                {
                    paciente = GenerarEntidadPaciente();
                    if (!paciente.Existe)
                    {
                        resultado = logica.Insertar(paciente); // si no existe se inserta
                    }
                    else
                    {
                        resultado = logica.Modificar(paciente); // si existe se modifica
                    }

                    if (resultado > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Operación realizada con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarListaDataSet();
                    }
                    else
                    {

                        MessageBox.Show("No se realizaron cambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Limpiar()
        {
            txtPaciente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpFechaNacimiento.Value = Convert.ToDateTime("01/01/1900");
            txtDireccion.Text = string.Empty;
            txtNombre.Focus();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
            DataSet DSPacientes;
            try
            {
                DSPacientes = logica.ListarPacientes(condicion, orden);
                grdPacientes.DataSource = DSPacientes;
                grdPacientes.DataMember = DSPacientes.Tables["Pacientes"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
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
            formularioBuscar = new FrmBuscarPaciente();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
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
            BLPaciente traerPaciente = new BLPaciente(Configuracion.getConnectionString);
            try
            {
                paciente = traerPaciente.ObtenerPaciente(id);

                if (paciente != null)
                {
                    txtPaciente.Text = paciente.Id_paciente.ToString();
                    txtNombre.Text = paciente.Nombre;
                    txtApellidos.Text = paciente.Apellido;
                    txtTelefono.Text = paciente.Telefono;
                    dtpFechaNacimiento.Value = paciente.Fecha_nac;
                    txtDireccion.Text = paciente.Direccion;
                    txtEmail.Text = paciente.Email;

                    // se le asigna la entidad vliente local a la variable global
                    pacienteRegistrado = paciente; // actualizar el cliente
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grdPacientes_DoubleClick(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                // se recupero el ID
                id = (int)grdPacientes.SelectedRows[0].Cells[0].Value;
                // ya con el id recuperado se puede llamar a la funcion que carga el cliente
                // desde la base de datos del form
                CargarPaciente(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EntidadPaciente paciente;
            int resultado;
            BLPaciente logica = new BLPaciente(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtPaciente.Text))
                {
                    // busca primero el cljuee antes de borrarlo prara ver si existe
                    paciente = logica.ObtenerPaciente(int.Parse(txtPaciente.Text)); // metodo obtener cliente
                    if (paciente != null)
                    {
                        // eliminar sin procedimiento almacenado
                        resultado = logica.EliminarPaciente(paciente); //  metodo eliminar Paciente
                        MessageBox.Show(logica.Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        cargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("El paciente no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();
                        cargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un paciente antes de eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
