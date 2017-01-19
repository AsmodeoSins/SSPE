using Administracion.Presentacion.Autorizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Administracion.Presentacion.Convertidores
{
    [MarkupExtensionReturnType(typeof(bool))]
    public class AutorizationEnableExtension : MarkupExtension
    {
        public string Operation { get; set; }

        public AutorizationEnableExtension()
        {
            Operation = String.Empty;
        }

        public AutorizationEnableExtension(string operation)
        {
            Operation = operation;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Operation))
                return false;

            return AutorizacionProvider.Instancia.VerificiarAcceso(Operation);
        }
    }
}
