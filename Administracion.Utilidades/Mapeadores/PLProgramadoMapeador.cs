using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLProgramadoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLProgramado();
            CrearMapeadorParaPLProgramadoEntidad();
            CrearMapeadorParaPaseListaOTD();

            CrearMapeadorParaPaseListaBitacoraOTD();
        }

        public static void CrearMapeadorParaPLProgramado()
        {
            Mapper.CreateMap<PL_PROGRAMADO, PLProgramadoOtd>()
                .ForMember(dest => dest.FechaCreado, entidad => entidad.MapFrom(ft => ft.FECH_CREADO))
                .ForMember(dest => dest.IdPlProgramado, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdEmpleadoCreado, entidad => entidad.MapFrom(ft => ft.ID_EMPLEADO_CREADO))
                .ForMember(dest => dest.IdPLCatalogo, entidad => entidad.MapFrom(ft => ft.ID_PL_CATALOGO))
                .ForMember(dest => dest.Vigente, entidad => entidad.MapFrom(ft => ft.VIGENTE))
                .ForMember(dest => dest.PLCatalogo, entidad => entidad.MapFrom(ft => Mapper.Map<PLCatalogoOtd>(ft.PL_CATALOGO)))
                .ForMember(dest => dest.Empleado, entidad => entidad.Ignore())
                .ForMember(dest => dest.Centro, entidad => entidad.Ignore())
                .ForMember(dest => dest.PLProgramadoAsignaciones, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<PLProgramadoAsignacionOtd>>(ft.PL_PROGRAMADO_ASIGNACION)));
        }

        public static void CrearMapeadorParaPLProgramadoEntidad()
        {
            Mapper.CreateMap<PLProgramadoOtd, PL_PROGRAMADO>()
                .ForMember(dest => dest.FECH_CREADO, entidad => entidad.MapFrom(ft => ft.FechaCreado))
                .ForMember(dest => dest.ID_PL_PROGRAMADO, entidad => entidad.MapFrom(ft => ft.IdPlProgramado))
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
                .ForMember(dest => dest.ID_EMPLEADO_CREADO, entidad => entidad.MapFrom(ft => ft.IdEmpleadoCreado))
                .ForMember(dest => dest.ID_PL_CATALOGO, entidad => entidad.MapFrom(ft => ft.IdPLCatalogo))
                .ForMember(dest => dest.VIGENTE, entidad => entidad.MapFrom(ft => ft.Vigente))
                .ForMember(dest => dest.PL_CATALOGO, entidad => entidad.Ignore())
                .ForMember(dest => dest.PL_PROGRAMADO_ASIGNACION, entidad => entidad.Ignore());
        }

        public static void CrearMapeadorParaPaseListaOTD()
        {
            Mapper.CreateMap<PaseListaOtd, PLProgramadoOtd>()
                .ForMember(dest => dest.IdCentro, pl => pl.MapFrom(ft => (short)ft.CentroId))
                .ForMember(dest => dest.IdEmpleadoCreado, pl => pl.MapFrom(ft => ft.UsuarioId))
                .ForMember(dest => dest.IdPLCatalogo, pl => pl.MapFrom(ft => (short)ft.TipoDePaseListaId))
                .ForMember(dest => dest.Vigente, pl => pl.MapFrom(ft => ft.EsNuevo ? (short)1 : (short)0))
                .ForMember(dest => dest.IdCentro, pl => pl.MapFrom(ft => (short)ft.CentroId))
                .ForMember(dest => dest.FechaCreado, pl => pl.MapFrom(ft => DateTime.Now));
        }

        public static void CrearMapeadorParaPaseListaBitacoraOTD()
        {
            Mapper.CreateMap<PL_PROGRAMADO_BITACORA, PLProgramadoBitacoraOtd>()
                .ForMember(dest => dest.IdPLBitacora, entidad => entidad.MapFrom(ft => ft.ID_PL_BITACORA))
                .ForMember(dest => dest.IdPlProgramado, entidad => entidad.MapFrom(ft => ft.ID_PL_PROGRAMADO))
                .ForMember(dest => dest.FechaEjecucion, entidad => entidad.MapFrom(ft => ft.FECHA_EJECUCION))
                .ForMember(dest => dest.Resultados, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<PL_ASIGNACION_RESULTADO>>(ft.PL_ASIGNACION_RESULTADO)));
        }
    }
}
