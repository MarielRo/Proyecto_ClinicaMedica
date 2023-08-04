using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;

namespace Capa_LogicaNegocio
{
    public class BLCitas
    {

        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLCitas(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadCitas citas)
        {
            int id_citas = 0;
            DACitas accessoDatos = new DACitas(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_citas = accessoDatos.Insertar(citas); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_citas;
        }// fin de insertar

        public DataSet ListarCitas(string condicion = "", string orden = "")
        {
            DataSet DS;
            DACitas accesodatos = new DACitas(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarCitas(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes



        public EntidadCitas ObtenerCitas(int id)
        {
            EntidadCitas citas;
            DACitas accessoDatos = new DACitas(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                citas = accessoDatos.ObtenerCitas(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return citas;
        }// fin de insertar


        public int EliminarCita(EntidadCitas citas)
        {
            int resultado;
            DACitas accesoDatos = new DACitas(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarCita(citas);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un cliente
        public int Modificar(EntidadCitas citas)
        {
            int filasAfectadas;
            DACitas accesoDatos = new DACitas(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(citas);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
    }
}
