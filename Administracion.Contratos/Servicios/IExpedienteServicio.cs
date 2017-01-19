using Administracion.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el servicio de la tabla 'expediente'
    /// </summary>
    public interface IExpedienteServicio
    {
        /// <summary>
        /// Crea un nuevo expediente dado un ExpedienteModelo
        /// </summary>
        /// <param name="expediente">Expediente a insertar</param>
        /// <returns></returns>
        ExpedienteModelo CrearExpediente(ExpedienteModelo expediente);

        /// <summary>
        /// Obtiene un listado de expedientes
        /// </summary>
        /// <returns></returns>
        IList<ExpedienteModelo> ObtenerExpedientes();

        /// <summary>
        /// Modifica un expediente dado un ExpedienteModelo
        /// </summary>
        /// <param name="expediente">Expediente a modificar</param>
        void ModificarExpediente(ExpedienteModelo expediente);

        /// <summary>
        /// Obtiene un listado de ExpedienteModel dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<ExpedienteModelo> EncontrarPor(Expression<Func<ExpedienteModelo, bool>> expression);
    }
}
