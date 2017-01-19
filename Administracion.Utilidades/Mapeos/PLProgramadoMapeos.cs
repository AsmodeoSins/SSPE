using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLProgramadoMapeos
    {
        public static PL_PROGRAMADO MapearEntidad(PLProgramadoOtd plProgramado)
        {
            return Mapper.Map<PL_PROGRAMADO>(plProgramado);
        }

        public static PLProgramadoOtd MapearModelo(PL_PROGRAMADO plProgramado)
        {
            return Mapper.Map<PLProgramadoOtd>(plProgramado);
        }

        public static IList<PLProgramadoOtd> MapearListaDeModelos(IList<PL_PROGRAMADO> plProgramados)
        {
            return Mapper.Map<IList<PL_PROGRAMADO>, IList<PLProgramadoOtd>>(plProgramados);
        }

        public static PLProgramadoOtd MapearModelo(PaseListaOtd paseLista)
        {
            return Mapper.Map<PLProgramadoOtd>(paseLista);
        }

        public static PLProgramadoBitacoraOtd MapearBitacora(PL_PROGRAMADO_BITACORA plBitacora)
        {
            return Mapper.Map<PLProgramadoBitacoraOtd>(plBitacora);
        }
    }
}
