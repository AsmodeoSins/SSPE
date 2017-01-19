using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IPLProgramadoAsignacionServicio
    {
        /// <summary>
        /// Crea una nueva asignacion dado un PLProgramadoAsignacionOtd
        /// </summary>
        /// <param name="paseDeListaProgramadoAsignacionAsignacion">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        PLProgramadoAsignacionOtd CrearPaseDelistaProgramadoAsignacion(PLProgramadoAsignacionOtd paseDeListaProgramadoAsignacion);

        /// <summary>
        /// Obtiene un listado de asignaciones Disponibles
        /// </summary>
        /// <returns></returns>
        IList<PLProgramadoAsignacionOtd> ObtenerPasesDelistaProgramadoAsignacion();

        /// <summary>
        /// Modifica una asignacion dado un PLProgramadoAsignacionOtd
        /// </summary>
        /// <param name="paseDeListaProgramadoAsignacionAsignacion">PaseDeListaCatalogo a modificar</param>
        void ModificarPaseDelistaProgramadoAsignacion(PLProgramadoAsignacionOtd paseDeListaProgramadoAsignacionAsignacion);

        /// <summary>
        /// Obtiene un listado de asignaciones dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<PLProgramadoAsignacionOtd> EncontrarPor(Expression<Func<PLProgramadoAsignacionOtd, bool>> expression);
    }
}
