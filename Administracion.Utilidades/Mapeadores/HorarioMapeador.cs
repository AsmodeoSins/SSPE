using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class HorarioMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaVisitaDia();
            CrearMapeadorParaTipoVisita();
            CrearMapeadorParaHorarios();
        }

        private static void CrearMapeadorParaHorarios()
        {
            Mapper.CreateMap<HORARIO_VISITA, HorarioVisitaOtd>()
                .ForMember(dest => dest.Id, entidad => entidad.MapFrom(ft => ft.ID))
                .ForMember(dest => dest.IdDia, entidad => entidad.MapFrom(ft => ft.ID_DIA ?? default(int)))
                .ForMember(dest => dest.IdTipoVisita, entidad => entidad.MapFrom(ft => ft.ID_TIPO_VISITA ?? default(int)))
                .ForMember(dest => dest.HoraInicio, entidad => entidad.MapFrom(ft => ft.HORA_INICIO))
                .ForMember(dest => dest.HoraFin, entidad => entidad.MapFrom(ft => ft.HORA_FIN));
        }

        private static void CrearMapeadorParaTipoVisita()
        {
            Mapper.CreateMap<TIPO_VISITA, TipoVisitaOtd>()
                .ForMember(dest => dest.IdTipoVisita, entidad => entidad.MapFrom(ft => ft.ID_TIPO_VISITA))
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.Estatus, entidad => entidad.MapFrom(ft => ft.ESTATUS));
        }

        private static void CrearMapeadorParaVisitaDia()
        {
            Mapper.CreateMap<VISITA_DIA, VisitaDiaOtd>()
                .ForMember(dest => dest.IdDia, entidad => entidad.MapFrom(ft => ft.ID_DIA))
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR));
        }
    }
}
