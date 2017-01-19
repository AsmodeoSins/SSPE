using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class BiometricoTipoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_BIOMETRICO' de la tabla 'BIOMETRICO_TIPO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_BIOMETRICO")]
        public short IdTipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TIPO_BIOMETRICO' de la tabla 'BIOMETRICO_TIPO'
        /// </summary>
        [NombreDeColumna("TIPO_BIOMETRICO")]
        public string TipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO_BIOMETRICO' de la tabla 'BIOMETRICO_TIPO'
        /// </summary>
        [NombreDeColumna("IMPUTADO_BIOMETRICO")]
        public virtual ICollection<ImputadoBiometricoOtd> IMPUTADO_BIOMETRICO { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INGRESO_BIOMETRICO' de la tabla 'BIOMETRICO_TIPO'
        /// </summary>
        [NombreDeColumna("INGRESO_BIOMETRICO")]
        public virtual ICollection<IngresoBiometricoOtd> INGRESO_BIOMETRICO { get; set; }
    }
}
