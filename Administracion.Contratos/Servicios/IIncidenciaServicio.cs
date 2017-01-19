using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'Incidencia'
    /// </summary>
    public interface IIncidenciaServicio
    {
        /// <summary>
        /// Crea un nuevo Incidencia dado un IncidenciaOtd
        /// </summary>
        /// <param name="incidencia">Incidencia a insertar</param>
        /// <returns></returns>
        PLIncidenciaCatalogoOtd CrearIncidencia(PLIncidenciaCatalogoOtd incidencia);

        /// <summary>
        /// Obtiene un listado de Incidencias
        /// </summary>
        /// <returns></returns>
        IList<PLIncidenciaCatalogoOtd> ObtenerIncidencias();

        /// <summary>
        /// Modifica un Incidencia dado un IncidenciaOtd
        /// </summary>
        /// <param name="incidencia">Incidencia a modificar</param>
        void ModificarIncidencia(PLIncidenciaCatalogoOtd incidencia);

        /// <summary>
        /// Obtiene un listado de IncidenciaModel dada una expresion
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Lista de incidencias dada una expresion</returns>
        IList<PLIncidenciaCatalogoOtd> EncontrarPor(Expression<Func<PLIncidenciaCatalogoOtd, bool>> expression);
    }
}
