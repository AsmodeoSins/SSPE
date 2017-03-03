using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Administracion.Presentacion.Modelos
{
    public class HorarioVisita
    {
        public int CveTipoPersona { get; set; }
        public int CveDia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
    }
}
