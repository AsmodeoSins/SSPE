using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'Centro'
    /// </summary>
    public interface ICentroServicio
    {
        /// <summary>
        /// Crea un nuevo Centro dado un CentroOtd
        /// </summary>
        /// <param name="Centro">Centro a insertar</param>
        /// <returns></returns>
        CentroOtd CrearCentro(CentroOtd centro);

        /// <summary>
        /// Obtiene un listado de Centros
        /// </summary>
        /// <returns></returns>
        IList<CentroOtd> ObtenerCentros();

        /// <summary>
        /// Modifica un Centro dado un CentroOtd
        /// </summary>
        /// <param name="Centro">Centro a modificar</param>
        void ModificarCentro(CentroOtd centro);

        /// <summary>
        /// Obtiene un listado de CentroModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<CentroOtd> EncontrarPor(Expression<Func<CentroOtd, bool>> expression);
    }
}
