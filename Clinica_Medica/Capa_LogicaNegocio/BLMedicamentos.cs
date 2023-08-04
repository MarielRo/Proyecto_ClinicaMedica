using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;

namespace Capa_LogicaNegocio
{
    public class BLMedicamentos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLMedicamentos(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }
        public int Insertar(EntidadMedicamentos medicamentos)
        {
            int id_citas = 0;
            DAMedicamentos accessoDatos = new DAMedicamentos(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_citas = accessoDatos.Insertar(medicamentos); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_citas;
        }// fin de insertar

        public DataSet ListarMedicamentos(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAMedicamentos accesodatos = new DAMedicamentos(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarMedicamentos(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes



        public EntidadMedicamentos ObtenerMedicamentos(int id)
        {
            EntidadMedicamentos medicamentos;
            DAMedicamentos accessoDatos = new DAMedicamentos(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                medicamentos = accessoDatos.ObtenerMedicamentos(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return medicamentos;
        }// fin de insertar


        public int EliminarMedicamentos(EntidadMedicamentos medicamentos)
        {
            int resultado;
            DAMedicamentos accesoDatos = new DAMedicamentos(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarMedicamentos(medicamentos);
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }

        //llama el metodo creado en la capa de acceso el cual modifica un medicamento
        public int Modificar(EntidadMedicamentos medicamentos)
        {
            int filasAfectadas;
            DAMedicamentos accesoDatos = new DAMedicamentos(_cadenaConexion);
            try
            {
                filasAfectadas = accesoDatos.Modificar(medicamentos);
            }
            catch (Exception)
            {
                throw;
            }
            return filasAfectadas;
        }
    }
}
