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
    public class DAHistorial
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DAHistorial(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // métodos
        public int InsertarHistorial(EntidadHistorial historial)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO HISTORIAL_MEDICO (ID_PACIENTE,DIAGNOSTICOS) VALUES(@ID_PACIENTE,@DIAGNOSTICOS) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_PACIENTE", historial.Id_paciente);
            comando.Parameters.AddWithValue("@DIAGNOSTICOS", historial.Diagnosticos);
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
        public DataSet ListarHistorial(string condicion)
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_HISTORIAL,ID_PACIENTE,DIAGNOSTICOS FROM HISTORIAL_MEDICO";
            if (!string.IsNullOrEmpty(condicion))
            {
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }
            try
            {
                adapter = new SqlDataAdapter(sentencia, conexion);
                adapter.Fill(datos, "Historial");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista con los clientes

        public EntidadHistorial ObtenerHistorial(int id)
        {
            // devuelve un clietne cuando se busca
            EntidadHistorial historial = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_HISTORIAL,ID_PACIENTE,DIAGNOSTICOS FROM HISTORIAL_MEDICO WHERE ID_HISTORIAL = " +
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
                    historial = new EntidadHistorial();
                    dataReader.Read();
                    historial.Id_historial = dataReader.GetInt32(0);
                    historial.Id_paciente = dataReader.GetInt32(1);
                    historial.Diagnosticos = dataReader.GetString(2);
                    historial.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return historial;
        }


        public int EliminarHistorial(EntidadHistorial historial)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM HISTORIAL_MEDICO";
            sentencia = string.Format("{0} WHERE ID_HISTORIAL = {1}", sentencia, historial.Id_historial);
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

        public int Modificar(EntidadHistorial historial)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE HISTORIAL_MEDICO SET ID_PACIENTE = @ID_PACIENTE,DIAGNOSTICOS=@DIAGNOSTICOS WHERE " +
                "ID_HISTORIAL=@ID_HISTORIAL";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_HISTORIAL", historial.Id_historial);
            comando.Parameters.AddWithValue("@ID_PACIENTE", historial.Id_paciente);
            comando.Parameters.AddWithValue("@DIAGNOSTICOS",historial.Diagnosticos);
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

