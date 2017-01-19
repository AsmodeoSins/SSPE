using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Administracion.OTD
{
    public class PersonaOtd
    {
        public int Id { get; set; }

        public string Folio { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string NombreCentro { get; set; }

        public short IdCentro { get; set; }

        public short IdAnio { get; set; }

        public DateTime FechaIngreso { get; set; }

        public ImageSource Foto { get; set; }

        public CeldaOtd Ubicacion { get; set; }

        public IList<BiometricoOtd> Biometricos { get; set; }

        public bool EsImputado { get; set; }

        public bool FueIdentificado { get; set; }

        public short IdIngreso { get; set; }

        public bool BiometriaRegistrada { get; set; }
    }
}
