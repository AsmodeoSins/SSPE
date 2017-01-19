using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD.Reportes
{
    [Serializable]
    public class SeccionBaseRpt
    {
        public SeccionBaseRpt()
        {

        }

        public string Titulo { get; set; }

        public IList<RenglonBaseRpt> Tablas { get; set; }
    }
}
