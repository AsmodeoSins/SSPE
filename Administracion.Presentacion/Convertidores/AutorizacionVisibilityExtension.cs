using Administracion.Presentacion.Autorizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;

namespace Administracion.Presentacion.Convertidores
{
    public class AutorizacionVisibilityExtension : MarkupExtension
    {
        public string Operation { get; set; }

        public AutorizacionVisibilityExtension()
        {
            Operation = String.Empty;
        }

        public AutorizacionVisibilityExtension(string operation)
        {
            Operation = operation;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Operation))
                return Visibility.Collapsed;

            if (AutorizacionProvider.Instancia.VerificiarAcceso(Operation))
                return Visibility.Visible;
            return Visibility.Collapsed;
        }
    }
}
