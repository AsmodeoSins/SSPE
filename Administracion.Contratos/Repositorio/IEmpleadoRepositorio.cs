using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'EMPLEADO'
    /// </summary>
    public interface IEmpleadoRepositorio : IBaseRepositorio<Modelos.Entidades.EMPLEADO>, IDisposable
    {
    }
}