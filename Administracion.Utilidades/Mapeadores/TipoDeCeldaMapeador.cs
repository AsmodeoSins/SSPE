using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDeCeldaMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDeCelda();
        }

        private static void CrearMapeadorParaTipoDeCelda()
        {
            Mapper.CreateMap<TIPO_CELDA, TipoDeCeldaOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdTipoCelda, entidad => entidad.MapFrom(ft => ft.ID_TIPO_CELDA))
                .ForMember(dest => dest.Celdas, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<CeldaOtd>>(ft.CELDAs)));
        }
    }
}
