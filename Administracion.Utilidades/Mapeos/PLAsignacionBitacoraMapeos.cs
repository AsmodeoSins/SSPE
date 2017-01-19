using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLAsignacionBitacoraMapeos
    {
        public static PL_ASIGNACION_BITACORA MapearEntidad(PLAsignacionBitacoraOtd plAsignacionBitacora)
        {
            return Mapper.Map<PL_ASIGNACION_BITACORA>(plAsignacionBitacora);
        }

        public static PLAsignacionBitacoraOtd MapearModelo(PL_ASIGNACION_BITACORA plAsignacionBitacora)
        {
            return Mapper.Map<PLAsignacionBitacoraOtd>(plAsignacionBitacora);
        }

        public static IList<PLAsignacionBitacoraOtd> MapearListaDeModelos(IList<PL_ASIGNACION_BITACORA> plAsignacionBitacoras)
        {
            return Mapper.Map<IList<PL_ASIGNACION_BITACORA>, IList<PLAsignacionBitacoraOtd>>(plAsignacionBitacoras);
        }
    }
}
