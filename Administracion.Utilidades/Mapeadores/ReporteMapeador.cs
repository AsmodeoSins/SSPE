using Administracion.Modelos.Entidades;
using Administracion.OTD.Reportes;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class ReporteMapeador
    {
        public static void Configuraction()
        {
            CrearMapeadorParaReporteGeneral();
        }

        private static void CrearMapeadorParaReporteGeneral()
        {
            Mapper.CreateMap<PL_ASIGNACION_RESULTADO, SeccionBaseRpt>()
                .ForMember(dest => dest.Titulo, entidad => entidad.MapFrom(ft => string.Format("PASE DE LISTA {0} {1}", ft.PL_PROGRAMADO_BITACORA.PL_PROGRAMADO.PL_CATALOGO.DESCR, ft.PL_PROGRAMADO_BITACORA.FECHA_EJECUCION.ToString("MMM dd yyyy"))));
                //.ForMember(dest => dest, entidad => entidad.MapFrom(ft => ft.DESCR))
                //.ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                //.ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                //.ForMember(dest => dest.IdTipoEdificio, entidad => entidad.MapFrom(ft => ft.ID_TIPO_EDIFICIO))
                //.ForMember(dest => dest.TipoDeEdificio, entidad => entidad.Ignore())
                //.ForMember(dest => dest.Centro, entidad => entidad.Ignore())
                //.ForMember(dest => dest.Sectores, entidad => entidad.Ignore())
                //.ForMember(dest => dest.PLProgramadoAsignaciones, entidad => entidad.Ignore());
        }
    }
}