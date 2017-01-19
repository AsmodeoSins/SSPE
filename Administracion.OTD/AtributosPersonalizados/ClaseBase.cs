using System;

namespace Administracion.OTD.AtributosPersonalizados
{
    /// <summary>
    /// Atributo para especificar la clase de la cual se mapearan los datos
    /// </summary>
    public class ClaseBase : Attribute
    {
        #region Propiedades
        /// <summary>
        /// Representa el tipo de clase del que se mapearan los datos
        /// </summary>
        public Type ClaseOrigen { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para el mapeo de modelos dado un tipo de clase de origen
        /// </summary>
        /// <param name="tipo"></param>
        public ClaseBase(Type tipo)
        {
            ClaseOrigen = tipo;
        }
        #endregion
    }
}
