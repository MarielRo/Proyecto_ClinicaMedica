using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;


namespace Capa_LogicaNegocio
{
    public class BLPaciente
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLPaciente(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Método para llamar al metodo insertar de lacapaAccesoDatos
        // 
        public int Insertar(EntidadPaciente paciente)
        {
            int id_paciente = 0;
            DAPaciente accessoDatos = new DAPaciente(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_paciente = accessoDatos.Insertar(paciente); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_paciente;
        }// fin de insertar

        public DataSet ListarPacientes(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAPaciente accesodatos = new DAPaciente(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarPacientes(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes


       
        public EntidadPaciente ObtenerPaciente(int id)
        {
            EntidadPaciente paciente;
            DAPaciente accessoDatos = new DAPaciente(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                paciente = accessoDatos.ObtenerPaciente(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return paciente;
        }// fin de insertar

  
        public int EliminarPaciente(EntidadPaciente paciente)
        {
            int resultado;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarPaciente(paciente);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadPaciente paciente)
        {
            int filasAfectadas;
            DAPaciente accesoDatos = new DAPaciente(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(paciente);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
    }
}
