using Administracion.OTD;
using System.Collections.ObjectModel;

namespace Administracion.Contratos
{
    public interface IBusquedaPersonaVistaModelo
    {
        ObservableCollection<PersonaOtd> Personas { get; set; }

        void BuscarPersonaPorFiltro(PersonaFiltroOtd filtro);
    }
}