using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadPagos
    {

        #region Atributos
        private int id_pagos;
        private int id_paciente;
        private DateTime fecha;
        private double monto;
        private string detalle;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_pagos { get => id_pagos; set => id_pagos = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Monto { get => monto; set => monto = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadPagos()
        {
            Id_pagos = 0;
            Id_paciente = 0;
            fecha = Convert.ToDateTime("01/01/1900");
            monto = 0.0;
            detalle = string.Empty;
            Existe = false;
        }
        public EntidadPagos(int id_pagos, int id_paciente, DateTime fecha,double monto, string detalle, bool existe)
        {
            this.id_pagos = id_pagos ;
            this.id_paciente = id_paciente ;
            this.fecha = fecha;
            this.monto = monto;
            this.detalle = detalle;
            this.Existe = existe;
        }
        #endregion
    }
}
