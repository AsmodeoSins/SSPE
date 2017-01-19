using System;

namespace Administracion.OTD.AtributosPersonalizados
{
    /// <summary>
    /// Atributo personalizado para las propiedades de navegacion
    /// </summary>
    public class Navegacion : Attribute
    {
        #region Propiedades
        /// <summary>
        /// Representa el tipo de la propiedad de navegacion
        /// </summary>
        public Type Tipo { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para mapear propiedades de navegacion
        /// </summary>
        /// <param name="nombreDeColumna"></param>
        public Navegacion(Type tipo)
        {
            Tipo = tipo;
        }
        #endregion
    }
}
