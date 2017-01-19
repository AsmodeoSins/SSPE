using Administracion.Modelos.Entidades;
using Administracion.OTD;
using AutoMapper;
using System.Collections.Generic;

namespace Administracion.Utilidades.Mapeadores
{
    public static class IngresoMapeador
    {
        public static void Configuracion()
        {
            CrearMapeadorIngresos();
            CrearMapeadorIngresosEntidad();
        }

        private static void CrearMapeadorIngresos()
        {
            Mapper.CreateMap<INGRESO, IngresoOtd>()
                .ForMember(dest => dest.IdCentro, entidad => entidad.MapFrom(e => e.ID_CENTRO))
                .ForMember(dest => dest.IdAnio, entidad => entidad.MapFrom(e => e.ID_ANIO))
                .ForMember(dest => dest.IdImputado, entidad => entidad.MapFrom(e => e.ID_IMPUTADO))
                .ForMember(dest => dest.IdIngreso, entidad => entidad.MapFrom(e => e.ID_INGRESO))
                .ForMember(dest => dest.FechaRegistro, entidad => entidad.MapFrom(e => e.FEC_REGISTRO))
                .ForMember(dest => dest.FechaIngresoCereso, entidad => entidad.MapFrom(e => e.FEC_INGRESO_CERESO))
                .ForMember(dest => dest.IdTipoIngreso, entidad => entidad.MapFrom(e => e.ID_TIPO_INGRESO))
                .ForMember(dest => dest.IdClasificacionJuridica, entidad => entidad.MapFrom(e => e.ID_CLASIFICACION_JURIDICA))
                .ForMember(dest => dest.IdEstatusAdministrativo, entidad => entidad.MapFrom(e => e.ID_ESTATUS_ADMINISTRATIVO))
                .ForMember(dest => dest.DocInternacionNumOficio, entidad => entidad.MapFrom(e => e.DOCINTERNACION_NUM_OFICIO))
                .ForMember(dest => dest.IdAutoridadInterna, entidad => entidad.MapFrom(e => e.ID_AUTORIDAD_INTERNA))
                .ForMember(dest => dest.IdTipoSeguridad, entidad => entidad.MapFrom(e => e.ID_TIPO_SEGURIDAD))
                .ForMember(dest => dest.IdDisposicion, entidad => entidad.MapFrom(e => e.ID_DISPOSICION))
                .ForMember(dest => dest.IdTipoDocumentoInternacion, entidad => entidad.MapFrom(e => e.ID_TIPO_DOCUMENTO_INTERNACION))
                .ForMember(dest => dest.DocumentoInternacion, entidad => entidad.MapFrom(e => e.DOCUMENTO_INTERNACION))
                .ForMember(dest => dest.NUC, entidad => entidad.MapFrom(e => e.NUC))
                .ForMember(dest => dest.AvPrevia, entidad => entidad.MapFrom(e => e.AV_PREVIA))
                .ForMember(dest => dest.IdImputadoExpediente, entidad => entidad.MapFrom(e => e.ID_IMPUTADO_EXPEDIENTE))
                .ForMember(dest => dest.IdUbCentro, entidad => entidad.MapFrom(e => e.ID_UB_CENTRO))
                .ForMember(dest => dest.IdUbEdificio, entidad => entidad.MapFrom(e => e.ID_UB_EDIFICIO))
                .ForMember(dest => dest.IdUbSector, entidad => entidad.MapFrom(e => e.ID_UB_SECTOR))
                .ForMember(dest => dest.IdUbCelda, entidad => entidad.MapFrom(e => e.ID_UB_CELDA))
                .ForMember(dest => dest.IdUbCama, entidad => entidad.MapFrom(e => e.ID_UB_CAMA))
                .ForMember(dest => dest.ADisposicion, entidad => entidad.MapFrom(e => e.A_DISPOSICION))
                .ForMember(dest => dest.AnioGobierno, entidad => entidad.MapFrom(e => e.ANIO_GOBIERNO))
                .ForMember(dest => dest.FolioGobierno, entidad => entidad.MapFrom(e => e.FOLIO_GOBIERNO))
                .ForMember(dest => dest.IdIngresoDelito, entidad => entidad.MapFrom(e => e.ID_INGRESO_DELITO))
                .ForMember(dest => dest.Centro, entidad => entidad.Ignore())
                .ForMember(dest => dest.Imputado, entidad => entidad.Ignore())
                .ForMember(dest => dest.IngresosBiometricos, entidad => entidad.Ignore());
                //.ForMember(dest => dest.Centro, entidad => entidad.MapFrom(ft => Mapper.Map<CentroOtd>(ft.CENTRO)))
                //.ForMember(dest => dest.IngresosBiometricos, entidad => entidad.MapFrom(ft => Mapper.Map<ICollection<IngresoBiometricoOtd>>(ft.INGRESO_BIOMETRICO)));
        }

