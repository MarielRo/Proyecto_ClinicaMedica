using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Entidades
{
    public class EntidadMedicamentos
    {
        #region Atributos
        private int id_medicamentos;
        private int id_historial;
        private int id_medico;
        private string dosis;
        private bool existe;
        #endregion

        #region Propiedades
        public int Id_medicamentos { get => id_medicamentos; set => id_medicamentos = value; }
        public int Id_historial { get => id_historial; set => id_historial = value; }
        public int Id_medico { get => id_medico; set => id_medico = value; }
        public string Dosis { get => dosis; set => dosis = value; }
        public bool Existe { get => existe; set => existe = value; }
        #endregion

        #region Constructores
        public EntidadMedicamentos()
        {
            Id_medicamentos = 0;
            Id_historial = 0;
            Id_medico = 0;
            dosis = string.Empty;
            Existe = false;
        }
        public EntidadMedicamentos(int id_medicamentos,int id_historial, int id_medico, string dosis, bool existe)
        {
            this.id_medicamentos = id_medicamentos;
            this.Id_historial = id_historial;
            this.Id_medico = id_medico;
            this.dosis = dosis;
            this.Existe = existe;
        }
        #endregion
    }
}
