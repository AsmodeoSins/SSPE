using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'IMPUTADO'
    /// </summary>
    public interface IImputadoServicio
    {
        /// <summary>
        /// Crea un nuevo Imputado dado un ImputadoOtd
        /// </summary>
        /// <param name="Imputado">Imputado a insertar</param>
        /// <returns></returns>
        ImputadoOtd CrearImputado(ImputadoOtd Imputado);

        /// <summary>
        /// Obtiene un listado de Imputados
        /// </summary>
        /// <returns></returns>
        IList<ImputadoOtd> ObtenerImputados(bool desactivarLazyLoading = false);

        /// <summary>
        /// Modifica un Imputado dado un ImputadoOtd
        /// </summary>
        /// <param name="Imputado">Imputado a modificar</param>
        void ModificarImputado(ImputadoOtd Imputado);

        /// <summary>
        /// Obtiene un listado de ImputadoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<ImputadoOtd> EncontrarPor(Expression<Func<ImputadoOtd, bool>> expression, bool desactivarLazyLoading = false);
    }
}
