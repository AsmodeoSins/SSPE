using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLProgramadoAsignacionMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLProgramadoAsignacion();
            CrearMapeadorParaPLProgramadoAsignacionEntidad();
        }

        private static void CrearMapeadorParaPLProgramadoAsignacion()
        {
            Mapper.CreateMap<PL_PROGRAMADO_ASIGNACION, PLProgramadoAsignacionOtd>()
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEdificio, entidad => entidad.MapFrom(ft => ft.ID_EDIFICIO))
                .ForMember(dest => dest.IdEmpleado, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO))
                .ForMember(dest => dest.IdPLAsignacion, entidad => entidad.MapFrom(ft => ft.ID_PL_ASIGNACION))
                .ForMember(dest => dest.IdPLProgramado, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO))
                .ForMember(dest => dest.IdSector, entidad => entidad.MapFrom(ft => ft.ID_SECTOR))
                .ForMember(dest => dest.Edificio, entidad => entidad.Ignore())
                .ForMember(dest => dest.Empleado, entidad => entidad.Ignore())
                .ForMember(dest => dest.PLProgramdo, entidad => entidad.Ignore())
                .ForMember(dest => dest.Sector, entidad => entidad.Ignore())
                .ForMember(dest => dest.PlAsignacionResultado, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaPLProgramadoAsignacionEntidad()
        {
            Mapper.CreateMap<PLProgramadoAsignacionOtd, PL_PROGRAMADO_ASIGNACION>()
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
                .ForMember(dest => dest.ID_EDIFICIO, entidad => entidad.MapFrom(ft => ft.IdEdificio))
                .ForMember(dest => dest.ID_EMPLEADO, entidad => entidad.MapFrom(ft => ft.IdEmpleado))
                .ForMember(dest => dest.ID_PL_ASIGNACION, entidad => entidad.MapFrom(ft => ft.IdPLAsignacion))
                .ForMember(dest => dest.ID_PL_PROGRAMADO, entidad => entidad.MapFrom(ft => ft.IdPLProgramado))
                .ForMember(dest => dest.ID_SECTOR, entidad => entidad.MapFrom(ft => ft.IdSector))
                .ForMember(dest => dest.EDIFICIO, entidad => entidad.Ignore())
                .ForMember(dest => dest.EMPLEADO, entidad => entidad.Ignore())
                .ForMember(dest => dest.PL_PROGRAMADO, entidad => entidad.Ignore())
                .ForMember(dest => dest.SECTOR, entidad => entidad.Ignore())
                .ForMember(dest => dest.PL_ASIGNACION_RESULTADO, entidad => entidad.Ignore());
        }
    }
}
