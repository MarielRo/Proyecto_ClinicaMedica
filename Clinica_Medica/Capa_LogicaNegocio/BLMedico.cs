using System;
using System.Collections.Generic;
using System.Text;
using Capa_Entidades;
using Capa_AccesoDatos;
using System.Data;

namespace Capa_LogicaNegocio
{
    public class BLMedico
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        // Propiedaddes
        public string Mensaje { get => _mensaje; }

        //Constructor
        public BLMedico(string cadenaConexion)// recibe como prametro cadena conexion 
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        // Método para llamar al metodo insertar de lacapaAccesoDatos
        // 
        public int Insertar(EntidadMedico medico)
        {
            int id_medico = 0;
            DAMedico accessoDatos = new DAMedico(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                id_medico = accessoDatos.Insertar(medico); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return id_medico;
        }// fin de insertar

        public DataSet ListarMedicos(string condicion = "", string orden = "")
        {
            DataSet DS;
            DAMedico accesodatos = new DAMedico(_cadenaConexion);

            try
            {
                DS = accesodatos.ListarMedicos(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;

        }// fin listar clientes



        public EntidadMedico ObtenerMedico(int id)
        {
            EntidadMedico medico;
            DAMedico accessoDatos = new DAMedico(_cadenaConexion); // objeto llamar el metodo de acceso a datos 
            try
            {
                medico = accessoDatos.ObtenerMedico(id); // devuleve numero si no encuentra o hay problema

            }
            catch (Exception)
            {
                throw;
            }

            return medico;
        }// fin de insertar


        public int EliminarMedico(EntidadMedico medico)
        {
            int resultado;
            DAMedico accesoDatos = new DAMedico(_cadenaConexion);
            try
            {
                resultado = accesoDatos.EliminarMedico(medico);
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
