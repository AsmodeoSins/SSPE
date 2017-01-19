using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IPLCatalogoServicio
    {
        /// <summary>
        /// Crea un nuevo Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        PLCatalogoOtd CrearPaseDelistaCatalogo(PLCatalogoOtd paseDeListaCatalogo);

        /// <summary>
        /// Obtiene un listado de Catalogos Disponibles
        /// </summary>
        /// <returns></returns>
        IList<PLCatalogoOtd> ObtenerPasesDeListaCatalogo();

        /// <summary>
        /// Modifica un Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a modificar</param>
        void ModificarPaseDeListaCatalogo(PLCatalogoOtd paseDeListaCatalogo);

        /// <summary>
        /// Obtiene un listado de ImputadoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<PLCatalogoOtd> EncontrarPor(Expression<Func<PLCatalogoOtd, bool>> expression);
    }
}
