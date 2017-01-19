using Administracion.OTD;
using Administracion.Utilidades.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Administracion.Servicio
{
    public class ServicioBase
    {
        protected FaultException<LogFallaServicioOtd> ObtenerFalla(Exception ex)
        {
            var mensajeDeError = new StringBuilder();
            mensajeDeError.Append(ex.Message);

            Exception errorInterno = ex.InnerException;

            while (errorInterno != null)
            {
                mensajeDeError.AppendFormat("--> {0}", errorInterno.Message);
                errorInterno = errorInterno.InnerException;
            }

            var falla = new LogFallaServicioOtd
            {
                ApplicationName = "Administracion.Servicio",
                CodigoDeError = ex.GetType().ToString(),
                DetalleDeErrror = ex.ToString(),
                MensajeDeError = mensajeDeError.ToString(),
                FechaDeCreacion = DateTime.Now
            };

            using (var logger = new LogFallaServicio())
            {
                falla.LogFallaServicioId = logger.GuardarLogFallaServicio(falla).LogFallaServicioId;
                ex = new Exception(string.Format(SSPConst.ErrorInesperadoMsg, falla.LogFallaServicioId));
            }

            return new FaultException<LogFallaServicioOtd>(falla, new FaultReason(ex.Message));
        }

        public string GuardarFalla(Exception ex)
        {
            return ObtenerFalla(ex).Message;
        }

    }
}
