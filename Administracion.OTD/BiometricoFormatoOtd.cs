using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class BiometricoFormatoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_BIOMETRICO' de la tabla 'BIOMETRICO_FORMATO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_BIOMETRICO")]
        public short IdTipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TIPO_BIOMETRICO' de la tabla 'BIOMETRICO_FORMATO'
        /// </summary>
        [NombreDeColumna("TIPO_BIOMETRICO")]
        public string TipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO_BIOMETRICO' de la tabla 'BIOMETRICO_FORMATO'
        /// </summary>
        [NombreDeColumna("IMPUTADO_BIOMETRICO")]
        public virtual ICollection<ImputadoBiometricoOtd> ImputadosBiometricos { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INGRESO_BIOMETRICO' de la tabla 'BIOMETRICO_FORMATO'
        /// </summary>
        [NombreDeColumna("INGRESO_BIOMETRICO")]
        public virtual ICollection<IngresoBiometricoOtd> IngresosBiometricos { get; set; }
    }
}
