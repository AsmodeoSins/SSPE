using Administracion.OTD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Administracion.Contratos.Servicios
{
    public interface ILogFallaServicio
    {
        LogFallaServicioOtd GuardarLogFallaServicio(LogFallaServicioOtd falla);

        IList<LogFallaServicioOtd> EncontrarPor(Expression<Func<LogFallaServicioOtd, bool>> expresion);
    }
}
