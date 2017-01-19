using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class ParametroMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaPaseDeListaCatalogo();
            CrearMapeadorParaPaseDeListaCatalogoEntidad();
        }

        private static void CrearMapeadorParaPaseDeListaCatalogo()
        {
            Mapper.CreateMap<PARAMETRO, ParametroOtd>()
                .ForMember(dest => dest.Contenido, entidad => entidad.MapFrom(ft => ft.CONTENIDO))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdClave, entidad => entidad.MapFrom(ft => ft.ID_CLAVE))
                .ForMember(dest => dest.Valor, entidad => entidad.MapFrom(ft => ft.VALOR.Trim()))
                .ForMember(dest => dest.ValorNum, entidad => entidad.MapFrom(ft => ft.VALOR_NUM))
                .ForMember(dest => dest.ParametroClave, entidad => entidad.MapFrom(ft => Mapper.Map<ParametroClaveOtd>(ft.PARAMETRO_CLAVE)));
        }

        private static void CrearMapeadorParaPaseDeListaCatalogoEntidad()
        {
            Mapper.CreateMap<ParametroOtd, PARAMETRO>()
                .ForMember(dest => dest.CONTENIDO, entidad => entidad.MapFrom(ft => ft.Contenido))
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
                .ForMember(dest => dest.ID_CLAVE, entidad => entidad.MapFrom(ft => ft.IdClave))
                .ForMember(dest => dest.VALOR, entidad => entidad.MapFrom(ft => ft.Valor))
                .ForMember(dest => dest.VALOR_NUM, entidad => entidad.MapFrom(ft => ft.ValorNum))
                .ForMember(dest => dest.PARAMETRO_CLAVE, entidad => entidad.Ignore());
        }
    }
}
