using Administracion.Modelos.Entidades;
using System;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para el repositorio de la tabla 'PERSONA_BIOMETRICO'
    /// </summary>
    public interface IPersonaBiometricoRepositorio : IBaseRepositorio<PERSONA_BIOMETRICO>, IDisposable
    {
    }
}