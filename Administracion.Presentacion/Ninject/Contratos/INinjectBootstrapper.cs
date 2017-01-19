using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.Presentacion.Ninject
{
    public interface INinjectBootstrapper
    {
        IKernel Nucleo { get; set; }

        void CargarModulos();
    }
}
