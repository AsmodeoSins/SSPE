using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLIncidenciaBitacoraMapeos
    {
        public static PLIncidenciaBitacoraOtd MapearModelo(PL_INCIDENCIA_BITACORA plIncidenciaBitacora)
        {
            return Mapper.Map<PLIncidenciaBitacoraOtd>(plIncidenciaBitacora);
        }

        public static IList<PLIncidenciaBitacoraOtd> MapearLista(IList<PL_INCIDENCIA_BITACORA> plIncidenciaBitacoras)
        {
            return Mapper.Map<IList<PLIncidenciaBitacoraOtd>>(plIncidenciaBitacoras);
        }
    }
}
