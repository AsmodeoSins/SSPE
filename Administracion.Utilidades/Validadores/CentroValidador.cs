using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    /// <summary>
    /// Validador para el modelo CentroOtd
    /// </summary>
    public class CentroValidador : AbstractValidator<CentroOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public CentroValidador()
        {
            
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="imputado">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(CentroOtd imputado)
        {
            return imputado == null
                ? new ValidationResult(new[] { new ValidationFailure("imputado", "El imputado no puede ser nulo") })
                : base.Validate(imputado);
        }
        #endregion
    }
}
