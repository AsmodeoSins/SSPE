using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Modelos
{
    public class PaseListaModelo
    {
        public float Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime Hora { get; set; }

        public string Estatus { get; set; }

        public string ModificadoPor { get; set; }

        public DateTime FechaModificacion { get; set; }
    }
}
