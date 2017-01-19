using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    public class ParametroValidador : AbstractValidator<ParametroOtd>
    {
        public ParametroValidador()
        {
            RuleFor(m => m.IdCentro).GreaterThan((short)0).WithMessage("El Centro es requerido");
            RuleFor(m => m.IdClave).NotEmpty().WithMessage("La Clave es requerida");
            RuleFor(m => m.Valor).Matches(@"\d+").WithMessage("La Hora es requerida");
        }

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="ingreso">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(ParametroOtd parametro)
        {
            return parametro == null
                ? new ValidationResult(new[] { new ValidationFailure("paseDeListaCatalogo", "El ingreso no puede ser nulo") })
                : base.Validate(parametro);
        }
        #endregion
    }
}
