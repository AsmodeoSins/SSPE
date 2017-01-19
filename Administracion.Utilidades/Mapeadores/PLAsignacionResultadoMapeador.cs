using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLAsignacionResultadoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLAsignacionResultado();
            CrearMapeadorParaPLAsignacionResultadoEntidad();
        }

        public static void CrearMapeadorParaPLAsignacionResultado()
        {
            Mapper.CreateMap<PL_ASIGNACION_RESULTADO, PLAsignacionResultadoOtd>()
                .ForMember(dest => dest.Asistencias, entidad => entidad.MapFrom(ft => ft.ASISTENCIAS))
                .ForMember(dest => dest.HoraFinal, entidad => entidad.MapFrom(ft => ft.HORA_FINAL))
                .ForMember(dest => dest.HoraInicial, entidad => entidad.MapFrom(ft => ft.HORA_INICIAL))
                .ForMember(dest => dest.IdAsignacionResulado, entidad => entidad.MapFrom(ft => ft.ID_ASIGNACION_RESULTADO))
                .ForMember(dest => dest.IdCelda, entidad => entidad.MapFrom(ft => ft.ID_CELDA))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                .ForMember(dest => dest.IdPLAsignacion, entidad => entidad.MapFrom(ft => ft.ID_PL_ASIGNACION))
                .ForMember(dest => dest.IdSector, entidad => entidad.MapFrom(ft => ft.ID_SECTOR))
                .ForMember(dest => dest.Inasistencias, entidad => entidad.MapFrom(ft => ft.INASISTENCIAS))
                .ForMember(dest => dest.Celda, entidad => entidad.MapFrom(ft => Mapper.Map<CeldaOtd>(ft.CELDA)))
                .ForMember(dest => dest.PLProgramadoAsignacion, entidad => entidad.MapFrom(ft => Mapper.Map<PLProgramadoAsignacionOtd>(ft.PL_PROGRAMADO_ASIGNACION)));
        }

        public static void CrearMapeadorParaPLAsignacionResultadoEntidad()
        {
            Mapper.CreateMap<PLAsignacionResultadoOtd, PL_ASIGNACION_RESULTADO>()
                .ForMember(dest => dest.ASISTENCIAS, entidad => entidad.MapFrom(ft => ft.Asistencias))
                .ForMember(dest => dest.HORA_FINAL, entidad => entidad.MapFrom(ft => ft.HoraFinal))
                .ForMember(dest => dest.HORA_INICIAL, entidad => entidad.MapFrom(ft => ft.HoraInicial))
                .ForMember(dest => dest.ID_ASIGNACION_RESULTADO, entidad => entidad.MapFrom(ft => ft.IdAsignacionResulado))
                .ForMember(dest => dest.ID_CELDA, entidad => entidad.MapFrom(ft => ft.IdCelda))
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
                .ForMember(dest => dest.ID_EDIFICIO, entidad => entidad.MapFrom(ft => ft.IdEdificio))
                .ForMember(dest => dest.ID_PL_ASIGNACION, entidad => entidad.MapFrom(ft => ft.IdPLAsignacion))
                .ForMember(dest => dest.ID_SECTOR, entidad => entidad.MapFrom(ft => ft.IdSector))
                .ForMember(dest => dest.INASISTENCIAS, entidad => entidad.MapFrom(ft => ft.Inasistencias))
                .ForMember(dest => dest.CELDA, entidad => entidad.Ignore())
                .ForMember(dest => dest.PL_PROGRAMADO_ASIGNACION, entidad => entidad.Ignore());
        }
    }
}
