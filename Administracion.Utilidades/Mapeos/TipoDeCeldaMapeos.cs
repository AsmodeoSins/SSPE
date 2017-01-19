using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class TipoDeCeldaMapeos
    {
        public static TIPO_CELDA MapearEntidad(TipoDeCeldaOtd tipoDeCelda)
        {
            return Mapper.Map<TIPO_CELDA>(tipoDeCelda);
        }

        public static TipoDeCeldaOtd MapearModelo(TIPO_CELDA tipoDeCelda)
        {
            return Mapper.Map<TipoDeCeldaOtd>(tipoDeCelda);
        }

        public static IList<TipoDeCeldaOtd> MapearListaDeModelos(IList<TIPO_CELDA> tiposDeCelda)
        {
            return Mapper.Map<IList<TIPO_CELDA>, IList<TipoDeCeldaOtd>>(tiposDeCelda);
        }
    }
}
