using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Administracion.Contratos
{
    public interface IUbicacionServicio
    {
        IList<EdificioOtd> ObtenerEdificiosPorCentro(short idCentro);

        IList<SectorOtd> ObtenerSectoresPorCentroYEdificio(short idCentro, short idEdificio);

        IList<CeldaOtd> ObtenerCeldas(short idCentro, short idEdificio, short idSector);

        IList<EdificioOtd> EncontrarEdificiosPor(Expression<Func<EdificioOtd, bool>> expresion);
    }
}
