using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.Utilidades.Mapeos
{
    public static class PLIncidenciaCatalogoMapeos
    {
        public static PL_INCIDENCIA_CATALOGO MapearEntidad(PLIncidenciaCatalogoOtd incidencia)
        {
            return Mapper.Map<PL_INCIDENCIA_CATALOGO>(incidencia);
        }

        public static PLIncidenciaCatalogoOtd MapearModelo(PL_INCIDENCIA_CATALOGO incidencia)
        {
            return Mapper.Map<PLIncidenciaCatalogoOtd>(incidencia);
        }

        public static IList<PLIncidenciaCatalogoOtd> MapearListaDeModelos(IList<PL_INCIDENCIA_CATALOGO> incidencias)
        {
            return incidencias.Select(i => MapearModelo(i)).ToList();
        }
    }
}
