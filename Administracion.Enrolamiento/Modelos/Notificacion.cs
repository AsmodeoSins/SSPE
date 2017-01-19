using Administracion.OTD;
using Fulcrum.FbF.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Enrolamiento
{
    public class Notificacion
    {
        public string Mensaje { get; set; }

        public TipoNotificacion Tipo { get; set; }

        public int TotalCompletado { get; set; }

        public PersonaOtd Persona { get; set; }

        public List<FbFBioResult> BioResults { get; set; }

        public string Folio { get; set; }
    }

    public enum TipoNotificacion
    {
        Validando = 1,
        Conectando = 2,
        Buscando = 3,
        Enrolando = 4,
        Compleado = 5,
        Error = 6,
    }
}
