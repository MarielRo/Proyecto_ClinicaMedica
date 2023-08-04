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
    public class DAPagos
    {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DAPagos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadPagos pagos)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO PAGOS (ID_PACIENTE,FECHA,MONTO,DETALLE) VALUES(@ID_MEDICO,@ID_PACIENTE,@FECHA,@MONTO,@DETALLE) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@ID_PACIENTE", pagos.Id_paciente);
            comando.Parameters.AddWithValue("@FECHA", pagos.Fecha);
            comando.Parameters.AddWithValue("@HORA", pagos.Monto);
            comando.Parameters.AddWithValue("@DETALLE", pagos.Detalle);

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

        public DataSet ListarPagos(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PAGOS,ID_PACIENTE,FECHA,MONTO,DETALLE,CANCELADO FROM PAGOS";
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
                adapter.Fill(datos, "Pagos");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista 

        public EntidadPagos ObtenerPagos(int id)
        {
            // devuelve una cita cuando se busca
            EntidadPagos pagos = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_PAGOS,ID_PACIENTE,FECHA,MONTO,DETALLE,CANCELADO FROM PAGOS WHERE ID_PAGOS = " +
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
                    pagos = new EntidadPagos();
                    dataReader.Read();
                    pagos.Id_pagos = dataReader.GetInt32(0);
                    pagos.Id_paciente = dataReader.GetInt32(1);
                    pagos.Fecha = dataReader.GetDateTime(2);
                    pagos.Monto = dataReader.GetInt32(3);
                    pagos.Detalle = dataReader.GetString(4);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return pagos;
        }


        public int EliminarPagos(EntidadPagos pagos)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM PAGOS";
            sentencia = string.Format("{0} WHERE ID_PAGOS = {1}", sentencia, pagos.Id_pagos);
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
        public int Modificar(EntidadPagos pagos)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PAGOS SET ID_PACIENTE = @ID_PACIENTE,FECHA=@FECHA,MONTO=@MONTO,DETALLE=@DETALLE WHERE " +
                "ID_PAGOS=@ID_PAGOS";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_PACIENTE", pagos.Id_paciente);
            comando.Parameters.AddWithValue("@FECHA", pagos.Fecha);
            comando.Parameters.AddWithValue("@MONTO", pagos.Monto);
            comando.Parameters.AddWithValue("@DETALLE", pagos.Detalle);
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
