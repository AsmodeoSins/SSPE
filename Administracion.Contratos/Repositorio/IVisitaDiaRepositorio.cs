using System;

namespace Administracion.Contratos.Repositorio
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'TIPO_VISITA'
    /// </summary>
    public interface IVisitaDiaRepositorio : IBaseRepositorio<Modelos.Entidades.VISITA_DIA>, IDisposable
    {
    }
}
