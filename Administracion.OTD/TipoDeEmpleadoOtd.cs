using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    /// <summary>
    /// Modelo para la tabla 'TIPO_EMPLEADO'
    /// </summary>
    public class TipoDeEmpleadoOtd
    {
        /// <summary>
        /// Propiedad par ala columna 'ID_TIPO_EMPLEADO' de la tabla 'TIPO_EMPLEADO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_EMPLEADO")]
        public short IdTipoDeEmpleado { get; set; }

        /// <summary>
        /// Propiedad par ala columna 'DESCR' de la tabla 'TIPO_EMPLEADO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad par ala columna 'EMPLEADOes' de la tabla 'TIPO_EMPLEADO'
        /// </summary>
        [NombreDeColumna("EMPLEADOes")]
        public virtual ICollection<EmpleadoOtd> Empleados { get; set; }
    }
}
