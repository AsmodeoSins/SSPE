using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class HorariosMapeos
    {
        public static IList<HorarioVisitaOtd> MapearHorarios(IEnumerable<HORARIO_VISITA> horarios)
        {
            return Mapper.Map<IList<HorarioVisitaOtd>>(horarios);
        }

        public static HorarioVisitaOtd MapearHorarios(HorarioVisitaOtd horarios)
        {
            return Mapper.Map<HorarioVisitaOtd>(horarios);
        }

        public static HORARIO_VISITA MapearEntidad(HorarioVisitaOtd horario)
        {
            return Mapper.Map<Modelos.Entidades.HORARIO_VISITA>(horario);
        }
    }
}
