using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace template.Models
{
    public class AlertaBean
    {
        public string CodAlerta { get; set; }
        public string CodUsuario { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Fecha { get; set; }
        public string HusoHorario { get; set; }
        public string Tipo { get; set; }

    }
}