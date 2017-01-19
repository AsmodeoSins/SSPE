using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos.Servicios
{
    public interface IPLProgramadoServicio
    {
        /// <summary>
        /// Crea un nuevo Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a insertar</param>
        /// <returns></returns>
        PLProgramadoOtd CrearPaseDelistaProgramado(PLProgramadoOtd paseDeListaProgramado);

        /// <summary>
        /// Obtiene un listado de Catalogos Disponibles
        /// </summary>
        /// <returns></returns>
        IList<PLProgramadoOtd> ObtenerPasesDelistaProgramados();

        /// <summary>
        /// Modifica un Imputado dado un PaseDeListaCatalogoOtd
        /// </summary>
        /// <param name="paseDeListaCatalogo">PaseDeListaCatalogo a modificar</param>
        void ModificarPaseDelistaProgramado(PLProgramadoOtd paseDeListaProgramado);

        /// <summary>
        /// Obtiene un listado de ImputadoModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<PLProgramadoOtd> EncontrarPor(Expression<Func<PLProgramadoOtd, bool>> expression);

        /// <summary>
        /// Desactiva un pase de lista programado dado un id
        /// </summary>
        /// <param name="paseListaProgramadoId">Id del pase de lista programado a desactivar</param>
        void DesactivarPaseDeListaProgramado(int paseListaProgramadoId);
    }
}
