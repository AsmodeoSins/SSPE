using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'INGRESO'
    /// </summary>
    public interface IIngresoRepositorio : IBaseRepositorio<Modelos.Entidades.INGRESO>, IDisposable
    {
    }
}
