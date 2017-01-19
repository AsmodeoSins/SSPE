using Administracion.Contratos.Repositorio;
using Administracion.Contratos.Servicios;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Administracion.Servicio
{
    public class LogFallaServicio : ServicioBase, ILogFallaServicio, IDisposable
    {
        #region Miembros privados
        private ILogFallaServicioRepositorio _logFallaRepositorio;
        #endregion

        #region Constructores
        public LogFallaServicio()
        {
            _logFallaRepositorio = new LogFallaServicioRepositorio();
        }
        public LogFallaServicio(ILogFallaServicioRepositorio logFallaRepositorio)
        {
            _logFallaRepositorio = logFallaRepositorio;
        }
        #endregion

        #region Metodos publicos
        public LogFallaServicioOtd GuardarLogFallaServicio(LogFallaServicioOtd falla)
        {
            try
            {
                var entidad = LogFallaServicioMapeos.MapearEntidad(falla);
                return LogFallaServicioMapeos.MapearModelo(_logFallaRepositorio.Insertar(entidad));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<LogFallaServicioOtd> EncontrarPor(Expression<Func<LogFallaServicioOtd, bool>> expresion)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<LogFallaServicioOtd, LOGFALLASERVICIO>(expresion);
                return LogFallaServicioMapeos.MapearListaModelos(_logFallaRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_logFallaRepositorio != null)
                {
                    _logFallaRepositorio.Dispose();
                }
            }
        }
    }
}
