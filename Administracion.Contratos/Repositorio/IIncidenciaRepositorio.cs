using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'INGRESO'
    /// </summary>
    public interface IIncidenciaRepositorio : IBaseRepositorio<Modelos.Entidades.PL_INCIDENCIA_CATALOGO>, IDisposable
    {
    }
}
