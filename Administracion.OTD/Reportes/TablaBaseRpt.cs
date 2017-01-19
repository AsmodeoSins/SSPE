using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD.Reportes
{
    [Serializable]
    public class TablaBaseRpt
    {
        public TablaBaseRpt()
        {

        }

        public RenglonBaseRpt Encabezado { get; set; }

        public IList<RenglonBaseRpt> Datos { get; set; }
    }
}
