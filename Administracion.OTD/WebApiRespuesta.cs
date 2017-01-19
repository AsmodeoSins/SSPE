
namespace Administracion.OTD
{
    /// <summary>
    /// Respuesta generica del web api para llamados externos a la aplicacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WebApiRespuesta<T>
    {
        /// <summary>
        /// Propiedad generica en caso que se ocupen regresar datos
        /// </summary>
        public T Datos { get; set; }

        /// <summary>
        /// Indica si el request fue exitoso
        /// </summary>
        public bool LlamadoExistoso { get; set; }

        /// <summary>
        /// El mensaje despues del request
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// En caso de algun error se especifica para regresar en la respuesta
        /// </summary>
        public string Error { get; set; }
    }
}
