using System;

namespace Administracion.OTD.AtributosPersonalizados
{
    public class NombreDeColumna : Attribute
    {
        #region Propiedades
        /// <summary>
        /// Representa el nombre de la columna de la cual se mapeara la propiedad
        /// </summary>
        public string Nombre { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para mapear columnas a las propiedades correspondientes
        /// </summary>
        /// <param name="nombreDeColumna"></param>
        public NombreDeColumna(string nombreDeColumna)
        {
            this.Nombre = nombreDeColumna;
        }
        #endregion
    }
}
