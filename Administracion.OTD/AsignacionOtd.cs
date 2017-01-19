using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class AsignacionOtd
    {
        public int PaseListaProgramadoId { get; set; }

        public CatalogoBaseOdt Edificio { get; set; }

        public CatalogoBaseOdt Sector { get; set; }

        public PersonaOtd Custodio { get; set; }

        public int Nivel { get; set; }

    }
}
