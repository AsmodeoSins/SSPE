using Administracion.OTD;
using FluentValidation;

namespace Administracion.Utilidades.Validadores
{
    public class PaseListaValidador : AbstractValidator<PaseListaOtd>
    {
        public PaseListaValidador()
        {
            //RuleFor(p => p.Descripcion).NotEmpty().NotNull().WithMessage("La descripción es requerida");
        }
    }
}