using System;
using System.Collections;
using System.Collections.Generic;

namespace Administracion.OTD.Reportes
{
    [Serializable]
    public class ReporteGeneralRpt
    {
        public EncabezadoBaseRpt Encabezado { get; set; }

        public IList<RenglonBaseRpt> Datos { get; set; }
    }
}