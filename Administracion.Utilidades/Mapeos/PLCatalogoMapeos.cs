using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLCatalogoMapeos
    {
        public static PL_CATALOGO MapearEntidad(PLCatalogoOtd paseDeListaCatalogo)
        {
            return Mapper.Map<PL_CATALOGO>(paseDeListaCatalogo);
        }

        public static PLCatalogoOtd MapearModelo(PL_CATALOGO paseDeListaCatalogo)
        {
            return Mapper.Map<PLCatalogoOtd>(paseDeListaCatalogo);
        }

        public static IList<PLCatalogoOtd> MapearListaDeModelos(IList<PL_CATALOGO> pasesDeListaCatalogo)
        {
            return Mapper.Map<IList<PLCatalogoOtd>>(pasesDeListaCatalogo);
        }

        public static IList<PLCatalogoEstatusOtd> MapearListaDeModelos(IList<PL_CATALOGO_ESTATUS> pasesDeListaCatalogoEstatus)
        {
            return Mapper.Map<IList<PLCatalogoEstatusOtd>>(pasesDeListaCatalogoEstatus);
        }
    }
}
