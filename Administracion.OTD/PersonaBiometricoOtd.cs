using Administracion.OTD.AtributosPersonalizados;

namespace Administracion.OTD
{
    /// <summary>
    /// Representa el modelo para la tabla 'PERSONA_BIOMETRICO'
    /// </summary>
    public class PersonaBiometricoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_PERSONA' de la tabla 'PERSONA_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_PERSONA")]
        public int IdPersona { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_BIOMETRICO' de la tabla 'PERSONA_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_BIOMETRICO")]
        public short IdTipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'BIOMETRICO' de la tabla 'PERSONA_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("BIOMETRICO")]
        public byte[] Biometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NOORIGINAL' de la tabla 'PERSONA_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("NOORIGINAL")]
        public int? NoOriginal { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_FORMATO' de la tabla 'PERSONA_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_FORMATO")]
        public short IdFormato { get; set; }
    }
}
