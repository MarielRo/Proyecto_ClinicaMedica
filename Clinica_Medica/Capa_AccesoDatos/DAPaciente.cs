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
    public class DAPaciente
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DAPaciente(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // métodos
        public int Insertar(EntidadPaciente paciente)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO PACIENTE (NOMBRE,APELLIDO,TELEFONO,FECHA_NAC,DIRECCION,EMAIL) VALUES(@NOMBRE,@APELLIDO, @TELEFONO,@FECHA_NAC,@EMAIL,@DIRECCION) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono);
            comando.Parameters.AddWithValue("@FECHA_NAC", paciente.Fecha_nac);
            comando.Parameters.AddWithValue("@DIRECCION", paciente.Direccion);
            comando.Parameters.AddWithValue("@EMAIL", paciente.Email);

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

        //forma de cargar el DataGridView 
        public DataSet ListarPacientes(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PACIENTE,NOMBRE,APELLIDO,TELEFONO,FECHA_NAC,DIRECCION,EMAIL FROM PACIENTE";
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
                adapter.Fill(datos, "Pacientes");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista con los clientes

        public EntidadPaciente ObtenerPaciente(int id)
        {
            // devuelve un clietne cuando se busca
            EntidadPaciente paciente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_PACIENTE, NOMBRE,APELLIDO, TELEFONO,FECHA_NAC,DIRECCION,EMAIL FROM PACIENTE WHERE ID_PACIENTE = " +
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
                    paciente = new EntidadPaciente();
                    dataReader.Read();
                    paciente.Id_paciente = dataReader.GetInt32(0);
                    paciente.Nombre = dataReader.GetString(1);
                    paciente.Apellido = dataReader.GetString(2);
                    paciente.Telefono = dataReader.GetString(3);
                    paciente.Fecha_nac = dataReader.GetDateTime(4);
                    paciente.Direccion = dataReader.GetString(5);
                    paciente.Telefono = dataReader.GetString(6);
                    paciente.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }

        public int EliminarPaciente(EntidadPaciente paciente)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM PACIENTE";
            sentencia = string.Format("{0} WHERE ID_PACIENTE = {1}", sentencia, paciente.Id_paciente);
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
        public int Modificar(EntidadPaciente paciente)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PACIENTE SET NOMBRE = @NOMBRE,APELLIDO=@APELLIDO, TELEFONO=@TELEFONO,FECHA_NAC=@FECHA_NAC,DIRECCION=@DIRECCION,EMAIL=@EMAIL WHERE " +
                "ID_PACIENTE=@ID_PACIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PACIENTE", paciente.Id_paciente);
            comando.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
            comando.Parameters.AddWithValue("@TELEFONO", paciente.Telefono);
            comando.Parameters.AddWithValue("@FECHA_NAC", paciente.Fecha_nac);
            comando.Parameters.AddWithValue("@DIRECCION", paciente.Direccion);
            comando.Parameters.AddWithValue("@eMAIL", paciente.Email);
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