        private static void CrearMapeadorIngresosEntidad()
        {
            Mapper.CreateMap<IngresoOtd, INGRESO>()
                .ForMember(dest => dest.ID_CENTRO, entidad => entidad.MapFrom(e => e.IdCentro))
                .ForMember(dest => dest.ID_ANIO, entidad => entidad.MapFrom(e => e.IdAnio))
                .ForMember(dest => dest.ID_IMPUTADO, entidad => entidad.MapFrom(e => e.IdImputado))
                .ForMember(dest => dest.ID_INGRESO, entidad => entidad.MapFrom(e => e.IdIngreso))
                .ForMember(dest => dest.FEC_REGISTRO, entidad => entidad.MapFrom(e => e.FechaRegistro))
                .ForMember(dest => dest.FEC_INGRESO_CERESO, entidad => entidad.MapFrom(e => e.FechaIngresoCereso))
                .ForMember(dest => dest.ID_TIPO_INGRESO, entidad => entidad.MapFrom(e => e.IdTipoIngreso))
                .ForMember(dest => dest.ID_CLASIFICACION_JURIDICA, entidad => entidad.MapFrom(e => e.IdClasificacionJuridica))
                .ForMember(dest => dest.ID_ESTATUS_ADMINISTRATIVO, entidad => entidad.MapFrom(e => e.IdEstatusAdministrativo))
                .ForMember(dest => dest.DOCINTERNACION_NUM_OFICIO, entidad => entidad.MapFrom(e => e.DocInternacionNumOficio))
                .ForMember(dest => dest.ID_AUTORIDAD_INTERNA, entidad => entidad.MapFrom(e => e.IdAutoridadInterna))
                .ForMember(dest => dest.ID_TIPO_SEGURIDAD, entidad => entidad.MapFrom(e => e.IdTipoSeguridad))
                .ForMember(dest => dest.ID_DISPOSICION, entidad => entidad.MapFrom(e => e.IdDisposicion))
                .ForMember(dest => dest.ID_TIPO_DOCUMENTO_INTERNACION, entidad => entidad.MapFrom(e => e.IdTipoDocumentoInternacion))
                .ForMember(dest => dest.DOCUMENTO_INTERNACION, entidad => entidad.MapFrom(e => e.DocumentoInternacion))
                .ForMember(dest => dest.NUC, entidad => entidad.MapFrom(e => e.NUC))
                .ForMember(dest => dest.AV_PREVIA, entidad => entidad.MapFrom(e => e.AvPrevia))
                .ForMember(dest => dest.ID_IMPUTADO_EXPEDIENTE, entidad => entidad.MapFrom(e => e.IdImputadoExpediente))
                .ForMember(dest => dest.ID_UB_CENTRO, entidad => entidad.MapFrom(e => e.IdUbCentro))
                .ForMember(dest => dest.ID_UB_EDIFICIO, entidad => entidad.MapFrom(e => e.IdUbEdificio))
                .ForMember(dest => dest.ID_UB_SECTOR, entidad => entidad.MapFrom(e => e.IdUbSector))
                .ForMember(dest => dest.ID_UB_CELDA, entidad => entidad.MapFrom(e => e.IdUbCelda))
                .ForMember(dest => dest.ID_UB_CAMA, entidad => entidad.MapFrom(e => e.IdUbCama))
                .ForMember(dest => dest.A_DISPOSICION, entidad => entidad.MapFrom(e => e.ADisposicion))
                .ForMember(dest => dest.ANIO_GOBIERNO, entidad => entidad.MapFrom(e => e.AnioGobierno))
                .ForMember(dest => dest.FOLIO_GOBIERNO, entidad => entidad.MapFrom(e => e.FolioGobierno))
                .ForMember(dest => dest.ID_INGRESO_DELITO, entidad => entidad.MapFrom(e => e.IdIngresoDelito))
                .ForMember(dest => dest.CENTRO, entidad => entidad.Ignore())
                .ForMember(dest => dest.IMPUTADO, entidad => entidad.Ignore())
                .ForMember(dest => dest.INGRESO_BIOMETRICO, entidad => entidad.Ignore());
        }
    }
}
