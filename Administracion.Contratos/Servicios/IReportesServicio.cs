using Administracion.OTD;
using Administracion.OTD.Filtros;
using Administracion.OTD.Reportes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Administracion.Contratos
{
    public interface IReportesServicio
    {
        ReporteGeneralRpt ReportePaseListaGeneral(ReporteFiltroOtd filtro);

        ReporteIncidenciasRpt ReporteIncidenciaPorUbicacion(ReporteFiltroOtd Filtro, IList<ImputadoOtd> imputados);

        ReporteIncidenciasRpt ReporteIncidenciasPorInterno(ReporteFiltroOtd filtro);

        ReporteGeneralRpt ReportePaseLista(ReporteFiltroOtd filtro);
    }
}