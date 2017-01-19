using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos
{
    public interface IPLIncidenciaBitacoraServicio
    {
        /// <summary>
        /// Obtiene un listado de bitacoras de incidencias Disponibles
        /// </summary>
        /// <returns></returns>
        IList<PLIncidenciaBitacoraOtd> ObtenerPLIncidenciasBitacoras();

        /// <summary>
        /// Obtiene un listado de bitacoras de incidencias dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<PLIncidenciaBitacoraOtd> EncontrarPor(Expression<Func<PLIncidenciaBitacoraOtd, bool>> expression);
    }
}
