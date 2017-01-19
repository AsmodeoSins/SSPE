using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'expediente'
    /// </summary>
    public interface IExpedienteRepositorio : IBaseRepositorio<ExpedienteModelo>, IDisposable
    {
    }
}
