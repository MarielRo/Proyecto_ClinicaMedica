using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadMedico
    {
        #region Atributos
        private int id_medico;
        private string nombre;
        private string apellido;
        private string telefono;
        private DateTime fecha_nac;
        private string direccion;
        private string email;
        private string especialidad;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_medico { get => id_medico; set => id_medico = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadMedico()
        {
            id_medico = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Fecha_nac = Convert.ToDateTime("01/01/1900");
            Direccion = string.Empty;
            Email = string.Empty;
            Especialidad = string.Empty;
            Existe = false;

        }
        public EntidadMedico(int id_medico, string nombre, string apellido, string telefono, string direccion, DateTime fecha_nac,string especialidad, string email,  bool existe)
        {
            this.id_medico = id_medico;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Fecha_nac = fecha_nac;
            this.Email = email;
            this.Especialidad = especialidad;
            this.Existe = existe;

        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return string.Format("{0} - {1}", id_medico, nombre);
        }
        #endregion
    }
}
