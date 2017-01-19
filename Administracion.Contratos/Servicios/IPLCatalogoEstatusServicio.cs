using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'PASELISTA_CATALOGO_ESTATUS'
    /// </summary>
    public interface IPLCatalogoEstatusServicio
    {
        /// <summary>
        /// Obtiene un listado de PaseDeListaCatalogoEstatuss
        /// </summary>
        /// <returns></returns>
        IList<PLCatalogoEstatusOtd> ObtenerPaseDeListaCatalogoEstatus();

        /// <summary>
        /// Obtiene un listado de PaseDeListaCatalogoEstatusModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<PLCatalogoEstatusOtd> EncontrarPor(Expression<Func<PLCatalogoEstatusOtd, bool>> expression);
    }
}
