using Administracion.OTD;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Administracion.Utilidades.Validadores
{
    /// <summary>
    /// Validador para el modelo IngresoModelo
    /// </summary>
    public class PaseDeListaCatalogoValidador : AbstractValidator<PLCatalogoOtd>
    {
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public PaseDeListaCatalogoValidador()
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("El Nombre es requerido", p => p.Nombre);
            RuleFor(p => p.Estatus).NotEmpty().WithMessage("El Estatus es requerido", p => p.Estatus);
        }
        #endregion

        #region Metodos sobreescritos
        /// <summary>
        /// Metodo override para la validacion del modelo
        /// </summary>
        /// <param name="ingreso">Modelo a validar</param>
        /// <returns></returns>
        public override ValidationResult Validate(PLCatalogoOtd paseDeListaCatalogo)
        {
            return paseDeListaCatalogo == null
                ? new ValidationResult(new[] { new ValidationFailure("paseDeListaCatalogo", "El ingreso no puede ser nulo") })
                : base.Validate(paseDeListaCatalogo);
        }
        #endregion
    }
}
