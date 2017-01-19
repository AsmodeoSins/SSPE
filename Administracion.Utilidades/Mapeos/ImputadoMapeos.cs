using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class ImputadoMapeos
    {
        public static IMPUTADO MapearEntidad(ImputadoOtd imputado)
        {
            return Mapper.Map<Modelos.Entidades.IMPUTADO>(imputado);
        }

        public static ImputadoOtd MapearModelo(IMPUTADO imputado)
        {
            return Mapper.Map<ImputadoOtd>(imputado);
        }

        public static IList<ImputadoOtd> MapearListaDeModelos(IList<IMPUTADO> imputados)
        {
            return Mapper.Map<IList<IMPUTADO>, IList<ImputadoOtd>>(imputados);
        }
    }
}
