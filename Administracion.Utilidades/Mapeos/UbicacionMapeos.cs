using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Administracion.Utilidades.Mapeos
{
    public static class UbicacionMapeos
    {
        public static IList<EdificioOtd> MapearEdificios(IEnumerable<EDIFICIO> edificios)
        {
            return Mapper.Map<IList<EdificioOtd>>(edificios);
        }

        public static IList<SectorOtd> MapearSectores(IList<SECTOR> sectores)
        {
            return Mapper.Map<IList<SectorOtd>>(sectores);
        }

        public static IList<SectorOtd> MapearSectores(HashSet<SECTOR> sectores)
        {
            return sectores.Select(s => Mapper.Map<SectorOtd>(s)).ToList();
        }

        public static AsignacionOtd MapearAsignacion(SECTOR sector)
        {
            return Mapper.Map<AsignacionOtd>(sector);
        }

        public static AsignacionOtd MapearAsignacion(SectorOtd sector)
        {
            return Mapper.Map<AsignacionOtd>(sector);
        }

        public static IList<CatalogoBaseOdt> MapearCatalogoBaseDeEdificios(IList<EdificioOtd> edificios)
        {
            return Mapper.Map<IList<CatalogoBaseOdt>>(edificios);
        }

        public static IList<CeldaOtd> MapearCeldas(List<CELDA> celdas)
        {
            return Mapper.Map<IList<CeldaOtd>>(celdas);
        }
    }
}