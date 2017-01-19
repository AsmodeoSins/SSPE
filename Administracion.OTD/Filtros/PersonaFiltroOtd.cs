using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class PersonaFiltroOtd
    {
        public string Folio { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public bool EsImputado { get; set; }

        public bool FiltrarPorUbicacion { get; set; }

        public short IdCentro { get; set; }

        public int PersonaId { get; set; }

        public short IdAnio { get; set; }

        public short IdIngreso { get; set; }

        public bool FiltrarSoloEnrolados { get; set; }
    }
}
