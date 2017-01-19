using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface ISectorServicio
    {
        /// <summary>
        /// Obtiene un listado de sectores Disponibles
        /// </summary>
        /// <returns></returns>
        IList<SectorOtd> ObtenerPasesDelistaProgramados();

        /// <summary>
        /// Obtiene un listado de sectores dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<SectorOtd> EncontrarPor(Expression<Func<SectorOtd, bool>> expression);
    }
}
