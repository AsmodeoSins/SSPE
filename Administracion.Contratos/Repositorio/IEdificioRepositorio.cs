using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'Edificio'
    /// </summary>
    public interface IEdificioRepositorio : IBaseRepositorio<Modelos.Entidades.EDIFICIO>, IDisposable
    {
    }
}
