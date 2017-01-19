using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;

namespace Administracion.Utilidades.Mapeadores
{
    public static class LogFallaServicioMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaLogFallaServicio();
            CrearMapeadorParaLogFallaServicioEntidad();
        }

        public static void CrearMapeadorParaLogFallaServicio()
        {
            Mapper.CreateMap<LOGFALLASERVICIO, LogFallaServicioOtd>()
                .ForMember(dest => dest.ApplicationName, entidad => entidad.MapFrom(ft => ft.APPLICATIONNAME))
                .ForMember(dest => dest.LogFallaServicioId, entidad => entidad.MapFrom(ft => ft.ID))
                .ForMember(dest => dest.MensajeDeError, entidad => entidad.MapFrom(ft => ft.MENSAJEDEERROR))
                .ForMember(dest => dest.DetalleDeErrror, entidad => entidad.MapFrom(ft => ft.DETALLEDELERROR))
                .ForMember(dest => dest.CodigoDeError, entidad => entidad.MapFrom(ft => ft.CODIGODEERROR))
                .ForMember(dest => dest.FechaDeCreacion, entidad => entidad.MapFrom(ft => ft.FECHADECREACION));
        }

        public static void CrearMapeadorParaLogFallaServicioEntidad()
        {
            Mapper.CreateMap<LogFallaServicioOtd, LOGFALLASERVICIO>()
                .ForMember(dest => dest.APPLICATIONNAME, entidad => entidad.MapFrom(ft => ft.ApplicationName))
                .ForMember(dest => dest.ID, entidad => entidad.MapFrom(ft => ft.LogFallaServicioId))
                .ForMember(dest => dest.MENSAJEDEERROR, entidad => entidad.MapFrom(ft => ft.MensajeDeError))
                .ForMember(dest => dest.DETALLEDELERROR, entidad => entidad.MapFrom(ft => ft.DetalleDeErrror))
                .ForMember(dest => dest.CODIGODEERROR, entidad => entidad.MapFrom(ft => ft.CodigoDeError))
                .ForMember(dest => dest.FECHADECREACION, entidad => entidad.MapFrom(ft => ft.FechaDeCreacion));
        }
    }
}
