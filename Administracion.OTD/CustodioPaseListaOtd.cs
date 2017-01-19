using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class CustodioPaseListaOtd
    {
        public int CustodioId { get; set; }

        public IList<AsignacionOtd> Asignaciones { get; set; }
    }
}
