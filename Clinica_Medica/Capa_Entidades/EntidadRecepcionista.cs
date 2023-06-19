using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadRecepcionista
    {
        #region Atributos
        private int id_recepcionista;
        private string nombre;
        private string apellido;
        private string telefono;
        private DateTime fecha_nac;
        private string direccion;
        private string email;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_recepcionista { get => id_recepcionista; set => id_recepcionista = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public DateTime Fecha_nac { get => fecha_nac; set => fecha_nac = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadRecepcionista()
        {
            id_recepcionista = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Telefono = string.Empty;
            Fecha_nac = Convert.ToDateTime("01/01/1900");
            Direccion = string.Empty;
            Email = string.Empty;
            Existe = false;

        }
        public EntidadRecepcionista(int id_recepcionista, string nombre, string apellido, string telefono, string direccion, DateTime fecha_nac, string email, bool existe)
        {
            this.id_recepcionista = id_recepcionista;
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
            return string.Format("{0} - {1}", id_recepcionista, nombre);
        }
        #endregion
    }
}
