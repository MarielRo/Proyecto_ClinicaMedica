using System;
using System.Collections.Generic;
using System.Text;

namespace Capa_Presentación
{
    class Configuracion
    {
        public static string getConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
                // Se obtiene la cadena de conexion del archivo
            }
        }
    }
}
