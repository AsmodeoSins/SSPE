using Administracion.Modelos;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    public class ExpedienteValidador : AbstractValidator<ExpedienteModelo>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public ExpedienteValidador()
        {
            RuleFor(e => e.EstadoId).GreaterThan(0).WithMessage("El campo 'EstadoId' es requerido", e => e.EstadoId);
            RuleFor(e => e.MunicipioId).GreaterThan(0).WithMessage("El campo 'MunicipioId' es requerido", e => e.MunicipioId);
            RuleFor(e => e.Cereso).NotEmpty().NotNull().Length(5).WithMessage("El campo 'Cereso' es requerido con una logitud maxima de 5 caracteres", e => e.Cereso);
            RuleFor(e => e.Ano).GreaterThan(0).WithMessage("El campo 'Año' es requerido", e => e.Ano);
            RuleFor(e => e.Folio).GreaterThan(0).WithMessage("El campo 'Folio' es requerido", e => e.Folio);
            RuleFor(e => e.Biometrico).NotEmpty().NotNull().Length(1).WithMessage("El campo 'Biometrico' es requerido con una logitud maxima de 1 caracter", e => e.Biometrico);
        }
        #endregion

        public override ValidationResult Validate(ExpedienteModelo instance)
        {
            return instance == null
                ? new ValidationResult(new[] { new ValidationFailure("Customer", "Customer cannot be null") })
                : base.Validate(instance);
        }
    }
}
