using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IEmpleadoServicio
    {
        /// <summary>
        /// Obtiene un listado de empleados Disponibles
        /// </summary>
        /// <returns></returns>
        IList<EmpleadoOtd> ObtenerEmpleados();

        /// <summary>
        /// Obtiene un listado de empleados dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<EmpleadoOtd> EncontrarPor(Expression<Func<EmpleadoOtd, bool>> expression);
    }
}
