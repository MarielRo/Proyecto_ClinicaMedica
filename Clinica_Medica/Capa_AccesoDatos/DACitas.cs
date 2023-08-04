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
    public class DACitas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DACitas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadCitas citas)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO CITAS (ID_MEDICO,ID_PACIENTE,FECHA,HORA,ESPECIALIDAD,CANCELADA) VALUES(@ID_MEDICO,@ID_PACIENTE,@FECHA,@HORA,@ESPECIALIDAD,@CANCELADA) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_MEDICO", citas.Id_medico);
            comando.Parameters.AddWithValue("@ID_PACIENTE", citas.Id_paciente);
            comando.Parameters.AddWithValue("@FECHA", citas.Fecha);
            comando.Parameters.AddWithValue("@HORA", citas.Hora);
            comando.Parameters.AddWithValue("@ESPECIALIDAD", citas.Especialidad);
            comando.Parameters.AddWithValue("@CANCELADA", citas.Cancelada);

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

        public DataSet ListarCitas(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_CITA,ID_MEDICO,ID_PACIENTE,FECHA,HORA,ESPECIALIDAD,CANCELADA FROM CITAS";
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
                adapter.Fill(datos, "Citas");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista 

        public EntidadCitas ObtenerCitas(int id)
        {
            // devuelve una cita cuando se busca
            EntidadCitas citas = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT D_CITA,ID_MEDICO,ID_PACIENTE,FECHA,HORA,ESPECIALIDAD,CANCELADA FROM CITAS WHERE ID_CITA = " +
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
                    citas = new EntidadCitas();
                    dataReader.Read();
                    citas.Id_citas = dataReader.GetInt32(0);
                    citas.Id_medico = dataReader.GetInt32(1);
                    citas.Id_paciente = dataReader.GetInt32(2);
                    citas.Fecha = dataReader.GetDateTime(3);
                    citas.Hora = dataReader.GetDateTime(4);
                    citas.Especialidad = dataReader.GetString(5);
                    citas.Cancelada = dataReader.GetBoolean(6);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return citas;
        }


        public int EliminarCita(EntidadCitas cita)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM CITAS";
            sentencia = string.Format("{0} WHERE ID_CITA = {1}", sentencia, cita.Id_citas);
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
        public int Modificar(EntidadCitas citas)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE CITAS SET ID_MEDICO = @ID_MEDICO,ID_PACIENTE=@ID_PACIENTE,FECHA=@FECHA,HORA=@HORA,ESPECIALIDAD=@ESPECIALIDAD,CANCELADA=@CANCELADA WHERE " +
                "ID_CITA=@ID_CITA";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_MEDICO", citas.Id_medico);
            comando.Parameters.AddWithValue("@ID_PACIENTE", citas.Id_paciente);
            comando.Parameters.AddWithValue("@FECHA", citas.Fecha);
            comando.Parameters.AddWithValue("@HORA", citas.Hora);
            comando.Parameters.AddWithValue("@ESPECIALIDAD", citas.Especialidad);
            comando.Parameters.AddWithValue("@CANCELADA", citas.Cancelada);
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
