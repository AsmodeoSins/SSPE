using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;

namespace Administracion.OTD
{
    /// <summary>
    /// Representa el modelo para la tabla 'IMPUTADO'
    /// </summary>
    public class IngresoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ANIO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_ANIO")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO")]
        public int IdImputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_INGRESO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_INGRESO")]
        public short IdIngreso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FEC_REGISTRO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("FEC_REGISTRO")]
        public DateTime? FechaRegistro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FEC_INGRESO_CERESO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("FEC_INGRESO_CERESO")]
        public DateTime? FechaIngresoCereso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_INGRESO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_INGRESO")]
        public short? IdTipoIngreso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CLASIFICACION_JURIDICA' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_CLASIFICACION_JURIDICA")]
        public string IdClasificacionJuridica { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ESTATUS_ADMINISTRATIVO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_ESTATUS_ADMINISTRATIVO")]
        public short? IdEstatusAdministrativo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOCINTERNACION_NUM_OFICIO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("DOCINTERNACION_NUM_OFICIO")]
        public string DocInternacionNumOficio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_AUTORIDAD_INTERNA' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_AUTORIDAD_INTERNA")]
        public short? IdAutoridadInterna { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_SEGURIDAD' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_SEGURIDAD")]
        public string IdTipoSeguridad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_DISPOSICION' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_DISPOSICION")]
        public short? IdDisposicion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_DOCUMENTO_INTERNACION' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_DOCUMENTO_INTERNACION")]
        public short? IdTipoDocumentoInternacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOCUMENTO_INTERNACION' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("DOCUMENTO_INTERNACION")]
        public string DocumentoInternacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NUC' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("NUC")]
        public string NUC { get; set; }

        /// <summary>
        /// Propiedad para la columna 'AV_PREVIA' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("AV_PREVIA")]
        public string AvPrevia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO_EXPEDIENTE' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO_EXPEDIENTE")]
        public string IdImputadoExpediente { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_CENTRO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_CENTRO")]
        public short? IdUbIngreso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_EDIFICIO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_EDIFICIO")]
        public short? IdUbEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_SECTOR' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_SECTOR")]
        public Nullable<short> IdUbSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_CELDA' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_CELDA")]
        public string IdUbCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_CENTRO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_CENTRO")]
        public short? IdUbCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_UB_CAMA' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_UB_CAMA")]
        public short? IdUbCama { get; set; }

        /// <summary>
        /// Propiedad para la columna 'A_DISPOSICION' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("A_DISPOSICION")]
        public string ADisposicion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ANIO_GOBIERNO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ANIO_GOBIERNO")]
        public short? AnioGobierno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FOLIO_GOBIERNO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("FOLIO_GOBIERNO")]
        public string FolioGobierno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_INGRESO_DELITO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("ID_INGRESO_DELITO")]
        public short? IdIngresoDelito { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("IMPUTADO")]
        public ImputadoOtd Imputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INGRESO_BIOMETRICO' de la tabla 'INGRESO'
        /// </summary>
        [NombreDeColumna("INGRESO_BIOMETRICO")]
        public ICollection<IngresoBiometricoOtd> IngresosBiometricos { get; set; }
    }
}
