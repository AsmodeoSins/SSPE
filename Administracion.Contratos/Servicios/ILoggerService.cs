using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Administracion.Contratos
{
    public interface ILoggerServicio
    {
        void Debug(string message);

        void Error(string message);
    }
}
