using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    /// <summary>
    /// Validador para el modelo ImputadoBiometricoOtd
    /// </summary>
    public class ImputadoBiometricoValidador : AbstractValidator<ImputadoBiometricoOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ImputadoBiometricoValidador()
        {
            //RuleFor(i => i.IdCentro).GreaterThan(0).WithMessage("IdCentro es requerido", i => i.IdCentro);
            //RuleFor(i => i.IdImputado).GreaterThan(0).WithMessage("IdImputado es requerido", i => i.IdImputado);
            //RuleFor(i => i.IdTipoBiometrico).GreaterThan(0).WithMessage("IdTipoBiometrico es requerido", i => i.IdTipoBiometrico);
            //RuleFor(i => i.IdFormato).GreaterThan(0).WithMessage("IdFormato es requerido", i => i.IdFormato);
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="imputadoBiometrico">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(ImputadoBiometricoOtd imputado)
        {
            return imputado == null
                ? new ValidationResult(new[] { new ValidationFailure("imputadoBiometrico", "El imputadoBiometrico no puede ser nulo") })
                : base.Validate(imputado);
        }
        #endregion
    }
}
