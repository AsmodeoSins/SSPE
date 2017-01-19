using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class PermisosModulo
    {
        public string NombreModulo { get; set; }

        public bool Insertar { get; set; }

        public bool Editar { get; set; }

        public bool Consultar { get; set; }
    }
}
