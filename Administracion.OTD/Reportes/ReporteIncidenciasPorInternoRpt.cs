using System;
using System.Collections.Generic;
using System.Linq;
using Administracion.Enum;

namespace Administracion.OTD.Reportes
{
    [Serializable]
    public class ReporteIncidenciasPorInternoRpt
    {
        #region Propiedades
        /// <summary>
        /// Encabezado del reporte
        /// </summary>
        public EncabezadoBaseRpt Encabezado { get; set; }

        /// <summary>
        /// Datos a mostrar
        /// </summary>
        public IList<RenglonBaseRpt> Datos { get; set; }

        public ImputadoOtd Imputado { get; set; }

        public IList<IngresoOtd> Ingresos { get; set; }

        public IngresoOtd UltimoIngreso { get; set; }

        /// <summary>
        /// Numero de expediente del interno
        /// </summary>
        public string Expediente { get; set; }

        /// <summary>
        /// Nombre del interno
        /// </summary>
        public string NombreDeInterno 
        {
            get
            {
                return string.Format("{0} {1} {2}", Imputado.Paterno.Trim(), Imputado.Materno.Trim(), Imputado.Nombre.Trim());
            }
        }

        /// <summary>
        /// Ubicacion del interno
        /// </summary>
        public string UbicacionActual 
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Numero de ingresos
        /// </summary>
        public int NumeroDeIngresos 
        {
            get
            {
                return Ingresos.Count;
            }
        }

        /// <summary>
        /// Fotografia del imputado
        /// </summary>
        public byte[] ImagenImputado
        {
            get
            {
                return Imputado.ImputadoBiometrico.SingleOrDefault(ib => ib.IdTipoBiometrico == (short)TipoBiometrico.FotoFrenteRegistro).Biometrico;
            }
        }

        /// <summary>
        /// Estatus del interno
        /// </summary>
        public string Activo { get; set; }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ReporteIncidenciasPorInternoRpt()
        {
            Datos = new List<RenglonBaseRpt>();
        }
        #endregion
    }    
}
