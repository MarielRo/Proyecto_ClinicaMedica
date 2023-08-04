using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Linq;
namespace Capa_AccesoDatos
{
    public class DAMedicamentos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DAMedicamentos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadMedicamentos medicamentos)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO MEDICAMENTOS (ID_HISTORIAL,ID_MEDICO,DOSIS) VALUES(@ID_HISTORIAL,@ID_MEDICO,@DOSIS) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_HISTORIAL", medicamentos.Id_historial);
            comando.Parameters.AddWithValue("@ID_MEDICO", medicamentos.Id_medico);
            comando.Parameters.AddWithValue("@DOSIS", medicamentos.Dosis);

            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();

            }

            return id;
        }// fin de insertar

        public DataSet ListarMedicamentos(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_MEDICAMENTO,ID_HISTORIAL,ID_MEDICO,DOSIS FROM MEDICAMENTOS";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                sentencia = string.Format("{0} order by {1}", sentencia, orden);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(datos, "Medicamentos");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista 

        public EntidadMedicamentos ObtenerMedicamentos(int id)
        {
            // devuelve una cita cuando se busca
            EntidadMedicamentos medicamentos = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_MEDICAMENTO,ID_HISTORIAL,ID_MEDICO,DOSIS FROM CITAS WHERE ID_MEDICAMENTO = " +
                " {0}", id);
            // SI EL ID ES TEXTO SE ESCRIBE ENTRE COMILLAS {0} en el string
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    medicamentos = new EntidadMedicamentos();
                    dataReader.Read();
                    medicamentos.Id_medicamentos = dataReader.GetInt32(0);
                    medicamentos.Id_historial = dataReader.GetInt32(1);
                    medicamentos.Id_medico = dataReader.GetInt32(2);
                    medicamentos.Dosis = dataReader.GetString(3);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return medicamentos;
        }


        public int EliminarMedicamentos(EntidadMedicamentos medicamentos)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM MEDICAMENTOS";
            sentencia = string.Format("{0} WHERE ID_MEDICAMENTO= {1}", sentencia, medicamentos.Id_medicamentos);
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                afectado = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return afectado;

        }

        // actualizar un cliente
        public int Modificar(EntidadMedicamentos medicamentos)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE MEDICAMENTOS SET ID_HISTORIAL = @ID_HISTORIAL,ID_MEDICO=@ID_MEDICO,DOSIS=@DOSIS WHERE " +
                "ID_MEDICAMENTO=@ID_MEDICAMENTO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_HISTORIAL", medicamentos.Id_historial);
            comando.Parameters.AddWithValue("@ID_PACIENTE", medicamentos.Id_medico);
            comando.Parameters.AddWithValue("@FECHA", medicamentos.Dosis);
            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }
            return filasAfectadas;

        } // modificar
    }
}
