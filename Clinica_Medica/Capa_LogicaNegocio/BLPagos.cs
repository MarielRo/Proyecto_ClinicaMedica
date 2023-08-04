using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;

namespace Capa_LogicaNegocio
{
    public class BLPagos
    {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLPagos(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadPagos pagos)
        {
            int id_citas = 0;
            DAPagos accessoDatos = new DAPagos(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_citas = accessoDatos.Insertar(pagos); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_citas;
        }// fin de insertar

        public DataSet ListarPagos(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAPagos accesodatos = new DAPagos(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarPagos(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes



        public EntidadPagos ObtenerPagos(int id)
        {
            EntidadPagos pagos;
            DAPagos accessoDatos = new DAPagos(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                pagos = accessoDatos.ObtenerPagos(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return pagos;
        }// fin de insertar


        public int EliminarPagos(EntidadPagos pagos)
        {
            int resultado;
            DAPagos accesoDatos = new DAPagos(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarPagos(pagos);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadPagos pagos)
        {
            int filasAfectadas;
            DAPagos accesoDatos = new DAPagos(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(pagos);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
    }
}

