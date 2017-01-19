using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public class TipoDeEdificionMapeos
    {
        public static TIPO_EDIFICIO MapearEntidad(TipoDeEdificioOtd tipoDeEdificio)
        {
            return Mapper.Map<TIPO_EDIFICIO>(tipoDeEdificio);
        }

        public static TipoDeEdificioOtd MapearModelo(TIPO_EDIFICIO tipoDeEdificio)
        {
            return Mapper.Map<TipoDeEdificioOtd>(tipoDeEdificio);
        }

        public static IList<TipoDeEdificioOtd> MapearListaDeModelos(IList<TIPO_EDIFICIO> tiposDeEdificio)
        {
            return Mapper.Map<IList<TIPO_EDIFICIO>, IList<TipoDeEdificioOtd>>(tiposDeEdificio);
        }
    }
}
