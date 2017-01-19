using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDeCentroMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDeCentro();
        }

        private static void CrearMapeadorParaTipoDeCentro()
        {
            Mapper.CreateMap<TIPO_CENTRO, TipoDeCentroOtd>()
                           .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                           .ForMember(dest => dest.idTipoCentro, entidad => entidad.MapFrom(ft => ft.ID_TIPO_CENTRO))
                           .ForMember(dest => dest.Centros, entidad => entidad.Ignore());
        }
    }
}
