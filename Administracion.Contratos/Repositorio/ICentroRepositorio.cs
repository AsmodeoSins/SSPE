using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'expediente'
    /// </summary>
    public interface ICentroRepositorio : IBaseRepositorio<Modelos.Entidades.CENTRO>, IDisposable
    {
    }
}
