using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class IngresoBiometricoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ANIO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_ANIO")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO")]
        public int IdImputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_INGRESO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_INGRESO")]
        public short IdIngreso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_BIOMETRICO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_BIOMETRICO")]
        public short IdTipoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'BIOMETRICO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("BIOMETRICO")]
        public byte[] Biometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_FORMATO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("ID_FORMATO")]
        public short IdFormato { get; set; }


        /// <summary>
        /// Propiedad para la columna 'BIOMETRICO_TIPO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("BIOMETRICO_TIPO")]
        public virtual BiometricoTipoOtd BiometricoTipo { get; set; }


        /// <summary>
        /// Propiedad para la columna 'INGRESO' de la tabla 'INGRESO_BIOMETRICO'
        /// </summary>
        [NombreDeColumna("INGRESO")]
        public virtual IngresoOtd Ingreso { get; set; }
    }
}
