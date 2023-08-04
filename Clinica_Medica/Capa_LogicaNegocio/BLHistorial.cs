using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;

namespace Capa_LogicaNegocio
{
    public class BLHistorial
    {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLHistorial(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Método para llamar al metodo insertar de lacapaAccesoDatos
        // 
        public int InsertarHistorial(EntidadHistorial historial)
        {
            int id_historial = 0;
            DAHistorial accessoDatos = new DAHistorial(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_historial = accessoDatos.InsertarHistorial(historial); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_historial;
        }// fin de insertar

        public DataSet ListarHistorial(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAHistorial accesodatos = new DAHistorial(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarHistorial(condicion);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes



        public EntidadHistorial ObtenerHistorial(int id)
        {
            EntidadHistorial historial;
            DAHistorial accessoDatos = new DAHistorial(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                historial = accessoDatos.ObtenerHistorial(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return historial;
        }// fin de insertar


        public int EliminarHistorial(EntidadHistorial historial)
        {
            int resultado;
            DAHistorial accesoDatos = new DAHistorial(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarHistorial(historial);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadMedico medico)
        {
            int filasAfectadas;
            DAMedico accesoDatos = new DAMedico(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(medico);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
    }

}

