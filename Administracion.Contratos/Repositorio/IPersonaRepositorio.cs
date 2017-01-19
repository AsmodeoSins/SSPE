using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'PERSONA'
    /// </summary>
    public interface IPersonaRepositorio : IBaseRepositorio<Modelos.Entidades.PERSONA>, IDisposable
    {
    }
}