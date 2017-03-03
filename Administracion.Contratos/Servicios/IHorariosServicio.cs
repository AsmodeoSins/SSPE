using Administracion.OTD;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace Administracion.Contratos.Servicios
{
    public interface IHorariosServicio
    {
        /// <summary>
        /// Obtiene el horario por ID visita
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IList<HorarioVisitaOtd> ObtenerHorarioPorVisita(Expression<Func<HorarioVisitaOtd, bool>> expression);

        /// <summary>
        /// Obtiene un listado de tipos de visita.
        /// </summary>
        /// <returns></returns>
        IList<TipoVisitaOtd> ObtenerTipoVisitas();

        /// <summary>
        /// Obtiene un listado de los dias de las semana.
        /// </summary>
        /// <returns></returns>
        IList<VisitaDiaOtd> ObtenerDiasSemana();

        /// <summary>
        /// Obtiene un listado de usuarios Disponibles
        /// </summary>
        /// <returns></returns>
        void AcutalizarHorario(HorarioVisitaOtd horario);

        void InsertarHorario(HorarioVisitaOtd horario);

        /// <summary>
        /// Verifica que un servicio dado se encuentre activo.
        /// </summary>
        /// <param name="servicioUrl">servico a verificar</param>
        /// <returns>El estado de conexion</returns>
        HttpStatusCode ServicioActivo(string servicioUrl);
    }
}