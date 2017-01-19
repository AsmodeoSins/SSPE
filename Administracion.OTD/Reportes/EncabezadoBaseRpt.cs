using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD.Reportes
{
    [Serializable]
    public class EncabezadoBaseRpt
    {
        public EncabezadoBaseRpt()
        {
        }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public string RangoFechas { get; set; }
    }
}
