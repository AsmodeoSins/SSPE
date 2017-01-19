using Administracion.OTD.AtributosPersonalizados;
using System.Collections.Generic;

namespace Administracion.OTD
{
    public class CentroOtd
    {
        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_CENTRO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_CENTRO")]
        public short? IdTipoCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ENTIDAD' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ID_ENTIDAD")]
        public short? IdEntidad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_MUNICIPIO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ID_MUNICIPIO")]
        public short? IdMunicipio { get; set; }
        
        /// <summary>
        /// Propiedad para la columna 'DESCR' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("DESCR")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CALLE' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("CALLE")]
        public string Calle { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NUM_EXT' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("NUM_EXT")]
        public int? NumeroExterior { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NUM_INT' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("NUM_INT")]
        public string NumeroInterior { get; set; }

        /// <summary>
        /// Propiedad para la columna 'COLONIA' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("COLONIA")]
        public string Colonia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CP' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("CP")]
        public int? CP { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TELEFONO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("TELEFONO")]
        public long? Telefono { get; set; }

        /// <summary>
        /// Propiedad para la columna 'FAX' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("FAX")]
        public long Fax { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DIRECTOR' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("DIRECTOR")]
        public string Director { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_EMISOR' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ID_EMISOR")]
        public int? IdEmisor { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CONS_ANUAL' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("CONS_ANUAL")]
        public int? ConsAnual { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATUS' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("ESTATUS")]
        public string Estatus { get; set; }


        /// <summary>
        /// Propiedad para la columna 'TIPO_CENTRO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("TIPO_CENTRO")]
        public TipoDeCentroOtd TipoDeCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EDIFICIOs' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("EDIFICIOs")]
        public ICollection<EdificioOtd> Edificios { get; set; }

        /// <summary>
        /// Propiedad para la columna 'EMPLEADOes' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("EMPLEADOes")]
        public ICollection<EmpleadoOtd> Empleados { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADOes' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("IMPUTADOes")]
        public virtual ICollection<ImputadoOtd> Imputados { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INGRESOes' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("INGRESOes")]
        public virtual ICollection<IngresoOtd> Ingresos { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PL_PROGRAMADO' de la tabla 'CENTRO'
        /// </summary>
        [NombreDeColumna("PL_PROGRAMADO")]
        public virtual ICollection<PLProgramadoOtd> PLProgramados { get; set; }
    }
}
