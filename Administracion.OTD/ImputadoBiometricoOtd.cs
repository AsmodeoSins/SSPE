using Administracion.OTD.AtributosPersonalizados;

namespace Administracion.OTD
{
    /// <summary>
    /// Representa el modelo para la tabla 'IMPUTADO'
    /// </summary>
    public class ImputadoBiometricoOtd
    {
        #region Propiedades
        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO")]
        public int IdImputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ANIO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_ANIO")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_BIOMETRICO")]
        public short IdTipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("BIOMETRICO")]
        public byte[] Biometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("CALIDAD")]
        public short? Calidad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_FORMATO")]
        public short IdFormato { get; set; }


        /// <summary>
        /// Propiedad para la columna 'BIOMETRICO_TIPO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("BIOMETRICO_TIPO")]
        public BiometricoTipoOtd BiometricoTipo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO' de la tabla 'IMPUTADO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("IMPUTADO")]
        public ImputadoOtd Imputado { get; set; }
        #endregion
    }
}
