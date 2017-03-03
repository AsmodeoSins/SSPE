using Administracion.Contratos.Repositorio;
using Administracion.Contratos.Servicios;
using Administracion.Modelos.Entidades;
using Administracion.OTD;
using Administracion.Repositorio.Accesso;
using Administracion.Utilidades;
using Administracion.Utilidades.Mapeos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace Administracion.Servicio
{
    public class HorariosServicio : ServicioBase, IHorariosServicio
    {
        #region Miembros privados
        private IHorariosRepositorio _horariosRepositorio;
        private ITipoVisitaRepositorio _visitasRepositorio;
        private IVisitaDiaRepositorio _diasRepositorio;
        #endregion

        #region Constructores
        public HorariosServicio()
        {
            _horariosRepositorio = new HorariosRepositorio();
            _visitasRepositorio = new TipoVisitaRepositorio();
            _diasRepositorio = new VisitaDiaRepositorio();
        }
        /// <summary>
        /// Constructor para inyeccion de dependencias
        /// </summary>
        /// <param name="usuarioRepositorio"></param>
        public HorariosServicio(IHorariosRepositorio horariosRepositorio)
        {
            _horariosRepositorio = horariosRepositorio;
        }
        #endregion

        #region Metodos publicos

        /// <summary>
        /// Obtiene un listado de los horarios por el tipo de visita
        /// </summary>
        /// <returns></returns>
        public IList<HorarioVisitaOtd> ObtenerHorarioPorVisita(Expression<Func<HorarioVisitaOtd, bool>> expression)
        {
            try
            {
                var nuevaExpression = GeneradorDePredicados.Convertir<HorarioVisitaOtd, HORARIO_VISITA>(expression);
                return HorariosMapeos.MapearHorarios(_horariosRepositorio.EncontrarPor(nuevaExpression).ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Obtiene un listado de usuarios dada una expresion
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IList<TipoVisitaOtd> ObtenerTipoVisitas()
        {
            try
            {
                return TipoVisitasMapeos.MapearVisitas(_visitasRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public IList<VisitaDiaOtd> ObtenerDiasSemana()
        {
            try
            {
                return VisitasDiaMapeos.MapearDias(_diasRepositorio.ObtenerTodos().ToList());
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public void AcutalizarHorario(HorarioVisitaOtd horario)
        {
            try
            {
                var horarioEntidad = HorariosMapeos.MapearEntidad(horario);
                _horariosRepositorio.Actualizar(horarioEntidad);
                _horariosRepositorio.Guardar();
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        public void InsertarHorario(HorarioVisitaOtd horario)
        {
            try
            {
                var horarioEntidad = HorariosMapeos.MapearEntidad(horario);
                _horariosRepositorio.Insertar(horarioEntidad);
                _horariosRepositorio.Guardar();
            }
            catch (Exception ex)
            {

                throw ObtenerFalla(ex);
            }
        }

        /// <summary>
        /// Verifica que la conexion dada sea valida y este activa
        /// </summary>
        /// <param name="conexion"></param>
        /// <returns></returns>
        public bool ConexionValida(string conexion)
        {
            try
            {
                OracleConnection oracleConexion = new OracleConnection(conexion);

                oracleConexion.Open();

                if (oracleConexion.State == System.Data.ConnectionState.Open)
                {
                    oracleConexion.Close();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public HttpStatusCode ServicioActivo(string servicioUrl)
        {
            try
            {
                HttpWebRequest peticionWeb = WebRequest.Create(servicioUrl) as HttpWebRequest;
                peticionWeb.Timeout = 10000;

                using (HttpWebResponse respuestaWeb = peticionWeb.GetResponse() as HttpWebResponse)
                {
                    return respuestaWeb.StatusCode;
                }
            }
            catch (WebException ex)
            {
                return HttpStatusCode.NotFound;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.NotFound;
            }
        }

        #endregion
    }
}
