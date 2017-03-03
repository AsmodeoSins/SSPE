using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class VisitasDiaMapeos
    {
        public static IList<VisitaDiaOtd> MapearDias(IEnumerable<VISITA_DIA> dias)
        {
            return Mapper.Map<IList<VisitaDiaOtd>>(dias);
        }
    }
}
