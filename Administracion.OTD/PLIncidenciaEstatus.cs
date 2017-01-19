using Administracion.OTD.AtributosPersonalizados;

namespace Administracion.OTD
{
    public class PLIncidenciaEstatus
    {
        /// <summary>
        /// Propiedad para la columna 'ID_INCIDENCIA_ESTATUS' de la tabla 'PL_INCIDENCIA_ESTATUS'
        /// </summary>
        [NombreDeColumna("ID_INCIDENCIA_ESTATUS")]
        public string IdIncidenciaEstatus { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'PL_INCIDENCIA_ESTATUS'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }
    }
}
