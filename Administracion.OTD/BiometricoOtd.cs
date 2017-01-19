using Administracion.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.OTD
{
    public class BiometricoOtd
    {
        public TipoBiometrico Tipo { get; set; }

        public FormatoBiometrico Formato { get; set; }

        public byte[] Biometrico { get; set; }

        public short? Calidad { get; set; }

        public short IdCentro { get; set; }

        public short Anio { get; set; }
    }
}
