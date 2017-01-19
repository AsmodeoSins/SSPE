using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class PLProgramadoBitacoraOtd
    {
        public int IdPLBitacora { get; set; }

        public int IdPlProgramado { get; set; }

        public DateTime FechaEjecucion { get; set; }

        public IList<PLAsignacionResultadoOtd> Resultados { get; set; }
    }
}
