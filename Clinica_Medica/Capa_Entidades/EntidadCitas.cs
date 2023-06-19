using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadCitas
    {
        #region Atributos
        private int id_citas;
        private int id_paciente;
        private int id_medico;
        private DateTime fecha;
        private DateTime hora;
        private string especialidad;
        private bool cancelada;
        #endregion

        #region Propiedades
        public int Id_citas { get => id_citas; set => id_citas = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public int Id_medico { get => id_medico; set => id_medico = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Hora { get => hora; set => hora = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public bool Cancelada { get => cancelada; set => cancelada = value; }
        #endregion

        #region Constructores
        public EntidadCitas()
        {
            id_citas = 0;
            Id_medico = 0;
            Id_paciente = 0;
            fecha = Convert.ToDateTime("01/01/1900");
            hora = Convert.ToDateTime("01/01/1900");
            especialidad = string.Empty;
            cancelada = false;
        }
        public EntidadCitas(int id_citas, int id_medico, int id_paciente,DateTime fecha, DateTime hora, string especialidad, bool cancelada)
        {
            this.id_citas = id_citas;
            this.Id_medico = id_medico;
            this.Id_paciente = id_paciente;
            this.especialidad = especialidad;
            this.fecha = fecha;
            this.hora = hora;
            this.cancelada = cancelada;
        }
        #endregion
    }
}
