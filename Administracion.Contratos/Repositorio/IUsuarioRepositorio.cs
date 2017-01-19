using System;

namespace Administracion.Contratos.Repositorio
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'USUARIO'
    /// </summary>
    public interface IUsuarioRepositorio : IBaseRepositorio<Modelos.Entidades.USUARIO>, IDisposable
    {
    }
}
