using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadHistorial
    {

        #region Atributos
        private int id_historial;
        private int id_paciente;
        private string diagnosticos;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_historial { get => id_historial; set => id_historial = value; }
        public int Id_paciente { get => id_paciente; set => id_paciente = value; }
        public string Diagnosticos { get => diagnosticos; set => diagnosticos = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadHistorial()
        {
            id_historial = 0;
            id_paciente = 0;
            diagnosticos = string.Empty;
            Existe = false;

        }
        public EntidadHistorial(int id_historial, int id_paciente,string diagnosticos, bool existe)
        {
            this.id_historial = id_historial;
            this.id_paciente = id_paciente;
            this.diagnosticos = diagnosticos;
            this.Existe = existe;

        }
        #endregion
    }
}
