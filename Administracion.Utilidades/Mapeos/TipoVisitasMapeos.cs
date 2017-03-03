using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class TipoVisitasMapeos
    {
        public static IList<TipoVisitaOtd> MapearVisitas(IEnumerable<TIPO_VISITA> visitas)
        {
            return Mapper.Map<IList<TipoVisitaOtd>>(visitas);
        }
    }
}
