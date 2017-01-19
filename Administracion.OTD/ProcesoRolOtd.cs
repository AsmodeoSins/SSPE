using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class ProcesoRolOtd
    {
        /// <summary>
        /// Representa la columna 'ID_PROCESO' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("ID_PROCESO")]
        public short IdProceso { get; set; }

        /// <summary>
        /// Representa la columna 'ID_ROL' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("ID_ROL")]
        public short IdRol { get; set; }

        /// <summary>
        /// Representa la columna 'INSERTAR' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("INSERTAR")]
        public short? Insertar { get; set; }

        /// <summary>
        /// Representa la columna 'EDITAR' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("EDITAR")]
        public short? Editar { get; set; }

        /// <summary>
        /// Representa la columna 'CONSULTAR' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("CONSULTAR")]
        public short? Consultar { get; set; }

        /// <summary>
        /// Representa la columna 'IMPRIMIR' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("IMPRIMIR")]
        public short? Imprimir { get; set; }

        /// <summary>
        /// Representa la columna 'DIGITALIZAR' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("DIGITALIZAR")]
        public short? Digitalizar { get; set; }

        /// <summary>
        /// Representa la columna 'PROCESO' de la tabla 'PROCESO_ROL'
        /// </summary>
        [NombreDeColumna("PROCESO")]
        public ProcesoOtd Proceso { get; set; }
    }
}
