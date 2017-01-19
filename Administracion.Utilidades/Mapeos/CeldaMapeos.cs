using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class CeldaMapeos
    {
        public static CELDA MapearEntidad(CeldaOtd celda)
        {
            return Mapper.Map<CELDA>(celda);
        }

        public static CeldaOtd MapearModelo(CELDA celda)
        {
            return Mapper.Map<CeldaOtd>(celda);
        }

        public static IList<CeldaOtd> MapearListaDeModelos(IList<CELDA> celdas)
        {
            return Mapper.Map<IList<CELDA>, IList<CeldaOtd>>(celdas);
        }
    }
}
