using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    /// <summary>
    /// Validador para el modelo IngresoOtd
    /// </summary>
    public class IngresoValidador : AbstractValidator<IngresoOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public IngresoValidador()
        {
            //RuleFor(i => i.IdImputado).GreaterThan(0).WithMessage("IdImputado es requerido", i => i.IdImputado);
            //RuleFor(i => i.IdCentro).GreaterThan(0).WithMessage("IdCentro es requerido", i => i.IdCentro);
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="ingreso">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(IngresoOtd ingreso)
        {
            return ingreso == null
                ? new ValidationResult(new[] { new ValidationFailure("Ingreso", "El ingreso no puede ser nulo") })
                : base.Validate(ingreso);
        }
        #endregion
    }
}
