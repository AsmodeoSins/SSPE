using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLIncidenciaEstatusMapeos
    {
        public static PL_INCIDENCIA_ESTATUS MapearEntidad(PLIncidenciaEstatus plIncidenciaEstatus)
        {
            return Mapper.Map<PL_INCIDENCIA_ESTATUS>(plIncidenciaEstatus);
        }

        public static PLIncidenciaEstatus MapearModelo(PL_INCIDENCIA_ESTATUS plIncidenciaEstatus)
        {
            return Mapper.Map<PLIncidenciaEstatus>(plIncidenciaEstatus);
        }

        public static IList<PLIncidenciaEstatus> MapearListaDeModelos(IList<PL_INCIDENCIA_ESTATUS> plIncidenciaEstatuses)
        {
            return Mapper.Map<IList<PL_INCIDENCIA_ESTATUS>, IList<PLIncidenciaEstatus>>(plIncidenciaEstatuses);
        }
    }
}
