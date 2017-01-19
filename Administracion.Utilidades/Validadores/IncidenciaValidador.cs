using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;

namespace Administracion.Utilidades.Validadores
{
    public class IncidenciaValidador : AbstractValidator<PLIncidenciaCatalogoOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public IncidenciaValidador()
        {
            RuleFor(i => i.Descripcion).NotEmpty().WithMessage("La Descripcion es requerida", i => i.Descripcion);
            RuleFor(i => i.Visible).GreaterThan((short)0).WithMessage("Visible es requerido, con longitud maxima de 1", i => i.Visible);
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="ingreso">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(PLIncidenciaCatalogoOtd incidencia)
        {
            return incidencia == null
                ? new ValidationResult(new[] { new ValidationFailure("Ingreso", "La incidencia no puede ser nula") })
                : base.Validate(incidencia);
        }
        #endregion
    }
}
