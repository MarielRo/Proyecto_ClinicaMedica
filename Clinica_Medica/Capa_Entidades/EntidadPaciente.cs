using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadPaciente
    {
        #region Atributos
        private int id_paciente;
        private string nombre;
        private string apellido;
        private string telefono;
        private DateTime fecha_nac;
        private string direccion;
        private string email;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadPaciente()
        {
            id_paciente = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Fecha_nac = Convert.ToDateTime("01/01/1900");
            Direccion = string.Empty;
            Email = string.Empty;
            Existe = false;

        }
        public EntidadPaciente(int id_paciente, string nombre, string apellido, string telefono, string direccion, DateTime fecha_nac, string email, bool existe)
        {
            this.id_paciente = id_paciente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Fecha_nac = fecha_nac;
            this.Email = email;
            this.Existe = existe;

        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return string.Format("{0} - {1}", id_paciente, nombre);
        }
        #endregion
    }
}
