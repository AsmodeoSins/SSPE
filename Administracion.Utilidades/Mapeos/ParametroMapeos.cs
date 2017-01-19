using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class ParametroMapeos
    {
        public static PARAMETRO MapearEntidad(ParametroOtd parametro)
        {
            return Mapper.Map<PARAMETRO>(parametro);
        }

        public static ParametroOtd MapearModelo(PARAMETRO parametro)
        {
            return Mapper.Map<ParametroOtd>(parametro);
        }

        public static IList<ParametroOtd> MapearListaDeModelos(IList<PARAMETRO> parametros)
        {
            return Mapper.Map<IList<PARAMETRO>, IList<ParametroOtd>>(parametros);
        }
    }
}
