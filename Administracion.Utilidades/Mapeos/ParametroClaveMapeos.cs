using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class ParametroClaveMapeos
    {
        public static PARAMETRO_CLAVE MapearEntidad(ParametroClaveOtd parametroClave)
        {
            return Mapper.Map<PARAMETRO_CLAVE>(parametroClave);
        }

        public static ParametroClaveOtd MapearModelo(PARAMETRO_CLAVE parametroClave)
        {
            return Mapper.Map<ParametroClaveOtd>(parametroClave);
        }

        public static IList<ParametroClaveOtd> MapearListaDeModelos(IList<PARAMETRO_CLAVE> parametroClaves)
        {
            return Mapper.Map<IList<PARAMETRO_CLAVE>, IList<ParametroClaveOtd>>(parametroClaves);
        }
    }
}
