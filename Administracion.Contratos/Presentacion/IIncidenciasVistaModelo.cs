using Administracion.OTD;
using System.Collections.ObjectModel;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para la vista Otd del control de incidencias
    /// </summary>
    public interface IIncidenciasVistaModelo
    {
        #region Metodos
        /// <summary>
        /// Crea una nueva incidencia
        /// </summary>
        void InsertarIncidencia();

        /// <summary>
        /// Pone una incidencia en estatus inactivo o eliminado
        /// </summary>
        void EliminarIncidencia();

        /// <summary>
        /// Modifica la incidencia seleccionada
        /// </summary>
        void ModificarIncidencia();
        #endregion
    }
}
