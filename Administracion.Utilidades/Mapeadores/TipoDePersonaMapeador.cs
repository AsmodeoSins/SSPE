using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDePersonaMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDePersona();
        }

        private static void CrearMapeadorParaTipoDePersona()
        {
            Mapper.CreateMap<TIPO_PERSONA, TipoDePersonaOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdTipoPersona, entidad => entidad.MapFrom(ft => ft.ID_TIPO_PERSONA))
                .ForMember(dest => dest.Personas, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<PersonaOtd>>(ft.PERSONAs)));

        }
    }
}
