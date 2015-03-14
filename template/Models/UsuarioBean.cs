using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace template.Models
{
    public class UsuarioBean
    {
        public string CodUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string IDUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Activo { get; set; }
        public string Alertas { get; set; }
        public string Receptors { get; set; }
    }
}

