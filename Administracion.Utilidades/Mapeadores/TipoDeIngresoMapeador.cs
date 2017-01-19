using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class TipoDeIngresoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaTipoDeIngreso();
        }

        private static void CrearMapeadorParaTipoDeIngreso()
        {
            Mapper.CreateMap<TIPO_INGRESO, TipoDeIngresoOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdTipoIngreso, entidad => entidad.MapFrom(ft => ft.ID_TIPO_INGRESO));
        }
    }
}
