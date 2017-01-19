using Administracion.OTD;

namespace Administracion.Contratos
{
    /// <summary>
    /// Contrato para la pantalla de tiempo de pase de lista
    /// </summary>
    public interface ITiempoPaseDeListaVistaModelo
    {
        #region Propiedades
        /// <summary>
        /// Representa el valor de hora especificado para el centro actual
        /// </summary>
        ParametroOtd HoraCentro { get; set; }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta/Edita un registro en la tabla 'PARAMETRO'
        /// </summary>
        void Guardar();
        #endregion
    }
}
