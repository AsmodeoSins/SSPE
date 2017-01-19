using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDeEdificionMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDeEdificio();
        }

        private static void CrearMapeadorParaTipoDeEdificio()
        {
            Mapper.CreateMap<TIPO_EDIFICIO, TipoDeEdificioOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdTipoDeEdificio, entidad => entidad.MapFrom(ft => ft.ID_TIPO_EDIFICIO))
                .ForMember(dest => dest.Edificios, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<EdificioOtd>>(ft.EDIFICIOs)));
        }
    }
}
