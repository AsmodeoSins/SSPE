using Administracion.OTD.AtributosPersonalizados;
using System;

namespace Administracion.OTD
{

    public class PLIncidenciaBitacoraOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_PL_INCIDENCIA_BIT' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_PL_INCIDENCIA_BIT")]
        public int IdPLIncidenciaBit { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_PL_PROGRAMADO_BIT' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_PL_PROGRAMADO_BIT")]
        public Nullable<int> IdPLProgramadoBit { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_INCIDENCIA' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_INCIDENCIA")]
        public short IdIncidencia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECHA_CREACION' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("FECHA_CREACION")]
        public DateTime? FechaCreacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_CREACION' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("HORA_CREACION")]
        public DateTime? HoraCreacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FECHA_SOLUCION' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("FECHA_SOLUCION")]
        public DateTime? FechaSolucion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'HORA_SOLUCION' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("HORA_SOLUCION")]
        public DateTime HoraSolucion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'OBSERVACIONES' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("OBSERVACIONES")]
        public string Observaciones { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATUS' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public string Estatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ANIO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_ANIO")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO")]
        public int IdImputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EDIFICIO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_EDIFICIO")]
        public Nullable<short> IdEdificio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_SECTOR' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_SECTOR")]
        public Nullable<short> IdSector { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_CELDA' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("ID_CELDA")]
        public string IdCelda { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("IMPUTADO")]
        public ImputadoOtd Imputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_INCIDENCIA_ESTATUS' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("PL_INCIDENCIA_ESTATUS")]
        public PLIncidenciaEstatus IncidenciaEstatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_INCIDENCIA_CATALOGO' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("PL_INCIDENCIA_CATALOGO")]
        public PLIncidenciaCatalogoOtd Incidencia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO_BITACORA' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO_BITACORA")]
        public PLProgramadoBitacoraOtd PLProgramadoBitacora { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CELDA' de la tabla 'PL_INCIDENCIA_BITACORA
        /// </summary>
        [NombreDeColumna("CELDA")]
        public virtual CeldaOtd Celda { get; set; }
    }
}
