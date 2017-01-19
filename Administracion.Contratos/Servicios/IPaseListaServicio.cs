using Administracion.Modelos;
using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Contratos
{
    public interface IPaseListaServicio
    {
        IList<PaseListaModelo> ObtenerPasesDeLista();

        bool ModificarPaseLista(PaseListaModelo paseLista);

        PaseListaOtd InicializarPaseListaPorCentro(int centroId);

        IEnumerable<PaseListaOtd> InicializarPasesListaPorCentro(int centroId);

        void GuardarPasesDeLista(PaseListaOtd PaseLista);
    }
}
