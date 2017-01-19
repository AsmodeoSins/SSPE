using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD.Reportes
{
    public class RenglonBaseRpt
    {
        public RenglonBaseRpt()
        {
        }

        public string PrimeraColumna { get; set; }

        public string SegundaColumna { get; set; }

        public string TerceraColumna { get; set; }

        public string CuartaColumna { get; set; }

        public string QuintaColumna { get; set; }

        public string SextaColumna { get; set; }

        public string SeptimaColumna { get; set; }

        public string OctavaColumna { get; set; }

        public bool EsTituloSeccion { get; set; }

        public bool EsEncabezadoDeTabla { get; set; }

        public bool EsPieDeSeccion { get; set; }

        public byte[] FotoImputado { get; set; }
    }
}
