using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeos
{
    public static class SectorMapeos
    {
        public static SECTOR MapearEntidad(SectorOtd sector)
        {
            return Mapper.Map<SECTOR>(sector);
        }

        public static SectorOtd MapearOtd(SECTOR sector)
        {
            return Mapper.Map<SectorOtd>(sector);
        }

        public static IList<SectorOtd> MapearListaDeOtds(IList<SECTOR> sectores)
        {
            return Mapper.Map<IList<SECTOR>, IList<SectorOtd>>(sectores);
        }

        public static AsignacionOtd MapearAsignacion(SECTOR sector)
        {
            return Mapper.Map<AsignacionOtd>(sector);
        }
    }
}
