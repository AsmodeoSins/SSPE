using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IParametroServicio
    {
        /// <summary>
        /// Crea un nuevo Centro dado un ParametroOtd
        /// </summary>
        /// <param name="parametro">Centro a insertar</param>
        /// <returns></returns>
        ParametroOtd CrearParametro(ParametroOtd parametro);

        /// <summary>
        /// Obtiene un listado de Parametro
        /// </summary>
        /// <returns></returns>
        IList<ParametroOtd> ObtenerParametro();

        /// <summary>
        /// Modifica un parametro dado un ParametroOtd
        /// </summary>
        /// <param name="parametro">Centro a modificar</param>
        void ModificarParametro(ParametroOtd parametro);

        /// <summary>
        /// Obtiene un listado de ParametroOtd dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<ParametroOtd> EncontrarPor(Expression<Func<ParametroOtd, bool>> expression);
    }
}
