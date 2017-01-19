using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class PaseListaOtd : BaseOtd
    {
        public int PaseListaId { get; set; }

        public short TipoDePaseListaId { get; set; }

        public int CentroId { get; set; }

        public DateTime FechaProgramada { get; set; }

        public string Estatus { get; set; }

        public List<AsignacionOtd> Asignaciones { get; set; }
    }
}
