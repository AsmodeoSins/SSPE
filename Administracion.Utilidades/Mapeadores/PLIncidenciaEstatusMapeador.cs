using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class PLIncidenciaEstatusMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPLIncidenciaEstatus();
            CrearMapeadorParaPLIncidenciaEstatusEntidad();
        }

        public static void CrearMapeadorParaPLIncidenciaEstatus()
        {
            Mapper.CreateMap<PL_INCIDENCIA_ESTATUS, PLIncidenciaEstatus>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdIncidenciaEstatus, entidad => entidad.MapFrom(ft => ft.ID_INCIDENCIA_ESTATUS));
        }

        public static void CrearMapeadorParaPLIncidenciaEstatusEntidad()
        {
            Mapper.CreateMap<PLIncidenciaEstatus, PL_INCIDENCIA_ESTATUS>()
                .ForMember(dest => dest.DESCR, entidad => entidad.MapFrom(ft => ft.Descripcion))
                .ForMember(dest => dest.ID_INCIDENCIA_ESTATUS, entidad => entidad.MapFrom(ft => ft.IdIncidenciaEstatus));
        }
    }
}
