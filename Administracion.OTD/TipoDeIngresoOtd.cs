using Administracion.OTD.AtributosPersonalizados;

namespace Administracion.OTD
{
    public class TipoDeIngresoOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_INGRESO' de la tabla 'TIPO_INGRESO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_INGRESO")]
        public short IdTipoIngreso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'TIPO_INGRESO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }
    }
}
