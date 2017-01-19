using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class TipoDeCentroMapeos
    {
        public static TIPO_CENTRO MapearEntidad(TipoDeCentroOtd tipoDeCelda)
        {
            return Mapper.Map<TIPO_CENTRO>(tipoDeCelda);
        }

        public static TipoDeCentroOtd MapearModelo(TIPO_CENTRO tipoDeCelda)
        {
            return Mapper.Map<TipoDeCentroOtd>(tipoDeCelda);
        }

        public static IList<TipoDeCentroOtd> MapearListaDeModelos(IList<TIPO_CENTRO> tiposDeCelda)
        {
            return Mapper.Map<IList<TIPO_CENTRO>, IList<TipoDeCentroOtd>>(tiposDeCelda);
        }
    }
}
