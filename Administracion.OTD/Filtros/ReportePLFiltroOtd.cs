using Administracion.Enum;
using System;

namespace Administracion.OTD.Filtros
{
    public class ReporteFiltroOtd
    {
        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public short IdEdificio { get; set; }

        public short IdCentro { get; set; }

        public short IdSector { get; set; }

        public string IdCelda { get; set; }

        public short IdPLCatalogo { get; set; }

        public ImputadoOtd Imputado { get; set; }

        public PaseListaReporteTipo TipoReporte { get; set; }
    }
}