using Administracion.Modelos;
using System;

namespace Administracion.Contratos
{
    public interface IPaseListaRepositorio : IBaseRepositorio<Modelos.Entidades.PL_PROGRAMADO>, IDisposable
    {
    }
}