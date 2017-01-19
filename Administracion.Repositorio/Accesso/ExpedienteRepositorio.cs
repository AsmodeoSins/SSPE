using Administracion.Contratos;
using Administracion.Modelos;

namespace Administracion.Repositorio.Accesso
{
    /// <summary>
    /// Repositorio para la tabla 'expediente'
    /// </summary>
    public class ExpedienteRepositorio : BaseRepositorio<ExpedienteModelo, Modelos.Entidades.IMPUTADO>, IExpedienteRepositorio
    {
    }
}
