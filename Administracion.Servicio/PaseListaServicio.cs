using Administracion.Contratos;
using Administracion.Contratos.Servicios;
using Administracion.Modelos;
using Administracion.OTD;
using Administracion.Utilidades.Autenticacion;
using Administracion.Utilidades.Mapeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Administracion.Servicio
{
    /// <summary>
    /// Servicio para crear los metodos referentes a un pase de lista
    /// </summary>
    public class PaseListaServicio : ServicioBase, IPaseListaServicio
    {
        private IPLProgramadoServicio _plProgramadoServicio;
        private IPLProgramadoAsignacionServicio _plProgramadoAsignacionServicio;
        private ISectorServicio _sectorServicio;
        private IPersonaServicio _personaServicio;
        private IUbicacionServicio _ubicacionServicio;
        private IPLCatalogoServicio _plCatalogoServicio;

        public PaseListaServicio(IPLProgramadoServicio plProgramadoServicio, IPLProgramadoAsignacionServicio plProgramadoAsignacionServicio, ISectorServicio sectorServicio, IPersonaServicio personaServicio, IUbicacionServicio ubicacionServicio, IPLCatalogoServicio plCatalogoServicio)
        {
            _plProgramadoServicio = plProgramadoServicio;
            _plProgramadoAsignacionServicio = plProgramadoAsignacionServicio;
            _sectorServicio = sectorServicio;
            _personaServicio = personaServicio;
            _ubicacionServicio = ubicacionServicio;
            _plCatalogoServicio = plCatalogoServicio;
        }

        public IList<PaseListaModelo> ObtenerPasesDeLista()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public bool ModificarPaseLista(PaseListaModelo paseLista)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public PaseListaOtd InicializarPaseListaPorCentro(int centroId)
        {
            try
            {
                var pasesDeLista = new List<PaseListaOtd>();
                var plProgramados = _plProgramadoServicio.EncontrarPor(plp => plp.IdCentro == Sesion.ObjetoDeSesion.IdCentro && plp.Vigente == (short)1);

                foreach (var plProgramado in plProgramados)
                {
                    var paseLista = new PaseListaOtd { EsNuevo = plProgramado == null, PaseListaId = plProgramado == null ? 0 : plProgramado.IdPlProgramado };
                    var edificios = _ubicacionServicio.ObtenerEdificiosPorCentro(Sesion.ObjetoDeSesion.IdCentro);
                    var catalogoEdificios = UbicacionMapeos.MapearCatalogoBaseDeEdificios(edificios);
                    var sectores = _sectorServicio.EncontrarPor(s => s.IdCentro == centroId).ToList();

                    if (sectores != null && sectores.Count > 0)
                    {
                        paseLista.Asignaciones = new List<AsignacionOtd>();
                        var custodios = _personaServicio.TraerCustodiosParaPaseLista();
                        foreach (var sector in sectores)
                        {

                            var asignacion = UbicacionMapeos.MapearAsignacion(sector);
                            var custodio = new PersonaOtd();
                            if (!paseLista.EsNuevo && plProgramado.PLProgramadoAsignaciones.Any(plp => plp.IdSector == sector.IdSector && plp.IdEdificio == sector.IdEdificio))
                            {
                                var plpAsignado = plProgramado.PLProgramadoAsignaciones.SingleOrDefault(plp => plp.IdSector == sector.IdSector && plp.IdEdificio == sector.IdEdificio);
                                custodio = custodios.SingleOrDefault(c => c.Id == plpAsignado.IdEmpleado);
                            }
                            asignacion.Edificio = catalogoEdificios.SingleOrDefault(e => e.Id == sector.IdEdificio);
                            asignacion.Custodio = custodio;
                            paseLista.Asignaciones.Add(asignacion);
                        }
                    }
                    pasesDeLista.Add(paseLista);
                }               

                return pasesDeLista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public IEnumerable<PaseListaOtd> InicializarPasesListaPorCentro(int centroId)
        {
            try
            {
                var pasesDeLista = new List<PaseListaOtd>();
                var tiposDePaseDeLista = _plCatalogoServicio.EncontrarPor(pl => pl.Estatus == "AC");
                var plProgramados = _plProgramadoServicio.EncontrarPor(plp => plp.IdCentro == Sesion.ObjetoDeSesion.IdCentro && plp.Vigente == (short)1);

                foreach (var tipoPl in tiposDePaseDeLista)
                {
                    var plProgramado = plProgramados.SingleOrDefault(plp => plp.IdPLCatalogo == tipoPl.IdPLCatalgo) ?? new PLProgramadoOtd { IdPLCatalogo = tipoPl.IdPLCatalgo, PLProgramadoAsignaciones = new List<PLProgramadoAsignacionOtd>(), Vigente = 1 };
                    var paseLista = new PaseListaOtd { EsNuevo = plProgramado == null, PaseListaId = plProgramado == null ? 0 : plProgramado.IdPlProgramado, TipoDePaseListaId = tipoPl.IdPLCatalgo };
                    var edificios = _ubicacionServicio.ObtenerEdificiosPorCentro(Sesion.ObjetoDeSesion.IdCentro);
                    var catalogoEdificios = UbicacionMapeos.MapearCatalogoBaseDeEdificios(edificios);
                    var sectores = _sectorServicio.EncontrarPor(s => s.IdCentro == centroId).ToList();

                    if (sectores != null && sectores.Count > 0)
                    {
                        paseLista.Asignaciones = new List<AsignacionOtd>();
                        var custodios = _personaServicio.TraerCustodiosParaPaseLista();
                        foreach (var sector in sectores)
                        {

                            var asignacion = UbicacionMapeos.MapearAsignacion(sector);
                            var custodio = new PersonaOtd();
                            if (!paseLista.EsNuevo && plProgramado.PLProgramadoAsignaciones.Any(plp => plp.IdSector == sector.IdSector && plp.IdEdificio == sector.IdEdificio))
                            {
                                var plpAsignado = plProgramado.PLProgramadoAsignaciones.SingleOrDefault(plp => plp.IdSector == sector.IdSector && plp.IdEdificio == sector.IdEdificio);
                                custodio = custodios.SingleOrDefault(c => c.Id == plpAsignado.IdEmpleado);
                            }
                            asignacion.Edificio = catalogoEdificios.SingleOrDefault(e => e.Id == sector.IdEdificio);
                            asignacion.Custodio = custodio;
                            paseLista.Asignaciones.Add(asignacion);
                        }
                    }
                    pasesDeLista.Add(paseLista);
                }

                return pasesDeLista;
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        public void GuardarPasesDeLista(PaseListaOtd paseLista)
        {
            if (paseLista.PaseListaId > default(int))
            {
                ActualizarPaseDeLista(paseLista);
            }
            else
            {
                CrearPasesDeLista(paseLista);
            }
        }

        private void CrearPasesDeLista(PaseListaOtd paseLista)
        {
            try
            {
                paseLista.UsuarioId = Sesion.ObjetoDeSesion.IdEmpleado;
                paseLista.CentroId = Sesion.ObjetoDeSesion.IdCentro;
                paseLista.Asignaciones = paseLista.Asignaciones.Where(pl => pl.Custodio.Id > 0).ToList();
                var plProgramado = PLProgramadoMapeos.MapearModelo(paseLista);
                using(var transaccion = new TransactionScope())
                {
                    plProgramado.Vigente = 1;
                    var plProgInsertado = _plProgramadoServicio.CrearPaseDelistaProgramado(plProgramado);
                    paseLista.PaseListaId = plProgInsertado.IdPlProgramado;
                    foreach (var plAsignacion in paseLista.Asignaciones)
                    {
                        var plProgramadoAsignacion = new PLProgramadoAsignacionOtd
                        {
                            IdCentro = Sesion.ObjetoDeSesion.IdCentro,
                            IdEdificio = (short)plAsignacion.Edificio.Id,
                            IdEmpleado = plAsignacion.Custodio.Id,
                            IdPLProgramado = plProgInsertado.IdPlProgramado,
                            IdSector = (short)plAsignacion.Sector.Id,
                        };
                        var plProgAsignacionInsertado = _plProgramadoAsignacionServicio.CrearPaseDelistaProgramadoAsignacion(plProgramadoAsignacion);
                    }
                    transaccion.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }

        private void ActualizarPaseDeLista(PaseListaOtd paseLista)
        {
            try
            {
                paseLista.EsNuevo = true;
                _plProgramadoServicio.DesactivarPaseDeListaProgramado(paseLista.PaseListaId);
                CrearPasesDeLista(paseLista);
            }
            catch (Exception ex)
            {
                throw ObtenerFalla(ex);
            }
        }
    }
}