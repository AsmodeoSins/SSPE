using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    /// <summary>
    /// Validador para el modelo ImputadoModelo
    /// </summary>
    public class ImputadoValidador : AbstractValidator<ImputadoOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ImputadoValidador()
        {
            //RuleFor(i => i.IdCentro).GreaterThan(0).WithMessage("IdCentro es requerido", i => i.IdCentro);
            //RuleFor(i => i.Paterno).NotNull().NotEmpty().WithMessage("Paterno es requerido", i => i.Paterno);
            //RuleFor(i => i.Nombre).NotNull().NotEmpty().WithMessage("Nombre es requerido", i => i.Nombre);
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="imputado">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(ImputadoOtd imputado)
        {
            return imputado == null
                ? new ValidationResult(new[] { new ValidationFailure("imputado", "El imputado no puede ser nulo") })
                : base.Validate(imputado);
        }
        #endregion
    }
}
