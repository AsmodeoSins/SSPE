using System.Collections.Generic;
namespace Administracion.OTD.Reportes
{
    public class IncidenciaGeneralRpt
    {
        public EncabezadoBaseRpt Encabezado { get; set; }

        public IList<SeccionBaseRpt> Secciones { get; set; }
    }
}