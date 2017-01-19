using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'INGRESO'
    /// </summary>
    public interface IIngresoServicio
    {
        /// <summary>
        /// Crea un nuevo Ingreso dado un IngresoOtd
        /// </summary>
        /// <param name="Ingreso">Ingreso a insertar</param>
        /// <returns></returns>
        IngresoOtd CrearIngreso(IngresoOtd Ingreso);

        /// <summary>
        /// Obtiene un listado de Ingresos
        /// </summary>
        /// <returns></returns>
        IList<IngresoOtd> ObtenerIngresos();

        /// <summary>
        /// Modifica un Ingreso dado un IngresoOtd
        /// </summary>
        /// <param name="Ingreso">Ingreso a modificar</param>
        void ModificarIngreso(IngresoOtd Ingreso);

        /// <summary>
        /// Obtiene un listado de IngresoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<IngresoOtd> EncontrarPor(Expression<Func<IngresoOtd, bool>> expression);
    }
}
