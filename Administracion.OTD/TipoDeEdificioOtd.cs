using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class TipoDeEdificioOtd
    {
        /// <summary>
        /// Propiedad par ala columna 'ID_TIPO_EDIFICIO' de la tabla 'TIPO_EDIFICIO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_EDIFICIO")]
        public short IdTipoDeEdificio { get; set; }

        /// <summary>
        /// Propiedad par ala columna 'DESCR' de la tabla 'TIPO_EDIFICIO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad par ala columna 'EDIFICIOs' de la tabla 'TIPO_EDIFICIO'
        /// </summary>
        [NombreDeColumna("EDIFICIOs")]
        public virtual ICollection<EdificioOtd> Edificios { get; set; }
    }
}
