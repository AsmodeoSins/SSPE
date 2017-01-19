using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLAsignacionResultadoMapeos
    {
        public static PL_ASIGNACION_RESULTADO MapearEntidad(PLAsignacionResultadoOtd plAsignacionResultado)
        {
            return Mapper.Map<PL_ASIGNACION_RESULTADO>(plAsignacionResultado);
        }

        public static PLAsignacionResultadoOtd MapearModelo(PL_ASIGNACION_RESULTADO plAsignacionResultado)
        {
            return Mapper.Map<PLAsignacionResultadoOtd>(plAsignacionResultado);
        }

        public static IList<PLAsignacionResultadoOtd> MapearListaDeModelos(IList<PL_ASIGNACION_RESULTADO> plAsignacionResultados)
        {
            return Mapper.Map<IList<PL_ASIGNACION_RESULTADO>, IList<PLAsignacionResultadoOtd>>(plAsignacionResultados);
        }
    }
}
