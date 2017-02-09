using Administracion.OTD;
using System.Collections.Generic;

namespace Administracion.Contratos
{
    public interface IPersonaServicio
    {
        IList<PersonaOtd> BuscarPersonaPorFiltro(PersonaFiltroOtd filtro);

        bool AsignarBiometria(PersonaOtd persona);

        bool RemoverBiometrias(PersonaOtd persona);

        IList<PersonaOtd> TraerCustodiosParaPaseLista();

        IList<PersonaOtd> BusquedaGlobal(PersonaFiltroOtd filtro);
    }
}