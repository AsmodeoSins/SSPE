using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLIncidenciaCatalogoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLINcidenciaCatalogo();
            CrearMapeadorParaPLINcidenciaCatalogoEntidad();
        }

        private static void CrearMapeadorParaPLINcidenciaCatalogo()
        {
            Mapper.CreateMap<PL_INCIDENCIA_CATALOGO, PLIncidenciaCatalogoOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR.Trim()))
                .ForMember(dest => dest.FechaModificacion, entidad => entidad.MapFrom(ft => ft.FECHA_MODIF))
                .ForMember(dest => dest.IdPLIncidenciaCatalogo, entidad => entidad.MapFrom(ft => ft.ID))
                .ForMember(dest => dest.ModificadoPor, entidad => entidad.MapFrom(ft => ft.LOGIN_MODIF.Trim()))
                .ForMember(dest => dest.Visible, entidad => entidad.MapFrom(ft => ft.VISIBLE));
                
        }

        private static void CrearMapeadorParaPLINcidenciaCatalogoEntidad()
        {
            Mapper.CreateMap<PLIncidenciaCatalogoOtd, PL_INCIDENCIA_CATALOGO>()
                .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
                .ForMember(dest => dest.FECHA_MODIF, entidad => entidad.MapFrom(ft => ft.FechaModificacion))
                .ForMember(dest => dest.ID, entidad => entidad.MapFrom(ft => ft.IdPLIncidenciaCatalogo))
                .ForMember(dest => dest.LOGIN_MODIF, entidad => entidad.MapFrom(ft => ft.ModificadoPor))
                .ForMember(dest => dest.VISIBLE, entidad => entidad.MapFrom(ft => ft.Visible));
        }
    }
}
