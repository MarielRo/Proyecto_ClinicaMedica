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
    public partial class FrmMedico : Form
    {
        public FrmMedico()
        {
            InitializeComponent();
        }
        FrmBuscarMedico formularioBuscar; //variable de tipo objeto FrmBuscarPaciente de forma global
        EntidadMedico MedicoRegistrado;
        public EntidadMedico GenerarEntidadMedico()
        {

            EntidadMedico medico;
            if (!string.IsNullOrEmpty(txtMedico.Text))
            {
                medico = MedicoRegistrado; // si el cliente existe , utiliza la entidad clienteregistrado
                                               //y le asigna los valores a la entidad cliente
            }
            else
            {
                medico = new EntidadMedico();
            }
            medico.Nombre = txtNombre.Text;
            medico.Apellido = txtApellidos.Text;
            medico.Telefono = txtTelefono.Text;
            medico.Email = txtEmail.Text;
            medico.Especialidad = cmbEspecialidad.Text;

            return medico;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadMedico medico; //= new EntidadCliente();
            BLMedico logica = new BLMedico(Configuracion.getConnectionString); // llama al construcctor,recibe parametros, llamar meytodo get conexion string, asigna los parametor s BLCliente
            int resultado;

            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text)
                  && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(cmbEspecialidad.Text))
                {
                    medico = GenerarEntidadMedico();
                    if (!medico.Existe)
                    {
                        resultado = logica.Insertar(medico); // si no existe se inserta
                    }
                    else
                    {
                        resultado = logica.Modificar(medico); // si existe se modifica
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
            txtMedico.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbEspecialidad.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void cargarListaDataSet(string condicion = "", string orden = "")
        {
            BLMedico logica = new BLMedico(Configuracion.getConnectionString);
            DataSet DSMedico;
            try
            {
                DSMedico = logica.ListarMedicos(condicion, orden);
                grdMedico.DataSource = DSMedico;
                grdMedico.DataMember = DSMedico.Tables["Medicos"].TableName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmMedico_Load(object sender, EventArgs e)
        {
            try
            {
                AgregarElementos();
                cargarListaDataSet();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formularioBuscar = new FrmBuscarMedico();
            formularioBuscar.Aceptar += new EventHandler(Aceptar);
            formularioBuscar.ShowDialog();
        }



        private void Aceptar(object id, EventArgs e)
        {
            try
            {
                int idMedico = (int)id;
                if (idMedico != -1)
                {
                    CargarMedico(idMedico);
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

        private void CargarMedico(int id)
        {
            EntidadMedico medico = new EntidadMedico();
            BLMedico traerMedico = new BLMedico(Configuracion.getConnectionString);
            try
            {
                medico = traerMedico.ObtenerMedico(id);

                if (medico != null)
                {
                    txtMedico.Text = medico.Id_medico.ToString();
                    txtNombre.Text = medico.Nombre;
                    txtApellidos.Text = medico.Apellido;
                    txtTelefono.Text = medico.Telefono;

                    // se le asigna la entidad vliente local a la variable global
                    MedicoRegistrado = medico; // actualizar el cliente
                }
                else
                {
                    MessageBox.Show("El medico no se encuentra en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                id = (int)grdMedico.SelectedRows[0].Cells[0].Value;
                // ya con el id recuperado se puede llamar a la funcion que carga el cliente
                // desde la base de datos del form
                CargarMedico(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EntidadMedico medico;
            int resultado;
            BLMedico logica = new BLMedico(Configuracion.getConnectionString);
            try
            {
                if (!string.IsNullOrEmpty(txtMedico.Text))
                {
                    // busca primero el cljuee antes de borrarlo prara ver si existe
                    medico = logica.ObtenerMedico(int.Parse(txtMedico.Text)); // metodo obtener cliente
                    if (medico != null)
                    {
                        // eliminar sin procedimiento almacenado
                        resultado = logica.EliminarMedico(medico); //  metodo eliminar Paciente
                        MessageBox.Show(logica.Mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        cargarListaDataSet();
                    }
                    else
                    {
                        MessageBox.Show("El medico no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Limpiar();
                        cargarListaDataSet();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un medico antes de eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarElementos()
        {
            // Agregar elementos al ComboBox
            cmbEspecialidad.Items.Add("GENERAL");
            cmbEspecialidad.Items.Add("PEDIATRÍA");
            cmbEspecialidad.Items.Add("OBSTETRICIA/GINECOLOGÍA");
            cmbEspecialidad.Items.Add("INTERNA");
            cmbEspecialidad.Items.Add("CARDIOLOGÍA");
            cmbEspecialidad.Items.Add("OFTALMOLOGÍA");
            cmbEspecialidad.Items.Add("OTORRINOLARINGOLOGÍA");
            cmbEspecialidad.Items.Add("DERMATOLOGÍA");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}