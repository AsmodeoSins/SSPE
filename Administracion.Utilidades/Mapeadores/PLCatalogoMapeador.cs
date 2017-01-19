using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLCatalogoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLCatalogo();
            CrearMapeadorParaPLCatalogoEntidad();
            CrearMapeadorParaPLCatalogoEstatus();
            CrearMapeadorParaPLCatalogoEstatusEntidad();
        }

        public static void CrearMapeadorParaPLCatalogo()
        {
            Mapper.CreateMap<PL_CATALOGO, PLCatalogoOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR.Trim()))
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS.Trim()))
                .ForMember(dest => dest.FechaCreado, entidad => entidad.MapFrom(ft => ft.FECHA_CREADO))
                .ForMember(dest => dest.HoraInicio, entidad => entidad.MapFrom(ft => ft.HORA_INICIO))
                .ForMember(dest => dest.IdPLCatalgo, entidad => entidad.MapFrom(ft => ft.ID_PL_CATALOGO))
                .ForMember(dest => dest.Nombre, entidad => entidad.MapFrom(ft => ft.NOMBRE.Trim()))
                .ForMember(dest => dest.PLCatalogoEstatus, entidad => entidad.MapFrom(ft => Mapper.Map<PLCatalogoEstatusOtd>(ft.PL_CATALOGO_ESTATUS)))
                .ForMember(dest => dest.PLProgramados, entidad => entidad.Ignore());
                //.ForMember(dest => dest.PLProgramados, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<PLProgramadoOtd>>(ft.PL_PROGRAMADO)));
        }

        public static void CrearMapeadorParaPLCatalogoEntidad()
        {
            Mapper.CreateMap<PLCatalogoOtd, PL_CATALOGO>()
                .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
                .ForMember(dest => dest.ESTATUS, entidad => entidad.MapFrom(ft => ft.Estatus))
                .ForMember(dest => dest.FECHA_CREADO, entidad => entidad.MapFrom(ft => ft.FechaCreado))
                .ForMember(dest => dest.HORA_INICIO, entidad => entidad.MapFrom(ft => ft.HoraInicio))
                .ForMember(dest => dest.ID_PL_CATALOGO, entidad => entidad.MapFrom(ft => ft.IdPLCatalgo))
                .ForMember(dest => dest.NOMBRE, entidad => entidad.MapFrom(ft => ft.Nombre))
                .ForMember(dest => dest.FECHA_CREADO, entidad => entidad.MapFrom(ft => DateTime.Now))
                .ForMember(dest => dest.PL_CATALOGO_ESTATUS, entidad => entidad.Ignore())
                .ForMember(dest => dest.PL_PROGRAMADO, entidad => entidad.Ignore());
        }

        public static void CrearMapeadorParaPLCatalogoEstatus()
        {
            Mapper.CreateMap<PL_CATALOGO_ESTATUS, PLCatalogoEstatusOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdEstatus, entidad => entidad.MapFrom(ft => ft.ID_ESTATUS));
        }

        public static void CrearMapeadorParaPLCatalogoEstatusEntidad()
        {
            Mapper.CreateMap<PLCatalogoEstatusOtd, PL_CATALOGO_ESTATUS>()
                .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
                .ForMember(dest => dest.ID_ESTATUS, entidad => entidad.MapFrom(ft => ft.IdEstatus));
        }
    }
}
