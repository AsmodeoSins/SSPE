using Administracion.Modelos;
using System;

namespace Administracion.Contratos.Repositorio
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'PASELISTA_CATALOGO'
    /// </summary>
    public interface IPLCatalogoRepositorio : IBaseRepositorio<Modelos.Entidades.PL_CATALOGO>, IDisposable
    {
    }
}
