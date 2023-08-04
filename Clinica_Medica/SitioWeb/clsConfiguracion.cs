using System;
using System.Collections.Generic;
using System.Configuration; // Configuration manager
using System.Linq;
using System.Web;

namespace SitioWeb
{
    public static class clsConfiguracion
    {
        public static string getConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }
    }
}