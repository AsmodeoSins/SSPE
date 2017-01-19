using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLProgramadoAsignacionMapeos
    {
        public static PL_PROGRAMADO_ASIGNACION MapearEntidad(PLProgramadoAsignacionOtd plProgramadoAsignacion)
        {
            return Mapper.Map<PL_PROGRAMADO_ASIGNACION>(plProgramadoAsignacion);
        }

        public static PLProgramadoAsignacionOtd MapearModelo(PL_PROGRAMADO_ASIGNACION plProgramadoAsignacion)
        {
            return Mapper.Map<PLProgramadoAsignacionOtd>(plProgramadoAsignacion);
        }

        public static IList<PLProgramadoAsignacionOtd> MapearListaDeModelos(IList<PL_PROGRAMADO_ASIGNACION> plProgramadoAsignaciones)
        {
            return Mapper.Map<IList<PL_PROGRAMADO_ASIGNACION>, IList<PLProgramadoAsignacionOtd>>(plProgramadoAsignaciones);
        }
    }
}
