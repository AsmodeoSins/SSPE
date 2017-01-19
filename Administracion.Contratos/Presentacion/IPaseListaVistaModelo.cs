using Administracion.OTD;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para la vista Otd del control de pase de lista
    /// </summary>
    public interface IPaseListaVistaModelo
    {
        #region Metodos
        /// <summary>
        /// Inserta un nuevo pase de lista
        /// </summary>
        void InsertarPaseDeLista();
        
        /// <summary>
        /// Elimina un pase de lista
        /// </summary>
        void EliminarPaseDeLista();

        /// <summary>
        /// Edita un pase de lista seleccionado
        /// </summary>
        void EditarPaseDeLista();
        #endregion
    }
}
