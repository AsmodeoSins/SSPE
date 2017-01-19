using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class ParametroClaveMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaParametroClave();
        }

        public static void CrearMapeadorParaParametroClave()
        {
            Mapper.CreateMap<PARAMETRO_CLAVE, ParametroClaveOtd>()
                .ForMember(dest => dest.Descripcion, entidad => entidad.MapFrom(ft => ft.DESCR))
                .ForMember(dest => dest.IdClave, entidad => entidad.MapFrom(ft => ft.ID_CLAVE))
                .ForMember(dest => dest.Sistema, entidad => entidad.MapFrom(ft => ft.SISTEMA))
                .ForMember(dest => dest.Parametros, entidad => entidad.Ignore());

        }
    }
}
