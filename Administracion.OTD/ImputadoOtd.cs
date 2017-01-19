using Administracion.OTD.AtributosPersonalizados;
using System;
using System.Collections.Generic;

namespace Administracion.OTD
{
    /// <summary>
    /// Representa el modelo para la tabla 'IMPUTADO'
    /// </summary>
    public class ImputadoOtd
    {
        #region Propiedades
        /// <summary>
        /// Propiedad para la columna 'ID_CENTRO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_CENTRO")]
        public short IdCentro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ANIO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_ANIO")]
        public short IdAnio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IMPUTADO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_IMPUTADO")]
        public int IdImputado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PATERNO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("PATERNO")]
        public string Paterno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'MATERNO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("MATERNO")]
        public string Materno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NOMBRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NOMBRE")]
        public string Nombre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SEXO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("SEXO")]
        public string Sexo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ESTADO_CIVIL' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_ESTADO_CIVIL")]
        public short? IdEstadoCivil { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_OCUPACION' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_OCUPACION")]
        public short? IdOcupacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ESCOLARIDAD' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_ESCOLARIDAD")]
        public short? IdEscolaridad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_RELIGION' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_RELIGION")]
        public short? IdReligion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ETNIA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_ETNIA")]
        public short? IdEtnia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_NACIONALIDAD' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_NACIONALIDAD")]
        public short? IdNacionalidad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOMICILIO_CALLE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("DOMICILIO_CALLE")]
        public string DomicilioCalle { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOMICILIO_NUM_EXT' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("DOMICILIO_NUM_EXT")]
        public int? DomicilioNumeroExterior { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOMICILIO_NUM_INT' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("DOMICILIO_NUM_INT")]
        public string DomicilioNumeroInterior { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_COLONIA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_COLONIA")]
        public int? IdColonia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_MUNICIPIO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_MUNICIPIO")]
        public short? IdMunicipio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_ENTIDAD' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_ENTIDAD")]
        public short? IdEntidad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_PAIS' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_PAIS")]
        public short? IdPais { get; set; }

        /// <summary>
        /// Propiedad para la columna 'DOMICILIO_CODIGO_POSTAL' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("DOMICILIO_CODIGO_POSTAL")]
        public int DomicilioCodigoPostal { get; set; }

        /// <summary>
        /// Propiedad para la columna 'RESIDENCIA_ANIOS' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("RESIDENCIA_ANIOS")]
        public short? ResidenciaAnios { get; set; }

        /// <summary>
        /// Propiedad para la columna 'RESIDENCIA_MESES' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("RESIDENCIA_MESES")]
        public short? ResidenciaMeses { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TELEFONO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("TELEFONO")]
        public long? Telefono { get; set; }
        
        /// <summary>
        /// Propiedad para la columna 'DOMICILIO_TRABAJO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("DOMICILIO_TRABAJO")]
        public string DomicilioTrabajo { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NACIMIENTO_PAIS' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NACIMIENTO_PAIS")]
        public short? NacimientoPais { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NACIMIENTO_ESTADO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NACIMIENTO_ESTADO")]
        public short NacimientoEstado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NACIMIENTO_MUNICIPIO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NACIMIENTO_MUNICIPIO")]
        public short? NacimientoMunicipio { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NACIMIENTO_FECHA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NACIMIENTO_FECHA")]
        public DateTime? NacimientoFecha { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NACIMIENTO_LUGAR' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NACIMIENTO_LUGAR")]
        public string NacimientoLugar { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PATERNO_MADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("PATERNO_MADRE")]
        public string PaternoMadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'MATERNO_MADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("MATERNO_MADRE")]
        public string MaternoMadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NOMBRE_MADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NOMBRE_MADRE")]
        public string NombreMadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'MADRE_FINADO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("MADRE_FINADO")]
        public string MadreFinado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PATERNO_PADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("PATERNO_PADRE")]
        public string PaternoPadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'MATERNO_PADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("MATERNO_PADRE")]
        public string MaternoPadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NOMBRE_PADRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NOMBRE_PADRE")]
        public string NombrePadre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PADRE_FINADO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("PADRE_FINADO")]
        public string PadreFinado { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TABAJADOR_CERESO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("TABAJADOR_CERESO")]
        public string TrabajadorCereso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'RFC' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("RFC")]
        public string RFC { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CURP' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("CURP")]
        public string CURP { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IFE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("IFE")]
        public string IFE { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NIP' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NIP")]
        public string NIP { get; set; }

        /// <summary>
        /// Propiedad para la columna 'LUGAR_RESIDENCIA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("LUGAR_RESIDENCIA")]
        public string LugarResidencia { get; set; }

        /// <summary>
        /// Propiedad para la columna 'NUMERO_IDENTIFICACION' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("NUMERO_IDENTIFICACION")]
        public string NumeroIdentificacion { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_TIPO_DISCAPACIDAD' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_TIPO_DISCAPACIDAD")]
        public Nullable<short> IdTipoDiscapacidad { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ESTATURA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ESTATURA")]
        public short Estatura { get; set; }

        /// <summary>
        /// Propiedad para la columna 'PESO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("PESO")]
        public short? Peso { get; set; }

        /// <summary>
        /// Propiedad para la columna 'BI_FECALTA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("BI_FECALTA")]
        public DateTime? BIFechaAlta { get; set; }

        /// <summary>
        /// Propiedad para la columna 'BI_USER' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("BI_USER")]
        public string BIUser { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TELORIGINAL' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("TELORIGINAL")]
        public string TELOriginal { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SPATERNO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("SPATERNO")]
        public string SPaterno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SMATERNO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("SMATERNO")]
        public string SMaterno { get; set; }

        /// <summary>
        /// Propiedad para la columna 'SNOMBRE' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("SNOMBRE")]
        public string SNombre { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_IDIOMA' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_IDIOMA")]
        public short? IdIdioma { get; set; }

        /// <summary>
        /// Propiedad para la columna 'ID_DIALECTO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("ID_DIALECTO")]
        public short? IdDialecto { get; set; }

        /// <summary>
        /// Propiedad para la columna 'TRADUCTOR' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("TRADUCTOR")]
        public string Traductor { get; set; }

        /// <summary>
        /// Propiedad para la columna 'CENTRO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("CENTRO")]
        public CentroOtd Centro { get; set; }

        /// <summary>
        /// Propiedad para la columna 'IMPUTADO_BIOMETRICO' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("IMPUTADO_BIOMETRICO")]
        public ICollection<ImputadoBiometricoOtd> ImputadoBiometrico { get; set; }

        /// <summary>
        /// Propiedad para la columna 'INGRESOes' de la tabla 'IMPUTADO'
        /// </summary>
        [NombreDeColumna("INGRESOes")]
        public ICollection<IngresoOtd> Ingresos { get; set; }

        #endregion

        #region Propiedades personalizadas
        public string Folio 
        {
            get
            {
                return string.Format("{0}/{1}", IdAnio, IdImputado);
            }
         }
        #endregion
    }
}
