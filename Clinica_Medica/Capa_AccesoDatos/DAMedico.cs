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
    public class DAMedico
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public DAMedico(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // métodos
        public int Insertar(EntidadMedico medico)
        {
            int id = 0;
            //Establecer el objeto de conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            // Establecer los comandos SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            string sentencia = "INSERT INTO MEDICO (NOMBRE,APELLIDO,TELEFONO,FECHA_NAC,EMAIL,ESPECIALIDAD) VALUES(@NOMBRE,@APELLIDO, @TELEFONO,@FECHA_NAC,@EMAIL,@ESPECIALIDAD) SELECT @@IDENTITY";
            comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido);
            comando.Parameters.AddWithValue("@TELEFONO", medico.Telefono);
            comando.Parameters.AddWithValue("@FECHA_NAC", medico.Fecha_nac);
            comando.Parameters.AddWithValue("@EMAIL", medico.Email);
            comando.Parameters.AddWithValue("@ESPECIALIDAD", medico.Especialidad);

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
        public DataSet ListarMedicos(string condicion = "", string orden = "")
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_MEDICO,NOMBRE,APELLIDO,TELEFONO,FECHA_NAC,EMAIL,ESPECIALIDAD FROM MEDICO";
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
                adapter.Fill(datos, "Medicos");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }// devulve la lista con los clientes

        public EntidadMedico ObtenerMedico(int id)
        {
            // devuelve un clietne cuando se busca
            EntidadMedico medico = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;
            string sentencia = string.Format("SELECT ID_MEDICO, NOMBRE,APELLIDO, TELEFONO,FECHA_NAC,EMAIL,ESPECIALIDAD FROM MEDICO WHERE ID_MEDICO = " +
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
                    medico = new EntidadMedico();
                    dataReader.Read();
                    medico.Id_medico = dataReader.GetInt32(0);
                    medico.Nombre = dataReader.GetString(1);
                    medico.Apellido = dataReader.GetString(2);
                    medico.Telefono = dataReader.GetString(3);
                    medico.Fecha_nac = dataReader.GetDateTime(4);
                    medico.Email = dataReader.GetString(5);
                    medico.Especialidad = dataReader.GetString(6);
                    medico.Existe = true;
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return medico;
        }

        public int EliminarMedico(EntidadMedico medico)
        {
            int afectado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "DELETE FROM MEDICO";
            sentencia = string.Format("{0} WHERE ID_MEDICO = {1}", sentencia, medico.Id_medico);
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
        public int Modificar(EntidadMedico medico)
        {
            int filasAfectadas = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE MEDICO SET NOMBRE = @NOMBRE,APELLIDO=@APELLIDO,TELEFONO=@TELEFONO,FECHA_NAC=@FECHA_NAC,EMAIL=@EMAIL,ESPECIALIDAD=@ESPECIALIDAD WHERE " +
                "ID_MEDICO=@ID_MEDICO";
            comando.CommandText = sentencia;
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@ID_MEDICO", medico.Id_medico);
            comando.Parameters.AddWithValue("@NOMBRE", medico.Nombre);
            comando.Parameters.AddWithValue("@APELLIDO", medico.Apellido);
            comando.Parameters.AddWithValue("@TELEFONO", medico.Telefono);
            comando.Parameters.AddWithValue("@FECHA_NAC", medico.Fecha_nac);
            comando.Parameters.AddWithValue("@EMAIL", medico.Email);
            comando.Parameters.AddWithValue("@ESPECIALIDAD", medico.Especialidad);
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
