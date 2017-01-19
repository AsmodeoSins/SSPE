using Administracion.OTD;
using Administracion.Modelos.Entidades;
using AutoMapper;
using System;

namespace Administracion.Utilidades.Mapeadores
{
    public static class BiometricoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorParaImputadoBiometricoDeBiometricoOtd();
            CrearMapeadorParaPersonaBiometricoDeBiometricoOtd();
            CrearMapeadorParaImputadoBiometrico();
            CrearMapeadorParaImputadoBiometricoOtd();
            CrearMapeadorParaBiometricoOtdDePersonaBiometrico();
        }

        private static void CrearMapeadorParaImputadoBiometricoDeBiometricoOtd()
        {
            Mapper.CreateMap<BiometricoOtd, IMPUTADO_BIOMETRICO>()
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(ft => ft.IdCentro))
                .ForMember(dest => dest.ID_FORMATO, entidad => entidad.MapFrom(ft => (short)ft.Formato))
                .ForMember(dest => dest.ID_TIPO_BIOMETRICO, entidad => entidad.MapFrom(ft => (short)ft.Tipo))
                .ForMember(dest => dest.ID_ANIO, entidad => entidad.MapFrom(ft => ft.Anio))
                .ForMember(dest => dest.BIOMETRICO, entidad => entidad.MapFrom(ft => ft.Biometrico))
                .ForMember(dest => dest.BIOMETRICO_TIPO, entidad => entidad.Ignore())
                .ForMember(dest => dest.IMPUTADO, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaPersonaBiometricoDeBiometricoOtd()
        {
            Mapper.CreateMap<BiometricoOtd, PERSONA_BIOMETRICO>()
                .ForMember(dest => dest.ID_FORMATO, entidad => entidad.MapFrom(ft => (short)ft.Formato))
                .ForMember(dest => dest.ID_TIPO_BIOMETRICO, entidad => entidad.MapFrom(ft => (short)ft.Tipo))
                .ForMember(dest => dest.BIOMETRICO, entidad => entidad.MapFrom(ft => ft.Biometrico));
        }

        private static void CrearMapeadorParaBiometricoOtdDePersonaBiometrico()
        {
            Mapper.CreateMap<PERSONA_BIOMETRICO, BiometricoOtd>()
                .ForMember(dest => dest.Formato, entidad => entidad.MapFrom(ft => (int)ft.ID_FORMATO))
                .ForMember(dest => dest.Tipo, entidad => entidad.MapFrom(ft => (int)ft.ID_TIPO_BIOMETRICO))
                .ForMember(dest => dest.Biometrico, entidad => entidad.MapFrom(ft => ft.BIOMETRICO));
        }

        private static void CrearMapeadorParaImputadoBiometrico()
        {
            Mapper.CreateMap<IMPUTADO_BIOMETRICO, BiometricoOtd>()
                .ForMember(dest => dest.Biometrico, entidad => entidad.MapFrom(ft => ft.BIOMETRICO))
                .ForMember(dest => dest.Formato, entidad => entidad.MapFrom(ft => (int)ft.ID_FORMATO))
                .ForMember(dest => dest.Tipo, entidad => entidad.MapFrom(ft => (int)ft.ID_TIPO_BIOMETRICO))
                .ForMember(dest => dest.Anio, entidad => entidad.MapFrom(ft => ft.ID_ANIO))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.Calidad, entidad => entidad.Ignore());
        }

        private static void CrearMapeadorParaImputadoBiometricoOtd()
        {
            Mapper.CreateMap<IMPUTADO_BIOMETRICO, ImputadoBiometricoOtd>()
                .ForMember(dest => dest.Biometrico, entidad => entidad.MapFrom(ft => ft.BIOMETRICO))
                .ForMember(dest => dest.IdAnio, entidad => entidad.MapFrom(ft => ft.ID_ANIO))
                .ForMember(dest => dest.BiometricoTipo, entidad => entidad.Ignore())
                .ForMember(dest => dest.Calidad, entidad => entidad.MapFrom(ft => ft.CALIDAD))
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(ft => ft.ID_CENTRO))
                .ForMember(dest => dest.IdFormato, entidad => entidad.MapFrom(ft => ft.ID_FORMATO))
                .ForMember(dest => dest.IdImputado, entidad => entidad.MapFrom(ft => ft.ID_IMPUTADO))
                .ForMember(dest => dest.IdTipoBiometrico, entidad => entidad.MapFrom(ft => ft.ID_TIPO_BIOMETRICO))
                .ForMember(dest => dest.Imputado, entidad => entidad.Ignore());
        }
    }
}
