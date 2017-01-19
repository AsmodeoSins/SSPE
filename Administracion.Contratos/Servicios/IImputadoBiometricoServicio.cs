using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IImputadoBiometricoServicio
    {
        /// <summary>
        /// Obtiene un listado de ImputadosBiometricos
        /// </summary>
        /// <returns></returns>
        IList<ImputadoBiometricoOtd> ObtenerImputadosBiometricos(bool desactivarLazyLoading = false);

        /// <summary>
        /// Modifica un Imputado dado un ImputadoBiometricoOtd
        /// </summary>
        /// <param name="Imputado">Imputado a modificar</param>
        void ModificarImputadoBiometrico(ImputadoBiometricoOtd imputadoBiometrico);

        /// <summary>
        /// Obtiene un listado de ImputadoBiometricoOtd dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<ImputadoBiometricoOtd> EncontrarPor(Expression<Func<ImputadoBiometricoOtd, bool>> expression, bool desactivarLazyLoading = false);
    }
}
