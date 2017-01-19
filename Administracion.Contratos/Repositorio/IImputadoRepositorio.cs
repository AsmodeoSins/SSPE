using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'Imputado'
    /// </summary>
    public interface IImputadoRepositorio : IBaseRepositorio<Modelos.Entidades.IMPUTADO>, IDisposable
    {
    }
}
