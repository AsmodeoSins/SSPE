using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class TipoDePersonaMapeos
    {
        public static TIPO_PERSONA MapearEntidad(TipoDePersonaOtd tipoDePersona)
        {
            return Mapper.Map<TIPO_PERSONA>(tipoDePersona);
        }

        public static TipoDePersonaOtd MapearModelo(TIPO_PERSONA tipoDePersona)
        {
            return Mapper.Map<TipoDePersonaOtd>(tipoDePersona);
        }

        public static IList<TipoDePersonaOtd> MapearListaDeModelos(IList<TIPO_PERSONA> tiposDePersona)
        {
            return Mapper.Map<IList<TIPO_PERSONA>, IList<TipoDePersonaOtd>>(tiposDePersona);
        }
    }
}
